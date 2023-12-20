using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialCommunication
{
    class Program
    {
        static void Main(string[] args)
        {
            Teensy teensy = new Teensy(Message_t.MESSAGE_MAGIC);

            if (teensy.Port == null)
            {
                Console.WriteLine("Unable to find any teensy device.");
                Console.WriteLine("Press any key to exit...");
                Console.Read();
                return;
            }
            else
            {
                Console.WriteLine("Found teensy at port " + teensy.Port.PortName);
            }
            Thread.Sleep(1000);

            teensy.MouseSetScreenSize();
            for (int i = 0; i < 1000; i++)
            {
                teensy.MouseMove(1, 1);
                Thread.Sleep(10);
            }

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}