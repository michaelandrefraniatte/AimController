using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
 
namespace SerialCommunication
{
    class Teensy
    {
        public ushort Magic;
        public SerialPort Port;
 
        public Teensy(SerialPort port, ushort magic)
        {
            Port = port;
            Magic = magic;
        }
 
        public Teensy(ushort magic)
        {
            Port = GetArduinoPort();
            Magic = magic;
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
                    Thread.Sleep(100);
 
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
 
        private void sendCommand(Command_t command, int d1, int d2, int d3)
        {
            Message_t msgOut = new Message_t();
            msgOut.Magic = Magic;
            msgOut.Command = command;
            msgOut.Data.d1 = d1;
            msgOut.Data.d2 = d2;
            msgOut.Data.d3 = d3;
            Message_t.WriteMessage(Port, ref msgOut);
        }
        public void KeyboardPress(int key)
        {
            sendCommand(Command_t.KeyboardPress, key, 0, 0);
        }
        public void KeyboardRelease(int key)
        {
            sendCommand(Command_t.KeyboardRelease, key, 0, 0);
        }
        public void MouseSetScreenSize()
        {
            sendCommand(Command_t.MouseSetScreenSize, 0, 0, 0);
        }
        public void MouseMove(int x, int y)
        {
            sendCommand(Command_t.MouseMove, x, y, 0);
        }
        public void MouseMoveTo(int x, int y)
        {
            sendCommand(Command_t.MouseMoveTo, x, y, 0);
        }
        public void MouseMoveAs(int x, int y)
        {
            sendCommand(Command_t.MouseMoveAs, x, y, 0);
        }
        public void MouseSetButtons(int left, int mid, int right)
        {
            sendCommand(Command_t.MouseSetButtons, left, mid, right);
        }
        public void MouseScroll(int scroll)
        {
            sendCommand(Command_t.MouseScroll, scroll, 0, 0);
        }
    }
}