namespace Journaley.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Text;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Helper class that reads byte array binary font file and return font family.
    /// </summary>
    public class FontReader
    {
        /// <summary>
        /// Reads the embedded font.
        /// </summary>
        /// <param name="fontData">The font data.</param>
        /// <returns></returns>
        public static FontFamily ReadEmbeddedFont(string fontName, byte[] fontData)
        {
            IntPtr memoryData = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, memoryData, fontData.Length);

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(memoryData, fontData.Length);

            Marshal.FreeCoTaskMem(memoryData);

            string fontFilePath = Path.Combine(Path.GetTempPath(), fontName);
            File.WriteAllBytes(fontFilePath, fontData);
            PInvoke.AddFontResourceEx(fontFilePath, 0x10, IntPtr.Zero);

            return pfc.Families[0];
        }
    }
}
