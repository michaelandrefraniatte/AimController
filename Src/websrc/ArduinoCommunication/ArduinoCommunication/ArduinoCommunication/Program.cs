using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;

namespace ArduinoCommunication
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort port = GetArduinoPort();
            if (port == null)
            {
                Console.WriteLine("Couldn't find Arduino!");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Arduino found at \"{0}\"", port.PortName);
            }

            Random ran = new Random();
            Stopwatch w = new Stopwatch();
            w.Start();
            int fails = 0;
            int runs = 1000;

            //Instruct the arduino to perform some calculations!
            for (int i = 0; i < runs; i++)
            {
                Message_t msgIn = new Message_t(), msgOut = new Message_t();
                msgOut.Magic = Message_t.MESSAGE_MAGIC;
                msgOut.Command = Command_t.CalcPlusF;

                msgOut.Vec3f.X = 100 + (runs % 100) + 0.7f;
                msgOut.Vec3f.Y = 100 + (runs % 15) + 0.5f;

                Message_t.WriteMessage(port, ref msgOut);
                //Wait for the arduino to respond, shouldn't take too long
                while (!Message_t.MessageReady(port)) ;
                Message_t.ReadMessage(port, ref msgIn);

                //Check for valid magic and response
                if (msgIn.Magic != Message_t.MESSAGE_MAGIC)
                {
                    fails++;
                    continue;
                }
                if (msgIn.Command != Command_t.CalcResult)
                {
                    fails++;
                    continue;
                }
                else
                {
                    //Check whether the result is correct!
                    if (msgIn.Vec3f.Z != msgOut.Vec3f.X + msgOut.Vec3f.Y)
                    {
                        fails++;
                        continue;
                    }
                }
            }
            w.Stop();
            Console.WriteLine("Calculating stuff {3} times took {0}s, {1} fails, exchanging {2} bytes in total",
                Math.Round(TimeSpan.FromMilliseconds(w.ElapsedMilliseconds).TotalSeconds, 2),
                fails,
                runs * Marshal.SizeOf(typeof(Message_t)),
                runs);
            Console.ReadLine();
        }

        private unsafe static SerialPort GetArduinoPort()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                SerialPort p = new SerialPort(port, 9600);
                //Prepare messages
                Message_t msgIn = new Message_t(), msgOut = new Message_t();
                msgOut.Magic = Message_t.MESSAGE_MAGIC;
                msgOut.Command = Command_t.Ping;

                try
                {
                    p.Open();
                    //Write ping-message
                    Message_t.WriteMessage(p, ref msgOut);

                    //Wait about a second for the arduino to reply
                    Thread.Sleep(1000);

                    //No response within a second, go check the next port
                    if (!Message_t.MessageReady(p))
                        continue;

                    //Read message from serial, check for valid magic and reponse
                    Message_t.ReadMessage(p, ref msgIn);
                    if (msgIn.Magic != Message_t.MESSAGE_MAGIC)
                        continue;

                    if (msgIn.Command != Command_t.Pong)
                        continue;

                    return p;
                }
                catch
                {
                    //Close port in case we ran into any exception (should never happen though)
                    p.Close();
                }
            }
            return null;
        }
    }
}