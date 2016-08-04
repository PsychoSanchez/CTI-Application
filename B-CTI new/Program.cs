using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using BCTI.DialogBoxes;
using Ionic.Zip;
using SendFileTo;
using System.IO;

namespace BCTI
{
    static class Program
    {
        #region Dll Imports
        private const int HWND_BROADCAST = 0xFFFF;

        //public static readonly uint BCTI_CALLTo = RegisterWindowMessage("BCTI_CALLTO");
        public const int WM_CALLTO = 0x004A;

        [DllImport("user32")]
        private static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        //static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam); // original
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, ref COPYDATASTRUCT cds); // override
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }
        #endregion Dll Imports
        /// <summary>
        /// Мьютекс указывающий, что приложение уже запущено
        /// </summary>
        static Mutex mutex = new Mutex(false, "{4EABFF23-A35E-F0AB-3189-C823113BCAFF1}");
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ///Проверка запущено ли приложение, если да отправляем ему аргумент
            if (!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
            {
                if (args.Length < 1)
                    BMessageBox.Show("Application already started!", BMessageBoxButtons.OK);
                else
                {
                    COPYDATASTRUCT cds;
                    cds.dwData = IntPtr.Zero;
                    string arg = string.Empty;
                    foreach (string s in args)
                    {
                        arg += s;
                    }
                    cds.lpData = Marshal.StringToHGlobalAnsi(arg);
                    cds.cbData = args[0].Length;
                    ///Отправляем сообщение с callto 
                    SendMessage((IntPtr)HWND_BROADCAST, (int)WM_CALLTO, IntPtr.Zero, ref cds);
                    //PostMessage((IntPtr)HWND_BROADCAST, BCTI_CALLTo, Marshal.StringToHGlobalUni(args[0]), new IntPtr());
                }
                return;
            }
            ///Проверка запущена ли дебаговая версия
            if (!AppDomain.CurrentDomain.FriendlyName.EndsWith("vshost.exe"))
            {
                Application.ThreadException += Application_ThreadException;
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            }
            try
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BLFPanel(args));
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        ///Необработаное исключение в потоке
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                BMessageBox.Show("Unhandled exception catched. Application is going to close now. You can read more in log files");
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Exception inside handler.", "Fatal WinForm Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    mutex.ReleaseMutex();
                    Application.Exit();
                }
            }
        }
        ///Необработанное исключение, обрабатываем и записываем в лог
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                ///Обрабатываем исключение и записываем в лог.
                Exception ex = (Exception)e.ExceptionObject;
                string errMessage = "An application error occupied. More information about exception in log file";
                EventLogs.WriteLog("Unhandled exception", ex.Message + "\r\n" + ex.StackTrace);
                DateTime savefile = DateTime.UtcNow;
                switch (BMessageBox.Show(errMessage + "Unhandled exception:" + ex.Message, "Unhandled Exception", BMessageBoxButtons.AbortRetryIgnore))
                {
                    case DialogResult.Abort:
                        using (ZipFile zip = new ZipFile())
                        {
                            try
                            {
                                zip.AddSelectedFiles("*", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\" + DateTime.Today.ToShortDateString() + "\\", string.Empty, false);
                                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\B-Cti\\log\\"))
                                {
                                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\B-Cti");
                                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\B-Cti\\log");
                                }
                                zip.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\B-Cti\\log\\" + savefile);
                            }
                            catch (Exception exe)
                            {
                                EventLogs.WriteLog("Error occupied while zipping folder", exe.Message);
                            }
                        }
                        try
                        {
                            MAPI mapi = new MAPI();
                            mapi.AddAttachment(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\B -Cti\\log\\" + savefile);
                            mapi.AddRecipientTo("support@b-cti.com");
                            mapi.SendMailPopup("Application Exception", "Unhandled Exception catched. \r\nOs version: " + Environment.OSVersion + "\r\nLast error info:" + ex.Message + "\r\n" + ex.StackTrace + "\r\n" + ex.HelpLink + "\r\n" + ex.InnerException);
                        }
                        catch (Exception exe)
                        {
                            EventLogs.WriteLog(exe.Message);
                            var proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = string.Format("mailto:support@b-cti.com?subject=b-cti bugthread" + "&body=Unhandled Exception catched. \r\nOs version: " + Environment.OSVersion + "\r\nPlease manually attach debug file from path: " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\B -Cti\\log\\" + savefile + "\r\n\r\n" + "Last error info:" + ex.Message + "\r\n" + ex.StackTrace + "\r\n" + ex.HelpLink + "\r\n" + ex.InnerException + "&attach=" + savefile);
                            proc.StartInfo.UseShellExecute = true;
                            proc.StartInfo.RedirectStandardOutput = false;
                            proc.Start();
                        }
                        break;
                    case DialogResult.Retry:
                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddSelectedFiles("*", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\" + DateTime.Today.ToShortDateString() + "\\", string.Empty, false);
                            zip.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\B-Cti\\log\\" + savefile);
                        }
                        break;
                    case DialogResult.Ignore:
                        break;
                    default:
                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddSelectedFiles("*", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\" + DateTime.Today.ToShortDateString() + "\\", string.Empty, false);
                            zip.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\B-Cti\\log\\" + savefile);
                        }
                        break;
                }
                ///Журнал собыий виндоус. Полезно для сисадминов. И дебага без файлов.
                EventLog log = new EventLog();
                log.Source = "ThreadException";
                log.WriteEntry(errMessage + "" + ex.Message + "StackTrace:" + ex.StackTrace);
            }
            catch (Exception exsep)
            {
                EventLogs.WriteLog("Fatal Exception inside handler", exsep.Message);
                BMessageBox.Show("Fatal Exception inside handler.", "Fatal WinForm Error", BMessageBoxButtons.OK, BMessageBoxIcon.Stop);
            }
            finally
            {
                mutex.ReleaseMutex();
                Application.Exit();
            }
        }
    }
}

