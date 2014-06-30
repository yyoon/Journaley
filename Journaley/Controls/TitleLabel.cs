namespace Journaley.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Journaley.Utilities;

    /// <summary>
    /// TitleLabel class to force background fill.
    /// </summary>
    public class TitleLabel : Label
    {
        /// <summary>
        /// Force fill the background color.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            base.OnPaint(e);
        }

        /// <summary>
        /// Windows message loop
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            switch ((PInvoke.WindowsMessages)m.Msg)
            {
                // Relay the mouse events to its parent.
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
