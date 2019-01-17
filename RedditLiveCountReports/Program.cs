using LivecountStats.DataLayer;
using System;
using System.Data.Entity;
using System.Threading;
using System.Windows.Forms;

namespace LivecountStats.App.UI
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{60ECB2E2-EAD6-44C1-859C-279A67DB1E6C}");

        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDataContext, AppConfigDatabase>());

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                mutex.ReleaseMutex();
            }
            else
            {
                // send our Win32 message to make the currently running instance
                // jump on top of all the other windows
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
        }
    }
}
