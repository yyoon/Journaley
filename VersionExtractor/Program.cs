namespace VersionExtractor
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This program extracts the version number string from the given assembly.
    /// Used when packaging the Squirrel installer.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            if (args.Length != 2 ||
                !File.Exists(args[0]) ||
                (args[1] != "Stable" && args[1] != "Develop"))
            {
                Console.WriteLine("Usage: VersionExtractor <AssemblyPath> <Stable|Develop>");
                Environment.Exit(1);
            }

            FileVersionInfo ver = FileVersionInfo.GetVersionInfo(args[0]);

            if (args[1] == "Stable")
            {
                Console.WriteLine(string.Empty + ver.FileMajorPart + "." + ver.FileMinorPart);
            }
            else
            {
                Console.WriteLine(ver.FileVersion);
            }
        }
    }
}
