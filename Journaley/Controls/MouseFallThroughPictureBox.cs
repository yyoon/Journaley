namespace Journaley.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Journaley.Utilities;

    /// <summary>
    /// Picture box control that relays all the mouse events to its parent.
    /// </summary>
    public class MouseFallThroughPictureBox : PictureBox
    {
        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            switch ((PInvoke.WindowsMessages)m.Msg)
            {
                case PInvoke.WindowsMessages.WM_NCHITTEST:
                    m.Result = (IntPtr)PInvoke.HitTestValues.HTTRANSPARENT;
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
