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
    using Journaley.Utilities;

    /// <summary>
    /// The base form class for providing custom title bar dragging capability.
    /// </summary>
    public partial class BaseJournaleyForm : Form
    {
        /// <summary>
        /// The default corner size
        /// </summary>
        private const int DefaultCornerSize = 10;

        /// <summary>
        /// Indicates whether the title bar is being dragged.
        /// </summary>
        private bool draggingTitleBar = false;

        /// <summary>
        /// The dragging offset
        /// </summary>
        private Point draggingOffset;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseJournaleyForm"/> class.
        /// </summary>
        public BaseJournaleyForm()
        {
            int val = 2;
            PInvoke.DwmSetWindowAttribute(this.Handle, 2, ref val, 4);  // Enabling the DWM-based NC painting.

            PInvoke.MARGINS margins = new PInvoke.MARGINS();
            margins.leftWidth = 1;
            margins.topHeight = 1;
            margins.rightWidth = 1;
            margins.bottomHeight = 1;
            PInvoke.DwmExtendFrameIntoClientArea(this.Handle, ref margins);

            this.CornerSize = DefaultCornerSize;

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this form can be resized.
        /// </summary>
        /// <value>
        /// <c>true</c> if this form can be resized; otherwise, <c>false</c>.
        /// </value>
        [Category("Layout")]
        [Description("Specify whether the form can be resized or not.")]
        public bool Resizable { get; set; }

        /// <summary>
        /// Gets or sets the size of the corner.
        /// </summary>
        /// <value>
        /// The size of the corner.
        /// </value>
        [Category("Layout")]
        [Description("Specify the corner size which is used for determining resize direction.")]
        [DefaultValue(DefaultCornerSize)]
        public int CornerSize { get; set; }

        /// <summary>
        /// Gets or sets the real client size, which is the client area size - title bar size.
        /// </summary>
        /// <value>
        /// The size of the real client.
        /// </value>
        public virtual Size RealClientSize
        {
            get
            {
                return this.ClientSizeToRealClientSize(this.ClientSize);
            }

            set
            {
                this.ClientSize = this.RealClientSizeToClientSize(value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [dragging title bar].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [dragging title bar]; otherwise, <c>false</c>.
        /// </value>
        private bool DraggingTitleBar
        {
            get
            {
                return this.draggingTitleBar;
            }

            set
            {
                if (this.draggingTitleBar == true && value == false)
                {
                    if (this.WindowState != FormWindowState.Maximized && this.Location.Y < 0)
                    {
                        this.Location = new Point(this.Location.X, 0);
                    }
                }

                this.draggingTitleBar = value;
            }
        }

        /// <summary>
        /// Converts the real client size (excluding the title bar and the borders) to the client size.
        /// </summary>
        /// <param name="realClientSize">Size of the real client.</param>
        /// <returns>Size of the client area, including the title bar and the borders.</returns>
        protected virtual Size RealClientSizeToClientSize(Size realClientSize)
        {
            realClientSize.Height += this.panelTitlebar.Height + this.panelContent.Padding.Vertical;
            realClientSize.Width += this.panelContent.Padding.Horizontal;
            return realClientSize;
        }

        /// <summary>
        /// Converts the client size to the real client size (excluding the title bar and the borders).
        /// </summary>
        /// <param name="clientSize">Size of the client area, including the title bar and the borders.</param>
        /// <returns>Size of the real client.</returns>
        protected virtual Size ClientSizeToRealClientSize(Size clientSize)
        {
            clientSize.Height -= this.panelTitlebar.Height + this.panelContent.Padding.Vertical;
            clientSize.Width -= this.panelContent.Padding.Horizontal;
            return clientSize;
        }

        /// <summary>
        /// Toggles the maximize state.
        /// </summary>
        private void ToggleMaximize()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// Hit test against the border (padding) area.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        /// <param name="pad">The pad.</param>
        /// <param name="panelSize">Size of the panel.</param>
        /// <returns>The border position value in the HitTestValues enumeration. HTNOWHERE if not in any of the border area.</returns>
        private PInvoke.HitTestValues BorderHitTest(MouseEventArgs e, Padding pad, Size panelSize)
        {
            PInvoke.HitTestValues val = PInvoke.HitTestValues.HTNOWHERE;

            pad.Top = Math.Max(pad.Top, this.CornerSize);
            pad.Right = Math.Max(pad.Right, this.CornerSize);
            pad.Bottom = Math.Max(pad.Bottom, this.CornerSize);
            pad.Left = Math.Max(pad.Left, this.CornerSize);

            bool top = 0 <= e.Y && e.Y < pad.Top;
            bool right = (panelSize.Width - pad.Right) <= e.X && e.X < panelSize.Width;
            bool bottom = (panelSize.Height - pad.Bottom) <= e.Y && e.Y < panelSize.Height;
            bool left = 0 <= e.X && e.X < pad.Left;

            if (top)
            {
                if (left)
                {
                    val = PInvoke.HitTestValues.HTTOPLEFT;
                }
                else if (right)
                {
                    val = PInvoke.HitTestValues.HTTOPRIGHT;
                }
                else
                {
                    val = PInvoke.HitTestValues.HTTOP;
                }
            }
            else if (bottom)
            {
                if (left)
                {
                    val = PInvoke.HitTestValues.HTBOTTOMLEFT;
                }
                else if (right)
                {
                    val = PInvoke.HitTestValues.HTBOTTOMRIGHT;
                }
                else
                {
                    val = PInvoke.HitTestValues.HTBOTTOM;
                }
            }
            else
            {
                if (left)
                {
                    val = PInvoke.HitTestValues.HTLEFT;
                }
                else if (right)
                {
                    val = PInvoke.HitTestValues.HTRIGHT;
                }
            }

            return val;
        }

        #region Event Handlers

        /// <summary>
        /// Handles the Deactivate event of the BaseJournaleyForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BaseJournaleyForm_Deactivate(object sender, EventArgs e)
        {
            this.DraggingTitleBar = false;
        }

        /// <summary>
        /// Handles the MouseDown event of the panel title bar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PanelTitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.DraggingTitleBar = true;

                if (this.WindowState == FormWindowState.Maximized)
                {
                    Point offset = new Point();
                    if (this.RestoreBounds.Width >= this.Width)
                    {
                        offset = e.Location;
                    }
                    else if (e.X < this.RestoreBounds.Width / 2)
                    {
                        offset = e.Location;
                    }
                    else if (e.X >= this.Width - (this.RestoreBounds.Width / 2))
                    {
                        offset = new Point(e.Location.X - (this.Width - this.RestoreBounds.Width), e.Location.Y);
                    }
                    else
                    {
                        offset = new Point(this.RestoreBounds.Width / 2, e.Location.Y);
                    }

                    this.draggingOffset = offset;
                }
                else
                {
                    this.draggingOffset = e.Location;
                }
            }
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the panel title bar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PanelTitlebar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ToggleMaximize();
        }

        /// <summary>
        /// Handles the MouseMove event of the panel title bar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PanelTitlebar_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.DraggingTitleBar)
            {
                // Make it normal state before moving.
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }

                Point curScreenPos = this.PointToScreen(e.Location);
                this.Location = new Point(curScreenPos.X - this.draggingOffset.X, curScreenPos.Y - this.draggingOffset.Y);
            }
        }

        /// <summary>
        /// Handles the MouseUp event of the panel title bar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PanelTitlebar_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.imageButtonFormMaximize.Visible && this.PointToScreen(e.Location).Y == 0 && this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            this.DraggingTitleBar = false;
        }

        /// <summary>
        /// Handles the Click event of the imageButtonFormMinimize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ImageButtonFormMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Handles the Click event of the imageButtonFormMaximize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ImageButtonFormMaximize_Click(object sender, EventArgs e)
        {
            this.ToggleMaximize();
        }

        /// <summary>
        /// Handles the Click event of the imageButtonFormClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ImageButtonFormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the MouseDown event of the PanelContent control.
        /// Specifically, this handles the resizing of the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PanelContent_MouseDown(object sender, MouseEventArgs e)
        {
            // If the resizing is disabled, don't bother to check.
            if (!this.Resizable)
            {
                return;
            }

            // Only handle left button click.
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            // Determine if the border is clicked.
            Padding pad = this.panelContent.Padding;
            Size panelSize = this.panelContent.Size;
            if (pad.Left <= e.X && e.X < (panelSize.Width - pad.Right) &&
                pad.Top <= e.Y && e.Y < (panelSize.Height - pad.Bottom))
            {
                return;
            }

            PInvoke.HitTestValues val = this.BorderHitTest(e, pad, panelSize);

            if (val != PInvoke.HitTestValues.HTNOWHERE)
            {
                PInvoke.ReleaseCapture();
                PInvoke.SendMessage(this.Handle, (int)PInvoke.WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)val, IntPtr.Zero);
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the PanelContent control.
        /// Used for changing the cursor dynamically.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PanelContent_MouseMove(object sender, MouseEventArgs e)
        {
            // If the resizing is disabled, don't bother to check.
            if (!this.Resizable)
            {
                return;
            }

            PInvoke.HitTestValues val = this.BorderHitTest(e, this.panelContent.Padding, this.panelContent.Size);

            switch (val)
            {
                case PInvoke.HitTestValues.HTTOP:
                case PInvoke.HitTestValues.HTBOTTOM:
                    Cursor.Current = Cursors.SizeNS;
                    break;

                case PInvoke.HitTestValues.HTTOPRIGHT:
                case PInvoke.HitTestValues.HTBOTTOMLEFT:
                    Cursor.Current = Cursors.SizeNESW;
                    break;

                case PInvoke.HitTestValues.HTLEFT:
                case PInvoke.HitTestValues.HTRIGHT:
                    Cursor.Current = Cursors.SizeWE;
                    break;

                case PInvoke.HitTestValues.HTBOTTOMRIGHT:
                case PInvoke.HitTestValues.HTTOPLEFT:
                    Cursor.Current = Cursors.SizeNWSE;
                    break;

                default:
                    Cursor.Current = this.Cursor;
                    break;
            }
        }

        #endregion
    }
}
