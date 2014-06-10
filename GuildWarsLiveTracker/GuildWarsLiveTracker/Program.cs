using System;
using System.Runtime.InteropServices;
using System.IO.MemoryMappedFiles;
using System.Threading;

namespace GW2Position
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct LinkedMem
    {
        public uint uiVersion;
        public uint uiTick;
        public fixed float fAvatarPosition[3];
        public fixed float fAvatarFront[3];
        public fixed float fAvatarTop[3];
        public fixed byte name[512];
        public fixed float fCameraPosition[3];
        public fixed float fCameraFront[3];
        public fixed float fCameraTop[3];
        public fixed byte identity[512];
        public uint context_len;
        public fixed byte context[512];
        public fixed byte description[4096];
    };

    public class PlayerInfo
    {
        public float x, y, z = 0;
        public int map = 0;
    }

    class Program
    {
        // Number of inches per meter
        const float InchesPerMeter = 39.37010F;

        // 
        static MemoryMappedFile mappedFile;
        static MemoryMappedViewAccessor accessor;
        static LinkedMem data = new LinkedMem();
        static PlayerInfo playerInfo = new PlayerInfo();

        static void Main(string[] args)
        {
            // Print data to console (escape exits the loop)
            do
            {
                while (!Console.KeyAvailable)
                {
                    GetData();

                    Console.Clear();
                    Console.WriteLine("X: " + playerInfo.x.ToString());
                    Console.WriteLine("Y: " + playerInfo.y.ToString());
                    Console.WriteLine("Z: " + playerInfo.z.ToString());
                    Console.WriteLine("Map: " + playerInfo.map.ToString());

                    // Wait 50ms for next update
                    Thread.Sleep(50);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public static void OpenMumbleLink()
        {
            // Open the mapped memory file
            mappedFile = MemoryMappedFile.CreateOrOpen("MumbleLink", Marshal.SizeOf(data));
            accessor = mappedFile.CreateViewAccessor(0, Marshal.SizeOf(data));
        }

        public static void GetData()
        {
            // Make sure the map memory file is loaded
            if (mappedFile == null) OpenMumbleLink();

            // Read mapped memory file
            accessor.Read(0, out data);

            unsafe
            {
                fixed (LinkedMem* _data = &data)
                {
                    // Parse info
                    playerInfo.x = (float)(_data->fAvatarPosition[0]) * InchesPerMeter;
                    playerInfo.y = (float)(_data->fAvatarPosition[1]) * InchesPerMeter;
                    playerInfo.z = (float)(_data->fAvatarPosition[2]) * InchesPerMeter;

                    playerInfo.map = (int)_data->context[28] + ((int)_data->context[29] * 256);
                }
            }
        }


    }
}
