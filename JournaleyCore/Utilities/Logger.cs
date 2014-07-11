namespace Journaley.Utilities
{
    using System;
    using System.IO;
    using Journaley.Models;

    /// <summary>
    /// A utility class used for error logging.
    /// </summary>
    internal class Logger
    {
        /// <summary>
        /// The log file name.
        /// </summary>
        private static readonly string LogFile = "error.log";

        /// <summary>
        /// Logs the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public static void Log(string logMessage)
        {
            using (StreamWriter w = File.AppendText(Settings.GetFilePathUnderApplicationData(LogFile)))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine(
                    "{0} {1}",
                    DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
        }
    }
}
