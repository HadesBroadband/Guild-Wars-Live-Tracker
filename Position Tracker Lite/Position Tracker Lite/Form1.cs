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

namespace Position_Tracker_Lite
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct LinkedMap
    {
        public uint uiVersion;
        public uint uiTick;

        public fixed float fCharacterPosition[3];
    
        public fixed byte identity[512];
        public fixed byte context[512];
    }
   

    public class PlayerLocation
    {
        public float x, y, z = 0;
        public int map = 0;
    }

    public partial class Form1 : Form
    {
        const float InchesPerMeter = 39.37010F;

        static MemoryMappedFile memoryFile;
        static MemoryMappedViewAccessor accessor;
        static LinkedMap data = new LinkedMap();
        static PlayerLocation playerLocation = new PlayerLocation();

        public Form1()
        {
            InitializeComponent();
            trackPlayer();
        }

        public static void GetPlayerInfo()
        {
            if (memoryFile == null)
            {
                LinkMumbleAPI();
            }

            accessor.Read(0, out data);

            unsafe
            {
                fixed (LinkedMap* _data = &data)
                {

                }
            }
        }

        public static void LinkMumbleAPI()
        {
            memoryFile = MemoryMappedFile.CreateOrOpen("MumbleLink", Marshal.SizeOf(data));
            accessor = memoryFile.CreateViewAccessor(0, Marshal.SizeOf(data));
        }

        static void trackPlayer()
        {
            GetPlayerInfo();


        }
    }
}
