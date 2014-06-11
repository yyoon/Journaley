namespace Journaley.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// TableLayoutPanel with a transparent background.
    /// </summary>
    public class TransparentTableLayoutPanel : TableLayoutPanel
    {
        /// <summary>
        /// Gets the create parameters object.
        /// </summary>
        /// <value>
        /// The create parameters object with the transparent flag added.
        /// </value>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;

                return cp;
            }
        }
    }
}
