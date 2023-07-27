using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace MouseMove
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private unsafe static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
        private unsafe static ConsoleEventDelegate handler;
        private delegate bool ConsoleEventDelegate(int eventType);
        static unsafe SerialPort Port;
        static unsafe void Main(string[] args)
        {
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);
            string[] ports = SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                Port = new SerialPort(port, 9600);
                Port.DtrEnable = true;
                Port.Open(); 
                Ping();
                string a = Port.ReadExisting();
                if (a.Contains("1"))
                {
                    Task.Run(() => Start());
                    Console.ReadLine();
                    break;
                }
                else
                    Port.Close();
            }
        }
        public unsafe static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                Port.Close();
                Thread.Sleep(10000);
            }
            return false;
        }
        public unsafe static void Start()
        {
            for (int i = 0; i <= 100; i++)
            {
                MouseMove(1, -1); //y, x
                if (i >= 80)
                    KeyboardPress(Key.KEY_U);
                Thread.Sleep(1);
            }
            KeyboardRelease(Key.KEY_U);
        }
        public unsafe static void Ping()
        {
            sendCommand(-1, 0, 0, 0, 0, 0); //1
        }
        public unsafe static void KeyboardPress(int key)
        {
            sendCommand(1, key, 0, 0, 0, 0); //1, 3
        }
        public unsafe static void KeyboardRelease(int key)
        {
            sendCommand(2, key, 0, 0, 0, 0); //1, 3
        }
        public unsafe static void MouseMove(int x, int y)
        {
            sendCommand(3, y, x, 0, 0, 0);
        }
        public unsafe static void MouseWheel(int x)
        {
            sendCommand(4, x, 0, 0, 0, 0); //1, 3
        }
        public unsafe static void MousePress(int key)
        {
            sendCommand(5, key, 0, 0, 0, 0); //1, 3
        }
        public unsafe static void MouseRelease(int key)
        {
            sendCommand(6, key, 0, 0, 0, 0); //1, 3
        }
        private unsafe static void sendCommand(int d1, int d2, int d3, int d4, int d5, int d6)
        {
            Message_t msgOut = new Message_t();
            msgOut.Data.d1 = d1;
            msgOut.Data.d2 = d2;
            msgOut.Data.d3 = d3;
            msgOut.Data.d4 = d4;
            msgOut.Data.d5 = d5;
            msgOut.Data.d6 = d6;
            byte[] data = new byte[Marshal.SizeOf(typeof(Message_t))];
            fixed (byte* b = data)
                Marshal.StructureToPtr(msgOut, (IntPtr)b, true);
            Port.Write(data, 0, data.Length);
        }
        public class Key
        {
            public const int MOUSE_LEFT = 0;
            public const int MOUSE_RIGHT = 1;
            public const int MOUSE_MIDDLE = 2;
            public const int KEY_LEFT_CTRL = 3;
            public const int KEY_LEFT_SHIFT = 4;
            public const int KEY_LEFT_ALT = 5;
            public const int KEY_RIGHT_CTRL = 6;
            public const int KEY_RIGHT_SHIFT = 7;
            public const int KEY_RIGHT_ALT = 8;
            public const int KEY_UP_ARROW = 9;
            public const int KEY_DOWN_ARROW = 10;
            public const int KEY_LEFT_ARROW = 11;
            public const int KEY_RIGHT_ARROW = 12;
            public const int KEY_BACKSPACE = 13;
            public const int KEY_SPACE = 14;
            public const int KEY_TAB = 15;
            public const int KEY_RETURN = 16;
            public const int KEY_ESC = 17;
            public const int KEY_INSERT = 18;
            public const int KEY_DELETE = 19;
            public const int KEY_PAGE_UP = 20;
            public const int KEY_PAGE_DOWN = 21;
            public const int KEY_HOME = 22;
            public const int KEY_END = 23;
            public const int KEY_CAPS_LOCK = 24;
            public const int KEY_F1 = 25;
            public const int KEY_F2 = 26;
            public const int KEY_F3 = 27;
            public const int KEY_F4 = 28;
            public const int KEY_F5 = 29;
            public const int KEY_F6 = 30;
            public const int KEY_F7 = 31;
            public const int KEY_F8 = 32;
            public const int KEY_F9 = 33;
            public const int KEY_F10 = 34;
            public const int KEY_F11 = 35;
            public const int KEY_F12 = 36;
            public const int KEY_F13 = 37;
            public const int KEY_F14 = 38;
            public const int KEY_F15 = 39;
            public const int KEY_F16 = 40;
            public const int KEY_F17 = 41;
            public const int KEY_F18 = 42;
            public const int KEY_F19 = 43;
            public const int KEY_F20 = 44;
            public const int KEY_F21 = 45;
            public const int KEY_F22 = 46;
            public const int KEY_F23 = 47;
            public const int KEY_F24 = 48;
            public const int KEY_A = 49;
            public const int KEY_B = 50;
            public const int KEY_C = 51;
            public const int KEY_D = 52;
            public const int KEY_E = 53;
            public const int KEY_F = 54;
            public const int KEY_G = 55;
            public const int KEY_H = 56;
            public const int KEY_I = 57;
            public const int KEY_J = 58;
            public const int KEY_K = 59;
            public const int KEY_L = 60;
            public const int KEY_M = 61;
            public const int KEY_N = 62;
            public const int KEY_O = 63;
            public const int KEY_P = 64;
            public const int KEY_Q = 65;
            public const int KEY_R = 66;
            public const int KEY_S = 67;
            public const int KEY_T = 68;
            public const int KEY_U = 69;
            public const int KEY_V = 70;
            public const int KEY_W = 71;
            public const int KEY_X = 72;
            public const int KEY_Y = 73;
            public const int KEY_Z = 74;
            public const int KEY_1 = 75;
            public const int KEY_2 = 76;
            public const int KEY_3 = 77;
            public const int KEY_4 = 78;
            public const int KEY_5 = 79;
            public const int KEY_6 = 80;
            public const int KEY_7 = 81;
            public const int KEY_8 = 82;
            public const int KEY_9 = 83;
            public const int KEY_0 = 84;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct Data_t
        {
            public int d1;
            public int d2;
            public int d3;
            public int d4;
            public int d5;
            public int d6;
        }
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct Message_t
        {
            [FieldOffset(0)]
            public Data_t Data;
        }
    }
}
