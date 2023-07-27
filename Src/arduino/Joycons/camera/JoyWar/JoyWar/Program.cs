using Microsoft.Win32.SafeHandles;
using System;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
namespace JoyWar
{
    static class Program
    {
        [DllImport("advapi32.dll")]
        private unsafe static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);
        [DllImport("kernel32.dll")]
        private unsafe static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
        [DllImport("LeftJoyconPairing.dll", EntryPoint = "lconnect")]
        private static extern bool lconnect();
        [DllImport("RightJoyconPairing.dll", EntryPoint = "rconnect")]
        private static extern bool rconnect();
        [DllImport("LeftJoyconPairing.dll", EntryPoint = "disconnectLeft")]
        private static extern bool disconnectLeft();
        [DllImport("RightJoyconPairing.dll", EntryPoint = "disconnectRight")]
        private static extern bool disconnectRight();
        [DllImport("hid.dll")]
        private static extern void HidD_GetHidGuid(out Guid gHid);
        [DllImport("hid.dll")]
        private extern static bool HidD_SetOutputReport(IntPtr HidDeviceObject, byte[] lpReportBuffer, uint ReportBufferLength);
        [DllImport("setupapi.dll")]
        private static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, string Enumerator, IntPtr hwndParent, UInt32 Flags);
        [DllImport("setupapi.dll")]
        private static extern Boolean SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInvo, ref Guid interfaceClassGuid, Int32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);
        [DllImport("setupapi.dll")]
        private static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, IntPtr deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
        [DllImport("setupapi.dll")]
        private static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, ref SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
        [DllImport("Kernel32.dll")]
        private static extern IntPtr CreateFile(string fileName, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare, IntPtr securityAttributes, System.IO.FileMode creationDisposition, EFileAttributes flags, IntPtr template);
        [DllImport("lhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Lhid_read_timeout")]
        private static extern int Lhid_read_timeout(SafeFileHandle dev, byte[] data, UIntPtr length);
        [DllImport("lhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Lhid_write")]
        private static extern int Lhid_write(SafeFileHandle device, byte[] data, UIntPtr length);
        [DllImport("lhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Lhid_open_path")]
        private static extern SafeFileHandle Lhid_open_path(IntPtr handle);
        [DllImport("rhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Rhid_read_timeout")]
        private static extern int Rhid_read_timeout(SafeFileHandle dev, byte[] data, UIntPtr length);
        [DllImport("rhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Rhid_write")]
        private static extern int Rhid_write(SafeFileHandle device, byte[] data, UIntPtr length);
        [DllImport("rhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Rhid_open_path")]
        private static extern SafeFileHandle Rhid_open_path(IntPtr handle);
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        private static extern uint TimeBeginPeriod(uint ms);
        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod")]
        private static extern uint TimeEndPeriod(uint ms);
        [DllImport("ntdll.dll", EntryPoint = "NtSetTimerResolution")]
        private static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow([In] IntPtr hWnd, [In] Int32 nCmdShow);
        private const Int32 SW_MINIMIZE = 6;
        [DllImport("mouse.dll", EntryPoint = "MoveMouseTo", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void MoveMouseTo(int x, int y);
        [DllImport("mouse.dll", EntryPoint = "MoveMouseBy", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void MoveMouseBy(int x, int y);
        [DllImport("keyboard.dll", EntryPoint = "SendKey", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendKey(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendKeyF", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendKeyF(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendKeyArrows", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendKeyArrows(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendKeyArrowsF", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendKeyArrowsF(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonLeft", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendMouseEventButtonLeft();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonLeftF", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendMouseEventButtonLeftF();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonRight", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendMouseEventButtonRight();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonRightF", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendMouseEventButtonRightF();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonMiddle", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendMouseEventButtonMiddle();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonMiddleF", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendMouseEventButtonMiddleF();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonWheelUp", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendMouseEventButtonWheelUp();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonWheelDown", CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern void SendMouseEventButtonWheelDown();
        [DllImport("user32.dll")]
        private unsafe static extern void SetPhysicalCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        private unsafe static extern void SetCaretPos(int X, int Y);
        [DllImport("user32.dll")]
        private unsafe static extern void SetCursorPos(int X, int Y);
        private const ushort VK_LBUTTON = (ushort)0x01;
        private const ushort VK_RBUTTON = (ushort)0x02;
        private const ushort VK_CANCEL = (ushort)0x03;
        private const ushort VK_MBUTTON = (ushort)0x04;
        private const ushort VK_XBUTTON1 = (ushort)0x05;
        private const ushort VK_XBUTTON2 = (ushort)0x06;
        private const ushort VK_BACK = (ushort)0x08;
        private const ushort VK_Tab = (ushort)0x09;
        private const ushort VK_CLEAR = (ushort)0x0C;
        private const ushort VK_Return = (ushort)0x0D;
        private const ushort VK_SHIFT = (ushort)0x10;
        private const ushort VK_CONTROL = (ushort)0x11;
        private const ushort VK_MENU = (ushort)0x12;
        private const ushort VK_PAUSE = (ushort)0x13;
        private const ushort VK_CAPITAL = (ushort)0x14;
        private const ushort VK_KANA = (ushort)0x15;
        private const ushort VK_HANGEUL = (ushort)0x15;
        private const ushort VK_HANGUL = (ushort)0x15;
        private const ushort VK_JUNJA = (ushort)0x17;
        private const ushort VK_FINAL = (ushort)0x18;
        private const ushort VK_HANJA = (ushort)0x19;
        private const ushort VK_KANJI = (ushort)0x19;
        private const ushort VK_Escape = (ushort)0x1B;
        private const ushort VK_CONVERT = (ushort)0x1C;
        private const ushort VK_NONCONVERT = (ushort)0x1D;
        private const ushort VK_ACCEPT = (ushort)0x1E;
        private const ushort VK_MODECHANGE = (ushort)0x1F;
        private const ushort VK_Space = (ushort)0x20;
        private const ushort VK_PRIOR = (ushort)0x21;
        private const ushort VK_NEXT = (ushort)0x22;
        private const ushort VK_END = (ushort)0x23;
        private const ushort VK_HOME = (ushort)0x24;
        private const ushort VK_LEFT = (ushort)0x25;
        private const ushort VK_UP = (ushort)0x26;
        private const ushort VK_RIGHT = (ushort)0x27;
        private const ushort VK_DOWN = (ushort)0x28;
        private const ushort VK_SELECT = (ushort)0x29;
        private const ushort VK_PRINT = (ushort)0x2A;
        private const ushort VK_EXECUTE = (ushort)0x2B;
        private const ushort VK_SNAPSHOT = (ushort)0x2C;
        private const ushort VK_INSERT = (ushort)0x2D;
        private const ushort VK_DELETE = (ushort)0x2E;
        private const ushort VK_HELP = (ushort)0x2F;
        private const ushort VK_APOSTROPHE = (ushort)0xDE;
        private const ushort VK_0 = (ushort)0x30;
        private const ushort VK_1 = (ushort)0x31;
        private const ushort VK_2 = (ushort)0x32;
        private const ushort VK_3 = (ushort)0x33;
        private const ushort VK_4 = (ushort)0x34;
        private const ushort VK_5 = (ushort)0x35;
        private const ushort VK_6 = (ushort)0x36;
        private const ushort VK_7 = (ushort)0x37;
        private const ushort VK_8 = (ushort)0x38;
        private const ushort VK_9 = (ushort)0x39;
        private const ushort VK_A = (ushort)0x41;
        private const ushort VK_B = (ushort)0x42;
        private const ushort VK_C = (ushort)0x43;
        private const ushort VK_D = (ushort)0x44;
        private const ushort VK_E = (ushort)0x45;
        private const ushort VK_F = (ushort)0x46;
        private const ushort VK_G = (ushort)0x47;
        private const ushort VK_H = (ushort)0x48;
        private const ushort VK_I = (ushort)0x49;
        private const ushort VK_J = (ushort)0x4A;
        private const ushort VK_K = (ushort)0x4B;
        private const ushort VK_L = (ushort)0x4C;
        private const ushort VK_M = (ushort)0x4D;
        private const ushort VK_N = (ushort)0x4E;
        private const ushort VK_O = (ushort)0x4F;
        private const ushort VK_P = (ushort)0x50;
        private const ushort VK_Q = (ushort)0x51;
        private const ushort VK_R = (ushort)0x52;
        private const ushort VK_S = (ushort)0x53;
        private const ushort VK_T = (ushort)0x54;
        private const ushort VK_U = (ushort)0x55;
        private const ushort VK_V = (ushort)0x56;
        private const ushort VK_W = (ushort)0x57;
        private const ushort VK_X = (ushort)0x58;
        private const ushort VK_Y = (ushort)0x59;
        private const ushort VK_Z = (ushort)0x5A;
        private const ushort VK_LWIN = (ushort)0x5B;
        private const ushort VK_RWIN = (ushort)0x5C;
        private const ushort VK_APPS = (ushort)0x5D;
        private const ushort VK_SLEEP = (ushort)0x5F;
        private const ushort VK_NUMPAD0 = (ushort)0x60;
        private const ushort VK_NUMPAD1 = (ushort)0x61;
        private const ushort VK_NUMPAD2 = (ushort)0x62;
        private const ushort VK_NUMPAD3 = (ushort)0x63;
        private const ushort VK_NUMPAD4 = (ushort)0x64;
        private const ushort VK_NUMPAD5 = (ushort)0x65;
        private const ushort VK_NUMPAD6 = (ushort)0x66;
        private const ushort VK_NUMPAD7 = (ushort)0x67;
        private const ushort VK_NUMPAD8 = (ushort)0x68;
        private const ushort VK_NUMPAD9 = (ushort)0x69;
        private const ushort VK_MULTIPLY = (ushort)0x6A;
        private const ushort VK_ADD = (ushort)0x6B;
        private const ushort VK_SEPARATOR = (ushort)0x6C;
        private const ushort VK_SUBTRACT = (ushort)0x6D;
        private const ushort VK_DECIMAL = (ushort)0x6E;
        private const ushort VK_DIVIDE = (ushort)0x6F;
        private const ushort VK_F1 = (ushort)0x70;
        private const ushort VK_F2 = (ushort)0x71;
        private const ushort VK_F3 = (ushort)0x72;
        private const ushort VK_F4 = (ushort)0x73;
        private const ushort VK_F5 = (ushort)0x74;
        private const ushort VK_F6 = (ushort)0x75;
        private const ushort VK_F7 = (ushort)0x76;
        private const ushort VK_F8 = (ushort)0x77;
        private const ushort VK_F9 = (ushort)0x78;
        private const ushort VK_F10 = (ushort)0x79;
        private const ushort VK_F11 = (ushort)0x7A;
        private const ushort VK_F12 = (ushort)0x7B;
        private const ushort VK_F13 = (ushort)0x7C;
        private const ushort VK_F14 = (ushort)0x7D;
        private const ushort VK_F15 = (ushort)0x7E;
        private const ushort VK_F16 = (ushort)0x7F;
        private const ushort VK_F17 = (ushort)0x80;
        private const ushort VK_F18 = (ushort)0x81;
        private const ushort VK_F19 = (ushort)0x82;
        private const ushort VK_F20 = (ushort)0x83;
        private const ushort VK_F21 = (ushort)0x84;
        private const ushort VK_F22 = (ushort)0x85;
        private const ushort VK_F23 = (ushort)0x86;
        private const ushort VK_F24 = (ushort)0x87;
        private const ushort VK_NUMLOCK = (ushort)0x90;
        private const ushort VK_SCROLL = (ushort)0x91;
        private const ushort VK_LeftShift = (ushort)0xA0;
        private const ushort VK_RightShift = (ushort)0xA1;
        private const ushort VK_LeftControl = (ushort)0xA2;
        private const ushort VK_RightControl = (ushort)0xA3;
        private const ushort VK_LMENU = (ushort)0xA4;
        private const ushort VK_RMENU = (ushort)0xA5;
        private const ushort VK_BROWSER_BACK = (ushort)0xA6;
        private const ushort VK_BROWSER_FORWARD = (ushort)0xA7;
        private const ushort VK_BROWSER_REFRESH = (ushort)0xA8;
        private const ushort VK_BROWSER_STOP = (ushort)0xA9;
        private const ushort VK_BROWSER_SEARCH = (ushort)0xAA;
        private const ushort VK_BROWSER_FAVORITES = (ushort)0xAB;
        private const ushort VK_BROWSER_HOME = (ushort)0xAC;
        private const ushort VK_VOLUME_MUTE = (ushort)0xAD;
        private const ushort VK_VOLUME_DOWN = (ushort)0xAE;
        private const ushort VK_VOLUME_UP = (ushort)0xAF;
        private const ushort VK_MEDIA_NEXT_TRACK = (ushort)0xB0;
        private const ushort VK_MEDIA_PREV_TRACK = (ushort)0xB1;
        private const ushort VK_MEDIA_STOP = (ushort)0xB2;
        private const ushort VK_MEDIA_PLAY_PAUSE = (ushort)0xB3;
        private const ushort VK_LAUNCH_MAIL = (ushort)0xB4;
        private const ushort VK_LAUNCH_MEDIA_SELECT = (ushort)0xB5;
        private const ushort VK_LAUNCH_APP1 = (ushort)0xB6;
        private const ushort VK_LAUNCH_APP2 = (ushort)0xB7;
        private const ushort VK_OEM_1 = (ushort)0xBA;
        private const ushort VK_OEM_PLUS = (ushort)0xBB;
        private const ushort VK_OEM_COMMA = (ushort)0xBC;
        private const ushort VK_OEM_MINUS = (ushort)0xBD;
        private const ushort VK_OEM_PERIOD = (ushort)0xBE;
        private const ushort VK_OEM_2 = (ushort)0xBF;
        private const ushort VK_OEM_3 = (ushort)0xC0;
        private const ushort VK_OEM_4 = (ushort)0xDB;
        private const ushort VK_OEM_5 = (ushort)0xDC;
        private const ushort VK_OEM_6 = (ushort)0xDD;
        private const ushort VK_OEM_7 = (ushort)0xDE;
        private const ushort VK_OEM_8 = (ushort)0xDF;
        private const ushort VK_OEM_102 = (ushort)0xE2;
        private const ushort VK_PROCESSKEY = (ushort)0xE5;
        private const ushort VK_PACKET = (ushort)0xE7;
        private const ushort VK_ATTN = (ushort)0xF6;
        private const ushort VK_CRSEL = (ushort)0xF7;
        private const ushort VK_EXSEL = (ushort)0xF8;
        private const ushort VK_EREOF = (ushort)0xF9;
        private const ushort VK_PLAY = (ushort)0xFA;
        private const ushort VK_ZOOM = (ushort)0xFB;
        private const ushort VK_NONAME = (ushort)0xFC;
        private const ushort VK_PA1 = (ushort)0xFD;
        private const ushort VK_OEM_CLEAR = (ushort)0xFE;
        private const ushort S_LBUTTON = (ushort)0x0;
        private const ushort S_RBUTTON = 0;
        private const ushort S_CANCEL = 70;
        private const ushort S_MBUTTON = 0;
        private const ushort S_XBUTTON1 = 0;
        private const ushort S_XBUTTON2 = 0;
        private const ushort S_BACK = 14;
        private const ushort S_Tab = 15;
        private const ushort S_CLEAR = 76;
        private const ushort S_Return = 28;
        private const ushort S_SHIFT = 42;
        private const ushort S_CONTROL = 29;
        private const ushort S_MENU = 56;
        private const ushort S_PAUSE = 0;
        private const ushort S_CAPITAL = 58;
        private const ushort S_KANA = 0;
        private const ushort S_HANGEUL = 0;
        private const ushort S_HANGUL = 0;
        private const ushort S_JUNJA = 0;
        private const ushort S_FINAL = 0;
        private const ushort S_HANJA = 0;
        private const ushort S_KANJI = 0;
        private const ushort S_Escape = 1;
        private const ushort S_CONVERT = 0;
        private const ushort S_NONCONVERT = 0;
        private const ushort S_ACCEPT = 0;
        private const ushort S_MODECHANGE = 0;
        private const ushort S_Space = 57;
        private const ushort S_PRIOR = 73;
        private const ushort S_NEXT = 81;
        private const ushort S_END = 79;
        private const ushort S_HOME = 71;
        private const ushort S_LEFT = 75;
        private const ushort S_UP = 72;
        private const ushort S_RIGHT = 77;
        private const ushort S_DOWN = 80;
        private const ushort S_SELECT = 0;
        private const ushort S_PRINT = 0;
        private const ushort S_EXECUTE = 0;
        private const ushort S_SNAPSHOT = 84;
        private const ushort S_INSERT = 82;
        private const ushort S_DELETE = 83;
        private const ushort S_HELP = 99;
        private const ushort S_APOSTROPHE = 41;
        private const ushort S_0 = 11;
        private const ushort S_1 = 2;
        private const ushort S_2 = 3;
        private const ushort S_3 = 4;
        private const ushort S_4 = 5;
        private const ushort S_5 = 6;
        private const ushort S_6 = 7;
        private const ushort S_7 = 8;
        private const ushort S_8 = 9;
        private const ushort S_9 = 10;
        private const ushort S_A = 16;
        private const ushort S_B = 48;
        private const ushort S_C = 46;
        private const ushort S_D = 32;
        private const ushort S_E = 18;
        private const ushort S_F = 33;
        private const ushort S_G = 34;
        private const ushort S_H = 35;
        private const ushort S_I = 23;
        private const ushort S_J = 36;
        private const ushort S_K = 37;
        private const ushort S_L = 38;
        private const ushort S_M = 39;
        private const ushort S_N = 49;
        private const ushort S_O = 24;
        private const ushort S_P = 25;
        private const ushort S_Q = 30;
        private const ushort S_R = 19;
        private const ushort S_S = 31;
        private const ushort S_T = 20;
        private const ushort S_U = 22;
        private const ushort S_V = 47;
        private const ushort S_W = 44;
        private const ushort S_X = 45;
        private const ushort S_Y = 21;
        private const ushort S_Z = 17;
        private const ushort S_LWIN = 91;
        private const ushort S_RWIN = 92;
        private const ushort S_APPS = 93;
        private const ushort S_SLEEP = 95;
        private const ushort S_NUMPAD0 = 82;
        private const ushort S_NUMPAD1 = 79;
        private const ushort S_NUMPAD2 = 80;
        private const ushort S_NUMPAD3 = 81;
        private const ushort S_NUMPAD4 = 75;
        private const ushort S_NUMPAD5 = 76;
        private const ushort S_NUMPAD6 = 77;
        private const ushort S_NUMPAD7 = 71;
        private const ushort S_NUMPAD8 = 72;
        private const ushort S_NUMPAD9 = 73;
        private const ushort S_MULTIPLY = 55;
        private const ushort S_ADD = 78;
        private const ushort S_SEPARATOR = 0;
        private const ushort S_SUBTRACT = 74;
        private const ushort S_DECIMAL = 83;
        private const ushort S_DIVIDE = 53;
        private const ushort S_F1 = 59;
        private const ushort S_F2 = 60;
        private const ushort S_F3 = 61;
        private const ushort S_F4 = 62;
        private const ushort S_F5 = 63;
        private const ushort S_F6 = 64;
        private const ushort S_F7 = 65;
        private const ushort S_F8 = 66;
        private const ushort S_F9 = 67;
        private const ushort S_F10 = 68;
        private const ushort S_F11 = 87;
        private const ushort S_F12 = 88;
        private const ushort S_F13 = 100;
        private const ushort S_F14 = 101;
        private const ushort S_F15 = 102;
        private const ushort S_F16 = 103;
        private const ushort S_F17 = 104;
        private const ushort S_F18 = 105;
        private const ushort S_F19 = 106;
        private const ushort S_F20 = 107;
        private const ushort S_F21 = 108;
        private const ushort S_F22 = 109;
        private const ushort S_F23 = 110;
        private const ushort S_F24 = 118;
        private const ushort S_NUMLOCK = 69;
        private const ushort S_SCROLL = 70;
        private const ushort S_LeftShift = 42;
        private const ushort S_RightShift = 54;
        private const ushort S_LeftControl = 29;
        private const ushort S_RightControl = 29;
        private const ushort S_LMENU = 56;
        private const ushort S_RMENU = 56;
        private const ushort S_BROWSER_BACK = 106;
        private const ushort S_BROWSER_FORWARD = 105;
        private const ushort S_BROWSER_REFRESH = 103;
        private const ushort S_BROWSER_STOP = 104;
        private const ushort S_BROWSER_SEARCH = 101;
        private const ushort S_BROWSER_FAVORITES = 102;
        private const ushort S_BROWSER_HOME = 50;
        private const ushort S_VOLUME_MUTE = 32;
        private const ushort S_VOLUME_DOWN = 46;
        private const ushort S_VOLUME_UP = 48;
        private const ushort S_MEDIA_NEXT_TRACK = 25;
        private const ushort S_MEDIA_PREV_TRACK = 16;
        private const ushort S_MEDIA_STOP = 36;
        private const ushort S_MEDIA_PLAY_PAUSE = 34;
        private const ushort S_LAUNCH_MAIL = 108;
        private const ushort S_LAUNCH_MEDIA_SELECT = 109;
        private const ushort S_LAUNCH_APP1 = 107;
        private const ushort S_LAUNCH_APP2 = 33;
        private const ushort S_OEM_1 = 27;
        private const ushort S_OEM_PLUS = 13;
        private const ushort S_OEM_COMMA = 50;
        private const ushort S_OEM_MINUS = 0;
        private const ushort S_OEM_PERIOD = 51;
        private const ushort S_OEM_2 = 52;
        private const ushort S_OEM_3 = 40;
        private const ushort S_OEM_4 = 12;
        private const ushort S_OEM_5 = 43;
        private const ushort S_OEM_6 = 26;
        private const ushort S_OEM_7 = 41;
        private const ushort S_OEM_8 = 53;
        private const ushort S_OEM_102 = 86;
        private const ushort S_PROCESSKEY = 0;
        private const ushort S_PACKET = 0;
        private const ushort S_ATTN = 0;
        private const ushort S_CRSEL = 0;
        private const ushort S_EXSEL = 0;
        private const ushort S_EREOF = 93;
        private const ushort S_PLAY = 0;
        private const ushort S_ZOOM = 98;
        private const ushort S_NONAME = 0;
        private const ushort S_PA1 = 0;
        private const ushort S_OEM_CLEAR = 0;
        private static double mousex, mousey, irx, iry, Width, Height, WidthS, HeightS, incx, incy, inc, x, y, mWSButtonStateIRX, mWSButtonStateIRY, center = 160f;
        private static bool Getstate, ISLEFT, ISRIGHT;
        private static string xy;
        private static SerialPort arduinoSerial = new SerialPort();
        private static UInt32 result;
        private static uint CurrentResolution = 0;
        static ConsoleEventDelegate handler;
        private delegate bool ConsoleEventDelegate(int eventType);
        private static ThreadStart threadstart;
        private static Thread thread;
        private static int[] wd = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        private static int[] wu = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        static void valchanged(int n, bool val)
        {
            if (val)
            {
                if (wd[n] <= 1)
                {
                    wd[n] = wd[n] + 1;
                }
                wu[n] = 0;
            }
            else
            {
                if (wu[n] <= 1)
                {
                    wu[n] = wu[n] + 1;
                }
                wd[n] = 0;
            }
        }
        static void Main(string[] args)
        {
            TimeBeginPeriod(1);
            NtSetTimerResolution(1, true, ref CurrentResolution);
            MinimizeConsoleWindow();
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);
            String firstMacAddress = System.Net.NetworkInformation.NetworkInterface
            .GetAllNetworkInterfaces()
            .Where(nic => nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up && nic.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Loopback)
            .Select(nic => nic.GetPhysicalAddress().ToString())
            .FirstOrDefault();
            if (firstMacAddress == "1C95D1164E45")
            {
                IntPtr tokenHandle = new IntPtr(0);
                string UserName = null;
                string MachineName = null;
                string Pwd = null;
                MachineName = System.Environment.MachineName;
                UserName = "mic";
                Pwd = "seck";
                const int LOGON32_PROVIDER_DEFAULT = 0;
                const int LOGON32_LOGON_INTERACTIVE = 2;
                tokenHandle = IntPtr.Zero;
                bool returnValue = LogonUser(UserName, MachineName, Pwd, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out tokenHandle);
                if (returnValue)
                {
                    string[] ports = SerialPort.GetPortNames();
                    foreach (var port in ports)
                    {
                        try
                        {
                            arduinoSerial.PortName = port;
                            arduinoSerial.BaudRate = 9600;
                            arduinoSerial.DtrEnable = true;
                            arduinoSerial.Open();
                            arduinoSerial.DataReceived += arduinoSerial_DataReceived;
                            Task.Run(() => Start());
                            Console.ReadLine();
                        }
                        catch { }
                    }
                }
            }
        }
        private static void Start()
        {
            do
                Thread.Sleep(1);
            while (!lconnect());
            do
                Thread.Sleep(1);
            while (!rconnect());
            do
                Thread.Sleep(1);
            while (!ScanLeft());
            do
                Thread.Sleep(1);
            while (!ScanRight());
            Task.Run(() => taskDLeft());
            Task.Run(() => taskDRight());
            Thread.Sleep(6000);
            stick_rawLeft[0] = report_bufLeft[6 + (ISLEFT ? 0 : 3)];
            stick_rawLeft[1] = report_bufLeft[7 + (ISLEFT ? 0 : 3)];
            stick_rawLeft[2] = report_bufLeft[8 + (ISLEFT ? 0 : 3)];
            stick_calibrationLeft[0] = (UInt16)(stick_rawLeft[0] | ((stick_rawLeft[1] & 0xf) << 8));
            stick_calibrationLeft[1] = (UInt16)((stick_rawLeft[1] >> 4) | (stick_rawLeft[2] << 4));
            stick_rawRight[0] = report_bufRight[6 + (!ISRIGHT ? 0 : 3)];
            stick_rawRight[1] = report_bufRight[7 + (!ISRIGHT ? 0 : 3)];
            stick_rawRight[2] = report_bufRight[8 + (!ISRIGHT ? 0 : 3)];
            stick_calibrationRight[0] = (UInt16)(stick_rawRight[0] | ((stick_rawRight[1] & 0xf) << 8));
            stick_calibrationRight[1] = (UInt16)((stick_rawRight[1] >> 4) | (stick_rawRight[2] << 4));
            acc_gcalibrationLeftX = (float)averageLeft((Int16)(report_bufLeft[13 + 0 * 12] | ((report_bufLeft[14 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[13 + 1 * 12] | ((report_bufLeft[14 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[13 + 2 * 12] | ((report_bufLeft[14 + 2 * 12] << 8) & 0xff00)));
            acc_gcalibrationLeftY = (float)averageLeft((Int16)(report_bufLeft[15 + 0 * 12] | ((report_bufLeft[16 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[15 + 1 * 12] | ((report_bufLeft[16 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[15 + 2 * 12] | ((report_bufLeft[16 + 2 * 12] << 8) & 0xff00)));
            acc_gcalibrationLeftZ = (float)averageLeft((Int16)(report_bufLeft[17 + 0 * 12] | ((report_bufLeft[18 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[17 + 1 * 12] | ((report_bufLeft[18 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[17 + 2 * 12] | ((report_bufLeft[18 + 2 * 12] << 8) & 0xff00)));
            gyr_gcalibrationLeftX = (float)averageLeft((Int16)(report_bufLeft[19 + 0 * 12] | ((report_bufLeft[20 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[19 + 1 * 12] | ((report_bufLeft[20 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[19 + 2 * 12] | ((report_bufLeft[20 + 2 * 12] << 8) & 0xff00)));
            gyr_gcalibrationLeftY = (float)averageLeft((Int16)(report_bufLeft[21 + 0 * 12] | ((report_bufLeft[22 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[21 + 1 * 12] | ((report_bufLeft[22 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[21 + 2 * 12] | ((report_bufLeft[22 + 2 * 12] << 8) & 0xff00)));
            gyr_gcalibrationLeftZ = (float)averageLeft((Int16)(report_bufLeft[23 + 0 * 12] | ((report_bufLeft[24 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[23 + 1 * 12] | ((report_bufLeft[24 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[23 + 2 * 12] | ((report_bufLeft[24 + 2 * 12] << 8) & 0xff00)));
            acc_gcalibrationRightX = (float)averageRight((Int16)(report_bufRight[13 + 0 * 12] | ((report_bufRight[14 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[13 + 1 * 12] | ((report_bufRight[14 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[13 + 2 * 12] | ((report_bufRight[14 + 2 * 12] << 8) & 0xff00)));
            acc_gcalibrationRightY = (float)averageRight((Int16)(report_bufRight[15 + 0 * 12] | ((report_bufRight[16 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[15 + 1 * 12] | ((report_bufRight[16 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[15 + 2 * 12] | ((report_bufRight[16 + 2 * 12] << 8) & 0xff00)));
            acc_gcalibrationRightZ = (float)averageRight((Int16)(report_bufRight[17 + 0 * 12] | ((report_bufRight[18 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[17 + 1 * 12] | ((report_bufRight[18 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[17 + 2 * 12] | ((report_bufRight[18 + 2 * 12] << 8) & 0xff00)));
            gyr_gcalibrationRightX = (float)averageRight((Int16)(report_bufRight[19 + 0 * 12] | ((report_bufRight[20 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[19 + 1 * 12] | ((report_bufRight[20 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[19 + 2 * 12] | ((report_bufRight[20 + 2 * 12] << 8) & 0xff00)));
            gyr_gcalibrationRightY = (float)averageRight((Int16)(report_bufRight[21 + 0 * 12] | ((report_bufRight[22 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[21 + 1 * 12] | ((report_bufRight[22 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[21 + 2 * 12] | ((report_bufRight[22 + 2 * 12] << 8) & 0xff00)));
            gyr_gcalibrationRightZ = (float)averageRight((Int16)(report_bufRight[23 + 0 * 12] | ((report_bufRight[24 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[23 + 1 * 12] | ((report_bufRight[24 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[23 + 2 * 12] | ((report_bufRight[24 + 2 * 12] << 8) & 0xff00)));
            Task.Run(() => taskILeft());
            Task.Run(() => taskIRight());
            Task.Run(() => taskK());
            Task.Run(() => taskM());
            System.Media.SystemSounds.Beep.Play();
            Console.WriteLine("connected");
        }
        private unsafe static double Scale(double value, double min, double max, double minScale, double maxScale)
        {
            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
            return scaled;
        }
        private static void taskM()
        {
            for (; ; )
            {
                if (Getstate)
                {
                    mWSButtonStateIRX = x - 2360f;
                    mWSButtonStateIRY = (y - 1360f) * 2f;
                    irx = mWSButtonStateIRX;
                    iry = mWSButtonStateIRY + center >= 0 ? Scale(mWSButtonStateIRY + center, 0f, 1360f + center, 0f, 768f) : Scale(mWSButtonStateIRY + center, -1360f + center, 0f, -768f, 0f);
                    if (irx >= 1360f)
                        irx = 1360f;
                    if (irx <= -1360f)
                        irx = -1360f;
                    if (iry >= 768f)
                        iry = 768f;
                    if (iry <= -768f)
                        iry = -768f;
                    mousex = (irx >= 0f ? 1f : -1f) * (Math.Pow(irx >= 0 ? irx : -irx, 4.5f) / Math.Pow(1360f, 3.5f) * (1f - 1360f / (127f * 660f)) + Math.Pow(irx >= 0 ? irx : -irx, 0.5f) * Math.Pow(1360f, 0.5f) * 1360f / (127f * 660f));
                    mousey = (iry >= 0f ? 1f : -1f) * (Math.Pow(iry >= 0 ? iry : -iry, 4.5f) / Math.Pow(768f, 3.5f) * (1f - 768f / (127f * 360f)) + Math.Pow(iry >= 0 ? iry : -iry, 0.5f) * Math.Pow(768f, 0.5f) * 768f / (127f * 360f));
                    if (irx == 1360f | irx == -1360f | iry == 768f | iry == -768f)
                    {
                        inc += 1f;
                        if (inc >= 20f)
                            inc = 0f;
                        if (inc >= 0f & inc < 10f)
                        {
                            incx += 1f;
                            incy += 1f;
                        }
                        if (inc >= 10f & inc < 20f)
                        {
                            incx -= 1f;
                            incy -= 1f;
                        }
                    }
                    else
                    {
                        inc = 0f;
                        incx = 0f;
                        incy = 0f;
                    }
                    MoveMouseTo((int)(32767.5 - mousex * (32767.5 - incx * 32767.5 / 680f) / 1360f), (int)(32767.5 + mousey * (32767.5 - incy * 32767.5 / 384f) / 768f));
                }
                Thread.Sleep(1);
            }
        }
        private static void arduinoSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var bufferSize = arduinoSerial.BytesToRead;
            if (bufferSize >= 4)
            {
                byte[] data = new byte[4];
                arduinoSerial.Read(data, 0, 4);
                result = BitConverter.ToUInt32(data, 0);
                xy = result.ToString();
                x = Convert.ToDouble(xy.Substring(0, 4));
                y = Convert.ToDouble(xy.Substring(6, 4));
            }
        }
        private static void taskK()
        {
            for (; ; )
            {
                try
                {
                    ProcessButtonsAndStickLeft();
                }
                catch { }
                try
                {
                    ProcessButtonsAndStickRight();
                }
                catch { }
                valchanged(0, LeftButtonCAPTURE & RightButtonHOME);
                if (wd[0] == 1 & !Getstate)
                {
                    Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                    Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                    WidthS = Width / 2f;
                    HeightS = Height / 2f;
                    Getstate = true;
                }
                else
                {
                    if (wd[0] == 1 & Getstate)
                    {
                        Getstate = false;
                        for (int i = 1; i <= 38; i++)
                        {
                            wd[i] = 2;
                            wu[i] = 2;
                            Thread.Sleep(1);
                        }
                        SendKeyF(VK_A, S_A);
                        SendKeyF(VK_E, S_E);
                        SendKeyF(VK_V, S_V);
                        SendKeyF(VK_F, S_F);
                        SendKeyF(VK_Escape, S_Escape);
                    }
                }
                if (Getstate)
                {
                    valchanged(5, LeftButtonDPAD_UP);
                    if (wd[5] == 1)
                        SendKey(VK_7, S_7);
                    if (wu[5] == 1)
                        SendKeyF(VK_7, S_7);
                    valchanged(6, LeftButtonDPAD_LEFT);
                    if (wd[6] == 1)
                        SendKey(VK_8, S_8);
                    if (wu[6] == 1)
                        SendKeyF(VK_8, S_8);
                    valchanged(7, LeftButtonDPAD_DOWN);
                    if (wd[7] == 1)
                        SendKey(VK_9, S_9);
                    if (wu[7] == 1)
                        SendKeyF(VK_9, S_9);
                    valchanged(8, LeftButtonDPAD_RIGHT);
                    if (wd[8] == 1)
                        SendKey(VK_0, S_0);
                    if (wu[8] == 1)
                        SendKeyF(VK_0, S_0);
                    valchanged(3, LeftButtonMINUS);
                    if (wd[3] == 1)
                        SendKey(VK_T, S_T);
                    if (wu[3] == 1)
                        SendKeyF(VK_T, S_T);
                    valchanged(27, LeftButtonCAPTURE);
                    if (wd[27] == 1)
                        SendKey(VK_Escape, S_Escape);
                    if (wu[27] == 1)
                        SendKeyF(VK_Escape, S_Escape);
                    valchanged(9, LeftButtonSTICK);
                    if (wd[9] == 1)
                        SendKey(VK_LeftShift, S_LeftShift);
                    if (wu[9] == 1)
                        SendKeyF(VK_LeftShift, S_LeftShift);
                    valchanged(29, LeftButtonSL);
                    if (wd[29] == 1)
                        SendKey(VK_A, S_A);
                    if (wu[29] == 1)
                        SendKeyF(VK_A, S_A);
                    valchanged(28, LeftButtonSR);
                    if (wd[28] == 1)
                        SendKey(VK_LMENU, S_LMENU);
                    if (wu[28] == 1)
                        SendKeyF(VK_LMENU, S_LMENU);
                    valchanged(2, LeftButtonSHOULDER_1);
                    if (wd[2] == 1)
                        SendKey(VK_Space, S_Space);
                    if (wu[2] == 1)
                        SendKeyF(VK_Space, S_Space);
                    valchanged(24, LeftButtonSHOULDER_2);
                    if (wd[24] == 1)
                        SendKey(VK_1, S_1);
                    if (wu[24] == 1)
                        SendKeyF(VK_1, S_1);
                    valchanged(16, GetStickLeft()[0] > 0.25f);
                    valchanged(17, GetStickLeft()[0] < -0.25f);
                    valchanged(18, GetStickLeft()[1] > 0.25f);
                    valchanged(19, GetStickLeft()[1] < -0.25f);
                    if (wd[16] == 1)
                        SendKey(VK_D, S_D);
                    if (wu[16] == 1)
                        SendKeyF(VK_D, S_D);
                    if (wd[17] == 1)
                        SendKey(VK_Q, S_Q);
                    if (wu[17] == 1)
                        SendKeyF(VK_Q, S_Q);
                    if (wd[18] == 1)
                        SendKey(VK_Z, S_Z);
                    if (wu[18] == 1)
                        SendKeyF(VK_Z, S_Z);
                    if (wd[19] == 1)
                        SendKey(VK_S, S_S);
                    if (wu[19] == 1)
                        SendKeyF(VK_S, S_S);
                    valchanged(10, RightButtonDPAD_DOWN);
                    if (wd[10] == 1)
                        SendKey(VK_C, S_C);
                    if (wu[10] == 1)
                        SendKeyF(VK_C, S_C);
                    valchanged(21, RightButtonDPAD_RIGHT);
                    if (wd[21] == 1)
                        SendKey(VK_2, S_2);
                    if (wu[21] == 1)
                        SendKeyF(VK_2, S_2);
                    valchanged(33, RightButtonDPAD_LEFT);
                    if (wd[33] == 1)
                        SendMouseEventButtonRight();
                    if (wu[33] == 1)
                        SendMouseEventButtonRightF();
                    valchanged(25, RightButtonDPAD_UP);
                    if (wd[25] == 1)
                        SendKey(VK_X, S_X);
                    if (wu[25] == 1)
                        SendKeyF(VK_X, S_X);
                    valchanged(20, RightButtonPLUS);
                    if (wd[20] == 1)
                        SendKey(VK_G, S_G);
                    if (wu[20] == 1)
                        SendKeyF(VK_G, S_G);
                    valchanged(22, RightButtonHOME);
                    if (wd[22] == 1)
                        SendKey(VK_F, S_F);
                    if (wu[22] == 1)
                        SendKeyF(VK_F, S_F);
                    valchanged(26, RightButtonSTICK);
                    if (wd[26] == 1)
                        SendKey(VK_V, S_V);
                    if (wu[26] == 1)
                        SendKeyF(VK_V, S_V);
                    valchanged(14, RightButtonSL);
                    if (wd[14] == 1)
                        SendKey(VK_Tab, S_Tab);
                    if (wu[14] == 1)
                        SendKeyF(VK_Tab, S_Tab);
                    valchanged(15, RightButtonSR);
                    if (wd[15] == 1)
                        SendKey(VK_E, S_E);
                    if (wu[15] == 1)
                        SendKeyF(VK_E, S_E);
                    valchanged(23, RightButtonSHOULDER_1);
                    if (wd[23] == 1)
                        SendKey(VK_V, S_V);
                    if (wu[23] == 1)
                        SendKeyF(VK_V, S_V);
                    valchanged(11, RightButtonSHOULDER_2);
                    if (wd[11] == 1)
                        SendMouseEventButtonLeft();
                    if (wu[11] == 1)
                        SendMouseEventButtonLeftF();
                    valchanged(35, GetStickRight()[0] > 0.25f);
                    valchanged(36, GetStickRight()[0] < -0.25f);
                    valchanged(37, GetStickRight()[1] > 0.25f);
                    valchanged(38, GetStickRight()[1] < -0.25f);
                    if (wd[35] == 1)
                        SendKey(VK_5, S_5);
                    if (wu[35] == 1)
                        SendKeyF(VK_5, S_5);
                    if (wd[36] == 1)
                        SendKey(VK_6, S_6);
                    if (wu[36] == 1)
                        SendKeyF(VK_6, S_6);
                    if (wd[37] == 1)
                        SendKey(VK_3, S_3);
                    if (wu[37] == 1)
                        SendKeyF(VK_3, S_3);
                    if (wd[38] == 1)
                        SendKey(VK_4, S_4);
                    if (wu[38] == 1)
                        SendKeyF(VK_4, S_4);
                }
                Thread.Sleep(10);
            }
        }
        private static void taskILeft()
        {
            for (; ; )
            {
                try
                {
                    ExtractIMUValuesLeft();
                }
                catch { }
                Thread.Sleep(12);
            }
        }
        private static void taskIRight()
        {
            for (; ; )
            {
                try
                {
                    ExtractIMUValuesRight();
                }
                catch { }
                Thread.Sleep(12);
            }
        }
        private static void taskDLeft()
        {
            for (; ; )
            {
                try
                {
                    Lhid_read_timeout(handleLeft, report_bufLeft, (UIntPtr)49);
                }
                catch { }
            }
        }
        private static void taskDRight()
        {
            for (; ; )
            {
                try
                {
                    Rhid_read_timeout(handleRight, report_bufRight, (UIntPtr)49);
                }
                catch { }
            }
        }
        private unsafe static void MinimizeConsoleWindow()
        {
            IntPtr hWndConsole = GetConsoleWindow();
            ShowWindow(hWndConsole, SW_MINIMIZE);
        }
        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                TimeEndPeriod(1);
                arduinoSerial.DataReceived -= arduinoSerial_DataReceived;
                arduinoSerial.Close();
                threadstart = new ThreadStart(FormCloseLeft);
                thread = new Thread(threadstart);
                thread.Start();
                threadstart = new ThreadStart(FormCloseRight);
                thread = new Thread(threadstart);
                thread.Start();
                Thread.Sleep(10000);
            }
            return false;
        }
        private static void FormCloseLeft()
        {
            disconnectLeft();
        }
        private static void FormCloseRight()
        {
            disconnectRight();
        }
        private static Quaternion GetVectoraLeft()
        {
            Vector3 v1 = new Vector3(j_aLeft.X, i_aLeft.X, k_aLeft.X);
            Vector3 v2 = -(new Vector3(j_aLeft.Z, i_aLeft.Z, k_aLeft.Z));
            return QuaternionLookRotationLeft(v1, v2);
        }
        private static Quaternion GetVectorbLeft()
        {
            Vector3 v1 = new Vector3(j_bLeft.X, i_bLeft.X, k_bLeft.X);
            Vector3 v2 = -(new Vector3(j_bLeft.Z, i_bLeft.Z, k_bLeft.Z));
            return QuaternionLookRotationLeft(v1, v2);
        }
        private static Quaternion GetVectorcLeft()
        {
            Vector3 v1 = new Vector3(j_cLeft.X, i_cLeft.X, k_cLeft.X);
            Vector3 v2 = -(new Vector3(j_cLeft.Z, i_cLeft.Z, k_cLeft.Z));
            return QuaternionLookRotationLeft(v1, v2);
        }
        private static Quaternion QuaternionLookRotationLeft(Vector3 forward, Vector3 up)
        {
            Vector3 vector = Vector3.Normalize(forward);
            Vector3 vector2 = Vector3.Normalize(Vector3.Cross(up, vector));
            Vector3 vector3 = Vector3.Cross(vector, vector2);
            var m00 = vector2.X;
            var m01 = vector2.Y;
            var m02 = vector2.Z;
            var m10 = vector3.X;
            var m11 = vector3.Y;
            var m12 = vector3.Z;
            var m20 = vector.X;
            var m21 = vector.Y;
            var m22 = vector.Z;
            double num8 = (m00 + m11) + m22;
            var quaternion = new Quaternion();
            if (num8 > 0f)
            {
                var num = (double)Math.Sqrt(num8 + 1f);
                quaternion.W = (float)num * 0.5f;
                num = 0.5f / num;
                quaternion.X = (float)(m12 - m21) * (float)num;
                quaternion.Y = (float)(m20 - m02) * (float)num;
                quaternion.Z = (float)(m01 - m10) * (float)num;
                return quaternion;
            }
            if ((m00 >= m11) && (m00 >= m22))
            {
                var num7 = (double)Math.Sqrt(((1f + m00) - m11) - m22);
                var num4 = 0.5f / num7;
                quaternion.X = 0.5f * (float)num7;
                quaternion.Y = (float)(m01 + m10) * (float)num4;
                quaternion.Z = (float)(m02 + m20) * (float)num4;
                quaternion.W = (float)(m12 - m21) * (float)num4;
                return quaternion;
            }
            if (m11 > m22)
            {
                var num6 = (double)Math.Sqrt(((1f + m11) - m00) - m22);
                var num3 = 0.5f / num6;
                quaternion.X = (float)(m10 + m01) * (float)num3;
                quaternion.Y = 0.5f * (float)num6;
                quaternion.Z = (float)(m21 + m12) * (float)num3;
                quaternion.W = (float)(m20 - m02) * (float)num3;
                return quaternion;
            }
            var num5 = (double)Math.Sqrt(((1f + m22) - m00) - m11);
            var num2 = 0.5f / num5;
            quaternion.X = (float)(m20 + m02) * (float)num2;
            quaternion.Y = (float)(m21 + m12) * (float)num2;
            quaternion.Z = 0.5f * (float)num5;
            quaternion.W = (float)(m01 - m10) * (float)num2;
            return quaternion;
        }
        private static Vector3 ToEulerAnglesLeft(Quaternion q)
        {
            Vector3 pitchYawRoll = new Vector3();
            double sqw = q.W * q.W;
            double sqx = q.X * q.X;
            double sqy = q.Y * q.Y;
            double sqz = q.Z * q.Z;
            double unit = sqx + sqy + sqz + sqw;
            double test = q.X * q.Y + q.Z * q.W;
            if (test > 0.4999f * unit)
            {
                pitchYawRoll.Y = 2f * (float)Math.Atan2(q.X, q.W);
                pitchYawRoll.X = (float)Math.PI * 0.5f;
                pitchYawRoll.Z = 0f;
                return pitchYawRoll;
            }
            else if (test < -0.4999f * unit)
            {
                pitchYawRoll.Y = -2f * (float)Math.Atan2(q.X, q.W);
                pitchYawRoll.X = -(float)Math.PI * 0.5f;
                pitchYawRoll.Z = 0f;
                return pitchYawRoll;
            }
            else
            {
                pitchYawRoll.Y = (float)Math.Atan2(2f * q.Y * q.W - 2f * q.X * q.Z, sqx - sqy - sqz + sqw);
                pitchYawRoll.X = (float)Math.Asin(2f * test / unit);
                pitchYawRoll.Z = (float)Math.Atan2(2f * q.X * q.W - 2f * q.Y * q.Z, -sqx + sqy - sqz + sqw);
            }
            return pitchYawRoll;
        }
        private static void ProcessButtonsAndStickLeft()
        {
            LeftButtonSHOULDER_1 = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x40) != 0;
            LeftButtonSHOULDER_2 = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x80) != 0;
            LeftButtonSR = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x10) != 0;
            LeftButtonSL = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x20) != 0;
            LeftButtonDPAD_DOWN = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x01 : 0x04)) != 0;
            LeftButtonDPAD_RIGHT = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x04 : 0x08)) != 0;
            LeftButtonDPAD_UP = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x02 : 0x02)) != 0;
            LeftButtonDPAD_LEFT = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x08 : 0x01)) != 0;
            LeftButtonMINUS = ((report_bufLeft[4] & 0x01) != 0);
            LeftButtonCAPTURE = ((report_bufLeft[4] & 0x20) != 0);
            LeftButtonSTICK = ((report_bufLeft[4] & (ISLEFT ? 0x08 : 0x04)) != 0);
            stick_rawLeft[0] = report_bufLeft[6 + (ISLEFT ? 0 : 3)];
            stick_rawLeft[1] = report_bufLeft[7 + (ISLEFT ? 0 : 3)];
            stick_rawLeft[2] = report_bufLeft[8 + (ISLEFT ? 0 : 3)];
            stick_precalLeft[0] = (UInt16)(stick_rawLeft[0] | ((stick_rawLeft[1] & 0xf) << 8));
            stick_precalLeft[1] = (UInt16)((stick_rawLeft[1] >> 4) | (stick_rawLeft[2] << 4));
            stickLeft = CenterSticksLeft(stick_precalLeft);
        }
        private static void ExtractIMUValuesLeft()
        {
            acc_gLeft.X = ((float)averageLeft((Int16)(report_bufLeft[13 + 0 * 12] | ((report_bufLeft[14 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[13 + 1 * 12] | ((report_bufLeft[14 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[13 + 2 * 12] | ((report_bufLeft[14 + 2 * 12] << 8) & 0xff00))) - acc_gcalibrationLeftX) * (1.0f / 4000f);
            acc_gLeft.Y = ((float)averageLeft((Int16)(report_bufLeft[15 + 0 * 12] | ((report_bufLeft[16 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[15 + 1 * 12] | ((report_bufLeft[16 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[15 + 2 * 12] | ((report_bufLeft[16 + 2 * 12] << 8) & 0xff00))) - acc_gcalibrationLeftY) * (1.0f / 4000f);
            acc_gLeft.Z = ((float)averageLeft((Int16)(report_bufLeft[17 + 0 * 12] | ((report_bufLeft[18 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[17 + 1 * 12] | ((report_bufLeft[18 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[17 + 2 * 12] | ((report_bufLeft[18 + 2 * 12] << 8) & 0xff00))) - acc_gcalibrationLeftZ) * (1.0f / 4000f);
            gyr_gLeft.X = ((float)averageLeft((Int16)(report_bufLeft[19 + 0 * 12] | ((report_bufLeft[20 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[19 + 1 * 12] | ((report_bufLeft[20 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[19 + 2 * 12] | ((report_bufLeft[20 + 2 * 12] << 8) & 0xff00))) - gyr_gcalibrationLeftX) * (1.0f / 900000f);
            gyr_gLeft.Y = ((float)averageLeft((Int16)(report_bufLeft[21 + 0 * 12] | ((report_bufLeft[22 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[21 + 1 * 12] | ((report_bufLeft[22 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[21 + 2 * 12] | ((report_bufLeft[22 + 2 * 12] << 8) & 0xff00))) - gyr_gcalibrationLeftY) * (1.0f / 900000f);
            gyr_gLeft.Z = ((float)averageLeft((Int16)(report_bufLeft[23 + 0 * 12] | ((report_bufLeft[24 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[23 + 1 * 12] | ((report_bufLeft[24 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[23 + 2 * 12] | ((report_bufLeft[24 + 2 * 12] << 8) & 0xff00))) - gyr_gcalibrationLeftZ) * (1.0f / 900000f);
            if (!Getstate)
                InitDirectAnglesLeft = acc_gLeft;
            DirectAnglesLeft = acc_gLeft - InitDirectAnglesLeft;
            i_cLeft = new Vector3(1, 0, 0);
            k_cLeft = new Vector3(0, 0, 1);
            j_cLeft.X = 0f;
            j_cLeft.Y = 1f;
            i_bLeft = new Vector3(1, 0, 0);
            k_bLeft = new Vector3(0, 0, 1);
            j_bLeft.Y = 1f;
            j_bLeft.Z = 0f;
            i_aLeft = new Vector3(1, 0, 0);
            j_aLeft = new Vector3(0, 1, 0);
            k_aLeft.Y = 0f;
            k_aLeft.Z = 1f;
            if (EulerAnglescLeft.Y == 0f)
                j_cLeft = new Vector3(0, 1, 0);
            if (EulerAnglesbLeft.X == 0f)
                j_bLeft = new Vector3(0, 1, 0);
            if (EulerAnglesaLeft.Z == 0f)
                k_aLeft = new Vector3(0, 0, 1);
            if (!Getstate | LeftButtonCAPTURE)
            {
                j_cLeft = new Vector3(0, 1, 0);
                InitEulerAnglescLeft = ToEulerAnglesLeft(GetVectorcLeft());
                j_bLeft = new Vector3(0, 1, 0);
                InitEulerAnglesbLeft = ToEulerAnglesLeft(GetVectorbLeft());
                k_aLeft = new Vector3(0, 0, 1);
                InitEulerAnglesaLeft = ToEulerAnglesLeft(GetVectoraLeft());
                EulerAnglesLeftAdd = new Vector3(0, 0, 0);
            }
            j_cLeft += Vector3.Cross(Vector3.Negate(gyr_gLeft), j_cLeft);
            j_cLeft = Vector3.Normalize(j_cLeft);
            errcLeft = (float)(Vector3.Dot(i_cLeft, j_cLeft) * 0.5);
            i_cLeft = Vector3.Normalize(i_cLeft - errcLeft * j_cLeft);
            j_cLeft = Vector3.Normalize(j_cLeft - errcLeft * i_cLeft);
            EulerAnglescLeft = ToEulerAnglesLeft(GetVectorcLeft()) - InitEulerAnglescLeft;
            j_bLeft += Vector3.Cross(Vector3.Negate(gyr_gLeft), j_bLeft);
            j_bLeft = Vector3.Normalize(j_bLeft);
            errbLeft = (float)(Vector3.Dot(k_bLeft, j_bLeft) * 0.5);
            k_bLeft = Vector3.Normalize(k_bLeft - errbLeft * j_bLeft);
            j_bLeft = Vector3.Normalize(j_bLeft - errbLeft * k_bLeft);
            EulerAnglesbLeft = ToEulerAnglesLeft(GetVectorbLeft()) - InitEulerAnglesbLeft;
            k_aLeft += Vector3.Cross(Vector3.Negate(gyr_gLeft), k_aLeft);
            k_aLeft = Vector3.Normalize(k_aLeft);
            erraLeft = (float)(Vector3.Dot(j_aLeft, k_aLeft) * 0.5);
            j_aLeft = Vector3.Normalize(j_aLeft - erraLeft * k_aLeft);
            k_aLeft = Vector3.Normalize(k_aLeft - erraLeft * j_aLeft);
            EulerAnglesaLeft = ToEulerAnglesLeft(GetVectoraLeft()) - InitEulerAnglesaLeft;
            if (EulerAnglesLeftTemp.Y == EulerAnglescLeft.Y)
                EulerAnglesLeftCount.Y++;
            else
                EulerAnglesLeftCount.Y = 0;
            if (EulerAnglesLeftCount.Y >= 1f)
            {
                EulerAnglesLeftAdd.Y += EulerAnglescLeft.Y;
                j_cLeft = new Vector3(0, 1, 0);
                InitEulerAnglescLeft = ToEulerAnglesLeft(GetVectorcLeft());
            }
            EulerAnglesLeftTemp.Y = EulerAnglescLeft.Y;
            if (EulerAnglesLeftTemp.X == EulerAnglesbLeft.X)
                EulerAnglesLeftCount.X++;
            else
                EulerAnglesLeftCount.X = 0;
            if (EulerAnglesLeftCount.X >= 1f)
            {
                EulerAnglesLeftAdd.X += EulerAnglesbLeft.X;
                j_bLeft = new Vector3(0, 1, 0);
                InitEulerAnglesbLeft = ToEulerAnglesLeft(GetVectorbLeft());
            }
            EulerAnglesLeftTemp.X = EulerAnglesbLeft.X;
            if (EulerAnglesLeftTemp.Z == EulerAnglesaLeft.Z)
                EulerAnglesLeftCount.Z++;
            else
                EulerAnglesLeftCount.Z = 0;
            if (EulerAnglesLeftCount.Z >= 1f)
            {
                EulerAnglesLeftAdd.Z += EulerAnglesaLeft.Z;
                k_aLeft = new Vector3(0, 0, 1);
                InitEulerAnglesaLeft = ToEulerAnglesLeft(GetVectoraLeft());
            }
            EulerAnglesLeftTemp.Z = EulerAnglesaLeft.Z;
            EulerAnglesLeft = new Vector3(EulerAnglesbLeft.X + EulerAnglesLeftAdd.X, EulerAnglescLeft.Y + EulerAnglesLeftAdd.Y, EulerAnglesaLeft.Z + EulerAnglesLeftAdd.Z);
        }
        private static double averageLeft(double val1, double val2, double val3)
        {
            arrayLeft = new double[] { val1, val2, val3 };
            return arrayLeft.Where(val => val != 0).Average();
        }
        private static double[] CenterSticksLeft(UInt16[] vals)
        {
            double[] s = { 0, 0 };
            s[0] = ((int)((vals[0] - stick_calibrationLeft[0]) / 100f)) / 13f;
            s[1] = ((int)((vals[1] - stick_calibrationLeft[1]) / 100f)) / 13f;
            return s;
        }
        private static Quaternion GetVectoraRight()
        {
            Vector3 v1 = new Vector3(j_aRight.X, i_aRight.X, k_aRight.X);
            Vector3 v2 = -(new Vector3(j_aRight.Z, i_aRight.Z, k_aRight.Z));
            return QuaternionLookRotationRight(v1, v2);
        }
        private static Quaternion GetVectorbRight()
        {
            Vector3 v1 = new Vector3(j_bRight.X, i_bRight.X, k_bRight.X);
            Vector3 v2 = -(new Vector3(j_bRight.Z, i_bRight.Z, k_bRight.Z));
            return QuaternionLookRotationRight(v1, v2);
        }
        private static Quaternion GetVectorcRight()
        {
            Vector3 v1 = new Vector3(j_cRight.X, i_cRight.X, k_cRight.X);
            Vector3 v2 = -(new Vector3(j_cRight.Z, i_cRight.Z, k_cRight.Z));
            return QuaternionLookRotationRight(v1, v2);
        }
        private static Quaternion QuaternionLookRotationRight(Vector3 forward, Vector3 up)
        {
            Vector3 vector = Vector3.Normalize(forward);
            Vector3 vector2 = Vector3.Normalize(Vector3.Cross(up, vector));
            Vector3 vector3 = Vector3.Cross(vector, vector2);
            var m00 = vector2.X;
            var m01 = vector2.Y;
            var m02 = vector2.Z;
            var m10 = vector3.X;
            var m11 = vector3.Y;
            var m12 = vector3.Z;
            var m20 = vector.X;
            var m21 = vector.Y;
            var m22 = vector.Z;
            double num8 = (m00 + m11) + m22;
            var quaternion = new Quaternion();
            if (num8 > 0f)
            {
                var num = (double)Math.Sqrt(num8 + 1f);
                quaternion.W = (float)num * 0.5f;
                num = 0.5f / num;
                quaternion.X = (float)(m12 - m21) * (float)num;
                quaternion.Y = (float)(m20 - m02) * (float)num;
                quaternion.Z = (float)(m01 - m10) * (float)num;
                return quaternion;
            }
            if ((m00 >= m11) && (m00 >= m22))
            {
                var num7 = (double)Math.Sqrt(((1f + m00) - m11) - m22);
                var num4 = 0.5f / num7;
                quaternion.X = 0.5f * (float)num7;
                quaternion.Y = (float)(m01 + m10) * (float)num4;
                quaternion.Z = (float)(m02 + m20) * (float)num4;
                quaternion.W = (float)(m12 - m21) * (float)num4;
                return quaternion;
            }
            if (m11 > m22)
            {
                var num6 = (double)Math.Sqrt(((1f + m11) - m00) - m22);
                var num3 = 0.5f / num6;
                quaternion.X = (float)(m10 + m01) * (float)num3;
                quaternion.Y = 0.5f * (float)num6;
                quaternion.Z = (float)(m21 + m12) * (float)num3;
                quaternion.W = (float)(m20 - m02) * (float)num3;
                return quaternion;
            }
            var num5 = (double)Math.Sqrt(((1f + m22) - m00) - m11);
            var num2 = 0.5f / num5;
            quaternion.X = (float)(m20 + m02) * (float)num2;
            quaternion.Y = (float)(m21 + m12) * (float)num2;
            quaternion.Z = 0.5f * (float)num5;
            quaternion.W = (float)(m01 - m10) * (float)num2;
            return quaternion;
        }
        private static Vector3 ToEulerAnglesRight(Quaternion q)
        {
            Vector3 pitchYawRoll = new Vector3();
            double sqw = q.W * q.W;
            double sqx = q.X * q.X;
            double sqy = q.Y * q.Y;
            double sqz = q.Z * q.Z;
            double unit = sqx + sqy + sqz + sqw;
            double test = q.X * q.Y + q.Z * q.W;
            if (test > 0.4999f * unit)
            {
                pitchYawRoll.Y = 2f * (float)Math.Atan2(q.X, q.W);
                pitchYawRoll.X = (float)Math.PI * 0.5f;
                pitchYawRoll.Z = 0f;
                return pitchYawRoll;
            }
            else if (test < -0.4999f * unit)
            {
                pitchYawRoll.Y = -2f * (float)Math.Atan2(q.X, q.W);
                pitchYawRoll.X = -(float)Math.PI * 0.5f;
                pitchYawRoll.Z = 0f;
                return pitchYawRoll;
            }
            else
            {
                pitchYawRoll.Y = (float)Math.Atan2(2f * q.Y * q.W - 2f * q.X * q.Z, sqx - sqy - sqz + sqw);
                pitchYawRoll.X = (float)Math.Asin(2f * test / unit);
                pitchYawRoll.Z = (float)Math.Atan2(2f * q.X * q.W - 2f * q.Y * q.Z, -sqx + sqy - sqz + sqw);
            }
            return pitchYawRoll;
        }
        private static void ProcessButtonsAndStickRight()
        {
            RightButtonSHOULDER_1 = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x40) != 0;
            RightButtonSHOULDER_2 = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x80) != 0;
            RightButtonSR = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x10) != 0;
            RightButtonSL = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x20) != 0;
            RightButtonDPAD_DOWN = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x01 : 0x04)) != 0;
            RightButtonDPAD_RIGHT = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x04 : 0x08)) != 0;
            RightButtonDPAD_UP = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x02 : 0x02)) != 0;
            RightButtonDPAD_LEFT = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x08 : 0x01)) != 0;
            RightButtonPLUS = ((report_bufRight[4] & 0x02) != 0);
            RightButtonHOME = ((report_bufRight[4] & 0x10) != 0);
            RightButtonSTICK = ((report_bufRight[4] & (!ISRIGHT ? 0x08 : 0x04)) != 0);
            stick_rawRight[0] = report_bufRight[6 + (!ISRIGHT ? 0 : 3)];
            stick_rawRight[1] = report_bufRight[7 + (!ISRIGHT ? 0 : 3)];
            stick_rawRight[2] = report_bufRight[8 + (!ISRIGHT ? 0 : 3)];
            stick_precalRight[0] = (UInt16)(stick_rawRight[0] | ((stick_rawRight[1] & 0xf) << 8));
            stick_precalRight[1] = (UInt16)((stick_rawRight[1] >> 4) | (stick_rawRight[2] << 4));
            stickRight = CenterSticksRight(stick_precalRight);
        }
        private static void ExtractIMUValuesRight()
        {
            acc_gRight.X = ((float)(averageRight((Int16)(report_bufRight[13 + 0 * 12] | ((report_bufRight[14 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[13 + 1 * 12] | ((report_bufRight[14 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[13 + 2 * 12] | ((report_bufRight[14 + 2 * 12] << 8) & 0xff00)))) - acc_gcalibrationRightX) * (1.0f / 4000f);
            acc_gRight.Y = -((float)(averageRight((Int16)(report_bufRight[15 + 0 * 12] | ((report_bufRight[16 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[15 + 1 * 12] | ((report_bufRight[16 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[15 + 2 * 12] | ((report_bufRight[16 + 2 * 12] << 8) & 0xff00)))) - acc_gcalibrationRightY) * (1.0f / 4000f);
            acc_gRight.Z = -((float)(averageRight((Int16)(report_bufRight[17 + 0 * 12] | ((report_bufRight[18 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[17 + 1 * 12] | ((report_bufRight[18 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[17 + 2 * 12] | ((report_bufRight[18 + 2 * 12] << 8) & 0xff00)))) - acc_gcalibrationRightZ) * (1.0f / 4000f);
            gyr_gRight.X = ((float)(averageRight((Int16)(report_bufRight[19 + 0 * 12] | ((report_bufRight[20 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[19 + 1 * 12] | ((report_bufRight[20 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[19 + 2 * 12] | ((report_bufRight[20 + 2 * 12] << 8) & 0xff00)))) - gyr_gcalibrationRightX) * (1.0f / 900000f);
            gyr_gRight.Y = -((float)(averageRight((Int16)(report_bufRight[21 + 0 * 12] | ((report_bufRight[22 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[21 + 1 * 12] | ((report_bufRight[22 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[21 + 2 * 12] | ((report_bufRight[22 + 2 * 12] << 8) & 0xff00)))) - gyr_gcalibrationRightY) * (1.0f / 900000f);
            gyr_gRight.Z = -((float)(averageRight((Int16)(report_bufRight[23 + 0 * 12] | ((report_bufRight[24 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[23 + 1 * 12] | ((report_bufRight[24 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[23 + 2 * 12] | ((report_bufRight[24 + 2 * 12] << 8) & 0xff00)))) - gyr_gcalibrationRightZ) * (1.0f / 900000f);
            if (!Getstate)
                InitDirectAnglesRight = acc_gRight;
            DirectAnglesRight = acc_gRight - InitDirectAnglesRight;
            i_cRight = new Vector3(1, 0, 0);
            k_cRight = new Vector3(0, 0, 1);
            j_cRight.X = 0f;
            j_cRight.Y = 1f;
            i_bRight = new Vector3(1, 0, 0);
            k_bRight = new Vector3(0, 0, 1);
            j_bRight.Y = 1f;
            j_bRight.Z = 0f;
            i_aRight = new Vector3(1, 0, 0);
            j_aRight = new Vector3(0, 1, 0);
            k_aRight.Y = 0f;
            k_aRight.Z = 1f;
            if (EulerAnglescRight.Y == 0f)
                j_cRight = new Vector3(0, 1, 0);
            if (EulerAnglesbRight.X == 0f)
                j_bRight = new Vector3(0, 1, 0);
            if (EulerAnglesaRight.Z == 0f)
                k_aRight = new Vector3(0, 0, 1);
            if (!Getstate | RightButtonHOME)
            {
                j_cRight = new Vector3(0, 1, 0);
                InitEulerAnglescRight = ToEulerAnglesRight(GetVectorcRight());
                j_bRight = new Vector3(0, 1, 0);
                InitEulerAnglesbRight = ToEulerAnglesRight(GetVectorbRight());
                k_aRight = new Vector3(0, 0, 1);
                InitEulerAnglesaRight = ToEulerAnglesRight(GetVectoraRight());
                EulerAnglesRightAdd = new Vector3(0, 0, 0);
            }
            j_cRight += Vector3.Cross(Vector3.Negate(gyr_gRight), j_cRight);
            j_cRight = Vector3.Normalize(j_cRight);
            errcRight = (float)(Vector3.Dot(i_cRight, j_cRight) * 0.5);
            i_cRight = Vector3.Normalize(i_cRight - errcRight * j_cRight);
            j_cRight = Vector3.Normalize(j_cRight - errcRight * i_cRight);
            EulerAnglescRight = ToEulerAnglesRight(GetVectorcRight()) - InitEulerAnglescRight;
            j_bRight += Vector3.Cross(Vector3.Negate(gyr_gRight), j_bRight);
            j_bRight = Vector3.Normalize(j_bRight);
            errbRight = (float)(Vector3.Dot(k_bRight, j_bRight) * 0.5);
            k_bRight = Vector3.Normalize(k_bRight - errbRight * j_bRight);
            j_bRight = Vector3.Normalize(j_bRight - errbRight * k_bRight);
            EulerAnglesbRight = ToEulerAnglesRight(GetVectorbRight()) - InitEulerAnglesbRight;
            k_aRight += Vector3.Cross(Vector3.Negate(gyr_gRight), k_aRight);
            k_aRight = Vector3.Normalize(k_aRight);
            erraRight = (float)(Vector3.Dot(j_aRight, k_aRight) * 0.5);
            j_aRight = Vector3.Normalize(j_aRight - erraRight * k_aRight);
            k_aRight = Vector3.Normalize(k_aRight - erraRight * j_aRight);
            EulerAnglesaRight = ToEulerAnglesRight(GetVectoraRight()) - InitEulerAnglesaRight;
            if (EulerAnglesRightTemp.Y == EulerAnglescRight.Y)
                EulerAnglesRightCount.Y++;
            else
                EulerAnglesRightCount.Y = 0;
            if (EulerAnglesRightCount.Y >= 1f)
            {
                EulerAnglesRightAdd.Y += EulerAnglescRight.Y;
                j_cRight = new Vector3(0, 1, 0);
                InitEulerAnglescRight = ToEulerAnglesRight(GetVectorcRight());
            }
            EulerAnglesRightTemp.Y = EulerAnglescRight.Y;
            if (EulerAnglesRightTemp.X == EulerAnglesbRight.X)
                EulerAnglesRightCount.X++;
            else
                EulerAnglesRightCount.X = 0;
            if (EulerAnglesRightCount.X >= 1f)
            {
                EulerAnglesRightAdd.X += EulerAnglesbRight.X;
                j_bRight = new Vector3(0, 1, 0);
                InitEulerAnglesbRight = ToEulerAnglesRight(GetVectorbRight());
            }
            EulerAnglesRightTemp.X = EulerAnglesbRight.X;
            if (EulerAnglesRightTemp.Z == EulerAnglesaRight.Z)
                EulerAnglesRightCount.Z++;
            else
                EulerAnglesRightCount.Z = 0;
            if (EulerAnglesRightCount.Z >= 1f)
            {
                EulerAnglesRightAdd.Z += EulerAnglesaRight.Z;
                k_aRight = new Vector3(0, 0, 1);
                InitEulerAnglesaRight = ToEulerAnglesRight(GetVectoraRight());
            }
            EulerAnglesRightTemp.Z = EulerAnglesaRight.Z;
            EulerAnglesRight = new Vector3(EulerAnglesbRight.X + EulerAnglesRightAdd.X, EulerAnglescRight.Y + EulerAnglesRightAdd.Y, EulerAnglesaRight.Z + EulerAnglesRightAdd.Z);
        }
        private static double averageRight(double val1, double val2, double val3)
        {
            arrayRight = new double[] { val1, val2, val3 };
            return arrayRight.Where(val => val != 0).Average();
        }
        private static double[] CenterSticksRight(UInt16[] vals)
        {
            double[] s = { 0, 0 };
            s[0] = ((int)((vals[0] - stick_calibrationRight[0]) / 100f)) / 13f;
            s[1] = ((int)((vals[1] - stick_calibrationRight[1]) / 100f)) / 13f;
            return s;
        }
        private const string vendor_id = "57e", vendor_id_ = "057e", product_l = "2006", product_r = "2007";
        private enum EFileAttributes : uint
        {
            Overlapped = 0x40000000,
            Normal = 0x80
        };
        struct SP_DEVICE_INTERFACE_DATA
        {
            public int cbSize;
            public Guid InterfaceClassGuid;
            public int Flags;
            public IntPtr RESERVED;
        }
        struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            public UInt32 cbSize;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 256)]
            public string DevicePath;
        }
        private static double[] stickLeft = { 0, 0 };
        private static SafeFileHandle handleLeft;
        private static byte[] stick_rawLeft = { 0, 0, 0 };
        private static UInt16[] stick_calibrationLeft = { 0, 0 };
        private static UInt16[] stick_precalLeft = { 0, 0 };
        private static Vector3 gyr_gLeft = new Vector3();
        private static Vector3 acc_gLeft = new Vector3();
        private const uint report_lenLeft = 49;
        private static Vector3 i_aLeft = new Vector3(1, 0, 0);
        private static Vector3 j_aLeft = new Vector3(0, 1, 0);
        private static Vector3 k_aLeft = new Vector3(0, 0, 1);
        private static Vector3 i_bLeft = new Vector3(1, 0, 0);
        private static Vector3 j_bLeft = new Vector3(0, 1, 0);
        private static Vector3 k_bLeft = new Vector3(0, 0, 1);
        private static Vector3 i_cLeft = new Vector3(1, 0, 0);
        private static Vector3 j_cLeft = new Vector3(0, 1, 0);
        private static Vector3 k_cLeft = new Vector3(0, 0, 1);
        private static Vector3 InitDirectAnglesLeft, DirectAnglesLeft;
        private static Vector3 InitEulerAnglesaLeft, EulerAnglesaLeft, InitEulerAnglesbLeft, EulerAnglesbLeft, InitEulerAnglescLeft, EulerAnglescLeft, EulerAnglesLeft, EulerAnglesLeftCount, EulerAnglesLeftAdd, EulerAnglesLeftTemp;
        private static bool LeftButtonSHOULDER_1, LeftButtonSHOULDER_2, LeftButtonSR, LeftButtonSL, LeftButtonDPAD_DOWN, LeftButtonDPAD_RIGHT, LeftButtonDPAD_UP, LeftButtonDPAD_LEFT, LeftButtonMINUS, LeftButtonSTICK, LeftButtonCAPTURE;
        private static byte[] report_bufLeft = new byte[report_lenLeft];
        private static double[] arrayLeft;
        private static byte[] buf_Left = new byte[report_lenLeft];
        private static float acc_gcalibrationLeftX, acc_gcalibrationLeftY, acc_gcalibrationLeftZ, gyr_gcalibrationLeftX, gyr_gcalibrationLeftY, gyr_gcalibrationLeftZ;
        private static float erraLeft, errbLeft, errcLeft;
        private static double[] GetStickLeft()
        {
            return stickLeft;
        }
        private static Vector3 GetAccelLeft()
        {
            return acc_gLeft;
        }
        private static bool ScanLeft()
        {
            int index = 0;
            System.Guid guid;
            HidD_GetHidGuid(out guid);
            System.IntPtr hDevInfo = SetupDiGetClassDevs(ref guid, null, new System.IntPtr(), 0x00000010);
            SP_DEVICE_INTERFACE_DATA diData = new SP_DEVICE_INTERFACE_DATA();
            diData.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(diData);
            while (SetupDiEnumDeviceInterfaces(hDevInfo, new System.IntPtr(), ref guid, index, ref diData))
            {
                System.UInt32 size;
                SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, new System.IntPtr(), 0, out size, new System.IntPtr());
                SP_DEVICE_INTERFACE_DETAIL_DATA diDetail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                diDetail.cbSize = 5;
                if (SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, ref diDetail, size, out size, new System.IntPtr()))
                {
                    if ((diDetail.DevicePath.Contains(vendor_id) | diDetail.DevicePath.Contains(vendor_id_)) & diDetail.DevicePath.Contains(product_l))
                    {
                        ISLEFT = true;
                        AttachJoyLeft(diDetail.DevicePath);
                        AttachJoyLeft(diDetail.DevicePath);
                        AttachJoyLeft(diDetail.DevicePath);
                        return true;
                    }
                }
                index++;
            }
            return false;
        }
        private static void AttachJoyLeft(string path)
        {
            do
            {
                IntPtr handle = CreateFile(path, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite, new System.IntPtr(), System.IO.FileMode.Open, EFileAttributes.Normal, new System.IntPtr());
                handleLeft = Lhid_open_path(handle);
                SubcommandLeft(0x3, new byte[] { 0x30 }, 1);
                SubcommandLeft(0x40, new byte[] { 0x1 }, 1);
            }
            while (handleLeft.IsInvalid);
        }
        private static void SubcommandLeft(byte sc, byte[] buf, uint len)
        {
            Array.Copy(buf, 0, buf_Left, 11, len);
            buf_Left[0] = 0x1;
            buf_Left[1] = 0;
            buf_Left[10] = sc;
            Lhid_write(handleLeft, buf_Left, (UIntPtr)(len + 11));
            Lhid_read_timeout(handleLeft, buf_Left, (UIntPtr)49);
        }
        private static double[] stickRight = { 0, 0 };
        private static SafeFileHandle handleRight;
        private static byte[] stick_rawRight = { 0, 0, 0 };
        private static UInt16[] stick_calibrationRight = { 0, 0 };
        private static UInt16[] stick_precalRight = { 0, 0 };
        private static Vector3 acc_gRight = new Vector3();
        private static Vector3 gyr_gRight = new Vector3();
        private const uint report_lenRight = 49;
        private static Vector3 i_cRight = new Vector3(1, 0, 0);
        private static Vector3 j_cRight = new Vector3(0, 1, 0);
        private static Vector3 k_cRight = new Vector3(0, 0, 1);
        private static Vector3 i_bRight = new Vector3(1, 0, 0);
        private static Vector3 j_bRight = new Vector3(0, 1, 0);
        private static Vector3 k_bRight = new Vector3(0, 0, 1);
        private static Vector3 i_aRight = new Vector3(1, 0, 0);
        private static Vector3 j_aRight = new Vector3(0, 1, 0);
        private static Vector3 k_aRight = new Vector3(0, 0, 1);
        private static Vector3 InitDirectAnglesRight, DirectAnglesRight;
        private static Vector3 InitEulerAnglesaRight, EulerAnglesaRight, InitEulerAnglesbRight, EulerAnglesbRight, InitEulerAnglescRight, EulerAnglescRight, EulerAnglesRight, EulerAnglesRightCount, EulerAnglesRightAdd, EulerAnglesRightTemp;
        private static bool RightButtonSHOULDER_1, RightButtonSHOULDER_2, RightButtonSR, RightButtonSL, RightButtonDPAD_DOWN, RightButtonDPAD_RIGHT, RightButtonDPAD_UP, RightButtonDPAD_LEFT, RightButtonPLUS, RightButtonSTICK, RightButtonHOME;
        private static byte[] report_bufRight = new byte[report_lenRight];
        private static double[] arrayRight;
        private static byte[] buf_Right = new byte[report_lenRight];
        private static float acc_gcalibrationRightX, acc_gcalibrationRightY, acc_gcalibrationRightZ, gyr_gcalibrationRightX, gyr_gcalibrationRightY, gyr_gcalibrationRightZ;
        private static float erraRight, errbRight, errcRight;
        private static double[] GetStickRight()
        {
            return stickRight;
        }
        private static Vector3 GetAccelRight()
        {
            return acc_gRight;
        }
        private static bool ScanRight()
        {
            int index = 0;
            System.Guid guid;
            HidD_GetHidGuid(out guid);
            System.IntPtr hDevInfo = SetupDiGetClassDevs(ref guid, null, new System.IntPtr(), 0x00000010);
            SP_DEVICE_INTERFACE_DATA diData = new SP_DEVICE_INTERFACE_DATA();
            diData.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(diData);
            while (SetupDiEnumDeviceInterfaces(hDevInfo, new System.IntPtr(), ref guid, index, ref diData))
            {
                System.UInt32 size;
                SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, new System.IntPtr(), 0, out size, new System.IntPtr());
                SP_DEVICE_INTERFACE_DETAIL_DATA diDetail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                diDetail.cbSize = 5;
                if (SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, ref diDetail, size, out size, new System.IntPtr()))
                {
                    if ((diDetail.DevicePath.Contains(vendor_id) | diDetail.DevicePath.Contains(vendor_id_)) & diDetail.DevicePath.Contains(product_r))
                    {
                        ISRIGHT = true;
                        AttachJoyRight(diDetail.DevicePath);
                        AttachJoyRight(diDetail.DevicePath);
                        AttachJoyRight(diDetail.DevicePath);
                        return true;
                    }
                }
                index++;
            }
            return false;
        }
        private static void AttachJoyRight(string path)
        {
            do
            {
                IntPtr handle = CreateFile(path, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite, new System.IntPtr(), System.IO.FileMode.Open, EFileAttributes.Normal, new System.IntPtr());
                handleRight = Rhid_open_path(handle);
                SubcommandRight(0x3, new byte[] { 0x30 }, 1);
                SubcommandRight(0x40, new byte[] { 0x1 }, 1);
            }
            while (handleRight.IsInvalid);
        }
        private static void SubcommandRight(byte sc, byte[] buf, uint len)
        {
            Array.Copy(buf, 0, buf_Right, 11, len);
            buf_Right[0] = 0x1;
            buf_Right[1] = 0;
            buf_Right[10] = sc;
            Rhid_write(handleRight, buf_Right, (UIntPtr)(len + 11));
            Rhid_read_timeout(handleRight, buf_Right, (UIntPtr)49);
        }
    }
}