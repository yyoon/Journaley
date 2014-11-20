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
        /// <summary>
        /// The image
        /// </summary>
        private Image image;

        /// <summary>
        /// The back button normal image
        /// </summary>
        private Image backButtonNormalImage;

        /// <summary>
        /// The back button Y position
        /// </summary>
        private int backButtonYPos;

        /// <summary>
        /// The back button label image
        /// </summary>
        private Image backButtonLabelImage;

        /// <summary>
        /// The back button label Y position
        /// </summary>
        private int backButtonLabelYPos;

        /// <summary>
        /// The popout button normal image
        /// </summary>
        private Image popoutButtonNormalImage;

        /// <summary>
        /// The popout button Y position
        /// </summary>
        private int popoutButtonYPos;

        /// <summary>
        /// The popout button label image
        /// </summary>
        private Image popoutButtonLabelImage;

        /// <summary>
        /// The popout button label Y position
        /// </summary>
        private int popoutButtonLabelYPos;

        /// <summary>
        /// The expanded
        /// </summary>
        private bool expanded;

        /// <summary>
        /// The hover
        /// </summary>
        private bool hover;

        /// <summary>
        /// The image hover
        /// </summary>
        private bool imageHover;

        /// <summary>
        /// The back button hover
        /// </summary>
        private bool backButtonHover;

        /// <summary>
        /// The popout button hover
        /// </summary>
        private bool popoutButtonHover;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntryPhotoArea"/> class.
        /// </summary>
        public EntryPhotoArea()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        /// <summary>
        /// Occurs when [image click].
        /// </summary>
        [Category("Action")]
        public event EventHandler ImageClick;

        /// <summary>
        /// Occurs when [back button click].
        /// </summary>
        [Category("Action")]
        public event EventHandler BackButtonClick;

        /// <summary>
        /// Occurs when [popout button click].
        /// </summary>
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

        /// <summary>
        /// Gets or sets the back button normal image.
        /// </summary>
        /// <value>
        /// The back button normal image.
        /// </value>
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

        /// <summary>
        /// Gets or sets the back button hover image.
        /// </summary>
        /// <value>
        /// The back button hover image.
        /// </value>
        [Category("Appearance")]
        [Description("Back button hover image.")]
        public Image BackButtonHoverImage { get; set; }

        /// <summary>
        /// Gets or sets the back button Y position.
        /// A negative number -i indicates that the image should appear (i-1)pixel apart from the very bottom.
        /// </summary>
        /// <value>
        /// The back button Y position.
        /// </value>
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

        /// <summary>
        /// Gets or sets the back button label image.
        /// </summary>
        /// <value>
        /// The back button label image.
        /// </value>
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

        /// <summary>
        /// Gets or sets the back button label Y position.
        /// A negative number -i indicates that the image should appear (i-1)pixel apart from the very bottom.
        /// </summary>
        /// <value>
        /// The back button label Y position.
        /// </value>
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

        /// <summary>
        /// Gets or sets the popout button normal image.
        /// </summary>
        /// <value>
        /// The popout button normal image.
        /// </value>
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

        /// <summary>
        /// Gets or sets the popout button hover image.
        /// </summary>
        /// <value>
        /// The popout button hover image.
        /// </value>
        [Category("Appearance")]
        [Description("Popout button hover image.")]
        public Image PopoutButtonHoverImage { get; set; }

        /// <summary>
        /// Gets or sets the popout button Y position.
        /// A negative number -i indicates that the image should appear (i-1)pixel apart from the very bottom.
        /// </summary>
        /// <value>
        /// The popout button Y position.
        /// </value>
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

        /// <summary>
        /// Gets or sets the popout button label image.
        /// </summary>
        /// <value>
        /// The popout button label image.
        /// </value>
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

        /// <summary>
        /// Gets or sets the popout button label Y position.
        /// A negative number -i indicates that the image should appear (i-1)pixel apart from the very bottom.
        /// </summary>
        /// <value>
        /// The popout button label Y position.
        /// </value>
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

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
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

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EntryPhotoArea"/> is expanded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if expanded; otherwise, <c>false</c>.
        /// </value>
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

        /// <summary>
        /// Gets a value indicating whether the mouse is over the entire area.
        /// </summary>
        /// <value>
        ///   <c>true</c> if hover; otherwise, <c>false</c>.
        /// </value>
        public bool Hover
        {
            get
            {
                return this.hover;
            }

            private set
            {
                if (this.hover != value)
                {
                    this.hover = value;
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the mouse is over the image area.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [image hover]; otherwise, <c>false</c>.
        /// </value>
        public bool ImageHover
        {
            get
            {
                return this.imageHover;
            }

            private set
            {
                if (this.imageHover != value)
                {
                    this.imageHover = value;
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the mouse is over the back button.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [back button hover]; otherwise, <c>false</c>.
        /// </value>
        public bool BackButtonHover
        {
            get
            {
                return this.backButtonHover;
            }

            private set
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

        /// <summary>
        /// Gets a value indicating whether the mouse is over the popout button.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [popout button hover]; otherwise, <c>false</c>.
        /// </value>
        public bool PopoutButtonHover
        {
            get
            {
                return this.popoutButtonHover;
            }

            private set
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

        /// <summary>
        /// Gets or sets the destination image bounds.
        /// </summary>
        /// <value>
        /// The destination image bounds.
        /// </value>
        private Rectangle DestImageBounds { get; set; }

        /// <summary>
        /// Gets or sets the back button bounds.
        /// </summary>
        /// <value>
        /// The back button bounds.
        /// </value>
        private Rectangle BackButtonBounds { get; set; }

        /// <summary>
        /// Gets or sets the back button label bounds.
        /// </summary>
        /// <value>
        /// The back button label bounds.
        /// </value>
        private Rectangle BackButtonLabelBounds { get; set; }

        /// <summary>
        /// Gets or sets the popout button bounds.
        /// </summary>
        /// <value>
        /// The popout button bounds.
        /// </value>
        private Rectangle PopoutButtonBounds { get; set; }

        /// <summary>
        /// Gets or sets the popout button label bounds.
        /// </summary>
        /// <value>
        /// The popout button label bounds.
        /// </value>
        private Rectangle PopoutButtonLabelBounds { get; set; }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// Also recalculates the image bounds.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            this.RecalculateDestImageBounds();
            this.RecalculateButtonBounds();

            base.OnResize(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// Changes cursor to Hand Cursor.
        /// Also determines the hover states.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.Hover = true;
            this.ImageHover = this.DestImageBounds.Contains(e.Location);
            this.BackButtonHover = this.BackButtonBounds.Contains(e.Location);
            this.PopoutButtonHover = this.PopoutButtonBounds.Contains(e.Location);

            // Sets Hand Cursor only when EntryPhotoArea is not expanded.
            if (!expanded)
            {
                Cursor.Current = Cursors.Hand;
            }
           

            base.OnMouseMove(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// Resets cursor to Default Cursor.
        /// Removes all hover states.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            this.Hover = false;
            this.ImageHover = false;
            this.BackButtonHover = false;
            this.PopoutButtonHover = false;
            this.Cursor = Cursors.Default;

            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// Raises custom click events here.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.Expanded && this.BackButtonHover)
            {
                // Raise the BackButtonClick event.
                if (this.BackButtonClick != null)
                {
                    this.BackButtonClick(this, EventArgs.Empty);
                }
            }
            else if (this.Expanded && this.PopoutButtonHover)
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

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// Draws the image / hover mask / back button / popout button.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
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

        /// <summary>
        /// Recalculates the destination image bounds.
        /// </summary>
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

        /// <summary>
        /// Recalculates all the button related bounds.
        /// </summary>
        private void RecalculateButtonBounds()
        {
            this.RecalculateBackButtonBounds();
            this.RecalculateBackButtonLabelBounds();
            this.RecalculatePopoutButtonBounds();
            this.RecalculatePopoutButtonLabelBounds();
        }

        /// <summary>
        /// Recalculates the back button bounds.
        /// </summary>
        private void RecalculateBackButtonBounds()
        {
            this.BackButtonBounds = this.RecalculateBoundsHelper(this.BackButtonNormalImage, this.BackButtonYPos);
        }

        /// <summary>
        /// Recalculates the back button label bounds.
        /// </summary>
        private void RecalculateBackButtonLabelBounds()
        {
            this.BackButtonLabelBounds = this.RecalculateBoundsHelper(this.BackButtonLabelImage, this.BackButtonLabelYPos);
        }

        /// <summary>
        /// Recalculates the popout button bounds.
        /// </summary>
        private void RecalculatePopoutButtonBounds()
        {
            this.PopoutButtonBounds = this.RecalculateBoundsHelper(this.PopoutButtonNormalImage, this.PopoutButtonYPos);
        }

        /// <summary>
        /// Recalculates the popout button label bounds.
        /// </summary>
        private void RecalculatePopoutButtonLabelBounds()
        {
            this.PopoutButtonLabelBounds = this.RecalculateBoundsHelper(this.PopoutButtonLabelImage, this.PopoutButtonLabelYPos);
        }

        /// <summary>
        /// Recalculates the bounds helper.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="ypos">The y position value.</param>
        /// <returns>the calculated bounds</returns>
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

        /// <summary>
        /// Gets the actual Y position.
        /// </summary>
        /// <param name="ypos">The y position value.</param>
        /// <param name="imageHeight">Height of the image.</param>
        /// <returns>the calculated y position</returns>
        private int GetActualYPos(int ypos, int imageHeight)
        {
            return ypos >= 0 ? ypos : this.Height + ypos - imageHeight + 1;
        }
    }
}
