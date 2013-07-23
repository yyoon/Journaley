using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DayOneWindowsClient.Utilities
{
    class Logger
    {
        private static readonly string LOG_FILE = "error.log";

        public static void Log(string logMessage)
        {
            using (StreamWriter w = File.AppendText(LOG_FILE))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
        }
    }
}
