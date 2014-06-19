namespace Journaley.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel;

    /// <summary>
    /// Control for displaying an entry photo.
    /// </summary>
    public class EntryPhotoArea : Control
    {
        private Image image;

        private bool expanded;

        private bool hover;

        private bool imageHover;

        public EntryPhotoArea()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public event EventHandler ImageClick;

        public event EventHandler BackButtonClick;

        public event EventHandler PopoutButtonClick;

        /// <summary>
        /// Gets or sets the mask image.
        /// </summary>
        /// <value>
        /// The mask image.
        /// </value>
        [Category("Appearance")]
        [Description("Mask image to show when the mouse is over the image.")]
        public Image MaskImage { get; set; }

        public Image Image
        {
            get
            {
                return this.image;
            }

            set
            {
                if (this.image != value)
                {
                    this.image = value;

                    this.RecalculateDestImageBounds();
                    this.Refresh();
                }
            }
        }

        public bool Expanded
        {
            get
            {
                return this.expanded;
            }

            set
            {
                if (this.expanded != value)
                {
                    this.expanded = value;
                    this.Refresh();
                }
            }
        }

        public bool Hover
        {
            get
            {
                return this.hover;
            }

            set
            {
                if (this.hover != value)
                {
                    this.hover = value;
                    this.Refresh();
                }
            }
        }

        public bool ImageHover
        {
            get
            {
                return this.imageHover;
            }

            set
            {
                if (this.imageHover != value)
                {
                    this.imageHover = value;
                    this.Refresh();
                }
            }
        }

        private Rectangle DestImageBounds { get; set; }

        protected override void OnResize(EventArgs e)
        {
            this.RecalculateDestImageBounds();

            base.OnResize(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.Hover = true;
            this.ImageHover = this.DestImageBounds.Contains(e.Location);

            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Hover = false;
            this.ImageHover = false;

            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Do nothing if there is no image set for now.
            if (this.Image == null)
            {
                return;
            }

            // Draw the image!
            e.Graphics.DrawImage(this.Image, this.DestImageBounds);

            // Draw the 1px border line above / below the image.
            using (Pen pen = new Pen(Color.Black))
            {
                e.Graphics.DrawLine(pen, 0, this.DestImageBounds.Top - 1, this.Width - 1, this.DestImageBounds.Top - 1);
                e.Graphics.DrawLine(pen, 0, this.DestImageBounds.Bottom, this.Width - 1, this.DestImageBounds.Bottom);
            }

            if (this.Expanded)
            {
            }
            else
            {
                // Draw the hover mask, if needed.
                if (this.ImageHover && this.MaskImage != null)
                {
                    e.Graphics.DrawImage(this.MaskImage, this.DestImageBounds);
                }
            }

            base.OnPaint(e);
        }

        private void RecalculateDestImageBounds()
        {
            if (this.Image == null)
            {
                this.DestImageBounds = Rectangle.Empty;
                return;
            }

            int destHeight = this.Image.Height * this.Width / this.Image.Width;

            this.DestImageBounds = new Rectangle(
                0,
                (this.Height - destHeight) / 2,
                this.Width,
                destHeight);
        }
    }
}
