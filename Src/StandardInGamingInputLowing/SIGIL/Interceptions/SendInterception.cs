using System;
using System.Runtime.InteropServices;

namespace Interceptions
{
    public class SendInterception
    {
        [DllImport("user32.dll")]
        public static extern void SetPhysicalCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        public static extern void SetCaretPos(int X, int Y);
        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int X, int Y);
        public static int[] wd = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static int[] wu = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
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
        public static void UnLoadKM(Input input, int keyboard_1_id, int mouse_1_id)
        {
            SetKM(0, 0, input, keyboard_1_id, mouse_1_id, 0, 0, 0, 0, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
        }
        public static void SetKM(double MouseDesktopX, double MouseDesktopY, Input input, int keyboard_id, int mouse_id, double deltaX, double deltaY, double x, double y, bool SendLeftClick, bool SendRightClick, bool SendMiddleClick, bool SendWheelUp, bool SendWheelDown, bool SendCANCEL, bool SendBACK, bool SendTAB, bool SendCLEAR, bool SendRETURN, bool SendSHIFT, bool SendCONTROL, bool SendMENU, bool SendCAPITAL, bool SendESCAPE, bool SendSPACE, bool SendPRIOR, bool SendNEXT, bool SendEND, bool SendHOME, bool SendLEFT, bool SendUP, bool SendRIGHT, bool SendDOWN, bool SendSNAPSHOT, bool SendINSERT, bool SendNUMPADDEL, bool SendNUMPADINSERT, bool SendHELP, bool SendAPOSTROPHE, bool SendBACKSPACE, bool SendPAGEDOWN, bool SendPAGEUP, bool SendFIN, bool SendMOUSE, bool SendA, bool SendB, bool SendC, bool SendD, bool SendE, bool SendF, bool SendG, bool SendH, bool SendI, bool SendJ, bool SendK, bool SendL, bool SendM, bool SendN, bool SendO, bool SendP, bool SendQ, bool SendR, bool SendS, bool SendT, bool SendU, bool SendV, bool SendW, bool SendX, bool SendY, bool SendZ, bool SendLWIN, bool SendRWIN, bool SendAPPS, bool SendDELETE, bool SendNUMPAD0, bool SendNUMPAD1, bool SendNUMPAD2, bool SendNUMPAD3, bool SendNUMPAD4, bool SendNUMPAD5, bool SendNUMPAD6, bool SendNUMPAD7, bool SendNUMPAD8, bool SendNUMPAD9, bool SendMULTIPLY, bool SendADD, bool SendSUBTRACT, bool SendDECIMAL, bool SendPRINTSCREEN, bool SendDIVIDE, bool SendF1, bool SendF2, bool SendF3, bool SendF4, bool SendF5, bool SendF6, bool SendF7, bool SendF8, bool SendF9, bool SendF10, bool SendF11, bool SendF12, bool SendNUMLOCK, bool SendSCROLLLOCK, bool SendLEFTSHIFT, bool SendRIGHTSHIFT, bool SendLEFTCONTROL, bool SendRIGHTCONTROL, bool SendLEFTALT, bool SendRIGHTALT, bool SendBROWSER_BACK, bool SendBROWSER_FORWARD, bool SendBROWSER_REFRESH, bool SendBROWSER_STOP, bool SendBROWSER_SEARCH, bool SendBROWSER_FAVORITES, bool SendBROWSER_HOME, bool SendVOLUME_MUTE, bool SendVOLUME_DOWN, bool SendVOLUME_UP, bool SendMEDIA_NEXT_TRACK, bool SendMEDIA_PREV_TRACK, bool SendMEDIA_STOP, bool SendMEDIA_PLAY_PAUSE, bool SendLAUNCH_MAIL, bool SendLAUNCH_MEDIA_SELECT, bool SendLAUNCH_APP1, bool SendLAUNCH_APP2, bool SendOEM_1, bool SendOEM_PLUS, bool SendOEM_COMMA, bool SendOEM_MINUS, bool SendOEM_PERIOD, bool SendOEM_2, bool SendOEM_3, bool SendOEM_4, bool SendOEM_5, bool SendOEM_6, bool SendOEM_7, bool SendOEM_8, bool SendOEM_102, bool SendEREOF, bool SendZOOM, bool SendEscape, bool SendOne, bool SendTwo, bool SendThree, bool SendFour, bool SendFive, bool SendSix, bool SendSeven, bool SendEight, bool SendNine, bool SendZero, bool SendDashUnderscore, bool SendPlusEquals, bool SendBackspace, bool SendTab, bool SendOpenBracketBrace, bool SendCloseBracketBrace, bool SendEnter, bool SendControl, bool SendSemicolonColon, bool SendSingleDoubleQuote, bool SendTilde, bool SendLeftShift, bool SendBackslashPipe, bool SendCommaLeftArrow, bool SendPeriodRightArrow, bool SendForwardSlashQuestionMark, bool SendRightShift, bool SendRightAlt, bool SendSpace, bool SendCapsLock, bool SendUp, bool SendDown, bool SendRight, bool SendLeft, bool SendHome, bool SendEnd, bool SendDelete, bool SendPageUp, bool SendPageDown, bool SendInsert, bool SendPrintScreen, bool SendNumLock, bool SendScrollLock, bool SendMenu, bool SendWindowsKey, bool SendNumpadDivide, bool SendNumpadAsterisk, bool SendNumpad7, bool SendNumpad8, bool SendNumpad9, bool SendNumpad4, bool SendNumpad5, bool SendNumpad6, bool SendNumpad1, bool SendNumpad2, bool SendNumpad3, bool SendNumpad0, bool SendNumpadDelete, bool SendNumpadEnter, bool SendNumpadPlus, bool SendNumpadMinus)
        {
            MoveMouseBy(input, (int)deltaX, (int)deltaY, mouse_id);
            MoveMouseTo(input, (int)x, (int)y, mouse_id);
            if (MouseDesktopX != 0f | MouseDesktopY != 0f)
            {
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point((int)(MouseDesktopX), (int)(MouseDesktopY));
                SetPhysicalCursorPos((int)(MouseDesktopX), (int)(MouseDesktopY));
                SetCaretPos((int)(MouseDesktopX), (int)(MouseDesktopY));
                SetCursorPos((int)(MouseDesktopX), (int)(MouseDesktopY));
            }
            valchanged(1, SendLeftClick);
            if (wd[1] == 1)
                mouseclickleft(input, mouse_id);
            if (wu[1] == 1)
                mouseclickleftF(input, mouse_id);
            valchanged(2, SendRightClick);
            if (wd[2] == 1)
                mouseclickright(input, mouse_id);
            if (wu[2] == 1)
                mouseclickrightF(input, mouse_id);
            valchanged(3, SendMiddleClick);
            if (wd[3] == 1)
                mouseclickmiddle(input, mouse_id);
            if (wu[3] == 1)
                mouseclickmiddleF(input, mouse_id);
            valchanged(4, SendWheelUp);
            if (wd[4] == 1)
                mousewheelup(input, mouse_id);
            valchanged(5, SendWheelDown);
            if (wd[5] == 1)
                mousewheeldown(input, mouse_id);
            valchanged(6, SendCANCEL);
            if (wd[6] == 1)
                keyboardkey(input, Keys.CANCEL, keyboard_id);
            if (wu[6] == 1)
                keyboardkeyF(input, Keys.CANCEL, keyboard_id);
            valchanged(7, SendBACK);
            if (wd[7] == 1)
                keyboardkey(input, Keys.BACK, keyboard_id);
            if (wu[7] == 1)
                keyboardkeyF(input, Keys.BACK, keyboard_id);
            valchanged(8, SendTAB);
            if (wd[8] == 1)
                keyboardkey(input, Keys.TAB, keyboard_id);
            if (wu[8] == 1)
                keyboardkeyF(input, Keys.TAB, keyboard_id);
            valchanged(9, SendCLEAR);
            if (wd[9] == 1)
                keyboardkey(input, Keys.CLEAR, keyboard_id);
            if (wu[9] == 1)
                keyboardkeyF(input, Keys.CLEAR, keyboard_id);
            valchanged(10, SendRETURN);
            if (wd[10] == 1)
                keyboardkey(input, Keys.RETURN, keyboard_id);
            if (wu[10] == 1)
                keyboardkeyF(input, Keys.RETURN, keyboard_id);
            valchanged(11, SendSHIFT);
            if (wd[11] == 1)
                keyboardkey(input, Keys.SHIFT, keyboard_id);
            if (wu[11] == 1)
                keyboardkeyF(input, Keys.SHIFT, keyboard_id);
            valchanged(12, SendCONTROL);
            if (wd[12] == 1)
                keyboardkey(input, Keys.CONTROL, keyboard_id);
            if (wu[12] == 1)
                keyboardkeyF(input, Keys.CONTROL, keyboard_id);
            valchanged(13, SendMENU);
            if (wd[13] == 1)
                keyboardkey(input, Keys.MENU, keyboard_id);
            if (wu[13] == 1)
                keyboardkeyF(input, Keys.MENU, keyboard_id);
            valchanged(14, SendCAPITAL);
            if (wd[14] == 1)
                keyboardkey(input, Keys.CAPITAL, keyboard_id);
            if (wu[14] == 1)
                keyboardkeyF(input, Keys.CAPITAL, keyboard_id);
            valchanged(15, SendESCAPE);
            if (wd[15] == 1)
                keyboardkey(input, Keys.ESCAPE, keyboard_id);
            if (wu[15] == 1)
                keyboardkeyF(input, Keys.ESCAPE, keyboard_id);
            valchanged(16, SendSPACE);
            if (wd[16] == 1)
                keyboardkey(input, Keys.SPACE, keyboard_id);
            if (wu[16] == 1)
                keyboardkeyF(input, Keys.SPACE, keyboard_id);
            valchanged(17, SendPRIOR);
            if (wd[17] == 1)
                keyboardkey(input, Keys.PRIOR, keyboard_id);
            if (wu[17] == 1)
                keyboardkeyF(input, Keys.PRIOR, keyboard_id);
            valchanged(18, SendNEXT);
            if (wd[18] == 1)
                keyboardkey(input, Keys.NEXT, keyboard_id);
            if (wu[18] == 1)
                keyboardkeyF(input, Keys.NEXT, keyboard_id);
            valchanged(19, SendEND);
            if (wd[19] == 1)
                keyboardkey(input, Keys.END, keyboard_id);
            if (wu[19] == 1)
                keyboardkeyF(input, Keys.END, keyboard_id);
            valchanged(20, SendHOME);
            if (wd[20] == 1)
                keyboardkey(input, Keys.HOME, keyboard_id);
            if (wu[20] == 1)
                keyboardkeyF(input, Keys.HOME, keyboard_id);
            valchanged(21, SendLEFT);
            if (wd[21] == 1)
                keyboardkey(input, Keys.LEFT, keyboard_id);
            if (wu[21] == 1)
                keyboardkeyF(input, Keys.LEFT, keyboard_id);
            valchanged(22, SendUP);
            if (wd[22] == 1)
                keyboardkey(input, Keys.UP, keyboard_id);
            if (wu[22] == 1)
                keyboardkeyF(input, Keys.UP, keyboard_id);
            valchanged(23, SendRIGHT);
            if (wd[23] == 1)
                keyboardkey(input, Keys.RIGHT, keyboard_id);
            if (wu[23] == 1)
                keyboardkeyF(input, Keys.RIGHT, keyboard_id);
            valchanged(24, SendDOWN);
            if (wd[24] == 1)
                keyboardkey(input, Keys.DOWN, keyboard_id);
            if (wu[24] == 1)
                keyboardkeyF(input, Keys.DOWN, keyboard_id);
            valchanged(25, SendSNAPSHOT);
            if (wd[25] == 1)
                keyboardkey(input, Keys.SNAPSHOT, keyboard_id);
            if (wu[25] == 1)
                keyboardkeyF(input, Keys.SNAPSHOT, keyboard_id);
            valchanged(26, SendINSERT);
            if (wd[26] == 1)
                keyboardkey(input, Keys.INSERT, keyboard_id);
            if (wu[26] == 1)
                keyboardkeyF(input, Keys.INSERT, keyboard_id);
            valchanged(27, SendNUMPADDEL);
            if (wd[27] == 1)
                keyboardkey(input, Keys.NUMPADDEL, keyboard_id);
            if (wu[27] == 1)
                keyboardkeyF(input, Keys.NUMPADDEL, keyboard_id);
            valchanged(28, SendNUMPADINSERT);
            if (wd[28] == 1)
                keyboardkey(input, Keys.NUMPADINSERT, keyboard_id);
            if (wu[28] == 1)
                keyboardkeyF(input, Keys.NUMPADINSERT, keyboard_id);
            valchanged(29, SendHELP);
            if (wd[29] == 1)
                keyboardkey(input, Keys.HELP, keyboard_id);
            if (wu[29] == 1)
                keyboardkeyF(input, Keys.HELP, keyboard_id);
            valchanged(30, SendAPOSTROPHE);
            if (wd[30] == 1)
                keyboardkey(input, Keys.APOSTROPHE, keyboard_id);
            if (wu[30] == 1)
                keyboardkeyF(input, Keys.APOSTROPHE, keyboard_id);
            valchanged(31, SendBACKSPACE);
            if (wd[31] == 1)
                keyboardkey(input, Keys.BACKSPACE, keyboard_id);
            if (wu[31] == 1)
                keyboardkeyF(input, Keys.BACKSPACE, keyboard_id);
            valchanged(32, SendPAGEDOWN);
            if (wd[32] == 1)
                keyboardkey(input, Keys.PAGEDOWN, keyboard_id);
            if (wu[32] == 1)
                keyboardkeyF(input, Keys.PAGEDOWN, keyboard_id);
            valchanged(33, SendPAGEUP);
            if (wd[33] == 1)
                keyboardkey(input, Keys.PAGEUP, keyboard_id);
            if (wu[33] == 1)
                keyboardkeyF(input, Keys.PAGEUP, keyboard_id);
            valchanged(34, SendFIN);
            if (wd[34] == 1)
                keyboardkey(input, Keys.FIN, keyboard_id);
            if (wu[34] == 1)
                keyboardkeyF(input, Keys.FIN, keyboard_id);
            valchanged(35, SendMOUSE);
            if (wd[35] == 1)
                keyboardkey(input, Keys.MOUSE, keyboard_id);
            if (wu[35] == 1)
                keyboardkeyF(input, Keys.MOUSE, keyboard_id);
            valchanged(36, SendA);
            if (wd[36] == 1)
                keyboardkey(input, Keys.A, keyboard_id);
            if (wu[36] == 1)
                keyboardkeyF(input, Keys.A, keyboard_id);
            valchanged(37, SendB);
            if (wd[37] == 1)
                keyboardkey(input, Keys.B, keyboard_id);
            if (wu[37] == 1)
                keyboardkeyF(input, Keys.B, keyboard_id);
            valchanged(38, SendC);
            if (wd[38] == 1)
                keyboardkey(input, Keys.C, keyboard_id);
            if (wu[38] == 1)
                keyboardkeyF(input, Keys.C, keyboard_id);
            valchanged(39, SendD);
            if (wd[39] == 1)
                keyboardkey(input, Keys.D, keyboard_id);
            if (wu[39] == 1)
                keyboardkeyF(input, Keys.D, keyboard_id);
            valchanged(40, SendE);
            if (wd[40] == 1)
                keyboardkey(input, Keys.E, keyboard_id);
            if (wu[40] == 1)
                keyboardkeyF(input, Keys.E, keyboard_id);
            valchanged(41, SendF);
            if (wd[41] == 1)
                keyboardkey(input, Keys.F, keyboard_id);
            if (wu[41] == 1)
                keyboardkeyF(input, Keys.F, keyboard_id);
            valchanged(42, SendG);
            if (wd[42] == 1)
                keyboardkey(input, Keys.G, keyboard_id);
            if (wu[42] == 1)
                keyboardkeyF(input, Keys.G, keyboard_id);
            valchanged(43, SendH);
            if (wd[43] == 1)
                keyboardkey(input, Keys.H, keyboard_id);
            if (wu[43] == 1)
                keyboardkeyF(input, Keys.H, keyboard_id);
            valchanged(44, SendI);
            if (wd[44] == 1)
                keyboardkey(input, Keys.I, keyboard_id);
            if (wu[44] == 1)
                keyboardkeyF(input, Keys.I, keyboard_id);
            valchanged(45, SendJ);
            if (wd[45] == 1)
                keyboardkey(input, Keys.J, keyboard_id);
            if (wu[45] == 1)
                keyboardkeyF(input, Keys.J, keyboard_id);
            valchanged(46, SendK);
            if (wd[46] == 1)
                keyboardkey(input, Keys.K, keyboard_id);
            if (wu[46] == 1)
                keyboardkeyF(input, Keys.K, keyboard_id);
            valchanged(47, SendL);
            if (wd[47] == 1)
                keyboardkey(input, Keys.L, keyboard_id);
            if (wu[47] == 1)
                keyboardkeyF(input, Keys.L, keyboard_id);
            valchanged(48, SendM);
            if (wd[48] == 1)
                keyboardkey(input, Keys.M, keyboard_id);
            if (wu[48] == 1)
                keyboardkeyF(input, Keys.M, keyboard_id);
            valchanged(49, SendN);
            if (wd[49] == 1)
                keyboardkey(input, Keys.N, keyboard_id);
            if (wu[49] == 1)
                keyboardkeyF(input, Keys.N, keyboard_id);
            valchanged(50, SendO);
            if (wd[50] == 1)
                keyboardkey(input, Keys.O, keyboard_id);
            if (wu[50] == 1)
                keyboardkeyF(input, Keys.O, keyboard_id);
            valchanged(51, SendP);
            if (wd[51] == 1)
                keyboardkey(input, Keys.P, keyboard_id);
            if (wu[51] == 1)
                keyboardkeyF(input, Keys.P, keyboard_id);
            valchanged(52, SendQ);
            if (wd[52] == 1)
                keyboardkey(input, Keys.Q, keyboard_id);
            if (wu[52] == 1)
                keyboardkeyF(input, Keys.Q, keyboard_id);
            valchanged(53, SendR);
            if (wd[53] == 1)
                keyboardkey(input, Keys.R, keyboard_id);
            if (wu[53] == 1)
                keyboardkeyF(input, Keys.R, keyboard_id);
            valchanged(54, SendS);
            if (wd[54] == 1)
                keyboardkey(input, Keys.S, keyboard_id);
            if (wu[54] == 1)
                keyboardkeyF(input, Keys.S, keyboard_id);
            valchanged(55, SendT);
            if (wd[55] == 1)
                keyboardkey(input, Keys.T, keyboard_id);
            if (wu[55] == 1)
                keyboardkeyF(input, Keys.T, keyboard_id);
            valchanged(56, SendU);
            if (wd[56] == 1)
                keyboardkey(input, Keys.U, keyboard_id);
            if (wu[56] == 1)
                keyboardkeyF(input, Keys.U, keyboard_id);
            valchanged(57, SendV);
            if (wd[57] == 1)
                keyboardkey(input, Keys.V, keyboard_id);
            if (wu[57] == 1)
                keyboardkeyF(input, Keys.V, keyboard_id);
            valchanged(58, SendW);
            if (wd[58] == 1)
                keyboardkey(input, Keys.W, keyboard_id);
            if (wu[58] == 1)
                keyboardkeyF(input, Keys.W, keyboard_id);
            valchanged(59, SendX);
            if (wd[59] == 1)
                keyboardkey(input, Keys.X, keyboard_id);
            if (wu[59] == 1)
                keyboardkeyF(input, Keys.X, keyboard_id);
            valchanged(60, SendY);
            if (wd[60] == 1)
                keyboardkey(input, Keys.Y, keyboard_id);
            if (wu[60] == 1)
                keyboardkeyF(input, Keys.Y, keyboard_id);
            valchanged(61, SendZ);
            if (wd[61] == 1)
                keyboardkey(input, Keys.Z, keyboard_id);
            if (wu[61] == 1)
                keyboardkeyF(input, Keys.Z, keyboard_id);
            valchanged(62, SendLWIN);
            if (wd[62] == 1)
                keyboardkey(input, Keys.LWIN, keyboard_id);
            if (wu[62] == 1)
                keyboardkeyF(input, Keys.LWIN, keyboard_id);
            valchanged(63, SendRWIN);
            if (wd[63] == 1)
                keyboardkey(input, Keys.RWIN, keyboard_id);
            if (wu[63] == 1)
                keyboardkeyF(input, Keys.RWIN, keyboard_id);
            valchanged(64, SendAPPS);
            if (wd[64] == 1)
                keyboardkey(input, Keys.APPS, keyboard_id);
            if (wu[64] == 1)
                keyboardkeyF(input, Keys.APPS, keyboard_id);
            valchanged(65, SendDELETE);
            if (wd[65] == 1)
                keyboardkey(input, Keys.DELETE, keyboard_id);
            if (wu[65] == 1)
                keyboardkeyF(input, Keys.DELETE, keyboard_id);
            valchanged(66, SendNUMPAD0);
            if (wd[66] == 1)
                keyboardkey(input, Keys.NUMPAD0, keyboard_id);
            if (wu[66] == 1)
                keyboardkeyF(input, Keys.NUMPAD0, keyboard_id);
            valchanged(67, SendNUMPAD1);
            if (wd[67] == 1)
                keyboardkey(input, Keys.NUMPAD1, keyboard_id);
            if (wu[67] == 1)
                keyboardkeyF(input, Keys.NUMPAD1, keyboard_id);
            valchanged(68, SendNUMPAD2);
            if (wd[68] == 1)
                keyboardkey(input, Keys.NUMPAD2, keyboard_id);
            if (wu[68] == 1)
                keyboardkeyF(input, Keys.NUMPAD2, keyboard_id);
            valchanged(69, SendNUMPAD3);
            if (wd[69] == 1)
                keyboardkey(input, Keys.NUMPAD3, keyboard_id);
            if (wu[69] == 1)
                keyboardkeyF(input, Keys.NUMPAD3, keyboard_id);
            valchanged(70, SendNUMPAD4);
            if (wd[70] == 1)
                keyboardkey(input, Keys.NUMPAD4, keyboard_id);
            if (wu[70] == 1)
                keyboardkeyF(input, Keys.NUMPAD4, keyboard_id);
            valchanged(71, SendNUMPAD5);
            if (wd[71] == 1)
                keyboardkey(input, Keys.NUMPAD5, keyboard_id);
            if (wu[71] == 1)
                keyboardkeyF(input, Keys.NUMPAD5, keyboard_id);
            valchanged(72, SendNUMPAD6);
            if (wd[72] == 1)
                keyboardkey(input, Keys.NUMPAD6, keyboard_id);
            if (wu[72] == 1)
                keyboardkeyF(input, Keys.NUMPAD6, keyboard_id);
            valchanged(73, SendNUMPAD7);
            if (wd[73] == 1)
                keyboardkey(input, Keys.NUMPAD7, keyboard_id);
            if (wu[73] == 1)
                keyboardkeyF(input, Keys.NUMPAD7, keyboard_id);
            valchanged(74, SendNUMPAD8);
            if (wd[74] == 1)
                keyboardkey(input, Keys.NUMPAD8, keyboard_id);
            if (wu[74] == 1)
                keyboardkeyF(input, Keys.NUMPAD8, keyboard_id);
            valchanged(75, SendNUMPAD9);
            if (wd[75] == 1)
                keyboardkey(input, Keys.NUMPAD9, keyboard_id);
            if (wu[75] == 1)
                keyboardkeyF(input, Keys.NUMPAD9, keyboard_id);
            valchanged(76, SendMULTIPLY);
            if (wd[76] == 1)
                keyboardkey(input, Keys.MULTIPLY, keyboard_id);
            if (wu[76] == 1)
                keyboardkeyF(input, Keys.MULTIPLY, keyboard_id);
            valchanged(77, SendADD);
            if (wd[77] == 1)
                keyboardkey(input, Keys.ADD, keyboard_id);
            if (wu[77] == 1)
                keyboardkeyF(input, Keys.ADD, keyboard_id);
            valchanged(78, SendSUBTRACT);
            if (wd[78] == 1)
                keyboardkey(input, Keys.SUBTRACT, keyboard_id);
            if (wu[78] == 1)
                keyboardkeyF(input, Keys.SUBTRACT, keyboard_id);
            valchanged(79, SendDECIMAL);
            if (wd[79] == 1)
                keyboardkey(input, Keys.DECIMAL, keyboard_id);
            if (wu[79] == 1)
                keyboardkeyF(input, Keys.DECIMAL, keyboard_id);
            valchanged(80, SendPRINTSCREEN);
            if (wd[80] == 1)
                keyboardkey(input, Keys.PRINTSCREEN, keyboard_id);
            if (wu[80] == 1)
                keyboardkeyF(input, Keys.PRINTSCREEN, keyboard_id);
            valchanged(81, SendDIVIDE);
            if (wd[81] == 1)
                keyboardkey(input, Keys.DIVIDE, keyboard_id);
            if (wu[81] == 1)
                keyboardkeyF(input, Keys.DIVIDE, keyboard_id);
            valchanged(82, SendF1);
            if (wd[82] == 1)
                keyboardkey(input, Keys.F1, keyboard_id);
            if (wu[82] == 1)
                keyboardkeyF(input, Keys.F1, keyboard_id);
            valchanged(83, SendF2);
            if (wd[83] == 1)
                keyboardkey(input, Keys.F2, keyboard_id);
            if (wu[83] == 1)
                keyboardkeyF(input, Keys.F2, keyboard_id);
            valchanged(84, SendF3);
            if (wd[84] == 1)
                keyboardkey(input, Keys.F3, keyboard_id);
            if (wu[84] == 1)
                keyboardkeyF(input, Keys.F3, keyboard_id);
            valchanged(85, SendF4);
            if (wd[85] == 1)
                keyboardkey(input, Keys.F4, keyboard_id);
            if (wu[85] == 1)
                keyboardkeyF(input, Keys.F4, keyboard_id);
            valchanged(86, SendF5);
            if (wd[86] == 1)
                keyboardkey(input, Keys.F5, keyboard_id);
            if (wu[86] == 1)
                keyboardkeyF(input, Keys.F5, keyboard_id);
            valchanged(87, SendF6);
            if (wd[87] == 1)
                keyboardkey(input, Keys.F6, keyboard_id);
            if (wu[87] == 1)
                keyboardkeyF(input, Keys.F6, keyboard_id);
            valchanged(88, SendF7);
            if (wd[88] == 1)
                keyboardkey(input, Keys.F7, keyboard_id);
            if (wu[88] == 1)
                keyboardkeyF(input, Keys.F7, keyboard_id);
            valchanged(89, SendF8);
            if (wd[89] == 1)
                keyboardkey(input, Keys.F8, keyboard_id);
            if (wu[89] == 1)
                keyboardkeyF(input, Keys.F8, keyboard_id);
            valchanged(90, SendF9);
            if (wd[90] == 1)
                keyboardkey(input, Keys.F9, keyboard_id);
            if (wu[90] == 1)
                keyboardkeyF(input, Keys.F9, keyboard_id);
            valchanged(91, SendF10);
            if (wd[91] == 1)
                keyboardkey(input, Keys.F10, keyboard_id);
            if (wu[91] == 1)
                keyboardkeyF(input, Keys.F10, keyboard_id);
            valchanged(92, SendF11);
            if (wd[92] == 1)
                keyboardkey(input, Keys.F11, keyboard_id);
            if (wu[92] == 1)
                keyboardkeyF(input, Keys.F11, keyboard_id);
            valchanged(93, SendF12);
            if (wd[93] == 1)
                keyboardkey(input, Keys.F12, keyboard_id);
            if (wu[93] == 1)
                keyboardkeyF(input, Keys.F12, keyboard_id);
            valchanged(94, SendNUMLOCK);
            if (wd[94] == 1)
                keyboardkey(input, Keys.NUMLOCK, keyboard_id);
            if (wu[94] == 1)
                keyboardkeyF(input, Keys.NUMLOCK, keyboard_id);
            valchanged(95, SendSCROLLLOCK);
            if (wd[95] == 1)
                keyboardkey(input, Keys.SCROLLLOCK, keyboard_id);
            if (wu[95] == 1)
                keyboardkeyF(input, Keys.SCROLLLOCK, keyboard_id);
            valchanged(96, SendLEFTSHIFT);
            if (wd[96] == 1)
                keyboardkey(input, Keys.LEFTSHIFT, keyboard_id);
            if (wu[96] == 1)
                keyboardkeyF(input, Keys.LEFTSHIFT, keyboard_id);
            valchanged(97, SendRIGHTSHIFT);
            if (wd[97] == 1)
                keyboardkey(input, Keys.RIGHTSHIFT, keyboard_id);
            if (wu[97] == 1)
                keyboardkeyF(input, Keys.RIGHTSHIFT, keyboard_id);
            valchanged(98, SendLEFTCONTROL);
            if (wd[98] == 1)
                keyboardkey(input, Keys.LEFTCONTROL, keyboard_id);
            if (wu[98] == 1)
                keyboardkeyF(input, Keys.LEFTCONTROL, keyboard_id);
            valchanged(99, SendRIGHTCONTROL);
            if (wd[99] == 1)
                keyboardkey(input, Keys.RIGHTCONTROL, keyboard_id);
            if (wu[99] == 1)
                keyboardkeyF(input, Keys.RIGHTCONTROL, keyboard_id);
            valchanged(100, SendLEFTALT);
            if (wd[100] == 1)
                keyboardkey(input, Keys.LEFTALT, keyboard_id);
            if (wu[100] == 1)
                keyboardkeyF(input, Keys.LEFTALT, keyboard_id);
            valchanged(101, SendRIGHTALT);
            if (wd[101] == 1)
                keyboardkey(input, Keys.RIGHTALT, keyboard_id);
            if (wu[101] == 1)
                keyboardkeyF(input, Keys.RIGHTALT, keyboard_id);
            valchanged(102, SendBROWSER_BACK);
            if (wd[102] == 1)
                keyboardkey(input, Keys.BROWSER_BACK, keyboard_id);
            if (wu[102] == 1)
                keyboardkeyF(input, Keys.BROWSER_BACK, keyboard_id);
            valchanged(103, SendBROWSER_FORWARD);
            if (wd[103] == 1)
                keyboardkey(input, Keys.BROWSER_FORWARD, keyboard_id);
            if (wu[103] == 1)
                keyboardkeyF(input, Keys.BROWSER_FORWARD, keyboard_id);
            valchanged(104, SendBROWSER_REFRESH);
            if (wd[104] == 1)
                keyboardkey(input, Keys.BROWSER_REFRESH, keyboard_id);
            if (wu[104] == 1)
                keyboardkeyF(input, Keys.BROWSER_REFRESH, keyboard_id);
            valchanged(105, SendBROWSER_STOP);
            if (wd[105] == 1)
                keyboardkey(input, Keys.BROWSER_STOP, keyboard_id);
            if (wu[105] == 1)
                keyboardkeyF(input, Keys.BROWSER_STOP, keyboard_id);
            valchanged(106, SendBROWSER_SEARCH);
            if (wd[106] == 1)
                keyboardkey(input, Keys.BROWSER_SEARCH, keyboard_id);
            if (wu[106] == 1)
                keyboardkeyF(input, Keys.BROWSER_SEARCH, keyboard_id);
            valchanged(107, SendBROWSER_FAVORITES);
            if (wd[107] == 1)
                keyboardkey(input, Keys.BROWSER_FAVORITES, keyboard_id);
            if (wu[107] == 1)
                keyboardkeyF(input, Keys.BROWSER_FAVORITES, keyboard_id);
            valchanged(108, SendBROWSER_HOME);
            if (wd[108] == 1)
                keyboardkey(input, Keys.BROWSER_HOME, keyboard_id);
            if (wu[108] == 1)
                keyboardkeyF(input, Keys.BROWSER_HOME, keyboard_id);
            valchanged(109, SendVOLUME_MUTE);
            if (wd[109] == 1)
                keyboardkey(input, Keys.VOLUME_MUTE, keyboard_id);
            if (wu[109] == 1)
                keyboardkeyF(input, Keys.VOLUME_MUTE, keyboard_id);
            valchanged(110, SendVOLUME_DOWN);
            if (wd[110] == 1)
                keyboardkey(input, Keys.VOLUME_DOWN, keyboard_id);
            if (wu[110] == 1)
                keyboardkeyF(input, Keys.VOLUME_DOWN, keyboard_id);
            valchanged(111, SendVOLUME_UP);
            if (wd[111] == 1)
                keyboardkey(input, Keys.VOLUME_UP, keyboard_id);
            if (wu[111] == 1)
                keyboardkeyF(input, Keys.VOLUME_UP, keyboard_id);
            valchanged(112, SendMEDIA_NEXT_TRACK);
            if (wd[112] == 1)
                keyboardkey(input, Keys.MEDIA_NEXT_TRACK, keyboard_id);
            if (wu[112] == 1)
                keyboardkeyF(input, Keys.MEDIA_NEXT_TRACK, keyboard_id);
            valchanged(113, SendMEDIA_PREV_TRACK);
            if (wd[113] == 1)
                keyboardkey(input, Keys.MEDIA_PREV_TRACK, keyboard_id);
            if (wu[113] == 1)
                keyboardkeyF(input, Keys.MEDIA_PREV_TRACK, keyboard_id);
            valchanged(114, SendMEDIA_STOP);
            if (wd[114] == 1)
                keyboardkey(input, Keys.MEDIA_STOP, keyboard_id);
            if (wu[114] == 1)
                keyboardkeyF(input, Keys.MEDIA_STOP, keyboard_id);
            valchanged(115, SendMEDIA_PLAY_PAUSE);
            if (wd[115] == 1)
                keyboardkey(input, Keys.MEDIA_PLAY_PAUSE, keyboard_id);
            if (wu[115] == 1)
                keyboardkeyF(input, Keys.MEDIA_PLAY_PAUSE, keyboard_id);
            valchanged(116, SendLAUNCH_MAIL);
            if (wd[116] == 1)
                keyboardkey(input, Keys.LAUNCH_MAIL, keyboard_id);
            if (wu[116] == 1)
                keyboardkeyF(input, Keys.LAUNCH_MAIL, keyboard_id);
            valchanged(117, SendLAUNCH_MEDIA_SELECT);
            if (wd[117] == 1)
                keyboardkey(input, Keys.LAUNCH_MEDIA_SELECT, keyboard_id);
            if (wu[117] == 1)
                keyboardkeyF(input, Keys.LAUNCH_MEDIA_SELECT, keyboard_id);
            valchanged(118, SendLAUNCH_APP1);
            if (wd[118] == 1)
                keyboardkey(input, Keys.LAUNCH_APP1, keyboard_id);
            if (wu[118] == 1)
                keyboardkeyF(input, Keys.LAUNCH_APP1, keyboard_id);
            valchanged(119, SendLAUNCH_APP2);
            if (wd[119] == 1)
                keyboardkey(input, Keys.LAUNCH_APP2, keyboard_id);
            if (wu[119] == 1)
                keyboardkeyF(input, Keys.LAUNCH_APP2, keyboard_id);
            valchanged(120, SendOEM_1);
            if (wd[120] == 1)
                keyboardkey(input, Keys.OEM_1, keyboard_id);
            if (wu[120] == 1)
                keyboardkeyF(input, Keys.OEM_1, keyboard_id);
            valchanged(121, SendOEM_PLUS);
            if (wd[121] == 1)
                keyboardkey(input, Keys.OEM_PLUS, keyboard_id);
            if (wu[121] == 1)
                keyboardkeyF(input, Keys.OEM_PLUS, keyboard_id);
            valchanged(122, SendOEM_COMMA);
            if (wd[122] == 1)
                keyboardkey(input, Keys.OEM_COMMA, keyboard_id);
            if (wu[122] == 1)
                keyboardkeyF(input, Keys.OEM_COMMA, keyboard_id);
            valchanged(123, SendOEM_MINUS);
            if (wd[123] == 1)
                keyboardkey(input, Keys.OEM_MINUS, keyboard_id);
            if (wu[123] == 1)
                keyboardkeyF(input, Keys.OEM_MINUS, keyboard_id);
            valchanged(124, SendOEM_PERIOD);
            if (wd[124] == 1)
                keyboardkey(input, Keys.OEM_PERIOD, keyboard_id);
            if (wu[124] == 1)
                keyboardkeyF(input, Keys.OEM_PERIOD, keyboard_id);
            valchanged(125, SendOEM_2);
            if (wd[125] == 1)
                keyboardkey(input, Keys.OEM_2, keyboard_id);
            if (wu[125] == 1)
                keyboardkeyF(input, Keys.OEM_2, keyboard_id);
            valchanged(126, SendOEM_3);
            if (wd[126] == 1)
                keyboardkey(input, Keys.OEM_3, keyboard_id);
            if (wu[126] == 1)
                keyboardkeyF(input, Keys.OEM_3, keyboard_id);
            valchanged(127, SendOEM_4);
            if (wd[127] == 1)
                keyboardkey(input, Keys.OEM_4, keyboard_id);
            if (wu[127] == 1)
                keyboardkeyF(input, Keys.OEM_4, keyboard_id);
            valchanged(128, SendOEM_5);
            if (wd[128] == 1)
                keyboardkey(input, Keys.OEM_5, keyboard_id);
            if (wu[128] == 1)
                keyboardkeyF(input, Keys.OEM_5, keyboard_id);
            valchanged(129, SendOEM_6);
            if (wd[129] == 1)
                keyboardkey(input, Keys.OEM_6, keyboard_id);
            if (wu[129] == 1)
                keyboardkeyF(input, Keys.OEM_6, keyboard_id);
            valchanged(130, SendOEM_7);
            if (wd[130] == 1)
                keyboardkey(input, Keys.OEM_7, keyboard_id);
            if (wu[130] == 1)
                keyboardkeyF(input, Keys.OEM_7, keyboard_id);
            valchanged(131, SendOEM_8);
            if (wd[131] == 1)
                keyboardkey(input, Keys.OEM_8, keyboard_id);
            if (wu[131] == 1)
                keyboardkeyF(input, Keys.OEM_8, keyboard_id);
            valchanged(132, SendOEM_102);
            if (wd[132] == 1)
                keyboardkey(input, Keys.OEM_102, keyboard_id);
            if (wu[132] == 1)
                keyboardkeyF(input, Keys.OEM_102, keyboard_id);
            valchanged(133, SendEREOF);
            if (wd[133] == 1)
                keyboardkey(input, Keys.EREOF, keyboard_id);
            if (wu[133] == 1)
                keyboardkeyF(input, Keys.EREOF, keyboard_id);
            valchanged(134, SendZOOM);
            if (wd[134] == 1)
                keyboardkey(input, Keys.ZOOM, keyboard_id);
            if (wu[134] == 1)
                keyboardkeyF(input, Keys.ZOOM, keyboard_id);
            valchanged(135, SendEscape);
            if (wd[135] == 1)
                keyboardkey(input, Keys.Escape, keyboard_id);
            if (wu[135] == 1)
                keyboardkeyF(input, Keys.Escape, keyboard_id);
            valchanged(136, SendOne);
            if (wd[136] == 1)
                keyboardkey(input, Keys.One, keyboard_id);
            if (wu[136] == 1)
                keyboardkeyF(input, Keys.One, keyboard_id);
            valchanged(137, SendTwo);
            if (wd[137] == 1)
                keyboardkey(input, Keys.Two, keyboard_id);
            if (wu[137] == 1)
                keyboardkeyF(input, Keys.Two, keyboard_id);
            valchanged(138, SendThree);
            if (wd[138] == 1)
                keyboardkey(input, Keys.Three, keyboard_id);
            if (wu[138] == 1)
                keyboardkeyF(input, Keys.Three, keyboard_id);
            valchanged(139, SendFour);
            if (wd[139] == 1)
                keyboardkey(input, Keys.Four, keyboard_id);
            if (wu[139] == 1)
                keyboardkeyF(input, Keys.Four, keyboard_id);
            valchanged(140, SendFive);
            if (wd[140] == 1)
                keyboardkey(input, Keys.Five, keyboard_id);
            if (wu[140] == 1)
                keyboardkeyF(input, Keys.Five, keyboard_id);
            valchanged(141, SendSix);
            if (wd[141] == 1)
                keyboardkey(input, Keys.Six, keyboard_id);
            if (wu[141] == 1)
                keyboardkeyF(input, Keys.Six, keyboard_id);
            valchanged(142, SendSeven);
            if (wd[142] == 1)
                keyboardkey(input, Keys.Seven, keyboard_id);
            if (wu[142] == 1)
                keyboardkeyF(input, Keys.Seven, keyboard_id);
            valchanged(143, SendEight);
            if (wd[143] == 1)
                keyboardkey(input, Keys.Eight, keyboard_id);
            if (wu[143] == 1)
                keyboardkeyF(input, Keys.Eight, keyboard_id);
            valchanged(144, SendNine);
            if (wd[144] == 1)
                keyboardkey(input, Keys.Nine, keyboard_id);
            if (wu[144] == 1)
                keyboardkeyF(input, Keys.Nine, keyboard_id);
            valchanged(145, SendZero);
            if (wd[145] == 1)
                keyboardkey(input, Keys.Zero, keyboard_id);
            if (wu[145] == 1)
                keyboardkeyF(input, Keys.Zero, keyboard_id);
            valchanged(146, SendDashUnderscore);
            if (wd[146] == 1)
                keyboardkey(input, Keys.DashUnderscore, keyboard_id);
            if (wu[146] == 1)
                keyboardkeyF(input, Keys.DashUnderscore, keyboard_id);
            valchanged(147, SendPlusEquals);
            if (wd[147] == 1)
                keyboardkey(input, Keys.PlusEquals, keyboard_id);
            if (wu[147] == 1)
                keyboardkeyF(input, Keys.PlusEquals, keyboard_id);
            valchanged(148, SendBackspace);
            if (wd[148] == 1)
                keyboardkey(input, Keys.Backspace, keyboard_id);
            if (wu[148] == 1)
                keyboardkeyF(input, Keys.Backspace, keyboard_id);
            valchanged(149, SendTab);
            if (wd[149] == 1)
                keyboardkey(input, Keys.Tab, keyboard_id);
            if (wu[149] == 1)
                keyboardkeyF(input, Keys.Tab, keyboard_id);
            valchanged(150, SendOpenBracketBrace);
            if (wd[150] == 1)
                keyboardkey(input, Keys.OpenBracketBrace, keyboard_id);
            if (wu[150] == 1)
                keyboardkeyF(input, Keys.OpenBracketBrace, keyboard_id);
            valchanged(151, SendCloseBracketBrace);
            if (wd[151] == 1)
                keyboardkey(input, Keys.CloseBracketBrace, keyboard_id);
            if (wu[151] == 1)
                keyboardkeyF(input, Keys.CloseBracketBrace, keyboard_id);
            valchanged(152, SendEnter);
            if (wd[152] == 1)
                keyboardkey(input, Keys.Enter, keyboard_id);
            if (wu[152] == 1)
                keyboardkeyF(input, Keys.Enter, keyboard_id);
            valchanged(153, SendSemicolonColon);
            if (wd[153] == 1)
                keyboardkey(input, Keys.SemicolonColon, keyboard_id);
            if (wu[153] == 1)
                keyboardkeyF(input, Keys.SemicolonColon, keyboard_id);
            valchanged(154, SendSingleDoubleQuote);
            if (wd[154] == 1)
                keyboardkey(input, Keys.SingleDoubleQuote, keyboard_id);
            if (wu[154] == 1)
                keyboardkeyF(input, Keys.SingleDoubleQuote, keyboard_id);
            valchanged(155, SendTilde);
            if (wd[155] == 1)
                keyboardkey(input, Keys.Tilde, keyboard_id);
            if (wu[155] == 1)
                keyboardkeyF(input, Keys.Tilde, keyboard_id);
            valchanged(156, SendLeftShift);
            if (wd[156] == 1)
                keyboardkey(input, Keys.LeftShift, keyboard_id);
            if (wu[156] == 1)
                keyboardkeyF(input, Keys.LeftShift, keyboard_id);
            valchanged(157, SendBackslashPipe);
            if (wd[157] == 1)
                keyboardkey(input, Keys.BackslashPipe, keyboard_id);
            if (wu[157] == 1)
                keyboardkeyF(input, Keys.BackslashPipe, keyboard_id);
            valchanged(158, SendCommaLeftArrow);
            if (wd[158] == 1)
                keyboardkey(input, Keys.CommaLeftArrow, keyboard_id);
            if (wu[158] == 1)
                keyboardkeyF(input, Keys.CommaLeftArrow, keyboard_id);
            valchanged(159, SendPeriodRightArrow);
            if (wd[159] == 1)
                keyboardkey(input, Keys.PeriodRightArrow, keyboard_id);
            if (wu[159] == 1)
                keyboardkeyF(input, Keys.PeriodRightArrow, keyboard_id);
            valchanged(160, SendForwardSlashQuestionMark);
            if (wd[160] == 1)
                keyboardkey(input, Keys.ForwardSlashQuestionMark, keyboard_id);
            if (wu[160] == 1)
                keyboardkeyF(input, Keys.ForwardSlashQuestionMark, keyboard_id);
            valchanged(161, SendRightShift);
            if (wd[161] == 1)
                keyboardkey(input, Keys.RightShift, keyboard_id);
            if (wu[161] == 1)
                keyboardkeyF(input, Keys.RightShift, keyboard_id);
            valchanged(162, SendRightAlt);
            if (wd[162] == 1)
                keyboardkey(input, Keys.RightAlt, keyboard_id);
            if (wu[162] == 1)
                keyboardkeyF(input, Keys.RightAlt, keyboard_id);
            valchanged(163, SendSpace);
            if (wd[163] == 1)
                keyboardkey(input, Keys.Space, keyboard_id);
            if (wu[163] == 1)
                keyboardkeyF(input, Keys.Space, keyboard_id);
            valchanged(164, SendCapsLock);
            if (wd[164] == 1)
                keyboardkey(input, Keys.CapsLock, keyboard_id);
            if (wu[164] == 1)
                keyboardkeyF(input, Keys.CapsLock, keyboard_id);
            valchanged(165, SendUp);
            if (wd[165] == 1)
                keyboardkey(input, Keys.Up, keyboard_id);
            if (wu[165] == 1)
                keyboardkeyF(input, Keys.Up, keyboard_id);
            valchanged(166, SendDown);
            if (wd[166] == 1)
                keyboardkey(input, Keys.Down, keyboard_id);
            if (wu[166] == 1)
                keyboardkeyF(input, Keys.Down, keyboard_id);
            valchanged(167, SendRight);
            if (wd[167] == 1)
                keyboardkey(input, Keys.Right, keyboard_id);
            if (wu[167] == 1)
                keyboardkeyF(input, Keys.Right, keyboard_id);
            valchanged(168, SendLeft);
            if (wd[168] == 1)
                keyboardkey(input, Keys.Left, keyboard_id);
            if (wu[168] == 1)
                keyboardkeyF(input, Keys.Left, keyboard_id);
            valchanged(169, SendHome);
            if (wd[169] == 1)
                keyboardkey(input, Keys.Home, keyboard_id);
            if (wu[169] == 1)
                keyboardkeyF(input, Keys.Home, keyboard_id);
            valchanged(170, SendEnd);
            if (wd[170] == 1)
                keyboardkey(input, Keys.End, keyboard_id);
            if (wu[170] == 1)
                keyboardkeyF(input, Keys.End, keyboard_id);
            valchanged(171, SendDelete);
            if (wd[171] == 1)
                keyboardkey(input, Keys.Delete, keyboard_id);
            if (wu[171] == 1)
                keyboardkeyF(input, Keys.Delete, keyboard_id);
            valchanged(172, SendPageUp);
            if (wd[172] == 1)
                keyboardkey(input, Keys.PageUp, keyboard_id);
            if (wu[172] == 1)
                keyboardkeyF(input, Keys.PageUp, keyboard_id);
            valchanged(173, SendPageDown);
            if (wd[173] == 1)
                keyboardkey(input, Keys.PageDown, keyboard_id);
            if (wu[173] == 1)
                keyboardkeyF(input, Keys.PageDown, keyboard_id);
            valchanged(174, SendInsert);
            if (wd[174] == 1)
                keyboardkey(input, Keys.Insert, keyboard_id);
            if (wu[174] == 1)
                keyboardkeyF(input, Keys.Insert, keyboard_id);
            valchanged(175, SendPrintScreen);
            if (wd[175] == 1)
                keyboardkey(input, Keys.PrintScreen, keyboard_id);
            if (wu[175] == 1)
                keyboardkeyF(input, Keys.PrintScreen, keyboard_id);
            valchanged(176, SendNumLock);
            if (wd[176] == 1)
                keyboardkey(input, Keys.NumLock, keyboard_id);
            if (wu[176] == 1)
                keyboardkeyF(input, Keys.NumLock, keyboard_id);
            valchanged(177, SendScrollLock);
            if (wd[177] == 1)
                keyboardkey(input, Keys.ScrollLock, keyboard_id);
            if (wu[177] == 1)
                keyboardkeyF(input, Keys.ScrollLock, keyboard_id);
            valchanged(178, SendMenu);
            if (wd[178] == 1)
                keyboardkey(input, Keys.Menu, keyboard_id);
            if (wu[178] == 1)
                keyboardkeyF(input, Keys.Menu, keyboard_id);
            valchanged(179, SendWindowsKey);
            if (wd[179] == 1)
                keyboardkey(input, Keys.WindowsKey, keyboard_id);
            if (wu[179] == 1)
                keyboardkeyF(input, Keys.WindowsKey, keyboard_id);
            valchanged(180, SendNumpadDivide);
            if (wd[180] == 1)
                keyboardkey(input, Keys.NumpadDivide, keyboard_id);
            if (wu[180] == 1)
                keyboardkeyF(input, Keys.NumpadDivide, keyboard_id);
            valchanged(181, SendNumpadAsterisk);
            if (wd[181] == 1)
                keyboardkey(input, Keys.NumpadAsterisk, keyboard_id);
            if (wu[181] == 1)
                keyboardkeyF(input, Keys.NumpadAsterisk, keyboard_id);
            valchanged(182, SendNumpad7);
            if (wd[182] == 1)
                keyboardkey(input, Keys.Numpad7, keyboard_id);
            if (wu[182] == 1)
                keyboardkeyF(input, Keys.Numpad7, keyboard_id);
            valchanged(183, SendNumpad8);
            if (wd[183] == 1)
                keyboardkey(input, Keys.Numpad8, keyboard_id);
            if (wu[183] == 1)
                keyboardkeyF(input, Keys.Numpad8, keyboard_id);
            valchanged(184, SendNumpad9);
            if (wd[184] == 1)
                keyboardkey(input, Keys.Numpad9, keyboard_id);
            if (wu[184] == 1)
                keyboardkeyF(input, Keys.Numpad9, keyboard_id);
            valchanged(185, SendNumpad4);
            if (wd[185] == 1)
                keyboardkey(input, Keys.Numpad4, keyboard_id);
            if (wu[185] == 1)
                keyboardkeyF(input, Keys.Numpad4, keyboard_id);
            valchanged(186, SendNumpad5);
            if (wd[186] == 1)
                keyboardkey(input, Keys.Numpad5, keyboard_id);
            if (wu[186] == 1)
                keyboardkeyF(input, Keys.Numpad5, keyboard_id);
            valchanged(187, SendNumpad6);
            if (wd[187] == 1)
                keyboardkey(input, Keys.Numpad6, keyboard_id);
            if (wu[187] == 1)
                keyboardkeyF(input, Keys.Numpad6, keyboard_id);
            valchanged(188, SendNumpad1);
            if (wd[188] == 1)
                keyboardkey(input, Keys.Numpad1, keyboard_id);
            if (wu[188] == 1)
                keyboardkeyF(input, Keys.Numpad1, keyboard_id);
            valchanged(189, SendNumpad2);
            if (wd[189] == 1)
                keyboardkey(input, Keys.Numpad2, keyboard_id);
            if (wu[189] == 1)
                keyboardkeyF(input, Keys.Numpad2, keyboard_id);
            valchanged(190, SendNumpad3);
            if (wd[190] == 1)
                keyboardkey(input, Keys.Numpad3, keyboard_id);
            if (wu[190] == 1)
                keyboardkeyF(input, Keys.Numpad3, keyboard_id);
            valchanged(191, SendNumpad0);
            if (wd[191] == 1)
                keyboardkey(input, Keys.Numpad0, keyboard_id);
            if (wu[191] == 1)
                keyboardkeyF(input, Keys.Numpad0, keyboard_id);
            valchanged(192, SendNumpadDelete);
            if (wd[192] == 1)
                keyboardkey(input, Keys.NumpadDelete, keyboard_id);
            if (wu[192] == 1)
                keyboardkeyF(input, Keys.NumpadDelete, keyboard_id);
            valchanged(193, SendNumpadEnter);
            if (wd[193] == 1)
                keyboardkey(input, Keys.NumpadEnter, keyboard_id);
            if (wu[193] == 1)
                keyboardkeyF(input, Keys.NumpadEnter, keyboard_id);
            valchanged(194, SendNumpadPlus);
            if (wd[194] == 1)
                keyboardkey(input, Keys.NumpadPlus, keyboard_id);
            if (wu[194] == 1)
                keyboardkeyF(input, Keys.NumpadPlus, keyboard_id);
            valchanged(195, SendNumpadMinus);
            if (wd[195] == 1)
                keyboardkey(input, Keys.NumpadMinus, keyboard_id);
            if (wu[195] == 1)
                keyboardkeyF(input, Keys.NumpadMinus, keyboard_id);
        }
        public static void mouseclickleft(Input input, int mouse_id)
        {
            input.SendLeftClick(mouse_id);
        }
        public static void mouseclickleftF(Input input, int mouse_id)
        {
            input.SendLeftClickF(mouse_id);
        }
        public static void mouseclickright(Input input, int mouse_id)
        {
            input.SendRightClick(mouse_id);
        }
        public static void mouseclickrightF(Input input, int mouse_id)
        {
            input.SendRightClickF(mouse_id);
        }
        public static void mouseclickmiddle(Input input, int mouse_id)
        {
            input.SendMiddleClick(mouse_id);
        }
        public static void mouseclickmiddleF(Input input, int mouse_id)
        {
            input.SendMiddleClickF(mouse_id);
        }
        public static void mousewheelup(Input input, int mouse_id)
        {
            input.SendWheelUp(mouse_id);
        }
        public static void mousewheeldown(Input input, int mouse_id)
        {
            input.SendWheelDown(mouse_id);
        }
        public static void keyboardkey(Input input, Keys key, int keyboard_id)
        {
            input.SendKey(key, keyboard_id);
        }
        public static void keyboardkeyF(Input input, Keys key, int keyboard_id)
        {
            input.SendKeyF(key, keyboard_id);
        }
        public static void MoveMouseBy(Input input, int deltaX, int deltaY, int mouseId)
        {
            input.MoveMouseBy(deltaX, deltaY, mouseId);
        }
        public static void MoveMouseTo(Input input, int x, int y, int mouseId)
        {
            input.MoveMouseTo(x, y, mouseId);
        }
    }
    public class Input
    {
        private static IntPtr context;
        public KeyboardFilterMode KeyboardFilterMode { get; set; }
        public MouseFilterMode MouseFilterMode { get; set; }
        public static bool IsLoaded { get; set; }
        public Input()
        {
            context = IntPtr.Zero;
            KeyboardFilterMode = KeyboardFilterMode.None;
            MouseFilterMode = MouseFilterMode.None;
        }
        public bool Load()
        {
            context = InterceptionDriver.CreateContext();
            return true;
        }
        public void Unload()
        {
            InterceptionDriver.DestroyContext(context);
        }
        public void SendKey(Keys key, KeyState state, int keyboardId)
        {
            Stroke stroke = new Stroke();
            KeyStroke keyStroke = new KeyStroke();
            keyStroke.Code = key;
            keyStroke.State = state;
            stroke.Key = keyStroke;
            InterceptionDriver.Send(context, keyboardId, ref stroke, 1);
        }
        public void SendKey(Keys key, int keyboardId)
        {
            SendKey(key, KeyState.Down, keyboardId);
        }
        public void SendKeyF(Keys key, int keyboardId)
        {
            SendKey(key, KeyState.Up, keyboardId);
        }
        public void SendMouseEvent(MouseState state, int mouseId)
        {
            Stroke stroke = new Stroke();
            MouseStroke mouseStroke = new MouseStroke();
            mouseStroke.State = state;
            if (state == MouseState.ScrollUp)
            {
                mouseStroke.Rolling = 120;
            }
            else if (state == MouseState.ScrollDown)
            {
                mouseStroke.Rolling = -120;
            }
            stroke.Mouse = mouseStroke;
            InterceptionDriver.Send(context, mouseId, ref stroke, 1);
        }
        public void SendLeftClick(int mouseId)
        {
            SendMouseEvent(MouseState.LeftDown, mouseId);
        }
        public void SendRightClick(int mouseId)
        {
            SendMouseEvent(MouseState.RightDown, mouseId);
        }
        public void SendLeftClickF(int mouseId)
        {
            SendMouseEvent(MouseState.LeftUp, mouseId);
        }
        public void SendRightClickF(int mouseId)
        {
            SendMouseEvent(MouseState.RightUp, mouseId);
        }
        public void SendMiddleClick(int mouseId)
        {
            SendMouseEvent(MouseState.MiddleDown, mouseId);
        }
        public void SendMiddleClickF(int mouseId)
        {
            SendMouseEvent(MouseState.MiddleUp, mouseId);
        }
        public void SendWheelUp(int mouseId)
        {
            SendMouseEvent(MouseState.ScrollUp, mouseId);
        }
        public void SendWheelDown(int mouseId)
        {
            SendMouseEvent(MouseState.ScrollDown, mouseId);
        }
        public void MoveMouseBy(int deltaX, int deltaY, int mouseId)
        {
            if (deltaX != 0 | deltaY != 0)
            {
                Stroke stroke = new Stroke();
                MouseStroke mouseStroke = new MouseStroke();
                mouseStroke.X = deltaX;
                mouseStroke.Y = deltaY;
                stroke.Mouse = mouseStroke;
                stroke.Mouse.Flags = MouseFlags.MoveRelative;
                InterceptionDriver.Send(context, mouseId, ref stroke, 1);
            }
        }
        public void MoveMouseTo(int x, int y, int mouseId)
        {
            if (x != 0 | y != 0)
            {
                Stroke stroke = new Stroke();
                MouseStroke mouseStroke = new MouseStroke();
                mouseStroke.X = x;
                mouseStroke.Y = y;
                stroke.Mouse = mouseStroke;
                stroke.Mouse.Flags = MouseFlags.MoveAbsolute;
                InterceptionDriver.Send(context, mouseId, ref stroke, 1);
            }
        }
    }
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int Predicate(int device);
    [Flags]
    public enum KeyState : ushort
    {
        Down = 0x00,
        Up = 0x01,
        E0 = 0x02,
        E1 = 0x04,
        TermsrvSetLED = 0x08,
        TermsrvShadow = 0x10,
        TermsrvVKPacket = 0x20
    }
    [Flags]
    public enum KeyboardFilterMode : ushort
    {
        None = 0x0000,
        All = 0xFFFF,
        KeyDown = KeyState.Up,
        KeyUp = KeyState.Up << 1,
        KeyE0 = KeyState.E0 << 1,
        KeyE1 = KeyState.E1 << 1,
        KeyTermsrvSetLED = KeyState.TermsrvSetLED << 1,
        KeyTermsrvShadow = KeyState.TermsrvShadow << 1,
        KeyTermsrvVKPacket = KeyState.TermsrvVKPacket << 1
    }
    [Flags]
    public enum MouseState : ushort
    {
        LeftDown = 0x01,
        LeftUp = 0x02,
        RightDown = 0x04,
        RightUp = 0x08,
        MiddleDown = 0x10,
        MiddleUp = 0x20,
        LeftExtraDown = 0x40,
        LeftExtraUp = 0x80,
        RightExtraDown = 0x100,
        RightExtraUp = 0x200,
        ScrollVertical = 0x400,
        ScrollUp = 0x400,
        ScrollDown = 0x400,
        ScrollHorizontal = 0x800,
        ScrollLeft = 0x800,
        ScrollRight = 0x800,
    }
    [Flags]
    public enum MouseFilterMode : ushort
    {
        None = 0x0000,
        All = 0xFFFF,
        LeftDown = 0x01,
        LeftUp = 0x02,
        RightDown = 0x04,
        RightUp = 0x08,
        MiddleDown = 0x10,
        MiddleUp = 0x20,
        LeftExtraDown = 0x40,
        LeftExtraUp = 0x80,
        RightExtraDown = 0x100,
        RightExtraUp = 0x200,
        MouseWheelVertical = 0x400,
        MouseWheelHorizontal = 0x800,
        MouseMove = 0x1000,
    }
    [Flags]
    public enum MouseFlags : ushort
    {
        MoveRelative = 0x000,
        MoveAbsolute = 0x001,
        VirtualDesktop = 0x002,
        AttributesChanged = 0x004,
        MoveWithoutCoalescing = 0x008,
        TerminalServicesSourceShadow = 0x100
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseStroke
    {
        public MouseState State;
        public MouseFlags Flags;
        public Int16 Rolling;
        public Int32 X;
        public Int32 Y;
        public UInt16 Information;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyStroke
    {
        public Keys Code;
        public KeyState State;
        public UInt32 Information;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct Stroke
    {
        [FieldOffset(0)]
        public MouseStroke Mouse;
        [FieldOffset(0)]
        public KeyStroke Key;
    }
    public static class InterceptionDriver
    {
        [DllImport("interception.dll", EntryPoint = "interception_create_context", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateContext();
        [DllImport("interception.dll", EntryPoint = "interception_destroy_context", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyContext(IntPtr context);
        [DllImport("interception.dll", EntryPoint = "interception_get_precedence", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetPrecedence(IntPtr context, Int32 device);
        [DllImport("interception.dll", EntryPoint = "interception_set_precedence", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPrecedence(IntPtr context, Int32 device, Int32 Precedence);
        [DllImport("interception.dll", EntryPoint = "interception_get_filter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetFilter(IntPtr context, Int32 device);
        [DllImport("interception.dll", EntryPoint = "interception_set_filter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetFilter(IntPtr context, Predicate predicate, Int32 keyboardFilterMode);
        [DllImport("interception.dll", EntryPoint = "interception_wait", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 Wait(IntPtr context);
        [DllImport("interception.dll", EntryPoint = "interception_wait_with_timeout", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 WaitWithTimeout(IntPtr context, UInt64 milliseconds);
        [DllImport("interception.dll", EntryPoint = "interception_send", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 Send(IntPtr context, Int32 device, ref Stroke stroke, UInt32 numStrokes);
        [DllImport("interception.dll", EntryPoint = "interception_receive", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 Receive(IntPtr context, Int32 device, ref Stroke stroke, UInt32 numStrokes);
        [DllImport("interception.dll", EntryPoint = "interception_get_hardware_id", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 GetHardwareId(IntPtr context, Int32 device, String hardwareIdentifier, UInt32 sizeOfString);
        [DllImport("interception.dll", EntryPoint = "interception_is_invalid", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 IsInvalid(Int32 device);
        [DllImport("interception.dll", EntryPoint = "interception_is_keyboard", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 IsKeyboard(Int32 device);
        [DllImport("interception.dll", EntryPoint = "interception_is_mouse", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 IsMouse(Int32 device);
    }
    public class KeyPressedEventArgs : EventArgs
    {
        public Keys Key { get; set; }
        public KeyState State { get; set; }
        public bool Handled { get; set; }
    }
    public enum Keys : ushort
    {
        CANCEL = 70,
        BACK = 14,
        TAB = 15,
        CLEAR = 76,
        RETURN = 28,
        SHIFT = 42,
        CONTROL = 29,
        MENU = 56,
        CAPITAL = 58,
        ESCAPE = 1,
        SPACE = 57,
        PRIOR = 73,
        NEXT = 81,
        END = 79,
        HOME = 71,
        LEFT = 101,
        UP = 100,
        RIGHT = 103,
        DOWN = 102,
        SNAPSHOT = 84,
        INSERT = 91,
        NUMPADDEL = 83,
        NUMPADINSERT = 82,
        HELP = 99,
        APOSTROPHE = 41,
        BACKSPACE = 14,
        PAGEDOWN = 97,
        PAGEUP = 93,
        FIN = 96,
        MOUSE = 105,
        A = 16,
        B = 48,
        C = 46,
        D = 32,
        E = 18,
        F = 33,
        G = 34,
        H = 35,
        I = 23,
        J = 36,
        K = 37,
        L = 38,
        M = 39,
        N = 49,
        O = 24,
        P = 25,
        Q = 30,
        R = 19,
        S = 31,
        T = 20,
        U = 22,
        V = 47,
        W = 44,
        X = 45,
        Y = 21,
        Z = 17,
        LWIN = 91,
        RWIN = 92,
        APPS = 93,
        DELETE = 95,
        NUMPAD0 = 82,
        NUMPAD1 = 79,
        NUMPAD2 = 80,
        NUMPAD3 = 81,
        NUMPAD4 = 75,
        NUMPAD5 = 76,
        NUMPAD6 = 77,
        NUMPAD7 = 71,
        NUMPAD8 = 72,
        NUMPAD9 = 73,
        MULTIPLY = 55,
        ADD = 78,
        SUBTRACT = 74,
        DECIMAL = 83,
        PRINTSCREEN = 84,
        DIVIDE = 53,
        F1 = 59,
        F2 = 60,
        F3 = 61,
        F4 = 62,
        F5 = 63,
        F6 = 64,
        F7 = 65,
        F8 = 66,
        F9 = 67,
        F10 = 68,
        F11 = 87,
        F12 = 88,
        NUMLOCK = 69,
        SCROLLLOCK = 70,
        LEFTSHIFT = 42,
        RIGHTSHIFT = 54,
        LEFTCONTROL = 29,
        RIGHTCONTROL = 99,
        LEFTALT = 56,
        RIGHTALT = 98,
        BROWSER_BACK = 106,
        BROWSER_FORWARD = 105,
        BROWSER_REFRESH = 103,
        BROWSER_STOP = 104,
        BROWSER_SEARCH = 101,
        BROWSER_FAVORITES = 102,
        BROWSER_HOME = 50,
        VOLUME_MUTE = 32,
        VOLUME_DOWN = 46,
        VOLUME_UP = 48,
        MEDIA_NEXT_TRACK = 25,
        MEDIA_PREV_TRACK = 16,
        MEDIA_STOP = 36,
        MEDIA_PLAY_PAUSE = 34,
        LAUNCH_MAIL = 108,
        LAUNCH_MEDIA_SELECT = 109,
        LAUNCH_APP1 = 107,
        LAUNCH_APP2 = 33,
        OEM_1 = 27,
        OEM_PLUS = 13,
        OEM_COMMA = 50,
        OEM_MINUS = 0,
        OEM_PERIOD = 51,
        OEM_2 = 52,
        OEM_3 = 40,
        OEM_4 = 12,
        OEM_5 = 43,
        OEM_6 = 26,
        OEM_7 = 41,
        OEM_8 = 53,
        OEM_102 = 86,
        EREOF = 93,
        ZOOM = 98,
        Escape = 1,
        One = 2,
        Two = 3,
        Three = 4,
        Four = 5,
        Five = 6,
        Six = 7,
        Seven = 8,
        Eight = 9,
        Nine = 10,
        Zero = 11,
        DashUnderscore = 12,
        PlusEquals = 13,
        Backspace = 14,
        Tab = 15,
        OpenBracketBrace = 26,
        CloseBracketBrace = 27,
        Enter = 28,
        Control = 29,
        SemicolonColon = 39,
        SingleDoubleQuote = 40,
        Tilde = 41,
        LeftShift = 42,
        BackslashPipe = 43,
        CommaLeftArrow = 51,
        PeriodRightArrow = 52,
        ForwardSlashQuestionMark = 53,
        RightShift = 54,
        RightAlt = 56,
        Space = 57,
        CapsLock = 58,
        Up = 72,
        Down = 80,
        Right = 77,
        Left = 75,
        Home = 71,
        End = 79,
        Delete = 83,
        PageUp = 73,
        PageDown = 81,
        Insert = 82,
        PrintScreen = 55,
        NumLock = 69,
        ScrollLock = 70,
        Menu = 93,
        WindowsKey = 91,
        NumpadDivide = 53,
        NumpadAsterisk = 55,
        Numpad7 = 71,
        Numpad8 = 72,
        Numpad9 = 73,
        Numpad4 = 75,
        Numpad5 = 76,
        Numpad6 = 77,
        Numpad1 = 79,
        Numpad2 = 80,
        Numpad3 = 81,
        Numpad0 = 82,
        NumpadDelete = 83,
        NumpadEnter = 28,
        NumpadPlus = 78,
        NumpadMinus = 74,
    }
    public class MousePressedEventArgs : EventArgs
    {
        public MouseState State { get; set; }
        public bool Handled { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public short Rolling { get; set; }
    }
    public enum ScrollDirection
    {
        Down,
        Up
    }
}