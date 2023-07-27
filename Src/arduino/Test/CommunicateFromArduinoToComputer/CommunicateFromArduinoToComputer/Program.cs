using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace CommunicateFromArduinoToComputer
{
    class Program
    {
        static SerialPort port;
        public static void Main()
        {
            port = new SerialPort("COM5", 9600);//Set your board COMmySerial
            port.DtrEnable = true;
            port.Open();
            while (true)
            {
                string a = port.ReadExisting();
                Console.WriteLine(a);
                Thread.Sleep(200);
            }
        }
    }
}
