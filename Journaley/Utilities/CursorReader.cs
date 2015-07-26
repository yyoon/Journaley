namespace Journaley.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Helper class that reads byte array for a cursor and returns a Cursor object.
    /// </summary>
    public class CursorReader
    {
        /// <summary>
        /// Loads the cursor from resource.
        /// </summary>
        /// <param name="byteArray">The byte array.</param>
        /// <returns>The Cursor object.</returns>
        public static Cursor LoadCursorFromResource(byte[] byteArray)
        {
            string fileName = Path.ChangeExtension(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()), ".cur");
            File.WriteAllBytes(fileName, byteArray);

            Cursor result = new Cursor(PInvoke.LoadCursorFromFile(fileName));

            File.Delete(fileName);

            return result;
        }
    }
}
