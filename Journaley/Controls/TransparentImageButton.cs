namespace Journaley.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Transparent Image Button
    /// </summary>
    public class TransparentImageButton : ImageButton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransparentImageButton"/> class.
        /// </summary>
        public TransparentImageButton()
        {
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
        }

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
