using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;

namespace ciine
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
                using System.Diagnostics;
                using controllers;
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
                        private static bool controller1_send_back, controller1_send_start, controller1_send_A, controller1_send_B, controller1_send_X, controller1_send_Y, controller1_send_up, controller1_send_left, controller1_send_down, controller1_send_right, controller1_send_leftstick, controller1_send_rightstick, controller1_send_leftbumper, controller1_send_rightbumper, controller1_send_xbox;
                        private static double controller1_send_leftstickx, controller1_send_leftsticky, controller1_send_rightstickx, controller1_send_rightsticky, controller1_send_lefttriggerposition, controller1_send_righttriggerposition;
                        private const double REGISTER_IR = 0x04b00030, REGISTER_EXTENSION_INIT_1 = 0x04a400f0, REGISTER_EXTENSION_INIT_2 = 0x04a400fb, REGISTER_EXTENSION_TYPE = 0x04a400fa, REGISTER_EXTENSION_CALIBRATION = 0x04a40020, REGISTER_MOTIONPLUS_INIT = 0x04a600fe;
                        private static double WiimoteRawValuesX, WiimoteRawValuesY, WiimoteRawValuesZ, calibrationinit;
                        private static bool WiimoteButtonStateA, WiimoteButtonStateB, WiimoteButtonStateMinus, WiimoteButtonStateHome, WiimoteButtonStatePlus, WiimoteButtonStateOne, WiimoteButtonStateTwo, WiimoteButtonStateUp, WiimoteButtonStateDown, WiimoteButtonStateLeft, WiimoteButtonStateRight, ISWIIMOTE, running, reconnectingwiimotebool, WiimoteNunchuckStateC, WiimoteNunchuckStateZ;                  
                        private static string path;
                        private static byte[] buff = new byte[] { 0x55 }, mBuff = new byte[22], aBuffer = new byte[22];
                        private const byte Type = 0x12, IR = 0x13, WriteMemory = 0x16, ReadMemory = 0x16, IRExtensionAccel = 0x37;
                        private static uint CurrentResolution = 0;
                        private static FileStream mStream;
                        private static SafeFileHandle handle = null;
                        private static double mousex = 0f, mousey = 0f, dzx = 15.0f, dzy = 0f;
                        private static bool[] getstate = new bool[12];
                        private static int[] pollcount = new int[12];
                        private static int[] keys12345 = new int[12];
                        private static int[] keys54321 = new int[12];
                        private static double[] mousexp = new double[12];
                        private static double[] mouseyp = new double[12];
                        private static int sleeptime = 1;
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
                        public static void Main()
                        {
                            TimeBeginPeriod(1);
                            NtSetTimerResolution(1, true, ref CurrentResolution);
                            SetProcessPriority();
                            Task.Run(() => Start());
                        }
                        private static void SetProcessPriority()
                        {
                            using (Process p = Process.GetCurrentProcess())
                            {
                                p.PriorityClass = ProcessPriorityClass.RealTime;
                            }
                        }
                        private static void Start()
                        {
                            running = true;
                            do
                                Thread.Sleep(1);
                            while (!wiimoteconnect());
                            ScanWiimote();
                            Task.Run(() => taskD());
                            Thread.Sleep(1000);
                            calibrationinit = -aBuffer[4] + 135f;
                            ScpBus.LoadController();
                            Task.Run(() => taskX());
                        }
                        private static void taskX()
                        {
                            while (running)
                            {
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
                                if (WiimoteRawValuesY > 0f)
                                    mousex = Scale(WiimoteRawValuesY * 45f, 0f, 1024f, (dzx / 100f) * 1024f, 1024f);
                                if (WiimoteRawValuesY < 0f)
                                    mousex = Scale(WiimoteRawValuesY * 45f, -1024f, 0f, -1024f, -(dzx / 100f) * 1024f);
                                if (WiimoteRawValuesX > 0f)
                                    mousey = Scale(WiimoteRawValuesX * 90f, 0f, 1024f, (dzy / 100f) * 1024f, 1024f);
                                if (WiimoteRawValuesX < 0f)
                                    mousey = Scale(WiimoteRawValuesX * 90f, -1024f, 0f, -1024f, -(dzy / 100f) * 1024f);
                                controller1_send_leftstickx   = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
                                controller1_send_leftsticky   = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
                                controller1_send_down         = WiimoteButtonStateLeft;
                                controller1_send_left         = WiimoteButtonStateUp;
                                controller1_send_right        = WiimoteButtonStateDown;
                                controller1_send_up           = WiimoteButtonStateRight;
                                controller1_send_A            = WiimoteButtonStateB;
                                controller1_send_B            = WiimoteButtonStateOne & WiimoteButtonStateTwo;  
                                controller1_send_Y            = WiimoteButtonStateA;
                                controller1_send_X            = WiimoteButtonStateHome;
                                controller1_send_rightbumper  = WiimoteButtonStatePlus;
                                controller1_send_leftbumper   = WiimoteButtonStateMinus;
                                controller1_send_lefttriggerposition  = WiimoteButtonStateOne ? 255 : 0;
                                controller1_send_righttriggerposition = WiimoteButtonStateTwo ? 255 : 0;
                                ScpBus.SetController(controller1_send_back, controller1_send_start, controller1_send_A, controller1_send_B, controller1_send_X, controller1_send_Y, controller1_send_up, controller1_send_left, controller1_send_down, controller1_send_right, controller1_send_leftstick, controller1_send_rightstick, controller1_send_leftbumper, controller1_send_rightbumper, controller1_send_leftstickx, controller1_send_leftsticky, controller1_send_rightstickx, controller1_send_rightsticky, controller1_send_lefttriggerposition, controller1_send_righttriggerposition, controller1_send_xbox);
                                Thread.Sleep(sleeptime);
                            }
                        }
                        public static void Close()
                        {
                            try
                            {
                                running = false;
                                Thread.Sleep(100);
                                ScpBus.UnLoadController();
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
            parameters.GenerateExecutable = true;
            parameters.GenerateInMemory = false;
            parameters.IncludeDebugInformation = false;
            parameters.CompilerOptions = "/optimize";
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            parameters.ReferencedAssemblies.Add("controllers.dll");
            provider = new Microsoft.CSharp.CSharpCodeProvider();
            results = provider.CompileAssemblyFromSource(parameters, code);
            assembly = results.CompiledAssembly;
            program = assembly.GetType("StringToCode.FooClass");
            obj = Activator.CreateInstance(program);
            program.InvokeMember("Main", BindingFlags.IgnoreReturn | BindingFlags.InvokeMethod, null, obj, new object[] { });
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            program.InvokeMember("Close", BindingFlags.IgnoreReturn | BindingFlags.InvokeMethod, null, obj, new object[] { });
        }
    }
}