namespace Journaley.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// A custom button control which changes the background color depending on its state.
    /// </summary>
    public class ColorButton : Control, ISelectable, IButtonControl, INotifyPropertyChanged
    {
        /// <summary>
        /// WM_KEYDOWN code
        /// </summary>
        private const int WMKeyDown = 0x0100;

        /// <summary>
        /// WM_KEYUP code
        /// </summary>
        private const int WMKeyUp = 0x0101;

        /// <summary>
        /// Indicates whether this button is the default button or not.
        /// </summary>
        private bool isDefault = false;

        /// <summary>
        /// Indicates whether the mouse is currently over this button.
        /// </summary>
        private bool hover = false;

        /// <summary>
        /// Indicates whether this button is currently down.
        /// </summary>
        private bool down = false;

        /// <summary>
        /// Indicates whether this button is currently selected.
        /// </summary>
        private bool selected = false;

        /// <summary>
        /// Indicates whether the space bar is held by the user.
        /// </summary>
        private bool holdingSpace = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorButton"/> class.
        /// Sets up some default values.
        /// </summary>
        public ColorButton()
        {
            this.SetStyle(ControlStyles.Selectable, true);

            // Set the default values.
            this.NormalColor = Color.FromArgb(195, 196, 211);
            this.BackColor = this.NormalColor;
            this.HoverColor = Color.FromArgb(218, 219, 228);
            this.DownColor = Color.FromArgb(0, 147, 255);

            this.BorderColor = Color.Black;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets a value indicating whether the mouse is currently over this button.
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
                bool prev = this.hover;
                this.hover = value;

                if (prev != value && this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Hover"));
                }
            }
        }

        /// <summary>
        /// Gets or sets the hover color.
        /// </summary>
        /// <value>
        /// The hover color.
        /// </value>
        [Category("Appearance")]
        [Description("Background color to show when the button is hovered over.")]
        public Color HoverColor { get; set; }

        /// <summary>
        /// Gets or sets the selected hover color.
        /// </summary>
        /// <value>
        /// The selected hover color.
        /// </value>
        [Category("Appearance")]
        [Description("Background color to show when the button is hovered over.")]
        public Color SelectedHoverColor { get; set; }

        /// <summary>
        /// Gets or sets the down color.
        /// </summary>
        /// <value>
        /// The down color.
        /// </value>
        [Category("Appearance")]
        [Description("Background color to show when the button is hovered over.")]
        public Color DownColor { get; set; }

        /// <summary>
        /// Gets or sets the selected down color.
        /// </summary>
        /// <value>
        /// The selected down color.
        /// </value>
        [Category("Appearance")]
        [Description("Background color to show when the button is hovered over.")]
        public Color SelectedDownColor { get; set; }

        /// <summary>
        /// Gets or sets the normal color.
        /// </summary>
        /// <value>
        /// The normal color.
        /// </value>
        [Category("Appearance")]
        [Description("Background color to show when the button is not in any other state.")]
        public Color NormalColor { get; set; }

        /// <summary>
        /// Gets or sets the selected color.
        /// </summary>
        /// <value>
        /// The selected color.
        /// </value>
        [Category("Appearance")]
        [Description("Background color to show when the button is currently selected.")]
        public Color SelectedColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [selected].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [selected]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [Description("Indicate whether this button is currently selected and should be displaying the SelectedImage.")]
        public bool Selected
        {
            get
            {
                return this.selected;
            }

            set
            {
                this.selected = value;

                if (this.down)
                {
                    this.BackColor = this.DownColorToDisplay;
                }
                else if (this.Hover)
                {
                    this.BackColor = this.HoverColorToDisplay;
                }
                else
                {
                    this.BackColor = value ? this.SelectedColor : this.NormalColor;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>
        /// The color of the border.
        /// </value>
        [Category("Appearance")]
        [Description("Border color")]
        public Color BorderColor { get; set; }

        /// <summary>
        /// Gets or sets the value returned to the parent form when the button is clicked.
        /// </summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
        public DialogResult DialogResult { get; set; }

        /// <summary>
        /// Gets the hover color to display.
        /// </summary>
        /// <value>
        /// The hover color to display.
        /// </value>
        private Color HoverColorToDisplay
        {
            get
            {
                return this.Selected ? this.SelectedHoverColor : this.HoverColor;
            }
        }

        /// <summary>
        /// Gets down color to display.
        /// </summary>
        /// <value>
        /// The down color to display.
        /// </value>
        private Color DownColorToDisplay
        {
            get
            {
                return this.Selected ? this.SelectedDownColor : this.DownColor;
            }
        }

        /// <summary>
        /// Notifies a control that it is the default button so that its appearance and behavior is adjusted accordingly.
        /// </summary>
        /// <param name="value">true if the control should behave as a default button; otherwise false.</param>
        public void NotifyDefault(bool value)
        {
            this.isDefault = value;
        }

        /// <summary>
        /// Generates a <see cref="E:System.Windows.Forms.Control.Click" /> event for the control.
        /// </summary>
        public void PerformClick()
        {
            if (this.CanSelect)
            {
                this.OnClick(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Preprocesses keyboard or input messages within the message loop before they are dispatched.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the message to process.
        /// The possible values are WM_KEYDOWN, WM_SYSKEYDOWN, WM_CHAR, and WM_SYSCHAR.</param>
        /// <returns>
        /// true if the message was processed by the control; otherwise, false.
        /// </returns>
        public override bool PreProcessMessage(ref Message msg)
        {
            if (msg.Msg == WMKeyUp)
            {
                if (this.holdingSpace)
                {
                    if ((int)msg.WParam == (int)Keys.Space)
                    {
                        this.OnMouseUp(null);
                        this.PerformClick();
                    }
                    else if ((int)msg.WParam == (int)Keys.Escape || (int)msg.WParam == (int)Keys.Tab)
                    {
                        this.holdingSpace = false;
                        this.OnMouseUp(null);
                    }
                }

                return true;
            }
            else if (msg.Msg == WMKeyDown)
            {
                if ((int)msg.WParam == (int)Keys.Space)
                {
                    this.holdingSpace = true;
                    this.OnMouseDown(null);
                }
                else if ((int)msg.WParam == (int)Keys.Enter)
                {
                    this.PerformClick();
                }

                return true;
            }
            else
            {
                return base.PreProcessMessage(ref msg);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// For the purpose of ImageButton, this method handles the hover event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.Hover = true;
            this.BackColor = this.down ? this.DownColorToDisplay : this.HoverColorToDisplay;

            base.OnMouseMove(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            this.holdingSpace = false;
            this.OnMouseUp(null);

            base.OnLostFocus(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            this.Hover = false;
            this.BackColor = this.Selected ? this.SelectedColor : this.NormalColor;

            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            this.down = true;

            this.BackColor = this.DownColorToDisplay;

            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.down = false;
            if (this.Hover)
            {
                this.BackColor = this.HoverColorToDisplay;
            }
            else
            {
                this.BackColor = this.Selected ? this.SelectedColor : this.NormalColor;
            }

            base.OnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            Form form = this.FindForm();
            if (form != null)
            {
                form.DialogResult = this.DialogResult;  
            }

            base.OnClick(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the border
            Rectangle rect = this.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            e.Graphics.DrawRectangle(new Pen(this.BorderColor), rect);

            // Draw the text
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            base.OnPaint(e);
        }
    }
}
