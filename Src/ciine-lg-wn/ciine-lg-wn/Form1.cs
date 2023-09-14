using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;

namespace ciine_lg_wn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Type program;
        private object obj;
        private Assembly assembly;
        private System.CodeDom.Compiler.CompilerResults results;
        private Microsoft.CSharp.CSharpCodeProvider provider;
        private System.CodeDom.Compiler.CompilerParameters parameters;
        private string code = @"
                using Microsoft.Win32.SafeHandles;
                using System;
                using System.Globalization;
                using System.IO;
                using System.Numerics;
                using System.Runtime.InteropServices;
                using System.Threading;
                using System.Threading.Tasks;
                using System.Windows;
                using System.Windows.Forms;
                using System.Reflection;
                using keyboards;
                using mouses;
                namespace StringToCode
                {
                    public class FooClass 
                    { 
                        [DllImport(""hid.dll"")]
                        private static extern void HidD_GetHidGuid(out Guid gHid);
                        [DllImport(""hid.dll"")]
                        private extern static bool HidD_SetOutputReport(IntPtr HidDeviceObject, byte[] lpReportBuffer, uint ReportBufferLength);
                        [DllImport(""setupapi.dll"")]
                        private static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, string Enumerator, IntPtr hwndParent, UInt32 Flags);
                        [DllImport(""setupapi.dll"")]
                        private static extern Boolean SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInvo, ref Guid interfaceClassGuid, Int32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);
                        [DllImport(""setupapi.dll"")]
                        private static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, IntPtr deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
                        [DllImport(""setupapi.dll"")]
                        private static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, ref SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
                        [DllImport(""Kernel32.dll"")]
                        private static extern SafeFileHandle CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess, [MarshalAs(UnmanagedType.U4)] FileShare fileShare, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr template);
                        [DllImport(""Kernel32.dll"")]
                        private static extern IntPtr CreateFile(string fileName, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare, IntPtr securityAttributes, System.IO.FileMode creationDisposition, EFileAttributes flags, IntPtr template);
                        [DllImport(""winmm.dll"", EntryPoint = ""timeBeginPeriod"")]
                        private static extern uint TimeBeginPeriod(uint ms);
                        [DllImport(""winmm.dll"", EntryPoint = ""timeEndPeriod"")]
                        private static extern uint TimeEndPeriod(uint ms);
                        [DllImport(""ntdll.dll"", EntryPoint = ""NtSetTimerResolution"")]
                        private static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
                        string KeyboardMouseDriverType = """"; double MouseMoveX; double MouseMoveY; double MouseAbsX; double MouseAbsY; double MouseDesktopX; double MouseDesktopY; bool SendLeftClick; bool SendRightClick; bool SendMiddleClick; bool SendWheelUp; bool SendWheelDown; bool SendLeft; bool SendRight; bool SendUp; bool SendDown; bool SendLButton; bool SendRButton; bool SendCancel; bool SendMBUTTON; bool SendXBUTTON1; bool SendXBUTTON2; bool SendBack; bool SendTab; bool SendClear; bool SendReturn; bool SendSHIFT; bool SendCONTROL; bool SendMENU; bool SendPAUSE; bool SendCAPITAL; bool SendKANA; bool SendHANGEUL; bool SendHANGUL; bool SendJUNJA; bool SendFINAL; bool SendHANJA; bool SendKANJI; bool SendEscape; bool SendCONVERT; bool SendNONCONVERT; bool SendACCEPT; bool SendMODECHANGE; bool SendSpace; bool SendPRIOR; bool SendNEXT; bool SendEND; bool SendHOME; bool SendLEFT; bool SendUP; bool SendRIGHT; bool SendDOWN; bool SendSELECT; bool SendPRINT; bool SendEXECUTE; bool SendSNAPSHOT; bool SendINSERT; bool SendDELETE; bool SendHELP; bool SendAPOSTROPHE; bool Send0; bool Send1; bool Send2; bool Send3; bool Send4; bool Send5; bool Send6; bool Send7; bool Send8; bool Send9; bool SendA; bool SendB; bool SendC; bool SendD; bool SendE; bool SendF; bool SendG; bool SendH; bool SendI; bool SendJ; bool SendK; bool SendL; bool SendM; bool SendN; bool SendO; bool SendP; bool SendQ; bool SendR; bool SendS; bool SendT; bool SendU; bool SendV; bool SendW; bool SendX; bool SendY; bool SendZ; bool SendLWIN; bool SendRWIN; bool SendAPPS; bool SendSLEEP; bool SendNUMPAD0; bool SendNUMPAD1; bool SendNUMPAD2; bool SendNUMPAD3; bool SendNUMPAD4; bool SendNUMPAD5; bool SendNUMPAD6; bool SendNUMPAD7; bool SendNUMPAD8; bool SendNUMPAD9; bool SendMULTIPLY; bool SendADD; bool SendSEPARATOR; bool SendSUBTRACT; bool SendDECIMAL; bool SendDIVIDE; bool SendF1; bool SendF2; bool SendF3; bool SendF4; bool SendF5; bool SendF6; bool SendF7; bool SendF8; bool SendF9; bool SendF10; bool SendF11; bool SendF12; bool SendF13; bool SendF14; bool SendF15; bool SendF16; bool SendF17; bool SendF18; bool SendF19; bool SendF20; bool SendF21; bool SendF22; bool SendF23; bool SendF24; bool SendNUMLOCK; bool SendSCROLL; bool SendLeftShift; bool SendRightShift; bool SendLeftControl; bool SendRightControl; bool SendLMENU; bool SendRMENU;
                        private const double REGISTER_IR = 0x04b00030, REGISTER_EXTENSION_INIT_1 = 0x04a400f0, REGISTER_EXTENSION_INIT_2 = 0x04a400fb, REGISTER_EXTENSION_TYPE = 0x04a400fa, REGISTER_EXTENSION_CALIBRATION = 0x04a40020, REGISTER_MOTIONPLUS_INIT = 0x04a600fe;
                        private static double irx0, iry0, irx1, iry1, irx, iry, WiimoteIRSensors0X, WiimoteIRSensors0Y, WiimoteIRSensors1X, WiimoteIRSensors1Y, WiimoteRawValuesX, WiimoteRawValuesY, WiimoteRawValuesZ, calibrationinit, WiimoteIRSensors0Xcam, WiimoteIRSensors0Ycam, WiimoteIRSensors1Xcam, WiimoteIRSensors1Ycam, WiimoteIRSensorsXcam, WiimoteIRSensorsYcam;
                        private static bool WiimoteIR1found, WiimoteIR0found, WiimoteButtonStateA, WiimoteButtonStateB, WiimoteButtonStateMinus, WiimoteButtonStateHome, WiimoteButtonStatePlus, WiimoteButtonStateOne, WiimoteButtonStateTwo, WiimoteButtonStateUp, WiimoteButtonStateDown, WiimoteButtonStateLeft, WiimoteButtonStateRight, ISWIIMOTE, running;
                        private static double reconnectingwiimotecount, stickviewxinit, stickviewyinit, WiimoteNunchuckStateRawValuesX, WiimoteNunchuckStateRawValuesY, WiimoteNunchuckStateRawValuesZ, WiimoteNunchuckStateRawJoystickX, WiimoteNunchuckStateRawJoystickY;
                        private static bool reconnectingwiimotebool, WiimoteNunchuckStateC, WiimoteNunchuckStateZ;                        
                        private static string path;
                        private static byte[] buff = new byte[] { 0x55 }, mBuff = new byte[22], aBuffer = new byte[22];
                        private const byte Type = 0x12, IR = 0x13, WriteMemory = 0x16, ReadMemory = 0x16, IRExtensionAccel = 0x37;
                        private static uint CurrentResolution = 0;
                        private static FileStream mStream;
                        private static SafeFileHandle handle = null;
                        private double statex = 0f, statey = 0f, mousex = 0f, mousey = 0f, mousestatex = 0f, mousestatey = 0f, viewpower1x = 1f, viewpower2x = 0f, viewpower3x = 0f, viewpower1y = 1f, viewpower2y = 0f, viewpower3y = 0f, dzx = 0f, dzy = 0f, centery = 80f;
                        private bool[] getstate = new bool[12];
                        private int[] pollcount = new int[12];
                        private int[] keys12345 = new int[12];
                        private int[] keys54321 = new int[12];
                        private double[] mousexp = new double[12];
                        private double[] mouseyp = new double[12];
                        private int sleeptime = 1;
                        private static int[] wd = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
                        private static int[] wu = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
                        public static void valchanged(int n, bool val)
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
                        public void Load()
                        {
                            TimeBeginPeriod(1);
                            NtSetTimerResolution(1, true, ref CurrentResolution);
                            Task.Run(() => Start());
                        }
                        private void Start()
                        {
                            running = true;
                            do
                                Thread.Sleep(1);
                            while (!wiimoteconnect());
                            ScanWiimote();
                            Task.Run(() => taskD());
                            Thread.Sleep(1000);
                            calibrationinit = -aBuffer[4] + 135f;
                            stickviewxinit = -aBuffer[16] + 125f;
                            stickviewyinit = -aBuffer[17] + 125f;
                            Task.Run(() => taskX());
                        }
                        private void taskX()
                        {
                            while (running)
                            {
                                if (reconnectingwiimotecount == 0)
                                    reconnectingwiimotebool = true;
                                reconnectingwiimotecount++;
                                if (reconnectingwiimotecount >= 150f / sleeptime)
                                {
                                    if (reconnectingwiimotebool)
                                    {
                                        WiimoteFound(path);
                                        reconnectingwiimotecount = -150;
                                    }
                                    else
                                        reconnectingwiimotecount = 0;
                                }
                                WiimoteIRSensors0X = aBuffer[6] | ((aBuffer[8] >> 4) & 0x03) << 8;
                                WiimoteIRSensors0Y = aBuffer[7] | ((aBuffer[8] >> 6) & 0x03) << 8;
                                WiimoteIRSensors1X = aBuffer[9] | ((aBuffer[8] >> 0) & 0x03) << 8;
                                WiimoteIRSensors1Y = aBuffer[10] | ((aBuffer[8] >> 2) & 0x03) << 8;
                                WiimoteIR0found = WiimoteIRSensors0X > 0f & WiimoteIRSensors0X <= 1024f & WiimoteIRSensors0Y > 0f & WiimoteIRSensors0Y <= 768f;
                                WiimoteIR1found = WiimoteIRSensors1X > 0f & WiimoteIRSensors1X <= 1024f & WiimoteIRSensors1Y > 0f & WiimoteIRSensors1Y <= 768f;
                                if (WiimoteIR0found)
                                {
                                    WiimoteIRSensors0Xcam = WiimoteIRSensors0X - 512f;
                                    WiimoteIRSensors0Ycam = WiimoteIRSensors0Y - 384f;
                                }
                                if (WiimoteIR1found)
                                {
                                    WiimoteIRSensors1Xcam = WiimoteIRSensors1X - 512f;
                                    WiimoteIRSensors1Ycam = WiimoteIRSensors1Y - 384f;
                                }
                                if (WiimoteIR0found & WiimoteIR1found)
                                {
                                    WiimoteIRSensorsXcam = (WiimoteIRSensors0Xcam + WiimoteIRSensors1Xcam) / 2f;
                                    WiimoteIRSensorsYcam = (WiimoteIRSensors0Ycam + WiimoteIRSensors1Ycam) / 2f;
                                }
                                if (WiimoteIR0found)
                                {
                                    irx0 = 2 * WiimoteIRSensors0Xcam - WiimoteIRSensorsXcam;
                                    iry0 = 2 * WiimoteIRSensors0Ycam - WiimoteIRSensorsYcam;
                                }
                                if (WiimoteIR1found)
                                {
                                    irx1 = 2 * WiimoteIRSensors1Xcam - WiimoteIRSensorsXcam;
                                    iry1 = 2 * WiimoteIRSensors1Ycam - WiimoteIRSensorsYcam;
                                }
                                irx = (irx0 + irx1) * (1024f / 1346f);
                                iry = iry0 + iry1 + centery >= 0 ? Scale(iry0 + iry1 + centery, 0f, 782f + centery, 0f, 1024f) : Scale(iry0 + iry1 + centery, -782f + centery, 0f, -1024f, 0f);
                                WiimoteButtonStateA = (aBuffer[2] & 0x08) != 0;
                                WiimoteButtonStateB = (aBuffer[2] & 0x04) != 0;
                                WiimoteButtonStateMinus = (aBuffer[2] & 0x10) != 0;
                                WiimoteButtonStateHome = (aBuffer[2] & 0x80) != 0;
                                WiimoteButtonStatePlus = (aBuffer[1] & 0x10) != 0;
                                WiimoteButtonStateOne = (aBuffer[2] & 0x02) != 0;
                                WiimoteButtonStateTwo = (aBuffer[2] & 0x01) != 0;
                                WiimoteButtonStateUp = (aBuffer[1] & 0x08) != 0;
                                WiimoteButtonStateDown = (aBuffer[1] & 0x04) != 0;
                                WiimoteButtonStateLeft = (aBuffer[1] & 0x01) != 0;
                                WiimoteButtonStateRight = (aBuffer[1] & 0x02) != 0;
                                WiimoteRawValuesX = aBuffer[3] - 135f + calibrationinit;
                                WiimoteRawValuesY = aBuffer[4] - 135f + calibrationinit;
                                WiimoteRawValuesZ = aBuffer[5] - 135f + calibrationinit;
                                WiimoteNunchuckStateRawJoystickX = aBuffer[16] - 125f + stickviewxinit;
                                WiimoteNunchuckStateRawJoystickY = aBuffer[17] - 125f + stickviewyinit;
                                WiimoteNunchuckStateRawValuesX = aBuffer[18] - 125f;
                                WiimoteNunchuckStateRawValuesY = aBuffer[19] - 125f;
                                WiimoteNunchuckStateRawValuesZ = aBuffer[20] - 125f;
                                WiimoteNunchuckStateC = (aBuffer[21] & 0x02) == 0;
                                WiimoteNunchuckStateZ = (aBuffer[21] & 0x01) == 0;
                                valchanged(0, WiimoteButtonStateOne);
                                if (wd[0] == 1 & !getstate[0]) 
                                {
                                    getstate[0] = true;
                                }
                                else 
                                { 
                                    if (wd[0] == 1 & getstate[0]) 
                                    {
                                        MouseMoveX     = 0;
                                        MouseMoveY     = 0;
                                        MouseDesktopX  = 0;
                                        MouseDesktopY  = 0;
                                        MouseAbsX      = 0;
                                        MouseAbsY      = 0;
                                        SendD          = false;
                                        SendQ          = false;
                                        SendZ          = false;
                                        SendS          = false;
                                        Send1          = false;
                                        Send2          = false;
                                        Send3          = false;
                                        Send4          = false;
                                        SendSpace      = false;
                                        SendLeftShift  = false;
                                        SendE          = false;
                                        SendA          = false;
                                        SendV          = false;
                                        SendEscape     = false;
                                        SendTab        = false;
                                        SendR          = false;
                                        SendF          = false;
                                        SendT          = false;
                                        SendG          = false;
                                        SendY          = false; 
                                        SendU          = false;
                                        SendX          = false;
                                        SendC          = false;
                                        SendRightClick = false;
                                        SendLeftClick  = false;
                                        getstate[0]       = false;
                                    }
                                }
                                if (getstate[0]) 
                                {
                                    if (irx >= 0f)
                                        mousex = Scale(irx * irx * irx / 1024f / 1024f * viewpower3x + irx * irx / 1024f * viewpower2x + irx * viewpower1x, 0f, 1024f, (dzx / 100f) * 1024f, 1024f);
                                    if (irx <= 0f)
                                        mousex = Scale(-(-irx * -irx * -irx) / 1024f / 1024f * viewpower3x - (-irx * -irx) / 1024f * viewpower2x - (-irx) * viewpower1x, -1024f, 0f, -1024f, -(dzx / 100f) * 1024f);
                                    if (iry >= 0f)
                                        mousey = Scale(iry * iry * iry / 1024f / 1024f * viewpower3y + iry * iry / 1024f * viewpower2y + iry * viewpower1y, 0f, 1024f, (dzy / 100f) * 1024f, 1024f);
                                    if (iry <= 0f)
                                        mousey = Scale(-(-iry * -iry * -iry) / 1024f / 1024f * viewpower3y - (-iry * -iry) / 1024f * viewpower2y - (-iry) * viewpower1y, -1024f, 0f, -1024f, -(dzy / 100f) * 1024f);  
                                    MouseAbsX = 32767.5f - mousex * 32f;
                                    MouseAbsY = 32767.5f + mousey * 32f;
                                    SendD = WiimoteNunchuckStateRawJoystickX * 600f >= 20000;
                                    SendQ = WiimoteNunchuckStateRawJoystickX * 600f <= -20000;
                                    SendZ = WiimoteNunchuckStateRawJoystickY * 600f >= 20000;
                                    SendS = WiimoteNunchuckStateRawJoystickY * 600f <= -20000;
                                    SendSpace = WiimoteNunchuckStateC;
                                    SendLeftShift = WiimoteNunchuckStateZ;
                                    SendV = WiimoteNunchuckStateRawValuesY > 33f;
                                    SendEscape = WiimoteButtonStateTwo;
                                    SendTab = WiimoteButtonStateOne;
                                    SendR = ((WiimoteRawValuesZ > 0 ? WiimoteRawValuesZ : -WiimoteRawValuesZ) >= 30f & (WiimoteRawValuesY > 0 ? WiimoteRawValuesY : -WiimoteRawValuesY) >= 30f & (WiimoteRawValuesX > 0 ? WiimoteRawValuesX : -WiimoteRawValuesX) >= 30f);
                                    SendF = WiimoteButtonStateHome;
                                    SendT = WiimoteButtonStateMinus;
                                    SendG = WiimoteButtonStatePlus;
                                    SendY = WiimoteButtonStateLeft;
                                    SendU = WiimoteButtonStateRight;
                                    SendX = WiimoteButtonStateUp;
                                    SendC = WiimoteButtonStateDown;
                                    SendRightClick = WiimoteButtonStateA;
                                    SendLeftClick  = WiimoteButtonStateB;
                                }
                                SendKeyboard.SetKM(KeyboardMouseDriverType, SendLeftClick, SendRightClick, SendMiddleClick, SendWheelUp, SendWheelDown, SendLeft, SendRight, SendUp, SendDown, SendLButton, SendRButton, SendCancel, SendMBUTTON, SendXBUTTON1, SendXBUTTON2, SendBack, SendTab, SendClear, SendReturn, SendSHIFT, SendCONTROL, SendMENU, SendPAUSE, SendCAPITAL, SendKANA, SendHANGEUL, SendHANGUL, SendJUNJA, SendFINAL, SendHANJA, SendKANJI, SendEscape, SendCONVERT, SendNONCONVERT, SendACCEPT, SendMODECHANGE, SendSpace, SendPRIOR, SendNEXT, SendEND, SendHOME, SendLEFT, SendUP, SendRIGHT, SendDOWN, SendSELECT, SendPRINT, SendEXECUTE, SendSNAPSHOT, SendINSERT, SendDELETE, SendHELP, SendAPOSTROPHE, Send0, Send1, Send2, Send3, Send4, Send5, Send6, Send7, Send8, Send9, SendA, SendB, SendC, SendD, SendE, SendF, SendG, SendH, SendI, SendJ, SendK, SendL, SendM, SendN, SendO, SendP, SendQ, SendR, SendS, SendT, SendU, SendV, SendW, SendX, SendY, SendZ, SendLWIN, SendRWIN, SendAPPS, SendSLEEP, SendNUMPAD0, SendNUMPAD1, SendNUMPAD2, SendNUMPAD3, SendNUMPAD4, SendNUMPAD5, SendNUMPAD6, SendNUMPAD7, SendNUMPAD8, SendNUMPAD9, SendMULTIPLY, SendADD, SendSEPARATOR, SendSUBTRACT, SendDECIMAL, SendDIVIDE, SendF1, SendF2, SendF3, SendF4, SendF5, SendF6, SendF7, SendF8, SendF9, SendF10, SendF11, SendF12, SendF13, SendF14, SendF15, SendF16, SendF17, SendF18, SendF19, SendF20, SendF21, SendF22, SendF23, SendF24, SendNUMLOCK, SendSCROLL, SendLeftShift, SendRightShift, SendLeftControl, SendRightControl, SendLMENU, SendRMENU);
                                SendMouse.SetKM(KeyboardMouseDriverType, MouseMoveX, MouseMoveY, MouseAbsX, MouseAbsY, MouseDesktopX, MouseDesktopY);
                                Thread.Sleep(sleeptime);
                            }
                        }
                        public void Close()
                        {
                            try
                            {
                                running = false;
                                Thread.Sleep(100);
                                mStream.Close();
                                handle.Close();
                                wiimotedisconnect();
                            }
                            catch { }
                        }
                        private static double Scale(double value, double min, double max, double minScale, double maxScale)
                        {
                            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
                            return scaled;
                        }
                        private static void taskD()
                        {
                            while (running)
                            {
                                try
                                {
                                    mStream.Read(aBuffer, 0, 22);
                                    reconnectingwiimotebool = false;
                                }
                                catch { }
                            }
                        }
                        private const string vendor_id = ""57e"", vendor_id_ = ""057e"", product_r1 = ""0330"", product_r2 = ""0306"", product_l = ""2006"";
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
                        [DllImport(""MotionInputPairing.dll"", EntryPoint = ""wiimoteconnect"")]
                        public static extern bool wiimoteconnect();
                        [DllImport(""MotionInputPairing.dll"", EntryPoint = ""wiimotedisconnect"")]
                        public static extern bool wiimotedisconnect();
                        private static bool ScanWiimote()
                        {
                            int index = 0;
                            Guid guid;
                            HidD_GetHidGuid(out guid);
                            IntPtr hDevInfo = SetupDiGetClassDevs(ref guid, null, new IntPtr(), 0x00000010);
                            SP_DEVICE_INTERFACE_DATA diData = new SP_DEVICE_INTERFACE_DATA();
                            diData.cbSize = Marshal.SizeOf(diData);
                            while (SetupDiEnumDeviceInterfaces(hDevInfo, new IntPtr(), ref guid, index, ref diData))
                            {
                                UInt32 size;
                                SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, new IntPtr(), 0, out size, new IntPtr());
                                SP_DEVICE_INTERFACE_DETAIL_DATA diDetail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                                diDetail.cbSize = 5;
                                if (SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, ref diDetail, size, out size, new IntPtr()))
                                {
                                    if ((diDetail.DevicePath.Contains(vendor_id) | diDetail.DevicePath.Contains(vendor_id_)) & (diDetail.DevicePath.Contains(product_r1) | diDetail.DevicePath.Contains(product_r2)))
                                    {
                                        path = diDetail.DevicePath;
                                        WiimoteFound(path);
                                        WiimoteFound(path);
                                        WiimoteFound(path);
                                        return true;
                                    }
                                }
                                index++;
                            }
                            return false;
                        }
                        private static void WiimoteFound(string path)
                        {
                            do
                            {
                                handle = CreateFile(path, FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, (uint)EFileAttributes.Overlapped, IntPtr.Zero);
                                WriteData(handle, IR, (int)REGISTER_IR, new byte[] { 0x08 }, 1);
                                WriteData(handle, Type, (int)REGISTER_EXTENSION_INIT_1, new byte[] { 0x55 }, 1);
                                WriteData(handle, Type, (int)REGISTER_EXTENSION_INIT_2, new byte[] { 0x00 }, 1);
                                WriteData(handle, Type, (int)REGISTER_MOTIONPLUS_INIT, new byte[] { 0x04 }, 1);
                                ReadData(handle, 0x0016, 7);
                                ReadData(handle, (int)REGISTER_EXTENSION_TYPE, 6);
                                ReadData(handle, (int)REGISTER_EXTENSION_CALIBRATION, 16);
                                ReadData(handle, (int)REGISTER_EXTENSION_CALIBRATION, 32);
                            }
                            while (handle.IsInvalid);
                            mStream = new FileStream(handle, FileAccess.ReadWrite, 22, true);
                        }
                        private static void ReadData(SafeFileHandle _hFile, int address, short size)
                        {
                            mBuff[0] = (byte)ReadMemory;
                            mBuff[1] = (byte)((address & 0xff000000) >> 24);
                            mBuff[2] = (byte)((address & 0x00ff0000) >> 16);
                            mBuff[3] = (byte)((address & 0x0000ff00) >> 8);
                            mBuff[4] = (byte)(address & 0x000000ff);
                            mBuff[5] = (byte)((size & 0xff00) >> 8);
                            mBuff[6] = (byte)(size & 0xff);
                            HidD_SetOutputReport(_hFile.DangerousGetHandle(), mBuff, 22);
                        }
                        private static void WriteData(SafeFileHandle _hFile, byte mbuff, int address, byte[] buff, short size)
                        {
                            mBuff[0] = (byte)mbuff;
                            mBuff[1] = (byte)(0x04);
                            mBuff[2] = (byte)IRExtensionAccel;
                            Array.Copy(buff, 0, mBuff, 3, 1);
                            HidD_SetOutputReport(_hFile.DangerousGetHandle(), mBuff, 22);
                            mBuff[0] = (byte)WriteMemory;
                            mBuff[1] = (byte)(((address & 0xff000000) >> 24));
                            mBuff[2] = (byte)((address & 0x00ff0000) >> 16);
                            mBuff[3] = (byte)((address & 0x0000ff00) >> 8);
                            mBuff[4] = (byte)((address & 0x000000ff) >> 0);
                            mBuff[5] = (byte)size;
                            Array.Copy(buff, 0, mBuff, 6, 1);
                            HidD_SetOutputReport(_hFile.DangerousGetHandle(), mBuff, 22);
                        }
                    }
                }";
        private void Form1_Load(object sender, EventArgs e)
        {
            parameters = new System.CodeDom.Compiler.CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            parameters.ReferencedAssemblies.Add("keyboards.dll");
            parameters.ReferencedAssemblies.Add("mouses.dll");
            provider = new Microsoft.CSharp.CSharpCodeProvider();
            results = provider.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();
                foreach (System.CodeDom.Compiler.CompilerError error in results.Errors)
                {
                    sb.AppendLine(String.Format("Error ({0}) : {1}", error.ErrorNumber, error.ErrorText));
                }
                MessageBox.Show("Script Error :\n\r" + sb.ToString());
                return;
            }
            assembly = results.CompiledAssembly;
            program = assembly.GetType("StringToCode.FooClass");
            obj = Activator.CreateInstance(program);
            program.InvokeMember("Load", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { });
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            program.InvokeMember("Close", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { });
        }
    }
}