namespace Journaley.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

        private Image backButtonNormalImage;

        private int backButtonYPos;

        private Image backButtonLabelImage;

        private int backButtonLabelYPos;

        private Image popoutButtonNormalImage;

        private int popoutButtonYPos;

        private Image popoutButtonLabelImage;

        private int popoutButtonLabelYPos;

        private bool expanded;

        private bool hover;

        private bool imageHover;

        private bool backButtonHover;

        private bool popoutButtonHover;

        public EntryPhotoArea()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        [Category("Action")]
        public event EventHandler ImageClick;

        [Category("Action")]
        public event EventHandler BackButtonClick;

        [Category("Action")]
        public event EventHandler PopoutButtonClick;

        /// <summary>
        /// Gets or sets the mask image.
        /// Not intended to be changed at runtime.
        /// </summary>
        /// <value>
        /// The mask image.
        /// </value>
        [Category("Appearance")]
        [Description("Mask image to show when the mouse is over the image.")]
        public Image MaskImage { get; set; }

        [Category("Appearance")]
        [Description("Back button normal image.")]
        public Image BackButtonNormalImage
        {
            get
            {
                return this.backButtonNormalImage;
            }

            set
            {
                if (this.backButtonNormalImage != value)
                {
                    this.backButtonNormalImage = value;
                    this.RecalculateBackButtonBounds();
                }
            }
        }

        [Category("Appearance")]
        [Description("Back button hover image.")]
        public Image BackButtonHoverImage { get; set; }

        [Category("Appearance")]
        [Description("Back button's y position relative to the photo area.")]
        public int BackButtonYPos
        {
            get
            {
                return this.backButtonYPos;
            }

            set
            {
                if (this.backButtonYPos != value)
                {
                    this.backButtonYPos = value;
                    this.RecalculateBackButtonBounds();
                }
            }
        }

        [Category("Appearance")]
        [Description("Back button label image.")]
        public Image BackButtonLabelImage
        {
            get
            {
                return this.backButtonLabelImage;
            }

            set
            {
                if (this.backButtonLabelImage != value)
                {
                    this.backButtonLabelImage = value;
                    this.RecalculateBackButtonLabelBounds();
                }
            }
        }

        [Category("Appearance")]
        [Description("Back button label y position relative to the photo area.")]
        public int BackButtonLabelYPos
        {
            get
            {
                return this.backButtonLabelYPos;
            }

            set
            {
                if (this.backButtonLabelYPos != value)
                {
                    this.backButtonLabelYPos = value;
                    this.RecalculateBackButtonLabelBounds();
                }
            }
        }

        [Category("Appearance")]
        [Description("Popout button normal image.")]
        public Image PopoutButtonNormalImage
        {
            get
            {
                return this.popoutButtonNormalImage;
            }

            set
            {
                if (this.popoutButtonNormalImage != value)
                {
                    this.popoutButtonNormalImage = value;
                    this.RecalculatePopoutButtonBounds();
                }
            }
        }

        [Category("Appearance")]
        [Description("Popout button hover image.")]
        public Image PopoutButtonHoverImage { get; set; }

        [Category("Appearance")]
        [Description("Popout button's y position relative to the photo area.")]
        public int PopoutButtonYPos
        {
            get
            {
                return this.popoutButtonYPos;
            }

            set
            {
                if (this.popoutButtonYPos != value)
                {
                    this.popoutButtonYPos = value;
                    this.RecalculatePopoutButtonBounds();
                }
            }
        }

        [Category("Appearance")]
        [Description("Popout button label image.")]
        public Image PopoutButtonLabelImage
        {
            get
            {
                return this.popoutButtonLabelImage;
            }

            set
            {
                if (this.popoutButtonLabelImage != value)
                {
                    this.popoutButtonLabelImage = value;
                    this.RecalculatePopoutButtonLabelBounds();
                }
            }
        }

        [Category("Appearance")]
        [Description("Popout button label y position relative to the photo area.")]
        public int PopoutButtonLabelYPos
        {
            get
            {
                return this.popoutButtonLabelYPos;
            }

            set
            {
                if (this.popoutButtonLabelYPos != value)
                {
                    this.popoutButtonLabelYPos = value;
                    this.RecalculatePopoutButtonLabelBounds();
                }
            }
        }

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

        public bool BackButtonHover
        {
            get
            {
                return this.backButtonHover;
            }

            set
            {
                if (this.backButtonHover != value)
                {
                    this.backButtonHover = value;
                    this.Invalidate(this.BackButtonBounds);
                    this.Invalidate(this.BackButtonLabelBounds);
                    this.Update();
                }
            }
        }

        public bool PopoutButtonHover
        {
            get
            {
                return this.popoutButtonHover;
            }

            set
            {
                if (this.popoutButtonHover != value)
                {
                    this.popoutButtonHover = value;
                    this.Invalidate(this.PopoutButtonBounds);
                    this.Invalidate(this.PopoutButtonLabelBounds);
                    this.Update();
                }
            }
        }

        private Rectangle DestImageBounds { get; set; }

        private Rectangle BackButtonBounds { get; set; }

        private Rectangle BackButtonLabelBounds { get; set; }

        private Rectangle PopoutButtonBounds { get; set; }

        private Rectangle PopoutButtonLabelBounds { get; set; }

        private bool ButtonsVisible
        {
            get
            {
                return this.Expanded && this.Hover;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            this.RecalculateDestImageBounds();
            this.RecalculateButtonBounds();

            base.OnResize(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.Hover = true;
            this.ImageHover = this.DestImageBounds.Contains(e.Location);
            this.BackButtonHover = this.BackButtonBounds.Contains(e.Location);
            this.PopoutButtonHover = this.PopoutButtonBounds.Contains(e.Location);

            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Hover = false;
            this.ImageHover = false;

            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.BackButtonHover)
            {
                // Raise the BackButtonClick event.
                if (this.BackButtonClick != null)
                {
                    this.BackButtonClick(this, EventArgs.Empty);
                }
            }
            else if (this.PopoutButtonHover)
            {
                // Raise the PopoutButtonClick event.
                if (this.PopoutButtonClick != null)
                {
                    this.PopoutButtonClick(this, EventArgs.Empty);
                }
            }
            else if (this.ImageHover)
            {
                // Raise the ImageClick event.
                if (this.ImageClick != null)
                {
                    this.ImageClick(this, EventArgs.Empty);
                }
            }

            base.OnMouseDown(e);
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
                if (this.Hover)
                {
                    // Back button
                    if (this.BackButtonHover)
                    {
                        // Draw the label.
                        e.Graphics.DrawImage(this.BackButtonLabelImage, this.BackButtonLabelBounds);

                        // Draw the hover button.
                        e.Graphics.DrawImage(this.BackButtonHoverImage, this.BackButtonBounds);
                    }
                    else
                    {
                        // Draw the normal button.
                        e.Graphics.DrawImage(this.BackButtonNormalImage, this.BackButtonBounds);
                    }

                    // Popout button
                    if (this.PopoutButtonHover)
                    {
                        // Draw the label.
                        e.Graphics.DrawImage(this.PopoutButtonLabelImage, this.PopoutButtonLabelBounds);

                        // Draw the hover button.
                        e.Graphics.DrawImage(this.PopoutButtonHoverImage, this.PopoutButtonBounds);
                    }
                    else
                    {
                        // Draw the normal button.
                        e.Graphics.DrawImage(this.PopoutButtonNormalImage, this.PopoutButtonBounds);
                    }
                }
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

        private void RecalculateButtonBounds()
        {
            this.RecalculateBackButtonBounds();
            this.RecalculateBackButtonLabelBounds();
            this.RecalculatePopoutButtonBounds();
            this.RecalculatePopoutButtonLabelBounds();
        }

        private void RecalculateBackButtonBounds()
        {
            this.BackButtonBounds = this.RecalculateBoundsHelper(this.BackButtonNormalImage, this.BackButtonYPos);
        }

        private void RecalculateBackButtonLabelBounds()
        {
            this.BackButtonLabelBounds = this.RecalculateBoundsHelper(this.BackButtonLabelImage, this.BackButtonLabelYPos);
        }

        private void RecalculatePopoutButtonBounds()
        {
            this.PopoutButtonBounds = this.RecalculateBoundsHelper(this.PopoutButtonNormalImage, this.PopoutButtonYPos);
        }

        private void RecalculatePopoutButtonLabelBounds()
        {
            this.PopoutButtonLabelBounds = this.RecalculateBoundsHelper(this.PopoutButtonLabelImage, this.PopoutButtonLabelYPos);
        }

        private Rectangle RecalculateBoundsHelper(Image image, int ypos)
        {
            if (image == null)
            {
                return Rectangle.Empty;
            }

            return new Rectangle(
                (this.Width - image.Width) / 2,
                this.GetActualYPos(ypos, image.Height),
                image.Width,
                image.Height);
        }

        private int GetActualYPos(int ypos, int imageHeight)
        {
            return ypos >= 0 ? ypos : this.Height + ypos - imageHeight + 1;
        }
    }
}
