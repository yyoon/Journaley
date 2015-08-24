namespace Journaley.Controls
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms.Design;
    using System.Windows.Forms.Integration;
    using System.Windows.Input;
    using System.Windows.Markup;

    /// <summary>
    /// Spell-checker enabled TextBox derived from WPF TextBox.
    /// </summary>
    [Designer(typeof(ControlDesigner))]
    internal class SpellCheckedTextBox : ElementHost
    {
        /// <summary>
        /// The WPF TextBox control
        /// </summary>
        private readonly TextBox box;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellCheckedTextBox"/> class.
        /// </summary>
        public SpellCheckedTextBox()
        {
            this.box = new TextBox();
            this.box.TextChanged += (s, e) => this.OnTextChanged(EventArgs.Empty);
            this.box.SpellCheck.IsEnabled = true;
            this.box.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            this.box.AcceptsReturn = true;

            this.box.Background = System.Windows.Media.Brushes.Transparent;
            this.box.BorderThickness = new System.Windows.Thickness(0);

            // TODO: Is there a way to make this support multiple languages?
            this.box.Language = System.Windows.Markup.XmlLanguage.GetLanguage("en-us");

            this.box.KeyDown += (s, e) =>
            {
                System.Windows.Input.Key wpfKey = e.Key;
                System.Windows.Forms.Keys formsKey = (System.Windows.Forms.Keys)KeyInterop.VirtualKeyFromKey(wpfKey);

                if ((Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Control) == System.Windows.Input.ModifierKeys.Control)
                {
                    formsKey |= System.Windows.Forms.Keys.Control;
                }

                if ((Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Shift) == System.Windows.Input.ModifierKeys.Shift)
                {
                    formsKey |= System.Windows.Forms.Keys.Shift;
                }

                if ((Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Alt) == System.Windows.Input.ModifierKeys.Alt)
                {
                    formsKey |= System.Windows.Forms.Keys.Alt;
                }

                System.Windows.Forms.KeyEventArgs args = new System.Windows.Forms.KeyEventArgs(formsKey);

                this.OnKeyDown(args);

                if (args.Handled == true)
                {
                    e.Handled = true;
                }
            };

            this.box.PreviewKeyDown += (s, e) =>
            {
                if (e.Key == Key.Insert && e.KeyboardDevice.Modifiers == System.Windows.Input.ModifierKeys.None)
                {
                    e.Handled = true;
                }
            };
        }

        /// <summary>
        /// Occurs when the <see cref="P:System.Windows.Forms.Control.Text" /> property value changes.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new event EventHandler TextChanged
        {
            add
            {
                base.TextChanged += value;
            }

            remove
            {
                base.TextChanged -= value;
            }
        }

        /// <summary>
        /// Occurs when a key is pressed while the control has focus.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new event System.Windows.Forms.KeyEventHandler KeyDown
        {
            add
            {
                base.KeyDown += value;
            }

            remove
            {
                base.KeyDown -= value;
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <returns>The text associated with this control.</returns>
        public override string Text
        {
            get
            {
                return this.box.Text;
            }

            set
            {
                this.box.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SpellCheckedTextBox"/> is multiline.
        /// </summary>
        /// <value>
        ///   <c>true</c> if multiline; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool Multiline
        {
            get
            {
                return this.box.AcceptsReturn;
            }

            set
            {
                this.box.AcceptsReturn = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [read only].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [read only]; otherwise, <c>false</c>.
        /// </value>
        public bool ReadOnly
        {
            get
            {
                return this.box.IsReadOnly;
            }

            set
            {
                this.box.IsReadOnly = value;
            }
        }

        /// <summary>
        /// Sets a value indicating whether the spell checker is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the spell checker is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool SpellCheckEnabled
        {
            set
            {
                this.box.SpellCheck.IsEnabled = value;
            }
        }

        /// <summary>
        /// Sets the spell check language.
        /// </summary>
        /// <value>
        /// The spell check language.
        /// </value>
        public string SpellCheckLanguage
        {
            set
            {
                this.box.Language = XmlLanguage.GetLanguage(value);
            }
        }

        /// <summary>
        /// Sets the font family.
        /// </summary>
        /// <value>
        /// The font family.
        /// </value>
        public System.Windows.Media.FontFamily FontFamily
        {
            set
            {
                this.box.FontFamily = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [word wrap].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [word wrap]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool WordWrap
        {
            get
            {
                return this.box.TextWrapping != TextWrapping.NoWrap;
            }

            set
            {
                this.box.TextWrapping = value ? TextWrapping.Wrap : TextWrapping.NoWrap;
            }
        }

        /// <summary>
        /// Focuses this instance.
        /// </summary>
        public new void Focus()
        {
            base.Focus();

            this.box.Focus();
        }

        /// <summary>
        /// Initializes this instance.
        /// Sets the child object to the TextBox object.
        /// Must be called from the host form.
        /// </summary>
        public void Initialize()
        {
            this.Child = this.box;

            // Setup the Font
            this.box.FontSize = this.Font.SizeInPoints * 96.0 / 72.0;

            switch (this.Font.Style)
            {
                case System.Drawing.FontStyle.Italic:
                    this.box.FontStyle = FontStyles.Italic;
                    break;

                default:
                    this.box.FontStyle = FontStyles.Normal;
                    break;
            }

            // Setup the padding value.
            this.box.Padding = new Thickness(
                this.Padding.Left,
                this.Padding.Top,
                this.Padding.Right,
                this.Padding.Bottom);
        }

        /// <summary>
        /// Wrapper method for TextBox.Select.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="length">The length.</param>
        public void Select(int start, int length)
        {
            this.box.Select(start, length);
        }
    }
}
