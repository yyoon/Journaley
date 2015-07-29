namespace Journaley.Core.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    using System.Text;

    /// <summary>
    /// A class containing a convenient method to retrieve a user-friendly name of the running OS.
    /// </summary>
    public static class OSNameRetriever
    {
        /// <summary>
        /// Gets the friendly name of the running OS.
        /// </summary>
        /// <returns>The friendly name of the running OS.</returns>
        public static string GetOSFriendlyName()
        {
            // Code retrieved from: http://stackoverflow.com/a/6331863/922135
            string result = string.Empty;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                "SELECT Caption FROM Win32_OperatingSystem");

            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }

            if (result != null && result.Contains("Windows "))
            {
                result = result.Replace("Windows ", "Windows/");
            }

            return result.Trim();
        }
    }
}
