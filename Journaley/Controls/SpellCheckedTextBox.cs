namespace Journaley.Controls
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms.Design;
    using System.Windows.Forms.Integration;

    /// <summary>
    /// Spell-checker enabled TextBox derived from WPF TextBox.
    /// </summary>
    [Designer(typeof(ControlDesigner))]
    internal class SpellCheckedTextBox : ElementHost
    {
        /// <summary>
        /// The WPF TextBox control
        /// </summary>
        private TextBox box;

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
            this.box.FontFamily = new System.Windows.Media.FontFamily(this.Font.FontFamily.Name);
            this.box.FontSize = this.Font.SizeInPoints * 96.0 / 72.0;

            switch (this.Font.Style)
            {
                case System.Drawing.FontStyle.Regular:
                    this.box.FontStyle = FontStyles.Normal;
                    break;

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
