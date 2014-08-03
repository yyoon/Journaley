namespace Journaley.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Photo Display Form to be displayed when the photo is double-clicked.
    /// </summary>
    public partial class PhotoDisplayForm : BaseJournaleyForm
    {
        /// <summary>
        /// The image
        /// </summary>
        private Image image;

        /// <summary>
        /// The photo state
        /// </summary>
        private PhotoState state;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoDisplayForm"/> class.
        /// </summary>
        public PhotoDisplayForm()
        {
            this.InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Enumeration for indicating whether the photo is resized to fit or not.
        /// </summary>
        private enum PhotoState : int
        {
            /// <summary>
            /// The image fits on the screen without resizing.
            /// </summary>
            Fit = 0,

            /// <summary>
            /// The image is currently shrunk to fit on the screen.
            /// </summary>
            Shrunk = 1,

            /// <summary>
            /// The image is currently expanded.
            /// </summary>
            Expanded = 2,
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
                this.image = value;
                this.pictureBox.Image = value;
            }
        }

        /// <summary>
        /// Gets or sets the real client size, which excludes the 1 pixel border as well.
        /// </summary>
        /// <value>
        /// The size of the real client.
        /// </value>
        public override Size RealClientSize
        {
            get
            {
                Size result = base.RealClientSize;
                result.Width -= 2;
                result.Height -= 2;

                return result;
            }

            set
            {
                value.Width += 2;
                value.Height += 2;

                base.RealClientSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the photo state.
        /// </summary>
        /// <value>
        /// The photo state.
        /// </value>
        private PhotoState State
        {
            get
            {
                return this.state;
            }

            set
            {
                this.state = value;

                switch (value)
                {
                    case PhotoState.Shrunk:
                        this.pictureBox.Dock = DockStyle.Fill;
                        this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;

                    case PhotoState.Expanded:
                        this.pictureBox.Dock = DockStyle.None;
                        this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Initializes the size.
        /// </summary>
        /// <param name="currentScreen">The current screen.</param>
        public void InitializeSize(Screen currentScreen)
        {
            this.RealClientSize = new Size(this.Image.Width, this.Image.Height);

            int screenWidth = currentScreen.Bounds.Width;
            int screenHeight = currentScreen.Bounds.Height;

            double threshold = 0.8;
            int maxWidth = (int)(screenWidth * threshold);
            int maxHeight = (int)(screenHeight * threshold);

            if (this.Width <= maxWidth && this.Height <= maxHeight)
            {
                this.State = PhotoState.Fit;
            }
            else
            {
                if ((double)this.Width / (double)maxWidth >= (double)this.Height / (double)maxHeight)
                {
                    // Wider
                    double ratio = (double)this.Image.Width / (double)(maxWidth - 2);
                    this.RealClientSize = new Size(maxWidth - 2, (int)(this.Image.Height / ratio));
                }
                else
                {
                    // Taller
                    double ratio = (double)this.Image.Height / (double)(maxHeight - this.panelTitlebar.Height - 2);
                    this.RealClientSize = new Size((int)(this.Image.Width / ratio), maxHeight - this.panelTitlebar.Height - 2);
                }

                this.State = PhotoState.Shrunk;
            }

            this.Width = Math.Min(this.Width, maxWidth);
            this.Height = Math.Min(this.Height, maxHeight);
        }
    }
}
