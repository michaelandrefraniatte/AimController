using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace ReceiveData
{
    class Program
    {
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        public unsafe static extern uint TimeBeginPeriod(uint ms);
        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod")]
        public unsafe static extern uint TimeEndPeriod(uint ms);
        [DllImport("ntdll.dll", EntryPoint = "NtSetTimerResolution")]
        public unsafe static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
        [DllImport("kernel32.dll", SetLastError = true)]
        private unsafe static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
        private unsafe static ConsoleEventDelegate handler;
        private delegate bool ConsoleEventDelegate(int eventType);
        public unsafe static uint CurrentResolution = 0;
        private static SerialPort arduinoSerial = new SerialPort();
        private static bool isxory;
        private static UInt32 result;
        private static double x, y;
        private static string xy;
        private void OnKeyDown(Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                const string message = "• Author: Michaël André Franiatte.\n\r\n\r• Contact: michael.franiatte@gmail.com.\n\r\n\r• Publisher: https://github.com/michaelandrefraniatte.\n\r\n\r• Copyrights: All rights reserved, no permissions granted.\n\r\n\r• License: Not open source, not free of charge to use.";
                const string caption = "About";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        static unsafe void Main(string[] args)
        {
            TimeBeginPeriod(1);
            NtSetTimerResolution(1, true, ref CurrentResolution);
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);
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
                    Console.ReadLine();
                }
                catch { }
            }
        }
        public unsafe static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                TimeEndPeriod(1);
                arduinoSerial.DataReceived -= arduinoSerial_DataReceived;
                arduinoSerial.Close();
                Thread.Sleep(10000);
            }
            return false;
        }
        static void arduinoSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
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
                if (!isxory) { 
                    Console.WriteLine("x0 : " + x.ToString() + ", y0 : " + y.ToString());
                    isxory = true;
                }
                else
                {
                    Console.WriteLine("x1 : " + x.ToString() + ", y1 : " + y.ToString());
                    isxory = false;
                }
            }
        }
    }
}
