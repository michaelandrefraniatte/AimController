﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;
using System.Runtime.InteropServices;
namespace CameraPositionning
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
        private static double x, y, x0, y0, x1, y1;
        private static string xy;
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
                if (!isxory)
                {
                    x0 = x;
                    y0 = y;
                    Console.WriteLine("x0 : " + (x0 - 1000f).ToString() + ", y0 : " + y0.ToString());
                    isxory = true;
                }
                else
                {
                    x1 = x;
                    y1 = y;
                    Console.WriteLine("x1 : " + (x1 - 1000f).ToString() + ", y1 : " + y1.ToString());
                    isxory = false;
                }
            }
        }
        private unsafe static double Scale(double value, double min, double max, double minScale, double maxScale)
        {
            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
            return scaled;
        }
    }
}