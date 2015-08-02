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
        private const int DefaultCornerSize = 5;

        /// <summary>
        /// The default resizing border width to be used for the title bar area
        /// </summary>
        private const int DefaultResizingBorderWidth = 1;

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
            this.ResizingBorderWidth = DefaultResizingBorderWidth;

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
        /// Gets or sets the width of the resizing border.
        /// </summary>
        /// <value>
        /// The width of the resizing border.
        /// </value>
        [Category("Layout")]
        [Description("Specify the resizing border width to be used for the title bar area.")]
        [DefaultValue(DefaultResizingBorderWidth)]
        public int ResizingBorderWidth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to disable the system menu.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the system menu should be disabled; otherwise, <c>false</c>.
        /// </value>
        [Category("Window Style")]
        [Description("Specify whether to disable the windows system menu")]
        public bool DisableSystemMenu { get; set; }

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
        protected bool DraggingTitleBar
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
        /// Gets or sets the dragging offset.
        /// </summary>
        /// <value>
        /// The dragging offset.
        /// </value>
        protected Point DraggingOffset
        {
            get
            {
                return this.draggingOffset;
            }

            set
            {
                this.draggingOffset = value;
            }
        }

        /// <summary>
        /// Overrides the message loop.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            switch ((PInvoke.WindowsMessages)m.Msg)
            {
                case PInvoke.WindowsMessages.WM_SETCURSOR:
                    PInvoke.HitTestValues val = this.BorderHitTest(this.PointToClient(Cursor.Position));
                    this.SetCursorOnBorder(val);
                    m.Result = (IntPtr)1;
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the Win32 message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// true if the keystroke was processed and consumed by the control; otherwise, false to allow further processing.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.Space))
            {
                this.PopupSystemMenu(this.PointToScreen(new Point(0, 20)));
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
        /// Updates the maximize/restore button image.
        /// </summary>
        protected void UpdateMaximizeRestoreButtonImage()
        {
            this.imageButtonFormMaximize.Selected = this.WindowState == FormWindowState.Maximized;
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

            this.UpdateMaximizeRestoreButtonImage();
        }

        /// <summary>
        /// Hit test against the border (padding) area.
        /// </summary>
        /// <param name="p">The position of the mouse cursor relative to the form.</param>
        /// <returns>
        /// The border position value in the HitTestValues enumeration. HTNOWHERE if not in any of the border area.
        /// </returns>
        private PInvoke.HitTestValues BorderHitTest(Point p)
        {
            PInvoke.HitTestValues val = PInvoke.HitTestValues.HTNOWHERE;

            Padding pad = this.panelContent.Padding;
            Size size = this.ClientSize;

            // Outside the form.
            if (p.X < 0 || p.X >= size.Width || p.Y < 0 || p.Y >= size.Height)
            {
                return val;
            }

            // Within the titlebar area
            if (0 <= p.Y && p.Y < this.panelTitlebar.Height)
            {
                if (pad.Left <= p.X && p.X < (size.Width - this.ResizingBorderWidth) && this.ResizingBorderWidth <= p.Y)
                {
                    return val;
                }

                pad.Top = Math.Max(this.ResizingBorderWidth, this.CornerSize);
                pad.Right = Math.Max(this.ResizingBorderWidth, this.CornerSize);
                pad.Bottom = Math.Max(pad.Bottom, this.CornerSize);
                pad.Left = Math.Max(pad.Left, this.CornerSize);
            }
            else
            {
                if (pad.Left <= p.X && p.X < (size.Width - pad.Right) && p.Y < (size.Height - pad.Bottom))
                {
                    return val;
                }

                pad.Top = Math.Max(this.ResizingBorderWidth, this.CornerSize);
                pad.Right = Math.Max(pad.Right, this.CornerSize);
                pad.Bottom = Math.Max(pad.Bottom, this.CornerSize);
                pad.Left = Math.Max(pad.Left, this.CornerSize);
            }

            bool top = 0 <= p.Y && p.Y < pad.Top;
            bool right = (size.Width - pad.Right) <= p.X && p.X < size.Width;
            bool bottom = (size.Height - pad.Bottom) <= p.Y && p.Y < size.Height;
            bool left = 0 <= p.X && p.X < pad.Left;

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

        /// <summary>
        /// Sets the cursor depending on whether the mouse cursor is on border.
        /// </summary>
        /// <param name="val">The hit test result.</param>
        private void SetCursorOnBorder(PInvoke.HitTestValues val)
        {
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

        /// <summary>
        /// Popups the system menu.
        /// </summary>
        /// <param name="p">The location in screen coordinates.</param>
        private void PopupSystemMenu(Point p)
        {
            this.PopupSystemMenu(p.X, p.Y);
        }

        /// <summary>
        /// Popups the system menu.
        /// </summary>
        /// <param name="screenX">The screen x.</param>
        /// <param name="screenY">The screen y.</param>
        private void PopupSystemMenu(int screenX, int screenY)
        {
            if (this.DisableSystemMenu)
            {
                return;
            }

            IntPtr menu = PInvoke.GetSystemMenu(this.Handle, false);

            // Disable minimize menu if the minimize button is not visible.
            if (!this.imageButtonFormMinimize.Visible)
            {
                PInvoke.EnableMenuItem(
                    menu,
                    PInvoke.SystemCommands.SC_MINIMIZE,
                    PInvoke.MenuFlags.MF_GRAYED);
            }

            // Disable maximize menu if the maximize button is not visible.
            if (!this.imageButtonFormMaximize.Visible)
            {
                PInvoke.EnableMenuItem(
                    menu,
                    PInvoke.SystemCommands.SC_MAXIMIZE,
                    PInvoke.MenuFlags.MF_GRAYED);
            }

            int command = PInvoke.TrackPopupMenuEx(
                menu,
                PInvoke.TrackPopupMenuFlags.TPM_RETURNCMD,
                screenX,
                screenY,
                this.Handle,
                IntPtr.Zero);

            if (command == 0)
            {
                return;
            }

            PInvoke.PostMessage(
                this.Handle,
                PInvoke.WindowsMessages.WM_SYSCOMMAND,
                new IntPtr(command),
                IntPtr.Zero);
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
        /// Handles the MouseDown event of the control buttons on the right hand side of the title bar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void ControlButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && this.Resizable && this.WindowState != FormWindowState.Maximized)
            {
                // Determine if the border is clicked.
                Point p = this.PointToClient(((Control)sender).PointToScreen(e.Location));
                PInvoke.HitTestValues val = this.BorderHitTest(p);

                if (val != PInvoke.HitTestValues.HTNOWHERE)
                {
                    PInvoke.ReleaseCapture();
                    PInvoke.SendMessage(this.Handle, (int)PInvoke.WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)val, IntPtr.Zero);
                }
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the control buttons on the right hand side of the title bar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void ControlButton_MouseMove(object sender, MouseEventArgs e)
        {
            // If the resizing is disabled, don't bother to check.
            if (this.Resizable && this.WindowState != FormWindowState.Maximized && !this.DraggingTitleBar)
            {
                Point p = this.PointToClient(((Control)sender).PointToScreen(e.Location));
                PInvoke.HitTestValues val = this.BorderHitTest(p);

                this.SetCursorOnBorder(val);
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the panel title bar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PanelTitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Determine if the resizing border is clicked.
                if (this.Resizable && this.WindowState != FormWindowState.Maximized)
                {
                    Point p = this.PointToClient(this.panelTitlebar.PointToScreen(e.Location));
                    PInvoke.HitTestValues val = this.BorderHitTest(p);

                    if (val != PInvoke.HitTestValues.HTNOWHERE)
                    {
                        PInvoke.ReleaseCapture();
                        PInvoke.SendMessage(this.Handle, (int)PInvoke.WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)val, IntPtr.Zero);
                        return;
                    }
                }

                this.DraggingTitleBar = true;

                if (this.WindowState == FormWindowState.Maximized)
                {
                    Point offset = new Point();
                    if (this.RestoreBounds.Width >= this.Width || e.X < this.RestoreBounds.Width / 2)
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
            else if (e.Button == MouseButtons.Right)
            {
                this.PopupSystemMenu(this.panelTitlebar.PointToScreen(e.Location));
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
            // If the resizing is disabled, don't bother to check.
            if (this.Resizable && this.WindowState != FormWindowState.Maximized && !this.DraggingTitleBar)
            {
                Point p = this.PointToClient(this.panelTitlebar.PointToScreen(e.Location));
                PInvoke.HitTestValues val = this.BorderHitTest(p);

                this.SetCursorOnBorder(val);
            }

            // Title Bar Dragging.
            if (this.DraggingTitleBar)
            {
                // Make it normal state before moving.
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.ToggleMaximize();
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
                this.ToggleMaximize();
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
            this.DialogResult = DialogResult.Cancel;
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

            // Disable when maximized
            if (this.WindowState == FormWindowState.Maximized)
            {
                return;
            }

            // Determine if the border is clicked.
            Point p = this.PointToClient(this.panelContent.PointToScreen(e.Location));
            PInvoke.HitTestValues val = this.BorderHitTest(p);

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
            if (this.Resizable && this.WindowState != FormWindowState.Maximized && !this.DraggingTitleBar)
            {
                Point p = this.PointToClient(this.panelContent.PointToScreen(e.Location));
                PInvoke.HitTestValues val = this.BorderHitTest(p);

                this.SetCursorOnBorder(val);
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the pictureBoxFormIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PictureBoxFormIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.PopupSystemMenu(this.PointToScreen(new Point(0, 20)));
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.PopupSystemMenu(this.pictureBoxFormIcon.PointToScreen(e.Location));
            }
        }

        #endregion
    }
}
