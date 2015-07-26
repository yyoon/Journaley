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
            this.RecalculateHeight();
            base.OnResize(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="pe">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            using (Pen pen = new Pen(Brushes.Black))
            {
                pe.Graphics.DrawLine(pen, 0, 0, this.Width - 1, 0);
                pe.Graphics.DrawLine(pen, 0, this.Height - 1, this.Width - 1, this.Height - 1);
            }
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

            // 2 pixels are added for the border.
            this.Height = (this.BackgroundImage.Height * this.Width / this.BackgroundImage.Width) + 2;
        }
    }
}
