namespace Journaley.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Fixed width picture box to be used for the entry photo.
    /// </summary>
    public class FixedWidthPictureBox : PictureBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedWidthPictureBox"/> class.
        /// </summary>
        public FixedWidthPictureBox()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }

            set
            {
                base.BackgroundImage = value;
                this.RecalculateHeight();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.RecalculateHeight();
        }

        /// <summary>
        /// Recalculates the height of this image.
        /// </summary>
        private void RecalculateHeight()
        {
            if (this.BackgroundImage == null)
            {
                this.Height = 0;
                return;
            }

            this.Height = this.BackgroundImage.Height * this.Width / this.BackgroundImage.Width;
        }
    }
}
