using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace Taurus
{
    static class Program
    {
        [DllImport("User32.dll", EntryPoint = "IsIconic")]
        private static extern int IsIconic(IntPtr hWnd);
        [DllImport("User32.dll", EntryPoint = "OpenIcon")]
        private static extern long OpenIcon(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AutoRegister();
            bool createdNew = true;
            Mutex mutex = new Mutex(true, "WorkSystemV3", out createdNew);
            if (createdNew)
            {
                System.Globalization.CultureInfo UICulture = new Base().InitLangName();
                SystemInfo.AppTitleLNG[0] = "金牛考勤软件";
                SystemInfo.AppTitleLNG[1] = "金牛考勤軟件";
                SystemInfo.AppTitleLNG[SystemInfo.AppTitleLNG.Length - 1] = "Attendance software";
                switch (SystemInfo.LangName)
                {
                    case "CHS"://简体中文
                        SystemInfo.AppTitle = SystemInfo.AppTitleLNG[0];
                        break;
                    case "CHT"://繁体中文
                        SystemInfo.AppTitle = SystemInfo.AppTitleLNG[1];
                        break;
                    default:
                        SystemInfo.AppTitle = SystemInfo.AppTitleLNG[SystemInfo.AppTitleLNG.Length - 1];
                        break;
                }
                SystemInfo.AppVersion = "V" + Application.ProductVersion;
                SystemInfo.CustomerName = "";
                SystemInfo.AllowInOutMode = false;
                Thread.CurrentThread.CurrentUICulture = UICulture;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SystemInfo.IsZhNeutral = false;
               
                if (new frmLogin().ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmMain());
                    mutex.Close();
                    if (SystemInfo.IsRestart)
                    {
                        SystemInfo.IsRestart = false;
                        Application.Restart();
                    }
                }
                else
                {
                    SystemInfo.db.Close();
                    mutex.Close();
                    if (SystemInfo.IsRestart)
                    {
                        SystemInfo.IsRestart = false;
                        Application.Restart();
                    }
                }               
            }
            else
            {
                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id)
                    {
                        if (IsIconic(process.MainWindowHandle) > 0)
                            OpenIcon(process.MainWindowHandle);
                        else
                            SetForegroundWindow(process.MainWindowHandle);
                        break;
                    }
                }
            }
        }

        private static void AutoRegister()
        {
            RegisterDllOcx("HSCPID.dll");
            RegisterDllOcx("grdes50.dll");
            RegisterDllOcx("gregn50.dll");
            RegisterDllOcx("RealSvrOcxTcp.ocx");
        }

        unsafe internal delegate UInt32 DllRegisterServer();
        [DllImport("kernel32.dll")]
        private extern static IntPtr LoadLibrary(String LibFileName);
        [DllImport("kernel32.dll")]
        private extern static IntPtr GetProcAddress(IntPtr hModule, String ProcName);
        [DllImport("kernel32.dll")]
        private extern static bool FreeLibrary(IntPtr hModule);
        private static void RegisterDllOcx(string fileName)
        {
            IntPtr hLib = LoadLibrary(fileName);
            if (hLib != IntPtr.Zero)
            {
                IntPtr proc = GetProcAddress(hLib, "DllRegisterServer");
                if (proc != IntPtr.Zero)
                {
                    try
                    {
                        DllRegisterServer drs = (DllRegisterServer)Marshal.GetDelegateForFunctionPointer(proc, typeof(DllRegisterServer));
                        drs();
                    }
                    catch
                    {
                    }
                    finally
                    {
                    }
                }
                FreeLibrary(hLib);
            }
        }
    }
}