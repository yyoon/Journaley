namespace Journaley
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using Journaley.Forms;
    using Journaley.Utilities;

    /// <summary>
    /// Main entry point
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            bool firstInstance = false;
            var mutex = new Mutex(true, "Journaley.Instance", out firstInstance);

            MainForm.NewEntryMessage = PInvoke.RegisterWindowMessage("Journaley.NewEntry");
            bool newEntry = false;
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                switch (Environment.GetCommandLineArgs()[1])
                {
                    case "NewEntry":
                        newEntry = true;
                        break;

                    default:
                        break;
                }
            }

            if (firstInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(newEntry, true));
            }
            else
            {
                if (newEntry)
                {
                    SendNewEntryMessage();
                }

                return;
            }

            GC.KeepAlive(mutex);
        }

        /// <summary>
        /// Sends the new entry message to the existing Journaley window.
        /// </summary>
        private static void SendNewEntryMessage()
        {
            IntPtr windowHandle = PInvoke.FindWindow(null, "Journaley");
            if (windowHandle == IntPtr.Zero)
            {
                return;
            }

            PInvoke.SendMessage(windowHandle, MainForm.NewEntryMessage, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
