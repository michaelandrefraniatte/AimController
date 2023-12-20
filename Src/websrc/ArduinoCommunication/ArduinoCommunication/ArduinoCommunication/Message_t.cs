using System;
using System.IO.Ports;
using System.Runtime.InteropServices;
 
namespace ArduinoCommunication
{
    public enum Command_t : byte
    {
        InvalidMessage = 0,
        InvalidRequest,
        Ping,
        Pong,
        CalcResult,
        CalcPlusF
    };
 
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3f_t
    {
        public float X;
        public float Y;
        public float Z;
    }
 
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3i_t
    {
        public int X;
        public int Y;
        public int Z;
    }
 
    [StructLayout(LayoutKind.Explicit)]
    unsafe struct Message_t
    {
        public static ushort MESSAGE_MAGIC = 0xBEEF;
 
        [FieldOffset(0)]
        public ushort Magic;
 
        [FieldOffset(2)]
        public Command_t Command;
 
        [FieldOffset(3)]
        public byte Parameter;
        
        [FieldOffset(4)]
        public fixed byte Data[12];
 
        [FieldOffset(4)]
        public Vec3f_t Vec3f;
 
        [FieldOffset(4)]
        public Vec3i_t Vec3i;
 
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