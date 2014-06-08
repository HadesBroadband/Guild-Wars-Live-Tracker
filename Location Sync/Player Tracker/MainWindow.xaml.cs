using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace Player_Tracker
{
    [StructLayout (LayoutKind.Sequential)]
    public struct LinkedMap
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const float InchesPerMeter = 39.37010F;

        static MemoryMappedFile memoryFile;
        static MemoryMappedViewAccessor accessor;
        static LinkedMap data = new LinkedMap ();
        static PlayerLocation playerLocation = new PlayerLocation ();

        public MainWindow()
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
                    playerLocation.x = (float)(_data->fCharacterPosition[0]) * InchesPerMeter;
                    playerLocation.y = (float)(_data->fCharacterPosition[1]) * InchesPerMeter;
                    playerLocation.y = (float)(_data->fCharacterPosition[2]) * InchesPerMeter;

                    playerLocation.map = (int)_data->context[28] + ((int)_data->context[29] * 256);
                }
            }
        }

        public static void LinkMumbleAPI ()
        {
            memoryFile = MemoryMappedFile.CreateOrOpen("MumbleLink", Marshal.SizeOf(data));
            accessor = memoryFile.CreateViewAccessor(0, Marshal.SizeOf(data));
        }

        static void trackPlayer()
        {
            GetPlayerInfo();

            
        }

        private void xPos_Loaded(object sender, RoutedEventArgs e)
        {
            xPos = sender as Label;
        }
    }
}
