using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace keyboards
{
    public class Valuechanges
    {
        public static double[] _valuechange = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static double[] _ValueChange = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public double this[int index]
        {
            get { return _ValueChange[index]; }
            set
            {
                if (_valuechange[index] != value)
                    _ValueChange[index] = value - _valuechange[index];
                else
                    _ValueChange[index] = 0;
                _valuechange[index] = value;
            }
        }
    }
    public class SendKeyboard
    {
        [DllImport("keyboard.dll", EntryPoint = "SendKey", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendKey(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendKeyF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendKeyF(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendKeyArrows", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendKeyArrows(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendKeyArrowsF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendKeyArrowsF(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonLeft", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonLeft();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonLeftF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonLeftF();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonRight", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonRight();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonRightF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonRightF();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonMiddle", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonMiddle();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonMiddleF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonMiddleF();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonWheelUp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonWheelUp();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonWheelDown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonWheelDown();
        [DllImport("keyboard.dll", EntryPoint = "SimulateKeyDown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SimulateKeyDown(UInt16 keyCode, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SimulateKeyUp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SimulateKeyUp(UInt16 keyCode, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SimulateKeyDownArrows", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SimulateKeyDownArrows(UInt16 keyCode, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SimulateKeyUpArrows", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SimulateKeyUpArrows(UInt16 keyCode, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "LeftClick", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LeftClick();
        [DllImport("keyboard.dll", EntryPoint = "LeftClickF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LeftClickF();
        [DllImport("keyboard.dll", EntryPoint = "RightClick", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RightClick();
        [DllImport("keyboard.dll", EntryPoint = "RightClickF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RightClickF();
        [DllImport("keyboard.dll", EntryPoint = "MiddleClick", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MiddleClick();
        [DllImport("keyboard.dll", EntryPoint = "MiddleClickF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MiddleClickF();
        [DllImport("keyboard.dll", EntryPoint = "WheelDownF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void WheelDownF();
        [DllImport("keyboard.dll", EntryPoint = "WheelUpF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void WheelUpF();
        public const ushort VK_LBUTTON = (ushort)0x01;
        public const ushort VK_RBUTTON = (ushort)0x02;
        public const ushort VK_CANCEL = (ushort)0x03;
        public const ushort VK_MBUTTON = (ushort)0x04;
        public const ushort VK_XBUTTON1 = (ushort)0x05;
        public const ushort VK_XBUTTON2 = (ushort)0x06;
        public const ushort VK_BACK = (ushort)0x08;
        public const ushort VK_Tab = (ushort)0x09;
        public const ushort VK_CLEAR = (ushort)0x0C;
        public const ushort VK_Return = (ushort)0x0D;
        public const ushort VK_SHIFT = (ushort)0x10;
        public const ushort VK_CONTROL = (ushort)0x11;
        public const ushort VK_MENU = (ushort)0x12;
        public const ushort VK_PAUSE = (ushort)0x13;
        public const ushort VK_CAPITAL = (ushort)0x14;
        public const ushort VK_KANA = (ushort)0x15;
        public const ushort VK_HANGEUL = (ushort)0x15;
        public const ushort VK_HANGUL = (ushort)0x15;
        public const ushort VK_JUNJA = (ushort)0x17;
        public const ushort VK_FINAL = (ushort)0x18;
        public const ushort VK_HANJA = (ushort)0x19;
        public const ushort VK_KANJI = (ushort)0x19;
        public const ushort VK_Escape = (ushort)0x1B;
        public const ushort VK_CONVERT = (ushort)0x1C;
        public const ushort VK_NONCONVERT = (ushort)0x1D;
        public const ushort VK_ACCEPT = (ushort)0x1E;
        public const ushort VK_MODECHANGE = (ushort)0x1F;
        public const ushort VK_Space = (ushort)0x20;
        public const ushort VK_PRIOR = (ushort)0x21;
        public const ushort VK_NEXT = (ushort)0x22;
        public const ushort VK_END = (ushort)0x23;
        public const ushort VK_HOME = (ushort)0x24;
        public const ushort VK_LEFT = (ushort)0x25;
        public const ushort VK_UP = (ushort)0x26;
        public const ushort VK_RIGHT = (ushort)0x27;
        public const ushort VK_DOWN = (ushort)0x28;
        public const ushort VK_SELECT = (ushort)0x29;
        public const ushort VK_PRINT = (ushort)0x2A;
        public const ushort VK_EXECUTE = (ushort)0x2B;
        public const ushort VK_SNAPSHOT = (ushort)0x2C;
        public const ushort VK_INSERT = (ushort)0x2D;
        public const ushort VK_DELETE = (ushort)0x2E;
        public const ushort VK_HELP = (ushort)0x2F;
        public const ushort VK_APOSTROPHE = (ushort)0xDE;
        public const ushort VK_0 = (ushort)0x30;
        public const ushort VK_1 = (ushort)0x31;
        public const ushort VK_2 = (ushort)0x32;
        public const ushort VK_3 = (ushort)0x33;
        public const ushort VK_4 = (ushort)0x34;
        public const ushort VK_5 = (ushort)0x35;
        public const ushort VK_6 = (ushort)0x36;
        public const ushort VK_7 = (ushort)0x37;
        public const ushort VK_8 = (ushort)0x38;
        public const ushort VK_9 = (ushort)0x39;
        public const ushort VK_A = (ushort)0x41;
        public const ushort VK_B = (ushort)0x42;
        public const ushort VK_C = (ushort)0x43;
        public const ushort VK_D = (ushort)0x44;
        public const ushort VK_E = (ushort)0x45;
        public const ushort VK_F = (ushort)0x46;
        public const ushort VK_G = (ushort)0x47;
        public const ushort VK_H = (ushort)0x48;
        public const ushort VK_I = (ushort)0x49;
        public const ushort VK_J = (ushort)0x4A;
        public const ushort VK_K = (ushort)0x4B;
        public const ushort VK_L = (ushort)0x4C;
        public const ushort VK_M = (ushort)0x4D;
        public const ushort VK_N = (ushort)0x4E;
        public const ushort VK_O = (ushort)0x4F;
        public const ushort VK_P = (ushort)0x50;
        public const ushort VK_Q = (ushort)0x51;
        public const ushort VK_R = (ushort)0x52;
        public const ushort VK_S = (ushort)0x53;
        public const ushort VK_T = (ushort)0x54;
        public const ushort VK_U = (ushort)0x55;
        public const ushort VK_V = (ushort)0x56;
        public const ushort VK_W = (ushort)0x57;
        public const ushort VK_X = (ushort)0x58;
        public const ushort VK_Y = (ushort)0x59;
        public const ushort VK_Z = (ushort)0x5A;
        public const ushort VK_LWIN = (ushort)0x5B;
        public const ushort VK_RWIN = (ushort)0x5C;
        public const ushort VK_APPS = (ushort)0x5D;
        public const ushort VK_SLEEP = (ushort)0x5F;
        public const ushort VK_NUMPAD0 = (ushort)0x60;
        public const ushort VK_NUMPAD1 = (ushort)0x61;
        public const ushort VK_NUMPAD2 = (ushort)0x62;
        public const ushort VK_NUMPAD3 = (ushort)0x63;
        public const ushort VK_NUMPAD4 = (ushort)0x64;
        public const ushort VK_NUMPAD5 = (ushort)0x65;
        public const ushort VK_NUMPAD6 = (ushort)0x66;
        public const ushort VK_NUMPAD7 = (ushort)0x67;
        public const ushort VK_NUMPAD8 = (ushort)0x68;
        public const ushort VK_NUMPAD9 = (ushort)0x69;
        public const ushort VK_MULTIPLY = (ushort)0x6A;
        public const ushort VK_ADD = (ushort)0x6B;
        public const ushort VK_SEPARATOR = (ushort)0x6C;
        public const ushort VK_SUBTRACT = (ushort)0x6D;
        public const ushort VK_DECIMAL = (ushort)0x6E;
        public const ushort VK_DIVIDE = (ushort)0x6F;
        public const ushort VK_F1 = (ushort)0x70;
        public const ushort VK_F2 = (ushort)0x71;
        public const ushort VK_F3 = (ushort)0x72;
        public const ushort VK_F4 = (ushort)0x73;
        public const ushort VK_F5 = (ushort)0x74;
        public const ushort VK_F6 = (ushort)0x75;
        public const ushort VK_F7 = (ushort)0x76;
        public const ushort VK_F8 = (ushort)0x77;
        public const ushort VK_F9 = (ushort)0x78;
        public const ushort VK_F10 = (ushort)0x79;
        public const ushort VK_F11 = (ushort)0x7A;
        public const ushort VK_F12 = (ushort)0x7B;
        public const ushort VK_F13 = (ushort)0x7C;
        public const ushort VK_F14 = (ushort)0x7D;
        public const ushort VK_F15 = (ushort)0x7E;
        public const ushort VK_F16 = (ushort)0x7F;
        public const ushort VK_F17 = (ushort)0x80;
        public const ushort VK_F18 = (ushort)0x81;
        public const ushort VK_F19 = (ushort)0x82;
        public const ushort VK_F20 = (ushort)0x83;
        public const ushort VK_F21 = (ushort)0x84;
        public const ushort VK_F22 = (ushort)0x85;
        public const ushort VK_F23 = (ushort)0x86;
        public const ushort VK_F24 = (ushort)0x87;
        public const ushort VK_NUMLOCK = (ushort)0x90;
        public const ushort VK_SCROLL = (ushort)0x91;
        public const ushort VK_LeftShift = (ushort)0xA0;
        public const ushort VK_RightShift = (ushort)0xA1;
        public const ushort VK_LeftControl = (ushort)0xA2;
        public const ushort VK_RightControl = (ushort)0xA3;
        public const ushort VK_LMENU = (ushort)0xA4;
        public const ushort VK_RMENU = (ushort)0xA5;
        public const ushort VK_BROWSER_BACK = (ushort)0xA6;
        public const ushort VK_BROWSER_FORWARD = (ushort)0xA7;
        public const ushort VK_BROWSER_REFRESH = (ushort)0xA8;
        public const ushort VK_BROWSER_STOP = (ushort)0xA9;
        public const ushort VK_BROWSER_SEARCH = (ushort)0xAA;
        public const ushort VK_BROWSER_FAVORITES = (ushort)0xAB;
        public const ushort VK_BROWSER_HOME = (ushort)0xAC;
        public const ushort VK_VOLUME_MUTE = (ushort)0xAD;
        public const ushort VK_VOLUME_DOWN = (ushort)0xAE;
        public const ushort VK_VOLUME_UP = (ushort)0xAF;
        public const ushort VK_MEDIA_NEXT_TRACK = (ushort)0xB0;
        public const ushort VK_MEDIA_PREV_TRACK = (ushort)0xB1;
        public const ushort VK_MEDIA_STOP = (ushort)0xB2;
        public const ushort VK_MEDIA_PLAY_PAUSE = (ushort)0xB3;
        public const ushort VK_LAUNCH_MAIL = (ushort)0xB4;
        public const ushort VK_LAUNCH_MEDIA_SELECT = (ushort)0xB5;
        public const ushort VK_LAUNCH_APP1 = (ushort)0xB6;
        public const ushort VK_LAUNCH_APP2 = (ushort)0xB7;
        public const ushort VK_OEM_1 = (ushort)0xBA;
        public const ushort VK_OEM_PLUS = (ushort)0xBB;
        public const ushort VK_OEM_COMMA = (ushort)0xBC;
        public const ushort VK_OEM_MINUS = (ushort)0xBD;
        public const ushort VK_OEM_PERIOD = (ushort)0xBE;
        public const ushort VK_OEM_2 = (ushort)0xBF;
        public const ushort VK_OEM_3 = (ushort)0xC0;
        public const ushort VK_OEM_4 = (ushort)0xDB;
        public const ushort VK_OEM_5 = (ushort)0xDC;
        public const ushort VK_OEM_6 = (ushort)0xDD;
        public const ushort VK_OEM_7 = (ushort)0xDE;
        public const ushort VK_OEM_8 = (ushort)0xDF;
        public const ushort VK_OEM_102 = (ushort)0xE2;
        public const ushort VK_PROCESSKEY = (ushort)0xE5;
        public const ushort VK_PACKET = (ushort)0xE7;
        public const ushort VK_ATTN = (ushort)0xF6;
        public const ushort VK_CRSEL = (ushort)0xF7;
        public const ushort VK_EXSEL = (ushort)0xF8;
        public const ushort VK_EREOF = (ushort)0xF9;
        public const ushort VK_PLAY = (ushort)0xFA;
        public const ushort VK_ZOOM = (ushort)0xFB;
        public const ushort VK_NONAME = (ushort)0xFC;
        public const ushort VK_PA1 = (ushort)0xFD;
        public const ushort VK_OEM_CLEAR = (ushort)0xFE;
        public const ushort S_LBUTTON = (ushort)0x0;
        public const ushort S_RBUTTON = 0;
        public const ushort S_CANCEL = 70;
        public const ushort S_MBUTTON = 0;
        public const ushort S_XBUTTON1 = 0;
        public const ushort S_XBUTTON2 = 0;
        public const ushort S_BACK = 14;
        public const ushort S_Tab = 15;
        public const ushort S_CLEAR = 76;
        public const ushort S_Return = 28;
        public const ushort S_SHIFT = 42;
        public const ushort S_CONTROL = 29;
        public const ushort S_MENU = 56;
        public const ushort S_PAUSE = 0;
        public const ushort S_CAPITAL = 58;
        public const ushort S_KANA = 0;
        public const ushort S_HANGEUL = 0;
        public const ushort S_HANGUL = 0;
        public const ushort S_JUNJA = 0;
        public const ushort S_FINAL = 0;
        public const ushort S_HANJA = 0;
        public const ushort S_KANJI = 0;
        public const ushort S_Escape = 1;
        public const ushort S_CONVERT = 0;
        public const ushort S_NONCONVERT = 0;
        public const ushort S_ACCEPT = 0;
        public const ushort S_MODECHANGE = 0;
        public const ushort S_Space = 57;
        public const ushort S_PRIOR = 73;
        public const ushort S_NEXT = 81;
        public const ushort S_END = 79;
        public const ushort S_HOME = 71;
        public const ushort S_LEFT = 75;
        public const ushort S_UP = 72;
        public const ushort S_RIGHT = 77;
        public const ushort S_DOWN = 80;
        public const ushort S_SELECT = 0;
        public const ushort S_PRINT = 0;
        public const ushort S_EXECUTE = 0;
        public const ushort S_SNAPSHOT = 84;
        public const ushort S_INSERT = 82;
        public const ushort S_DELETE = 83;
        public const ushort S_HELP = 99;
        public const ushort S_APOSTROPHE = 41;
        public const ushort S_0 = 11;
        public const ushort S_1 = 2;
        public const ushort S_2 = 3;
        public const ushort S_3 = 4;
        public const ushort S_4 = 5;
        public const ushort S_5 = 6;
        public const ushort S_6 = 7;
        public const ushort S_7 = 8;
        public const ushort S_8 = 9;
        public const ushort S_9 = 10;
        public const ushort S_A = 16;
        public const ushort S_B = 48;
        public const ushort S_C = 46;
        public const ushort S_D = 32;
        public const ushort S_E = 18;
        public const ushort S_F = 33;
        public const ushort S_G = 34;
        public const ushort S_H = 35;
        public const ushort S_I = 23;
        public const ushort S_J = 36;
        public const ushort S_K = 37;
        public const ushort S_L = 38;
        public const ushort S_M = 39;
        public const ushort S_N = 49;
        public const ushort S_O = 24;
        public const ushort S_P = 25;
        public const ushort S_Q = 30;
        public const ushort S_R = 19;
        public const ushort S_S = 31;
        public const ushort S_T = 20;
        public const ushort S_U = 22;
        public const ushort S_V = 47;
        public const ushort S_W = 44;
        public const ushort S_X = 45;
        public const ushort S_Y = 21;
        public const ushort S_Z = 17;
        public const ushort S_LWIN = 91;
        public const ushort S_RWIN = 92;
        public const ushort S_APPS = 93;
        public const ushort S_SLEEP = 95;
        public const ushort S_NUMPAD0 = 82;
        public const ushort S_NUMPAD1 = 79;
        public const ushort S_NUMPAD2 = 80;
        public const ushort S_NUMPAD3 = 81;
        public const ushort S_NUMPAD4 = 75;
        public const ushort S_NUMPAD5 = 76;
        public const ushort S_NUMPAD6 = 77;
        public const ushort S_NUMPAD7 = 71;
        public const ushort S_NUMPAD8 = 72;
        public const ushort S_NUMPAD9 = 73;
        public const ushort S_MULTIPLY = 55;
        public const ushort S_ADD = 78;
        public const ushort S_SEPARATOR = 0;
        public const ushort S_SUBTRACT = 74;
        public const ushort S_DECIMAL = 83;
        public const ushort S_DIVIDE = 53;
        public const ushort S_F1 = 59;
        public const ushort S_F2 = 60;
        public const ushort S_F3 = 61;
        public const ushort S_F4 = 62;
        public const ushort S_F5 = 63;
        public const ushort S_F6 = 64;
        public const ushort S_F7 = 65;
        public const ushort S_F8 = 66;
        public const ushort S_F9 = 67;
        public const ushort S_F10 = 68;
        public const ushort S_F11 = 87;
        public const ushort S_F12 = 88;
        public const ushort S_F13 = 100;
        public const ushort S_F14 = 101;
        public const ushort S_F15 = 102;
        public const ushort S_F16 = 103;
        public const ushort S_F17 = 104;
        public const ushort S_F18 = 105;
        public const ushort S_F19 = 106;
        public const ushort S_F20 = 107;
        public const ushort S_F21 = 108;
        public const ushort S_F22 = 109;
        public const ushort S_F23 = 110;
        public const ushort S_F24 = 118;
        public const ushort S_NUMLOCK = 69;
        public const ushort S_SCROLL = 70;
        public const ushort S_LeftShift = 42;
        public const ushort S_RightShift = 54;
        public const ushort S_LeftControl = 29;
        public const ushort S_RightControl = 29;
        public const ushort S_LMENU = 56;
        public const ushort S_RMENU = 56;
        public const ushort S_BROWSER_BACK = 106;
        public const ushort S_BROWSER_FORWARD = 105;
        public const ushort S_BROWSER_REFRESH = 103;
        public const ushort S_BROWSER_STOP = 104;
        public const ushort S_BROWSER_SEARCH = 101;
        public const ushort S_BROWSER_FAVORITES = 102;
        public const ushort S_BROWSER_HOME = 50;
        public const ushort S_VOLUME_MUTE = 32;
        public const ushort S_VOLUME_DOWN = 46;
        public const ushort S_VOLUME_UP = 48;
        public const ushort S_MEDIA_NEXT_TRACK = 25;
        public const ushort S_MEDIA_PREV_TRACK = 16;
        public const ushort S_MEDIA_STOP = 36;
        public const ushort S_MEDIA_PLAY_PAUSE = 34;
        public const ushort S_LAUNCH_MAIL = 108;
        public const ushort S_LAUNCH_MEDIA_SELECT = 109;
        public const ushort S_LAUNCH_APP1 = 107;
        public const ushort S_LAUNCH_APP2 = 33;
        public const ushort S_OEM_1 = 27;
        public const ushort S_OEM_PLUS = 13;
        public const ushort S_OEM_COMMA = 50;
        public const ushort S_OEM_MINUS = 0;
        public const ushort S_OEM_PERIOD = 51;
        public const ushort S_OEM_2 = 52;
        public const ushort S_OEM_3 = 40;
        public const ushort S_OEM_4 = 12;
        public const ushort S_OEM_5 = 43;
        public const ushort S_OEM_6 = 26;
        public const ushort S_OEM_7 = 41;
        public const ushort S_OEM_8 = 53;
        public const ushort S_OEM_102 = 86;
        public const ushort S_PROCESSKEY = 0;
        public const ushort S_PACKET = 0;
        public const ushort S_ATTN = 0;
        public const ushort S_CRSEL = 0;
        public const ushort S_EXSEL = 0;
        public const ushort S_EREOF = 93;
        public const ushort S_PLAY = 0;
        public const ushort S_ZOOM = 98;
        public const ushort S_NONAME = 0;
        public const ushort S_PA1 = 0;
        public const ushort S_OEM_CLEAR = 0;
        public static string drivertype;
        public static Valuechanges ValueChange = new Valuechanges();
        public static void UnLoadKM()
        {
            SetKM("kmevent", false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
            SetKM("sendinput", false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
        }
        public static void SetKM(string KeyboardMouseDriverType, bool SendLeftClick, bool SendRightClick, bool SendMiddleClick, bool SendWheelUp, bool SendWheelDown, bool SendLeft, bool SendRight, bool SendUp, bool SendDown, bool SendLButton, bool SendRButton, bool SendCancel, bool SendMBUTTON, bool SendXBUTTON1, bool SendXBUTTON2, bool SendBack, bool SendTab, bool SendClear, bool SendReturn, bool SendSHIFT, bool SendCONTROL, bool SendMENU, bool SendPAUSE, bool SendCAPITAL, bool SendKANA, bool SendHANGEUL, bool SendHANGUL, bool SendJUNJA, bool SendFINAL, bool SendHANJA, bool SendKANJI, bool SendEscape, bool SendCONVERT, bool SendNONCONVERT, bool SendACCEPT, bool SendMODECHANGE, bool SendSpace, bool SendPRIOR, bool SendNEXT, bool SendEND, bool SendHOME, bool SendLEFT, bool SendUP, bool SendRIGHT, bool SendDOWN, bool SendSELECT, bool SendPRINT, bool SendEXECUTE, bool SendSNAPSHOT, bool SendINSERT, bool SendDELETE, bool SendHELP, bool SendAPOSTROPHE, bool Send0, bool Send1, bool Send2, bool Send3, bool Send4, bool Send5, bool Send6, bool Send7, bool Send8, bool Send9, bool SendA, bool SendB, bool SendC, bool SendD, bool SendE, bool SendF, bool SendG, bool SendH, bool SendI, bool SendJ, bool SendK, bool SendL, bool SendM, bool SendN, bool SendO, bool SendP, bool SendQ, bool SendR, bool SendS, bool SendT, bool SendU, bool SendV, bool SendW, bool SendX, bool SendY, bool SendZ, bool SendLWIN, bool SendRWIN, bool SendAPPS, bool SendSLEEP, bool SendNUMPAD0, bool SendNUMPAD1, bool SendNUMPAD2, bool SendNUMPAD3, bool SendNUMPAD4, bool SendNUMPAD5, bool SendNUMPAD6, bool SendNUMPAD7, bool SendNUMPAD8, bool SendNUMPAD9, bool SendMULTIPLY, bool SendADD, bool SendSEPARATOR, bool SendSUBTRACT, bool SendDECIMAL, bool SendDIVIDE, bool SendF1, bool SendF2, bool SendF3, bool SendF4, bool SendF5, bool SendF6, bool SendF7, bool SendF8, bool SendF9, bool SendF10, bool SendF11, bool SendF12, bool SendF13, bool SendF14, bool SendF15, bool SendF16, bool SendF17, bool SendF18, bool SendF19, bool SendF20, bool SendF21, bool SendF22, bool SendF23, bool SendF24, bool SendNUMLOCK, bool SendSCROLL, bool SendLeftShift, bool SendRightShift, bool SendLeftControl, bool SendRightControl, bool SendLMENU, bool SendRMENU)
        {
            drivertype = KeyboardMouseDriverType;
            ValueChange[1] = SendLeftClick ? 1 : 0;
            if (Valuechanges._ValueChange[1] > 0f)
                mouseclickleft();
            if (Valuechanges._ValueChange[1] < 0f)
                mouseclickleftF();
            ValueChange[2] = SendRightClick ? 1 : 0;
            if (Valuechanges._ValueChange[2] > 0f)
                mouseclickright();
            if (Valuechanges._ValueChange[2] < 0f)
                mouseclickrightF();
            ValueChange[3] = SendMiddleClick ? 1 : 0;
            if (Valuechanges._ValueChange[3] > 0f)
                mouseclickmiddle();
            if (Valuechanges._ValueChange[3] < 0f)
                mouseclickmiddleF();
            ValueChange[4] = SendWheelUp ? 1 : 0;
            if (Valuechanges._ValueChange[4] > 0f)
                mousewheelup();
            ValueChange[5] = SendWheelDown ? 1 : 0;
            if (Valuechanges._ValueChange[5] > 0f)
                mousewheeldown();
            ValueChange[6] = SendLeft ? 1 : 0;
            if (Valuechanges._ValueChange[6] > 0f)
                keyboardArrows(VK_LEFT, S_LEFT);
            if (Valuechanges._ValueChange[6] < 0f)
                keyboardArrowsF(VK_LEFT, S_LEFT);
            ValueChange[7] = SendRight ? 1 : 0;
            if (Valuechanges._ValueChange[7] > 0f)
                keyboardArrows(VK_RIGHT, S_RIGHT);
            if (Valuechanges._ValueChange[7] < 0f)
                keyboardArrowsF(VK_RIGHT, S_RIGHT);
            ValueChange[8] = SendUp ? 1 : 0;
            if (Valuechanges._ValueChange[8] > 0f)
                keyboardArrows(VK_UP, S_UP);
            if (Valuechanges._ValueChange[8] < 0f)
                keyboardArrowsF(VK_UP, S_UP);
            ValueChange[9] = SendDown ? 1 : 0;
            if (Valuechanges._ValueChange[9] > 0f)
                keyboardArrows(VK_DOWN, S_DOWN);
            if (Valuechanges._ValueChange[9] < 0f)
                keyboardArrowsF(VK_DOWN, S_DOWN);
            ValueChange[10] = SendLButton ? 1 : 0;
            if (Valuechanges._ValueChange[10] > 0f)
                keyboard(VK_LBUTTON, S_LBUTTON);
            if (Valuechanges._ValueChange[10] < 0f)
                keyboardF(VK_LBUTTON, S_LBUTTON);
            ValueChange[11] = SendRButton ? 1 : 0;
            if (Valuechanges._ValueChange[11] > 0f)
                keyboard(VK_RBUTTON, S_RBUTTON);
            if (Valuechanges._ValueChange[11] < 0f)
                keyboardF(VK_RBUTTON, S_RBUTTON);
            ValueChange[12] = SendCancel ? 1 : 0;
            if (Valuechanges._ValueChange[12] > 0f)
                keyboard(VK_CANCEL, S_CANCEL);
            if (Valuechanges._ValueChange[12] < 0f)
                keyboardF(VK_CANCEL, S_CANCEL);
            ValueChange[13] = SendMBUTTON ? 1 : 0;
            if (Valuechanges._ValueChange[13] > 0f)
                keyboard(VK_MBUTTON, S_MBUTTON);
            if (Valuechanges._ValueChange[13] < 0f)
                keyboardF(VK_MBUTTON, S_MBUTTON);
            ValueChange[14] = SendXBUTTON1 ? 1 : 0;
            if (Valuechanges._ValueChange[14] > 0f)
                keyboard(VK_XBUTTON1, S_XBUTTON1);
            if (Valuechanges._ValueChange[14] < 0f)
                keyboardF(VK_XBUTTON1, S_XBUTTON1);
            ValueChange[15] = SendXBUTTON2 ? 1 : 0;
            if (Valuechanges._ValueChange[15] > 0f)
                keyboard(VK_XBUTTON2, S_XBUTTON2);
            if (Valuechanges._ValueChange[15] < 0f)
                keyboardF(VK_XBUTTON2, S_XBUTTON2);
            ValueChange[16] = SendBack ? 1 : 0;
            if (Valuechanges._ValueChange[16] > 0f)
                keyboard(VK_BACK, S_BACK);
            if (Valuechanges._ValueChange[16] < 0f)
                keyboardF(VK_BACK, S_BACK);
            ValueChange[17] = SendTab ? 1 : 0;
            if (Valuechanges._ValueChange[17] > 0f)
                keyboard(VK_Tab, S_Tab);
            if (Valuechanges._ValueChange[17] < 0f)
                keyboardF(VK_Tab, S_Tab);
            ValueChange[18] = SendClear ? 1 : 0;
            if (Valuechanges._ValueChange[18] > 0f)
                keyboard(VK_CLEAR, S_CLEAR);
            if (Valuechanges._ValueChange[18] < 0f)
                keyboardF(VK_CLEAR, S_CLEAR);
            ValueChange[19] = SendReturn ? 1 : 0;
            if (Valuechanges._ValueChange[19] > 0f)
                keyboard(VK_Return, S_Return);
            if (Valuechanges._ValueChange[19] < 0f)
                keyboardF(VK_Return, S_Return);
            ValueChange[20] = SendSHIFT ? 1 : 0;
            if (Valuechanges._ValueChange[20] > 0f)
                keyboard(VK_SHIFT, S_SHIFT);
            if (Valuechanges._ValueChange[20] < 0f)
                keyboardF(VK_SHIFT, S_SHIFT);
            ValueChange[21] = SendCONTROL ? 1 : 0;
            if (Valuechanges._ValueChange[21] > 0f)
                keyboard(VK_CONTROL, S_CONTROL);
            if (Valuechanges._ValueChange[21] < 0f)
                keyboardF(VK_CONTROL, S_CONTROL);
            ValueChange[22] = SendMENU ? 1 : 0;
            if (Valuechanges._ValueChange[22] > 0f)
                keyboard(VK_MENU, S_MENU);
            if (Valuechanges._ValueChange[22] < 0f)
                keyboardF(VK_MENU, S_MENU);
            ValueChange[23] = SendPAUSE ? 1 : 0;
            if (Valuechanges._ValueChange[23] > 0f)
                keyboard(VK_PAUSE, S_PAUSE);
            if (Valuechanges._ValueChange[23] < 0f)
                keyboardF(VK_PAUSE, S_PAUSE);
            ValueChange[24] = SendCAPITAL ? 1 : 0;
            if (Valuechanges._ValueChange[24] > 0f)
                keyboard(VK_CAPITAL, S_CAPITAL);
            if (Valuechanges._ValueChange[24] < 0f)
                keyboardF(VK_CAPITAL, S_CAPITAL);
            ValueChange[25] = SendKANA ? 1 : 0;
            if (Valuechanges._ValueChange[25] > 0f)
                keyboard(VK_KANA, S_KANA);
            if (Valuechanges._ValueChange[25] < 0f)
                keyboardF(VK_KANA, S_KANA);
            ValueChange[26] = SendHANGEUL ? 1 : 0;
            if (Valuechanges._ValueChange[26] > 0f)
                keyboard(VK_HANGEUL, S_HANGEUL);
            if (Valuechanges._ValueChange[26] < 0f)
                keyboardF(VK_HANGEUL, S_HANGEUL);
            ValueChange[27] = SendHANGUL ? 1 : 0;
            if (Valuechanges._ValueChange[27] > 0f)
                keyboard(VK_HANGUL, S_HANGUL);
            if (Valuechanges._ValueChange[27] < 0f)
                keyboardF(VK_HANGUL, S_HANGUL);
            ValueChange[28] = SendJUNJA ? 1 : 0;
            if (Valuechanges._ValueChange[28] > 0f)
                keyboard(VK_JUNJA, S_JUNJA);
            if (Valuechanges._ValueChange[28] < 0f)
                keyboardF(VK_JUNJA, S_JUNJA);
            ValueChange[29] = SendFINAL ? 1 : 0;
            if (Valuechanges._ValueChange[29] > 0f)
                keyboard(VK_FINAL, S_FINAL);
            if (Valuechanges._ValueChange[29] < 0f)
                keyboardF(VK_FINAL, S_FINAL);
            ValueChange[30] = SendHANJA ? 1 : 0;
            if (Valuechanges._ValueChange[30] > 0f)
                keyboard(VK_HANJA, S_HANJA);
            if (Valuechanges._ValueChange[30] < 0f)
                keyboardF(VK_HANJA, S_HANJA);
            ValueChange[31] = SendKANJI ? 1 : 0;
            if (Valuechanges._ValueChange[31] > 0f)
                keyboard(VK_KANJI, S_KANJI);
            if (Valuechanges._ValueChange[31] < 0f)
                keyboardF(VK_KANJI, S_KANJI);
            ValueChange[32] = SendEscape ? 1 : 0;
            if (Valuechanges._ValueChange[32] > 0f)
                keyboard(VK_Escape, S_Escape);
            if (Valuechanges._ValueChange[32] < 0f)
                keyboardF(VK_Escape, S_Escape);
            ValueChange[33] = SendCONVERT ? 1 : 0;
            if (Valuechanges._ValueChange[33] > 0f)
                keyboard(VK_CONVERT, S_CONVERT);
            if (Valuechanges._ValueChange[33] < 0f)
                keyboardF(VK_CONVERT, S_CONVERT);
            ValueChange[34] = SendNONCONVERT ? 1 : 0;
            if (Valuechanges._ValueChange[34] > 0f)
                keyboard(VK_NONCONVERT, S_NONCONVERT);
            if (Valuechanges._ValueChange[34] < 0f)
                keyboardF(VK_NONCONVERT, S_NONCONVERT);
            ValueChange[35] = SendACCEPT ? 1 : 0;
            if (Valuechanges._ValueChange[35] > 0f)
                keyboard(VK_ACCEPT, S_ACCEPT);
            if (Valuechanges._ValueChange[35] < 0f)
                keyboardF(VK_ACCEPT, S_ACCEPT);
            ValueChange[36] = SendMODECHANGE ? 1 : 0;
            if (Valuechanges._ValueChange[36] > 0f)
                keyboard(VK_MODECHANGE, S_MODECHANGE);
            if (Valuechanges._ValueChange[36] < 0f)
                keyboardF(VK_MODECHANGE, S_MODECHANGE);
            ValueChange[37] = SendSpace ? 1 : 0;
            if (Valuechanges._ValueChange[37] > 0f)
                keyboard(VK_Space, S_Space);
            if (Valuechanges._ValueChange[37] < 0f)
                keyboardF(VK_Space, S_Space);
            ValueChange[38] = SendPRIOR ? 1 : 0;
            if (Valuechanges._ValueChange[38] > 0f)
                keyboard(VK_PRIOR, S_PRIOR);
            if (Valuechanges._ValueChange[38] < 0f)
                keyboardF(VK_PRIOR, S_PRIOR);
            ValueChange[39] = SendNEXT ? 1 : 0;
            if (Valuechanges._ValueChange[39] > 0f)
                keyboard(VK_NEXT, S_NEXT);
            if (Valuechanges._ValueChange[39] < 0f)
                keyboardF(VK_NEXT, S_NEXT);
            ValueChange[40] = SendEND ? 1 : 0;
            if (Valuechanges._ValueChange[40] > 0f)
                keyboard(VK_END, S_END);
            if (Valuechanges._ValueChange[40] < 0f)
                keyboardF(VK_END, S_END);
            ValueChange[41] = SendHOME ? 1 : 0;
            if (Valuechanges._ValueChange[41] > 0f)
                keyboard(VK_HOME, S_HOME);
            if (Valuechanges._ValueChange[41] < 0f)
                keyboardF(VK_HOME, S_HOME);
            ValueChange[42] = SendLEFT ? 1 : 0;
            if (Valuechanges._ValueChange[42] > 0f)
                keyboard(VK_LEFT, S_LEFT);
            if (Valuechanges._ValueChange[42] < 0f)
                keyboardF(VK_LEFT, S_LEFT);
            ValueChange[43] = SendUP ? 1 : 0;
            if (Valuechanges._ValueChange[43] > 0f)
                keyboard(VK_UP, S_UP);
            if (Valuechanges._ValueChange[43] < 0f)
                keyboardF(VK_UP, S_UP);
            ValueChange[44] = SendRIGHT ? 1 : 0;
            if (Valuechanges._ValueChange[44] > 0f)
                keyboard(VK_RIGHT, S_RIGHT);
            if (Valuechanges._ValueChange[44] < 0f)
                keyboardF(VK_RIGHT, S_RIGHT);
            ValueChange[45] = SendDOWN ? 1 : 0;
            if (Valuechanges._ValueChange[45] > 0f)
                keyboard(VK_DOWN, S_DOWN);
            if (Valuechanges._ValueChange[45] < 0f)
                keyboardF(VK_DOWN, S_DOWN);
            ValueChange[46] = SendSELECT ? 1 : 0;
            if (Valuechanges._ValueChange[46] > 0f)
                keyboard(VK_SELECT, S_SELECT);
            if (Valuechanges._ValueChange[46] < 0f)
                keyboardF(VK_SELECT, S_SELECT);
            ValueChange[47] = SendPRINT ? 1 : 0;
            if (Valuechanges._ValueChange[47] > 0f)
                keyboard(VK_PRINT, S_PRINT);
            if (Valuechanges._ValueChange[47] < 0f)
                keyboardF(VK_PRINT, S_PRINT);
            ValueChange[48] = SendEXECUTE ? 1 : 0;
            if (Valuechanges._ValueChange[48] > 0f)
                keyboard(VK_EXECUTE, S_EXECUTE);
            if (Valuechanges._ValueChange[48] < 0f)
                keyboardF(VK_EXECUTE, S_EXECUTE);
            ValueChange[49] = SendSNAPSHOT ? 1 : 0;
            if (Valuechanges._ValueChange[49] > 0f)
                keyboard(VK_SNAPSHOT, S_SNAPSHOT);
            if (Valuechanges._ValueChange[49] < 0f)
                keyboardF(VK_SNAPSHOT, S_SNAPSHOT);
            ValueChange[50] = SendINSERT ? 1 : 0;
            if (Valuechanges._ValueChange[50] > 0f)
                keyboard(VK_INSERT, S_INSERT);
            if (Valuechanges._ValueChange[50] < 0f)
                keyboardF(VK_INSERT, S_INSERT);
            ValueChange[51] = SendDELETE ? 1 : 0;
            if (Valuechanges._ValueChange[51] > 0f)
                keyboard(VK_DELETE, S_DELETE);
            if (Valuechanges._ValueChange[51] < 0f)
                keyboardF(VK_DELETE, S_DELETE);
            ValueChange[52] = SendHELP ? 1 : 0;
            if (Valuechanges._ValueChange[52] > 0f)
                keyboard(VK_HELP, S_HELP);
            if (Valuechanges._ValueChange[52] < 0f)
                keyboardF(VK_HELP, S_HELP);
            ValueChange[53] = SendAPOSTROPHE ? 1 : 0;
            if (Valuechanges._ValueChange[53] > 0f)
                keyboard(VK_APOSTROPHE, S_APOSTROPHE);
            if (Valuechanges._ValueChange[53] < 0f)
                keyboardF(VK_APOSTROPHE, S_APOSTROPHE);
            ValueChange[54] = Send0 ? 1 : 0;
            if (Valuechanges._ValueChange[54] > 0f)
                keyboard(VK_0, S_0);
            if (Valuechanges._ValueChange[54] < 0f)
                keyboardF(VK_0, S_0);
            ValueChange[55] = Send1 ? 1 : 0;
            if (Valuechanges._ValueChange[55] > 0f)
                keyboard(VK_1, S_1);
            if (Valuechanges._ValueChange[55] < 0f)
                keyboardF(VK_1, S_1);
            ValueChange[56] = Send2 ? 1 : 0;
            if (Valuechanges._ValueChange[56] > 0f)
                keyboard(VK_2, S_2);
            if (Valuechanges._ValueChange[56] < 0f)
                keyboardF(VK_2, S_2);
            ValueChange[57] = Send3 ? 1 : 0;
            if (Valuechanges._ValueChange[57] > 0f)
                keyboard(VK_3, S_3);
            if (Valuechanges._ValueChange[57] < 0f)
                keyboardF(VK_3, S_3);
            ValueChange[58] = Send4 ? 1 : 0;
            if (Valuechanges._ValueChange[58] > 0f)
                keyboard(VK_4, S_4);
            if (Valuechanges._ValueChange[58] < 0f)
                keyboardF(VK_4, S_4);
            ValueChange[59] = Send5 ? 1 : 0;
            if (Valuechanges._ValueChange[59] > 0f)
                keyboard(VK_5, S_5);
            if (Valuechanges._ValueChange[59] < 0f)
                keyboardF(VK_5, S_5);
            ValueChange[60] = Send6 ? 1 : 0;
            if (Valuechanges._ValueChange[60] > 0f)
                keyboard(VK_6, S_6);
            if (Valuechanges._ValueChange[60] < 0f)
                keyboardF(VK_6, S_6);
            ValueChange[61] = Send7 ? 1 : 0;
            if (Valuechanges._ValueChange[61] > 0f)
                keyboard(VK_7, S_7);
            if (Valuechanges._ValueChange[61] < 0f)
                keyboardF(VK_7, S_7);
            ValueChange[62] = Send8 ? 1 : 0;
            if (Valuechanges._ValueChange[62] > 0f)
                keyboard(VK_8, S_8);
            if (Valuechanges._ValueChange[62] < 0f)
                keyboardF(VK_8, S_8);
            ValueChange[63] = Send9 ? 1 : 0;
            if (Valuechanges._ValueChange[63] > 0f)
                keyboard(VK_9, S_9);
            if (Valuechanges._ValueChange[63] < 0f)
                keyboardF(VK_9, S_9);
            ValueChange[64] = SendA ? 1 : 0;
            if (Valuechanges._ValueChange[64] > 0f)
                keyboard(VK_A, S_A);
            if (Valuechanges._ValueChange[64] < 0f)
                keyboardF(VK_A, S_A);
            ValueChange[65] = SendB ? 1 : 0;
            if (Valuechanges._ValueChange[65] > 0f)
                keyboard(VK_B, S_B);
            if (Valuechanges._ValueChange[65] < 0f)
                keyboardF(VK_B, S_B);
            ValueChange[66] = SendC ? 1 : 0;
            if (Valuechanges._ValueChange[66] > 0f)
                keyboard(VK_C, S_C);
            if (Valuechanges._ValueChange[66] < 0f)
                keyboardF(VK_C, S_C);
            ValueChange[67] = SendD ? 1 : 0;
            if (Valuechanges._ValueChange[67] > 0f)
                keyboard(VK_D, S_D);
            if (Valuechanges._ValueChange[67] < 0f)
                keyboardF(VK_D, S_D);
            ValueChange[68] = SendE ? 1 : 0;
            if (Valuechanges._ValueChange[68] > 0f)
                keyboard(VK_E, S_E);
            if (Valuechanges._ValueChange[68] < 0f)
                keyboardF(VK_E, S_E);
            ValueChange[69] = SendF ? 1 : 0;
            if (Valuechanges._ValueChange[69] > 0f)
                keyboard(VK_F, S_F);
            if (Valuechanges._ValueChange[69] < 0f)
                keyboardF(VK_F, S_F);
            ValueChange[70] = SendG ? 1 : 0;
            if (Valuechanges._ValueChange[70] > 0f)
                keyboard(VK_G, S_G);
            if (Valuechanges._ValueChange[70] < 0f)
                keyboardF(VK_G, S_G);
            ValueChange[71] = SendH ? 1 : 0;
            if (Valuechanges._ValueChange[71] > 0f)
                keyboard(VK_H, S_H);
            if (Valuechanges._ValueChange[71] < 0f)
                keyboardF(VK_H, S_H);
            ValueChange[72] = SendI ? 1 : 0;
            if (Valuechanges._ValueChange[72] > 0f)
                keyboard(VK_I, S_I);
            if (Valuechanges._ValueChange[72] < 0f)
                keyboardF(VK_I, S_I);
            ValueChange[73] = SendJ ? 1 : 0;
            if (Valuechanges._ValueChange[73] > 0f)
                keyboard(VK_J, S_J);
            if (Valuechanges._ValueChange[73] < 0f)
                keyboardF(VK_J, S_J);
            ValueChange[74] = SendK ? 1 : 0;
            if (Valuechanges._ValueChange[74] > 0f)
                keyboard(VK_K, S_K);
            if (Valuechanges._ValueChange[74] < 0f)
                keyboardF(VK_K, S_K);
            ValueChange[75] = SendL ? 1 : 0;
            if (Valuechanges._ValueChange[75] > 0f)
                keyboard(VK_L, S_L);
            if (Valuechanges._ValueChange[75] < 0f)
                keyboardF(VK_L, S_L);
            ValueChange[76] = SendM ? 1 : 0;
            if (Valuechanges._ValueChange[76] > 0f)
                keyboard(VK_M, S_M);
            if (Valuechanges._ValueChange[76] < 0f)
                keyboardF(VK_M, S_M);
            ValueChange[77] = SendN ? 1 : 0;
            if (Valuechanges._ValueChange[77] > 0f)
                keyboard(VK_N, S_N);
            if (Valuechanges._ValueChange[77] < 0f)
                keyboardF(VK_N, S_N);
            ValueChange[78] = SendO ? 1 : 0;
            if (Valuechanges._ValueChange[78] > 0f)
                keyboard(VK_O, S_O);
            if (Valuechanges._ValueChange[78] < 0f)
                keyboardF(VK_O, S_O);
            ValueChange[79] = SendP ? 1 : 0;
            if (Valuechanges._ValueChange[79] > 0f)
                keyboard(VK_P, S_P);
            if (Valuechanges._ValueChange[79] < 0f)
                keyboardF(VK_P, S_P);
            ValueChange[80] = SendQ ? 1 : 0;
            if (Valuechanges._ValueChange[80] > 0f)
                keyboard(VK_Q, S_Q);
            if (Valuechanges._ValueChange[80] < 0f)
                keyboardF(VK_Q, S_Q);
            ValueChange[81] = SendR ? 1 : 0;
            if (Valuechanges._ValueChange[81] > 0f)
                keyboard(VK_R, S_R);
            if (Valuechanges._ValueChange[81] < 0f)
                keyboardF(VK_R, S_R);
            ValueChange[82] = SendS ? 1 : 0;
            if (Valuechanges._ValueChange[82] > 0f)
                keyboard(VK_S, S_S);
            if (Valuechanges._ValueChange[82] < 0f)
                keyboardF(VK_S, S_S);
            ValueChange[83] = SendT ? 1 : 0;
            if (Valuechanges._ValueChange[83] > 0f)
                keyboard(VK_T, S_T);
            if (Valuechanges._ValueChange[83] < 0f)
                keyboardF(VK_T, S_T);
            ValueChange[84] = SendU ? 1 : 0;
            if (Valuechanges._ValueChange[84] > 0f)
                keyboard(VK_U, S_U);
            if (Valuechanges._ValueChange[84] < 0f)
                keyboardF(VK_U, S_U);
            ValueChange[85] = SendV ? 1 : 0;
            if (Valuechanges._ValueChange[85] > 0f)
                keyboard(VK_V, S_V);
            if (Valuechanges._ValueChange[85] < 0f)
                keyboardF(VK_V, S_V);
            ValueChange[86] = SendW ? 1 : 0;
            if (Valuechanges._ValueChange[86] > 0f)
                keyboard(VK_W, S_W);
            if (Valuechanges._ValueChange[86] < 0f)
                keyboardF(VK_W, S_W);
            ValueChange[87] = SendX ? 1 : 0;
            if (Valuechanges._ValueChange[87] > 0f)
                keyboard(VK_X, S_X);
            if (Valuechanges._ValueChange[87] < 0f)
                keyboardF(VK_X, S_X);
            ValueChange[88] = SendY ? 1 : 0;
            if (Valuechanges._ValueChange[88] > 0f)
                keyboard(VK_Y, S_Y);
            if (Valuechanges._ValueChange[88] < 0f)
                keyboardF(VK_Y, S_Y);
            ValueChange[89] = SendZ ? 1 : 0;
            if (Valuechanges._ValueChange[89] > 0f)
                keyboard(VK_Z, S_Z);
            if (Valuechanges._ValueChange[89] < 0f)
                keyboardF(VK_Z, S_Z);
            ValueChange[90] = SendLWIN ? 1 : 0;
            if (Valuechanges._ValueChange[90] > 0f)
                keyboard(VK_LWIN, S_LWIN);
            if (Valuechanges._ValueChange[90] < 0f)
                keyboardF(VK_LWIN, S_LWIN);
            ValueChange[91] = SendRWIN ? 1 : 0;
            if (Valuechanges._ValueChange[91] > 0f)
                keyboard(VK_RWIN, S_RWIN);
            if (Valuechanges._ValueChange[91] < 0f)
                keyboardF(VK_RWIN, S_RWIN);
            ValueChange[92] = SendAPPS ? 1 : 0;
            if (Valuechanges._ValueChange[92] > 0f)
                keyboard(VK_APPS, S_APPS);
            if (Valuechanges._ValueChange[92] < 0f)
                keyboardF(VK_APPS, S_APPS);
            ValueChange[93] = SendSLEEP ? 1 : 0;
            if (Valuechanges._ValueChange[93] > 0f)
                keyboard(VK_SLEEP, S_SLEEP);
            if (Valuechanges._ValueChange[93] < 0f)
                keyboardF(VK_SLEEP, S_SLEEP);
            ValueChange[94] = SendNUMPAD0 ? 1 : 0;
            if (Valuechanges._ValueChange[94] > 0f)
                keyboard(VK_NUMPAD0, S_NUMPAD0);
            if (Valuechanges._ValueChange[94] < 0f)
                keyboardF(VK_NUMPAD0, S_NUMPAD0);
            ValueChange[95] = SendNUMPAD1 ? 1 : 0;
            if (Valuechanges._ValueChange[95] > 0f)
                keyboard(VK_NUMPAD1, S_NUMPAD1);
            if (Valuechanges._ValueChange[95] < 0f)
                keyboardF(VK_NUMPAD1, S_NUMPAD1);
            ValueChange[96] = SendNUMPAD2 ? 1 : 0;
            if (Valuechanges._ValueChange[96] > 0f)
                keyboard(VK_NUMPAD2, S_NUMPAD2);
            if (Valuechanges._ValueChange[96] < 0f)
                keyboardF(VK_NUMPAD2, S_NUMPAD2);
            ValueChange[97] = SendNUMPAD3 ? 1 : 0;
            if (Valuechanges._ValueChange[97] > 0f)
                keyboard(VK_NUMPAD3, S_NUMPAD3);
            if (Valuechanges._ValueChange[97] < 0f)
                keyboardF(VK_NUMPAD3, S_NUMPAD3);
            ValueChange[98] = SendNUMPAD4 ? 1 : 0;
            if (Valuechanges._ValueChange[98] > 0f)
                keyboard(VK_NUMPAD4, S_NUMPAD4);
            if (Valuechanges._ValueChange[98] < 0f)
                keyboardF(VK_NUMPAD4, S_NUMPAD4);
            ValueChange[99] = SendNUMPAD5 ? 1 : 0;
            if (Valuechanges._ValueChange[99] > 0f)
                keyboard(VK_NUMPAD5, S_NUMPAD5);
            if (Valuechanges._ValueChange[99] < 0f)
                keyboardF(VK_NUMPAD5, S_NUMPAD5);
            ValueChange[100] = SendNUMPAD6 ? 1 : 0;
            if (Valuechanges._ValueChange[100] > 0f)
                keyboard(VK_NUMPAD6, S_NUMPAD6);
            if (Valuechanges._ValueChange[100] < 0f)
                keyboardF(VK_NUMPAD6, S_NUMPAD6);
            ValueChange[101] = SendNUMPAD7 ? 1 : 0;
            if (Valuechanges._ValueChange[101] > 0f)
                keyboard(VK_NUMPAD7, S_NUMPAD7);
            if (Valuechanges._ValueChange[101] < 0f)
                keyboardF(VK_NUMPAD7, S_NUMPAD7);
            ValueChange[102] = SendNUMPAD8 ? 1 : 0;
            if (Valuechanges._ValueChange[102] > 0f)
                keyboard(VK_NUMPAD8, S_NUMPAD8);
            if (Valuechanges._ValueChange[102] < 0f)
                keyboardF(VK_NUMPAD8, S_NUMPAD8);
            ValueChange[103] = SendNUMPAD9 ? 1 : 0;
            if (Valuechanges._ValueChange[103] > 0f)
                keyboard(VK_NUMPAD9, S_NUMPAD9);
            if (Valuechanges._ValueChange[103] < 0f)
                keyboardF(VK_NUMPAD9, S_NUMPAD9);
            ValueChange[104] = SendMULTIPLY ? 1 : 0;
            if (Valuechanges._ValueChange[104] > 0f)
                keyboard(VK_MULTIPLY, S_MULTIPLY);
            if (Valuechanges._ValueChange[104] < 0f)
                keyboardF(VK_MULTIPLY, S_MULTIPLY);
            ValueChange[105] = SendADD ? 1 : 0;
            if (Valuechanges._ValueChange[105] > 0f)
                keyboard(VK_ADD, S_ADD);
            if (Valuechanges._ValueChange[105] < 0f)
                keyboardF(VK_ADD, S_ADD);
            ValueChange[106] = SendSEPARATOR ? 1 : 0;
            if (Valuechanges._ValueChange[106] > 0f)
                keyboard(VK_SEPARATOR, S_SEPARATOR);
            if (Valuechanges._ValueChange[106] < 0f)
                keyboardF(VK_SEPARATOR, S_SEPARATOR);
            ValueChange[107] = SendSUBTRACT ? 1 : 0;
            if (Valuechanges._ValueChange[107] > 0f)
                keyboard(VK_SUBTRACT, S_SUBTRACT);
            if (Valuechanges._ValueChange[107] < 0f)
                keyboardF(VK_SUBTRACT, S_SUBTRACT);
            ValueChange[108] = SendDECIMAL ? 1 : 0;
            if (Valuechanges._ValueChange[108] > 0f)
                keyboard(VK_DECIMAL, S_DECIMAL);
            if (Valuechanges._ValueChange[108] < 0f)
                keyboardF(VK_DECIMAL, S_DECIMAL);
            ValueChange[109] = SendDIVIDE ? 1 : 0;
            if (Valuechanges._ValueChange[109] > 0f)
                keyboard(VK_DIVIDE, S_DIVIDE);
            if (Valuechanges._ValueChange[109] < 0f)
                keyboardF(VK_DIVIDE, S_DIVIDE);
            ValueChange[110] = SendF1 ? 1 : 0;
            if (Valuechanges._ValueChange[110] > 0f)
                keyboard(VK_F1, S_F1);
            if (Valuechanges._ValueChange[110] < 0f)
                keyboardF(VK_F1, S_F1);
            ValueChange[111] = SendF2 ? 1 : 0;
            if (Valuechanges._ValueChange[111] > 0f)
                keyboard(VK_F2, S_F2);
            if (Valuechanges._ValueChange[111] < 0f)
                keyboardF(VK_F2, S_F2);
            ValueChange[112] = SendF3 ? 1 : 0;
            if (Valuechanges._ValueChange[112] > 0f)
                keyboard(VK_F3, S_F3);
            if (Valuechanges._ValueChange[112] < 0f)
                keyboardF(VK_F3, S_F3);
            ValueChange[113] = SendF4 ? 1 : 0;
            if (Valuechanges._ValueChange[113] > 0f)
                keyboard(VK_F4, S_F4);
            if (Valuechanges._ValueChange[113] < 0f)
                keyboardF(VK_F4, S_F4);
            ValueChange[114] = SendF5 ? 1 : 0;
            if (Valuechanges._ValueChange[114] > 0f)
                keyboard(VK_F5, S_F5);
            if (Valuechanges._ValueChange[114] < 0f)
                keyboardF(VK_F5, S_F5);
            ValueChange[115] = SendF6 ? 1 : 0;
            if (Valuechanges._ValueChange[115] > 0f)
                keyboard(VK_F6, S_F6);
            if (Valuechanges._ValueChange[115] < 0f)
                keyboardF(VK_F6, S_F6);
            ValueChange[116] = SendF7 ? 1 : 0;
            if (Valuechanges._ValueChange[116] > 0f)
                keyboard(VK_F7, S_F7);
            if (Valuechanges._ValueChange[116] < 0f)
                keyboardF(VK_F7, S_F7);
            ValueChange[117] = SendF8 ? 1 : 0;
            if (Valuechanges._ValueChange[117] > 0f)
                keyboard(VK_F8, S_F8);
            if (Valuechanges._ValueChange[117] < 0f)
                keyboardF(VK_F8, S_F8);
            ValueChange[118] = SendF9 ? 1 : 0;
            if (Valuechanges._ValueChange[118] > 0f)
                keyboard(VK_F9, S_F9);
            if (Valuechanges._ValueChange[118] < 0f)
                keyboardF(VK_F9, S_F9);
            ValueChange[119] = SendF10 ? 1 : 0;
            if (Valuechanges._ValueChange[119] > 0f)
                keyboard(VK_F10, S_F10);
            if (Valuechanges._ValueChange[119] < 0f)
                keyboardF(VK_F10, S_F10);
            ValueChange[120] = SendF11 ? 1 : 0;
            if (Valuechanges._ValueChange[120] > 0f)
                keyboard(VK_F11, S_F11);
            if (Valuechanges._ValueChange[120] < 0f)
                keyboardF(VK_F11, S_F11);
            ValueChange[121] = SendF12 ? 1 : 0;
            if (Valuechanges._ValueChange[121] > 0f)
                keyboard(VK_F12, S_F12);
            if (Valuechanges._ValueChange[121] < 0f)
                keyboardF(VK_F12, S_F12);
            ValueChange[122] = SendF13 ? 1 : 0;
            if (Valuechanges._ValueChange[122] > 0f)
                keyboard(VK_F13, S_F13);
            if (Valuechanges._ValueChange[122] < 0f)
                keyboardF(VK_F13, S_F13);
            ValueChange[123] = SendF14 ? 1 : 0;
            if (Valuechanges._ValueChange[123] > 0f)
                keyboard(VK_F14, S_F14);
            if (Valuechanges._ValueChange[123] < 0f)
                keyboardF(VK_F14, S_F14);
            ValueChange[124] = SendF15 ? 1 : 0;
            if (Valuechanges._ValueChange[124] > 0f)
                keyboard(VK_F15, S_F15);
            if (Valuechanges._ValueChange[124] < 0f)
                keyboardF(VK_F15, S_F15);
            ValueChange[125] = SendF16 ? 1 : 0;
            if (Valuechanges._ValueChange[125] > 0f)
                keyboard(VK_F16, S_F16);
            if (Valuechanges._ValueChange[125] < 0f)
                keyboardF(VK_F16, S_F16);
            ValueChange[126] = SendF17 ? 1 : 0;
            if (Valuechanges._ValueChange[126] > 0f)
                keyboard(VK_F17, S_F17);
            if (Valuechanges._ValueChange[126] < 0f)
                keyboardF(VK_F17, S_F17);
            ValueChange[127] = SendF18 ? 1 : 0;
            if (Valuechanges._ValueChange[127] > 0f)
                keyboard(VK_F18, S_F18);
            if (Valuechanges._ValueChange[127] < 0f)
                keyboardF(VK_F18, S_F18);
            ValueChange[128] = SendF19 ? 1 : 0;
            if (Valuechanges._ValueChange[128] > 0f)
                keyboard(VK_F19, S_F19);
            if (Valuechanges._ValueChange[128] < 0f)
                keyboardF(VK_F19, S_F19);
            ValueChange[129] = SendF20 ? 1 : 0;
            if (Valuechanges._ValueChange[129] > 0f)
                keyboard(VK_F20, S_F20);
            if (Valuechanges._ValueChange[129] < 0f)
                keyboardF(VK_F20, S_F20);
            ValueChange[130] = SendF21 ? 1 : 0;
            if (Valuechanges._ValueChange[130] > 0f)
                keyboard(VK_F21, S_F21);
            if (Valuechanges._ValueChange[130] < 0f)
                keyboardF(VK_F21, S_F21);
            ValueChange[131] = SendF22 ? 1 : 0;
            if (Valuechanges._ValueChange[131] > 0f)
                keyboard(VK_F22, S_F22);
            if (Valuechanges._ValueChange[131] < 0f)
                keyboardF(VK_F22, S_F22);
            ValueChange[132] = SendF23 ? 1 : 0;
            if (Valuechanges._ValueChange[132] > 0f)
                keyboard(VK_F23, S_F23);
            if (Valuechanges._ValueChange[132] < 0f)
                keyboardF(VK_F23, S_F23);
            ValueChange[133] = SendF24 ? 1 : 0;
            if (Valuechanges._ValueChange[133] > 0f)
                keyboard(VK_F24, S_F24);
            if (Valuechanges._ValueChange[133] < 0f)
                keyboardF(VK_F24, S_F24);
            ValueChange[134] = SendNUMLOCK ? 1 : 0;
            if (Valuechanges._ValueChange[134] > 0f)
                keyboard(VK_NUMLOCK, S_NUMLOCK);
            if (Valuechanges._ValueChange[134] < 0f)
                keyboardF(VK_NUMLOCK, S_NUMLOCK);
            ValueChange[135] = SendSCROLL ? 1 : 0;
            if (Valuechanges._ValueChange[135] > 0f)
                keyboard(VK_SCROLL, S_SCROLL);
            if (Valuechanges._ValueChange[135] < 0f)
                keyboardF(VK_SCROLL, S_SCROLL);
            ValueChange[136] = SendLeftShift ? 1 : 0;
            if (Valuechanges._ValueChange[136] > 0f)
                keyboard(VK_LeftShift, S_LeftShift);
            if (Valuechanges._ValueChange[136] < 0f)
                keyboardF(VK_LeftShift, S_LeftShift);
            ValueChange[137] = SendRightShift ? 1 : 0;
            if (Valuechanges._ValueChange[137] > 0f)
                keyboard(VK_RightShift, S_RightShift);
            if (Valuechanges._ValueChange[137] < 0f)
                keyboardF(VK_RightShift, S_RightShift);
            ValueChange[138] = SendLeftControl ? 1 : 0;
            if (Valuechanges._ValueChange[138] > 0f)
                keyboard(VK_LeftControl, S_LeftControl);
            if (Valuechanges._ValueChange[138] < 0f)
                keyboardF(VK_LeftControl, S_LeftControl);
            ValueChange[139] = SendRightControl ? 1 : 0;
            if (Valuechanges._ValueChange[139] > 0f)
                keyboard(VK_RightControl, S_RightControl);
            if (Valuechanges._ValueChange[139] < 0f)
                keyboardF(VK_RightControl, S_RightControl);
            ValueChange[140] = SendLMENU ? 1 : 0;
            if (Valuechanges._ValueChange[140] > 0f)
                keyboard(VK_LMENU, S_LMENU);
            if (Valuechanges._ValueChange[140] < 0f)
                keyboardF(VK_LMENU, S_LMENU);
            ValueChange[141] = SendRMENU ? 1 : 0;
            if (Valuechanges._ValueChange[141] > 0f)
                keyboard(VK_RMENU, S_RMENU);
            if (Valuechanges._ValueChange[141] < 0f)
                keyboardF(VK_RMENU, S_RMENU);
        }
        public static void mouseclickleft()
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendMouseEventButtonLeft());
            else
                Task.Run(() => LeftClick());
        }
        public static void mouseclickleftF()
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendMouseEventButtonLeftF());
            else
                Task.Run(() => LeftClickF());
        }
        public static void mouseclickright()
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendMouseEventButtonRight());
            else
                Task.Run(() => RightClick());
        }
        public static void mouseclickrightF()
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendMouseEventButtonRightF());
            else
                Task.Run(() => RightClickF());
        }
        public static void mouseclickmiddle()
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendMouseEventButtonMiddle());
            else
                Task.Run(() => MiddleClick());
        }
        public static void mouseclickmiddleF()
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendMouseEventButtonMiddleF());
            else
                Task.Run(() => MiddleClickF());
        }
        public static void mousewheelup()
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendMouseEventButtonWheelUp());
            else
                Task.Run(() => WheelUpF());
        }
        public static void mousewheeldown()
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendMouseEventButtonWheelDown());
            else
                Task.Run(() => WheelDownF());
        }
        public static void keyboard(UInt16 bVk, UInt16 bScan)
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendKey(bVk, bScan));
            else
                Task.Run(() => SimulateKeyDown(bVk, bScan));
        }
        public static void keyboardF(UInt16 bVk, UInt16 bScan)
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendKeyF(bVk, bScan));
            else
                Task.Run(() => SimulateKeyUp(bVk, bScan));
        }
        public static void keyboardArrows(UInt16 bVk, UInt16 bScan)
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendKeyArrows(bVk, bScan));
            else
                Task.Run(() => SimulateKeyDownArrows(bVk, bScan));
        }
        public static void keyboardArrowsF(UInt16 bVk, UInt16 bScan)
        {
            if (drivertype == "sendinput")
                Task.Run(() => SendKeyArrowsF(bVk, bScan));
            else
                Task.Run(() => SimulateKeyUpArrows(bVk, bScan));
        }
    }
}
