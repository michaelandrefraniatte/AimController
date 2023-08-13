using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;
using OpenWithSingleInstance;
namespace SIGIL
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            if (!hasAdminRights() & !AlreadyRunning())
            {
                RunElevated();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (SingleInstanceHelper.CheckInstancesUsingMutex() && args.Length > 0)
            {
                Process _otherInstance = SingleInstanceHelper.GetAlreadyRunningInstance();
                MessageHelper.SendDataMessage(_otherInstance, args[0]);
                return;//Exit this instance and let the existing one open the file
            }
            if (AlreadyRunning())
            {
                return;
            }
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
        public static bool hasAdminRights()
        {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        public static void RunElevated()
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.Verb = "runas";
                processInfo.FileName = Application.ExecutablePath;
                Process.Start(processInfo);
            }
            catch { }
        }
    }
}