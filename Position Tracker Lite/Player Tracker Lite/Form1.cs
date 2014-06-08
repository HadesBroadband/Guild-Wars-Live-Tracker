using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace Player_Tracker_Lite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Timer t = new Timer();
            t.Tick += new EventHandler(updatePosition);
            t.Interval = 5000;
            t.Start();
        }

        const float InchesPerMeter = 39.37010F;

        static MemoryMappedFile memoryFile;
        static MemoryMappedViewAccessor accessor;
        static LinkedMap data = new LinkedMap();
        static PlayerLocation playerLocation = new PlayerLocation();

        public static void LinkMumbleAPI()
        {
            memoryFile = MemoryMappedFile.CreateOrOpen("MumbleLink", Marshal.SizeOf(data));
            accessor = memoryFile.CreateViewAccessor(0, Marshal.SizeOf(data));
        }

        private void updatePosition (Object sender, EventArgs args)
        {
            if (memoryFile == null)
            {
                LinkMumbleAPI();
            }

            unsafe
            {
                fixed (LinkedMap* _data = &data)
                {
                    playerLocation.x = (float)(_data->fCharacterPosition[0]) * InchesPerMeter;
                    playerLocation.y = (float)(_data->fCharacterPosition[1]) * InchesPerMeter;
                    playerLocation.y = (float)(_data->fCharacterPosition[2]) * InchesPerMeter;

                    playerLocation.map = (int)_data->context[28] + ((int)_data->context[29] * 256);
                }
            }

            xLabel.Text = playerLocation.x.ToString();
            yLabel.Text = playerLocation.y.ToString();
            zLabel.Text = playerLocation.z.ToString();
            mLabel.Text = playerLocation.map.ToString();
        }
    }

    public class PlayerLocation
    {
        public float x, y, z = 0;
        public int map = 0;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct LinkedMap
    {
        public uint uiVersion;
        public uint uiTick;

        public fixed float fCharacterPosition[3];

        public fixed byte identity[512];
        public fixed byte context[512];
    }
}
