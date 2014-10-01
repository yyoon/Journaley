namespace Journaley.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Journaley.Utilities;

    /// <summary>
    /// Photo Display Form to be displayed when the photo is double-clicked.
    /// </summary>
    public partial class PhotoDisplayForm : BaseJournaleyForm
    {
        /// <summary>
        /// Indicates how much of the screen space should be used for the photo display form
        /// </summary>
        private static readonly double ScreenPortion = 0.8;

        /// <summary>
        /// The zoom in cursor
        /// </summary>
        private static Cursor zoomInCursor;

        /// <summary>
        /// The zoom out cursor
        /// </summary>
        private static Cursor zoomOutCursor;

        /// <summary>
        /// The image
        /// </summary>
        private Image image;

        /// <summary>
        /// The photo state
        /// </summary>
        private PhotoState state;

        /// <summary>
        /// Indicates whether the user is panning the image.
        /// </summary>
        private bool panningImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoDisplayForm"/> class.
        /// </summary>
        public PhotoDisplayForm()
        {
            this.InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resizable = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoDisplayForm"/> class.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="screen">The screen.</param>
        public PhotoDisplayForm(Image image, Screen screen)
        {
            this.InitializeComponent();

            this.AdjustBorderSize();

            this.Image = image;
            this.InitializeSize(screen);

            this.MoveToCenter(screen);

            this.Resizable = true;
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
            /// The image is currently resized to fit in the form.
            /// </summary>
            Resized = 1,

            /// <summary>
            /// The image is currently expanded.
            /// </summary>
            Actual = 2,
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
        /// Gets the zoom in cursor.
        /// </summary>
        /// <value>
        /// The zoom in cursor.
        /// </value>
        private static Cursor ZoomInCursor
        {
            get
            {
                if (zoomInCursor == null)
                {
                    zoomInCursor = CursorReader.LoadCursorFromResource(Properties.Resources.ZoomInCursor);
                }

                return zoomInCursor;
            }
        }

        /// <summary>
        /// Gets the zoom out cursor.
        /// </summary>
        /// <value>
        /// The zoom out cursor.
        /// </value>
        private static Cursor ZoomOutCursor
        {
            get
            {
                if (zoomOutCursor == null)
                {
                    zoomOutCursor = CursorReader.LoadCursorFromResource(Properties.Resources.ZoomOutCursor);
                }

                return zoomOutCursor;
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
                    case PhotoState.Resized:
                        break;

                    case PhotoState.Actual:
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [panning image].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [panning image]; otherwise, <c>false</c>.
        /// </value>
        private bool PanningImage
        {
            get
            {
                return this.panningImage;
            }

            set
            {
                this.panningImage = value;
                this.SetCursorOverPicture();
            }
        }

        /// <summary>
        /// Gets or sets the panning start scroll position.
        /// </summary>
        /// <value>
        /// The panning start scroll position.
        /// </value>
        private Point PanningStartScrollPosition { get; set; }

        /// <summary>
        /// Gets or sets the panning start mouse position.
        /// </summary>
        /// <value>
        /// The panning start mouse position.
        /// </value>
        private Point PanningStartMousePosition { get; set; }

        /// <summary>
        /// Initializes the size.
        /// </summary>
        /// <param name="screen">The screen.</param>
        public void InitializeSize(Screen screen)
        {
            Size estimatedSize = this.RealClientSizeToClientSize(new Size(this.Image.Width, this.Image.Height));
            Size maxSize = this.CalculateMaxSize(screen);

            if (estimatedSize.Width <= maxSize.Width && estimatedSize.Height <= maxSize.Height)
            {
                this.State = PhotoState.Fit;
                this.ClientSize = estimatedSize;
            }
            else
            {
                this.Shrink(screen);
            }

            // Set the minimum window size to the current size.
            this.MinimumSize = this.Size;
        }

        /// <summary>
        /// Calculates the maximum size of this form.
        /// </summary>
        /// <param name="screen">The screen.</param>
        /// <returns>the maximum size</returns>
        private Size CalculateMaxSize(Screen screen)
        {
            int screenWidth = screen.WorkingArea.Width;
            int screenHeight = screen.WorkingArea.Height;

            int maxWidth = (int)(screenWidth * ScreenPortion);
            int maxHeight = (int)(screenHeight * ScreenPortion);

            return new Size(maxWidth, maxHeight);
        }

        /// <summary>
        /// Moves this form to the center of the given screen.
        /// </summary>
        /// <param name="screen">The screen.</param>
        private void MoveToCenter(Screen screen)
        {
            this.Location = new Point(
                screen.WorkingArea.Left + ((screen.WorkingArea.Width - this.Width) / 2),
                screen.WorkingArea.Top + ((screen.WorkingArea.Height - this.Height) / 2));
        }

        /// <summary>
        /// Moves to center if this form is not fully enclosed in the working area.
        /// </summary>
        /// <param name="screen">The screen.</param>
        private void MoveToCenterIfNotFullyEnclosed(Screen screen)
        {
            if (!screen.WorkingArea.Contains(this.Bounds))
            {
                this.MoveToCenter(screen);
            }
        }

        /// <summary>
        /// Shrinks the photo.
        /// </summary>
        /// <param name="screen">The screen.</param>
        private void Shrink(Screen screen)
        {
            this.pictureBox.Dock = DockStyle.Fill;
            this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // TODO This makes the window flicker a bit.
            // Find a better way to do this when the window is maximized.
            FormWindowState prevWindowState = this.WindowState;
            this.WindowState = FormWindowState.Normal;

            Size prevSize = this.Size;

            this.ClientSize = this.GetShrunkClientSize(screen);

            // Try to center the resulting dialog w.r.t. the previous expanded dialog.
            this.Location = new Point(
                this.Location.X + ((prevSize.Width - this.Width) / 2),
                this.Location.Y + ((prevSize.Height - this.Height) / 2));

            // If it's out of screen, center w.r.t. the screen working space.
            this.MoveToCenterIfNotFullyEnclosed(screen);

            this.WindowState = prevWindowState;

            this.State = PhotoState.Resized;
        }

        /// <summary>
        /// Gets the size of the shrunk client.
        /// </summary>
        /// <param name="screen">The screen.</param>
        /// <returns>The resulting client size of the shrunk mode.</returns>
        private Size GetShrunkClientSize(Screen screen)
        {
            Size estimatedSize = this.RealClientSizeToClientSize(new Size(this.Image.Width, this.Image.Height));
            Size maxSize = this.CalculateMaxSize(screen);

            if ((double)estimatedSize.Width / (double)maxSize.Width >= (double)estimatedSize.Height / (double)maxSize.Height)
            {
                // Wider
                double ratio = (double)this.Image.Width / (double)(maxSize.Width - 2);
                return this.RealClientSizeToClientSize(new Size(maxSize.Width - 2, (int)(this.Image.Height / ratio)));
            }
            else
            {
                // Taller
                double ratio = (double)this.Image.Height / (double)(maxSize.Height - this.panelTitlebar.Height - 2);
                return this.RealClientSizeToClientSize(new Size((int)(this.Image.Width / ratio), maxSize.Height - this.panelTitlebar.Height - 2));
            }
        }

        /// <summary>
        /// Expands the photo.
        /// </summary>
        /// <param name="screen">The screen.</param>
        private void Expand(Screen screen)
        {
            this.pictureBox.Dock = DockStyle.None;
            this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            // TODO This makes the window flicker a bit.
            // Find a better way to do this when the window is maximized.
            FormWindowState prevWindowState = this.WindowState;
            this.WindowState = FormWindowState.Normal;

            Size estimatedSize = this.RealClientSizeToClientSize(new Size(this.Image.Width, this.Image.Height));
            Size maxSize = this.CalculateMaxSize(screen);

            this.Width = Math.Min(estimatedSize.Width, maxSize.Width);
            this.Height = Math.Min(estimatedSize.Height, maxSize.Height);

            this.MoveToCenterIfNotFullyEnclosed(screen);

            this.WindowState = prevWindowState;

            this.State = PhotoState.Actual;
        }

        /// <summary>
        /// Adjust the border size depending on the windows version.
        /// On Windows 8+, use the border size of 2 pixels.
        /// Otherwise, use 1 pixel.
        /// </summary>
        private void AdjustBorderSize()
        {
            if (Environment.OSVersion.Version >= new Version(6, 2))
            {
                this.panelContent.Padding = new Padding(2, 0, 2, 2);
            }
            else
            {
                this.panelContent.Padding = new Padding(1, 0, 1, 1);
            }
        }

        /// <summary>
        /// Determines whether if the currently displayed image is smaller than its actual size.
        /// </summary>
        /// <returns>true if the currently displayed image is smaller than its actual size. false otherwise.</returns>
        private bool IsCurrentImageSmallerThanActual()
        {
            return this.pictureBox.Width < this.Image.Width || this.pictureBox.Height < this.Image.Height;
        }

        /// <summary>
        /// Sets an appropriate mouse cursor when the mouse is over picture.
        /// </summary>
        private void SetCursorOverPicture()
        {
            if (this.PanningImage)
            {
                this.pictureBox.Cursor = Cursors.SizeAll;
            }
            else
            {
                if (this.State == PhotoState.Resized)
                {
                    this.pictureBox.Cursor = this.IsCurrentImageSmallerThanActual() ? ZoomInCursor : this.Cursor;
                }
                else if (this.State == PhotoState.Actual)
                {
                    this.pictureBox.Cursor = ZoomOutCursor;
                }
            }

            Cursor.Current = this.pictureBox.Cursor;
        }

        /// <summary>
        /// Handles the Deactivate event of the PhotoDisplayForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PhotoDisplayForm_Deactivate(object sender, EventArgs e)
        {
            this.PanningImage = false;
        }

        /// <summary>
        /// Handles the MouseClick event of the pictureBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                switch (this.State)
                {
                    case PhotoState.Resized:
                        // This is only possible when either dimension of the current image is smaller than the actual size.
                        if (this.IsCurrentImageSmallerThanActual())
                        {
                            this.Expand(Screen.FromControl(this));
                        }

                        break;

                    case PhotoState.Actual:
                        // This is always possible.
                        this.Shrink(Screen.FromControl(this));
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the pictureBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle && this.State == PhotoState.Actual)
            {
                this.PanningImage = true;
                this.PanningStartMousePosition = this.pictureBox.PointToScreen(e.Location);
                this.PanningStartScrollPosition = new Point(
                    -this.panelPhoto.AutoScrollPosition.X,
                    -this.panelPhoto.AutoScrollPosition.Y);
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the pictureBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // Only give focus to the photo panel when the photo panel is active.
            if (Form.ActiveForm == this)
            {
                this.panelPhoto.Focus();
            }

            // Change the cursor.
            this.SetCursorOverPicture();

            // Panning
            if (this.PanningImage)
            {
                Point screen = this.pictureBox.PointToScreen(e.Location);

                Point newScrollPosition = new Point(
                    this.PanningStartScrollPosition.X + this.PanningStartMousePosition.X - screen.X,
                    this.PanningStartScrollPosition.Y + this.PanningStartMousePosition.Y - screen.Y);

                if (newScrollPosition.X < 0)
                {
                    newScrollPosition.X = 0;
                }

                if (newScrollPosition.Y < 0)
                {
                    newScrollPosition.Y = 0;
                }

                if (this.panelPhoto.AutoScrollPosition != newScrollPosition)
                {
                    this.panelPhoto.AutoScrollPosition = newScrollPosition;
                }
            }
        }

        /// <summary>
        /// Handles the MouseUp event of the pictureBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            this.PanningImage = false;
        }

        /// <summary>
        /// Handles the MouseMove event of the panel title bar control.
        /// Sets the cursor back to default, in case it displays a wrong cursor (e.g., zoom cursor)
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void PanelTitlebar_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = this.Cursor;
        }

        /// <summary>
        /// Handles the Activated event of the PhotoDisplayForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PhotoDisplayForm_Activated(object sender, EventArgs e)
        {
            // Give focus to the photo panel to enable scrolling.
            this.panelPhoto.Focus();
        }
    }
}
