using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;

namespace ciine_ga_ds
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
                using System.Runtime.InteropServices;
                using System.Threading;
                using System.Threading.Tasks;
                using System.Windows;
                using System.Windows.Forms;
                using System.Reflection;
                using controllers;
                using DualSenseAPI;
                using DualSenseAPI.State;
                using DualSenseAPI.Util;
                using Device.Net;
                using System.Numerics;
                using System.Collections.Generic;
                using System.Runtime;
                using System.Linq;
                namespace StringToCode
                {
                    public class FooClass 
                    { 
                        [DllImport(""winmm.dll"", EntryPoint = ""timeBeginPeriod"")]
                        private static extern uint TimeBeginPeriod(uint ms);
                        [DllImport(""winmm.dll"", EntryPoint = ""timeEndPeriod"")]
                        private static extern uint TimeEndPeriod(uint ms);
                        [DllImport(""ntdll.dll"", EntryPoint = ""NtSetTimerResolution"")]
                        private static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
                        private static uint CurrentResolution = 0;
                        private static bool running;
                        private static bool back, start, A, B, X, Y, up, left, down, right, leftstick, rightstick, leftbumper, rightbumper, lefttrigger, righttrigger, xbox;
                        private static double leftstickx, leftsticky, rightstickx, rightsticky, lefttriggerposition, righttriggerposition;
                        private double statex = 0f, statey = 0f, mousex = 0f, mousey = 0f, mousestatex = 0f, mousestatey = 0f, dzx = 0.0f, dzy = 0.0f, viewpower1x = 0f, viewpower2x = 1f, viewpower3x = 0f, viewpower1y = 0.25f, viewpower2y = 0.75f, viewpower3y = 0f;
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
                            ds = ChooseController();
                            if (ds != null)
                            {
                                Task.Run(() => MainAsyncPolling());
                                ScpBus.LoadController();
                                Task.Run(() => taskX());
                            }
                        }
                        private void taskX()
                        {
                            while (running)
                            {
                                wheelPos = ProcessStateLogic(ds.InputState, wheelPos);
                                statex = PS5ControllerGyroX * 15f;
                                statey = PS5ControllerGyroY * 15f;
                                if (statex > 0f)
                                    mousestatex = Scale(statex, 0f, 32767f, dzx / 100f * 32767f, 32767f);
                                if (statex < 0f)
                                    mousestatex = Scale(statex, -32767f, 0f, -32767f, -(dzx / 100f) * 32767f);
                                if (statey > 0f)
                                    mousestatey = Scale(statey, 0f, 32767f, dzy / 100f * 32767f, 32767f);
                                if (statey < 0f)
                                    mousestatey = Scale(statey, -32767f, 0f, -32767f, -(dzy / 100f) * 32767f);
                                mousex = mousestatex + PS5ControllerRightStickX * 32767f;
                                mousey = mousestatey + PS5ControllerRightStickY * 32767f;
                                statex = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
                                statey = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
                                rightstickx = -statex;
                                rightsticky = -statey;
                                mousex = -PS5ControllerLeftStickX * 1024f;
                                mousey = -PS5ControllerLeftStickY * 1024f;
                                leftstickx = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
                                leftsticky = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
                                down = PS5ControllerButtonDPadDownPressed;
                                left = PS5ControllerButtonDPadLeftPressed;
                                right = PS5ControllerButtonDPadRightPressed;
                                up = PS5ControllerButtonDPadUpPressed;
                                leftstick = PS5ControllerButtonL3Pressed;
                                rightstick = PS5ControllerButtonR3Pressed;
                                B = PS5ControllerButtonCrossPressed;
                                A = PS5ControllerButtonCirclePressed;
                                Y = PS5ControllerButtonSquarePressed;
                                X = PS5ControllerButtonTrianglePressed;
                                lefttriggerposition = PS5ControllerLeftTriggerPosition * 255;
                                righttriggerposition = PS5ControllerRightTriggerPosition * 255;
                                leftbumper = PS5ControllerButtonL1Pressed;
                                rightbumper = PS5ControllerButtonR1Pressed;
                                back = PS5ControllerButtonLogoPressed;
                                start = PS5ControllerButtonTouchpadPressed;
                                ScpBus.SetController(back, start, A, B, X, Y, up, left, down, right, leftstick, rightstick, leftbumper, rightbumper, lefttrigger, righttrigger, leftstickx, leftsticky, rightstickx, rightsticky, lefttriggerposition, righttriggerposition, xbox);
                                Thread.Sleep(sleeptime);
                            }
                        }
                        public void Close()
                        {
                            try
                            {
                                running = false;
                                Thread.Sleep(100);
                                ScpBus.UnLoadController();
                            }
                            catch { }
                        }
                        private static double Scale(double value, double min, double max, double minScale, double maxScale)
                        {
                            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
                            return scaled;
                        }
                        public static bool PS5ControllerButtonCrossPressed;
                        public static bool PS5ControllerButtonCirclePressed;
                        public static bool PS5ControllerButtonSquarePressed;
                        public static bool PS5ControllerButtonTrianglePressed;
                        public static bool PS5ControllerButtonDPadUpPressed;
                        public static bool PS5ControllerButtonDPadRightPressed;
                        public static bool PS5ControllerButtonDPadDownPressed;
                        public static bool PS5ControllerButtonDPadLeftPressed;
                        public static bool PS5ControllerButtonL1Pressed;
                        public static bool PS5ControllerButtonR1Pressed;
                        public static bool PS5ControllerButtonL2Pressed;
                        public static bool PS5ControllerButtonR2Pressed;
                        public static bool PS5ControllerButtonL3Pressed;
                        public static bool PS5ControllerButtonR3Pressed;
                        public static bool PS5ControllerButtonCreatePressed;
                        public static bool PS5ControllerButtonMenuPressed;
                        public static bool PS5ControllerButtonLogoPressed;
                        public static bool PS5ControllerButtonTouchpadPressed;
                        public static bool PS5ControllerButtonMicPressed;
                        public static bool PS5ControllerTouchOn;
                        public static bool PS5ControllerButtonACC, PS5ControllerRollLeft, PS5ControllerRollRight;
                        private static double PS5ControllerLeftStickX, PS5ControllerLeftStickY, PS5ControllerRightStickX, PS5ControllerRightStickY, PS5ControllerRightTriggerPosition, PS5ControllerLeftTriggerPosition, PS5ControllerTouchX, PS5ControllerTouchY;
                        public static System.Collections.Generic.List<double> PS5ValListX = new System.Collections.Generic.List<double>(), PS5ValListY = new System.Collections.Generic.List<double>();
                        public static bool PS5ControllerAccelCenter;
                        public static double PS5ControllerAccelX, PS5ControllerAccelY, PS5ControllerGyroX, PS5ControllerGyroY;
                        public static Vector3 gyr_gPS5 = new Vector3();
                        public static Vector3 acc_gPS5 = new Vector3();
                        public static Vector3 InitDirectAnglesPS5, DirectAnglesPS5;
                        public static float acc_gcalibrationPS5X, acc_gcalibrationPS5Y, acc_gcalibrationPS5Z;
                        private static DualSense ds;
                        private static int wheelPos = 0;
                        static int ProcessStateLogic(DualSenseInputState dss, int wheelPos)
                        {
                            PS5ControllerLeftStickX = dss.LeftAnalogStick.X;
                            PS5ControllerLeftStickY = dss.LeftAnalogStick.Y;
                            PS5ControllerRightStickX = -dss.RightAnalogStick.X;
                            PS5ControllerRightStickY = -dss.RightAnalogStick.Y;
                            PS5ControllerLeftTriggerPosition = dss.L2;
                            PS5ControllerRightTriggerPosition = dss.R2;
                            PS5ControllerTouchX = dss.Touchpad1.X;
                            PS5ControllerTouchY = dss.Touchpad1.Y;
                            PS5ControllerTouchOn = dss.Touchpad1.IsDown;
                            gyr_gPS5.X = dss.Gyro.Z;
                            gyr_gPS5.Y = -dss.Gyro.X;
                            gyr_gPS5.Z = -dss.Gyro.Y;
                            PS5ControllerGyroX = gyr_gPS5.Z;
                            PS5ControllerGyroY = gyr_gPS5.Y;
                            acc_gPS5 = new Vector3(dss.Accelerometer.X, dss.Accelerometer.Z, dss.Accelerometer.Y);
                            if (PS5ControllerAccelCenter)
                                InitDirectAnglesPS5 = acc_gPS5;
                            DirectAnglesPS5 = acc_gPS5 - InitDirectAnglesPS5;
                            PS5ControllerAccelX = -(DirectAnglesPS5.Y + DirectAnglesPS5.Z) / 6f;
                            PS5ControllerAccelY = DirectAnglesPS5.X / 6f;
                            IEnumerable<string> pressedButtons = dss.GetType().GetProperties()
                                .Where(p => p.Name.EndsWith(""Button"") && p.PropertyType == typeof(bool))
                                .Where(p => (bool)p.GetValue(dss))
                                .Select(p => p.Name.Replace(""Button"", """"));
                            string joined = string.Join("", "", pressedButtons);
                            if (joined.Contains(""Cross""))
                                PS5ControllerButtonCrossPressed = true;
                            else
                                PS5ControllerButtonCrossPressed = false;
                            if (joined.Contains(""Circle""))
                                PS5ControllerButtonCirclePressed = true;
                            else
                                PS5ControllerButtonCirclePressed = false;
                            if (joined.Contains(""Square""))
                                PS5ControllerButtonSquarePressed = true;
                            else
                                PS5ControllerButtonSquarePressed = false;
                            if (joined.Contains(""Triangle""))
                                PS5ControllerButtonTrianglePressed = true;
                            else
                                PS5ControllerButtonTrianglePressed = false;
                            if (joined.Contains(""DPadUp""))
                                PS5ControllerButtonDPadUpPressed = true;
                            else
                                PS5ControllerButtonDPadUpPressed = false;
                            if (joined.Contains(""DPadRight""))
                                PS5ControllerButtonDPadRightPressed = true;
                            else
                                PS5ControllerButtonDPadRightPressed = false;
                            if (joined.Contains(""DPadDown""))
                                PS5ControllerButtonDPadDownPressed = true;
                            else
                                PS5ControllerButtonDPadDownPressed = false;
                            if (joined.Contains(""DPadLeft""))
                                PS5ControllerButtonDPadLeftPressed = true;
                            else
                                PS5ControllerButtonDPadLeftPressed = false;
                            if (joined.Contains(""L1""))
                                PS5ControllerButtonL1Pressed = true;
                            else
                                PS5ControllerButtonL1Pressed = false;
                            if (joined.Contains(""R1""))
                                PS5ControllerButtonR1Pressed = true;
                            else
                                PS5ControllerButtonR1Pressed = false;
                            if (joined.Contains(""L2""))
                                PS5ControllerButtonL2Pressed = true;
                            else
                                PS5ControllerButtonL2Pressed = false;
                            if (joined.Contains(""R2""))
                                PS5ControllerButtonR2Pressed = true;
                            else
                                PS5ControllerButtonR2Pressed = false;
                            if (joined.Contains(""L3""))
                                PS5ControllerButtonL3Pressed = true;
                            else
                                PS5ControllerButtonL3Pressed = false;
                            if (joined.Contains(""R3""))
                                PS5ControllerButtonR3Pressed = true;
                            else
                                PS5ControllerButtonR3Pressed = false;
                            if (joined.Contains(""Create""))
                                PS5ControllerButtonCreatePressed = true;
                            else
                                PS5ControllerButtonCreatePressed = false;
                            if (joined.Contains(""Menu""))
                                PS5ControllerButtonMenuPressed = true;
                            else
                                PS5ControllerButtonMenuPressed = false;
                            if (joined.Contains(""Logo""))
                                PS5ControllerButtonLogoPressed = true;
                            else
                                PS5ControllerButtonLogoPressed = false;
                            if (joined.Contains(""Touchpad""))
                                PS5ControllerButtonTouchpadPressed = true;
                            else
                                PS5ControllerButtonTouchpadPressed = false;
                            if (joined.Contains(""Mic""))
                                PS5ControllerButtonMicPressed = true;
                            else
                                PS5ControllerButtonMicPressed = false;
                            return (wheelPos + 5) % 384;
                        }
                        static T Choose<T>(T[] ts)
                        {
                            return ts[0];
                        }
                        static DualSense ChooseController()
                        {
                            DualSense[] available = DualSense.EnumerateControllers().ToArray();
                            if (available.Length == 0)
                            {
                                return null;
                            }
                            return Choose(available);
                        }
                        static void MainAsyncPolling()
                        {
                            ds.Acquire();
                            while (running)
                            {
                                ds.BeginPolling();
                                Thread.Sleep(1);
                            }
                            ds.EndPolling();
                            ds.Release();
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
            parameters.ReferencedAssemblies.Add("System.Runtime.dll");
            parameters.ReferencedAssemblies.Add("System.Numerics.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("netstandard.dll");
            parameters.ReferencedAssemblies.Add("Hid.Net.dll");
            parameters.ReferencedAssemblies.Add("Device.Net.dll");
            parameters.ReferencedAssemblies.Add("Dualsense.dll");
            parameters.ReferencedAssemblies.Add("controllers.dll");
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