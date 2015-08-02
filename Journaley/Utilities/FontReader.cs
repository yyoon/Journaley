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
        /// <param name="fontName">Name of the font file.</param>
        /// <param name="fontData">The font data.</param>
        /// <returns>The FontFamily object to be used.</returns>
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

        /// <summary>
        /// Reads the embedded font for WPF.
        /// </summary>
        /// <param name="fontName">Name of the font.</param>
        /// <param name="fontFamilyName">Name of the font family.</param>
        /// <returns>The FontFamily object to be used.</returns>
        public static System.Windows.Media.FontFamily ReadEmbeddedFont(string fontName, string fontFamilyName)
        {
            string path = Path.GetTempPath().Replace('\\', '/');
            path += "#" + fontFamilyName;

            return new System.Windows.Media.FontFamily(path);
        }
    }
}
