namespace Journaley.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

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
            base.OnResize(e);

            this.RecalculateDestImageBounds();
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
                if (this.ImageHover)
                {
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
