using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
 
namespace SerialCommunication
{
    public enum Command_t : byte
    {
        InvalidMessage = 0,
        InvalidRequest,
        Ping,
        Pong,
        KeyboardPress,
        KeyboardRelease,
        MouseSetScreenSize,
        MouseMove,
        MouseMoveTo,
        MouseMoveAs,
        MouseSetButtons,
        MouseScroll
    };
 
    [StructLayout(LayoutKind.Sequential)]
    public struct Data_t
    {
        public int d1;
        public int d2;
        public int d3;
    }
 
    [StructLayout(LayoutKind.Explicit)]
    unsafe struct Message_t
    {
        public static ushort MESSAGE_MAGIC = 0xBEEF;
 
        [FieldOffset(0)]
        public ushort Magic;
 
        [FieldOffset(2)]
        public Command_t Command;
 
        [FieldOffset(4)]
        public Data_t Data;
 
        public static bool MessageReady(SerialPort port)
        {
            return port.BytesToRead >= Marshal.SizeOf(typeof(Message_t));
        }
 
        public unsafe static void ReadMessage(SerialPort port, ref Message_t msg)
        {
            byte[] data = new byte[Marshal.SizeOf(typeof(Message_t))];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)port.ReadByte();
 
            fixed (byte* b = data)
                msg = (Message_t)Marshal.PtrToStructure((IntPtr)b, typeof(Message_t));
        }
 
        public unsafe static void WriteMessage(SerialPort port, ref Message_t msg)
        {
            byte[] data = new byte[Marshal.SizeOf(typeof(Message_t))];
 
            fixed (byte* b = data)
                Marshal.StructureToPtr(msg, (IntPtr)b, true);
 
            port.Write(data, 0, data.Length);
        }
    }
}