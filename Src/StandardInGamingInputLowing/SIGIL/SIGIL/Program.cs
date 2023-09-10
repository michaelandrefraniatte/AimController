using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using OpenWithSingleInstance;
namespace SIGIL
{
    internal static class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            if (AlreadyRunning())
            {
                if (File.Exists(Application.StartupPath + @"\temphandle"))
                    using (System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\temphandle"))
                    {
                        IntPtr handle = new IntPtr(int.Parse(file.ReadLine()));
                        ShowWindow(handle, 9);
                        SetForegroundWindow(handle);
                        Microsoft.VisualBasic.Interaction.AppActivate(file.ReadLine());
                    }
                if (SingleInstanceHelper.CheckInstancesUsingMutex() && args.Length > 0)
                {
                    Process _otherInstance = SingleInstanceHelper.GetAlreadyRunningInstance();
                    MessageHelper.SendDataMessage(_otherInstance, args[0]);
                }
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args.Length > 0 ? args[0] : null));
        }
        private static bool AlreadyRunning()
        {
            String thisprocessname = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(thisprocessname);
            if (processes.Length > 1)
                return true;
            else
                return false;
        }
    }
}