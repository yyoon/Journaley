namespace Journaley.Forms
{
    using System.Windows.Forms;
    using Journaley.Core.Models;

    /// <summary>
    /// The password input form shown when the user returns from other applications.
    /// </summary>
    public partial class PasswordInputForm : BaseJournaleyForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordInputForm"/> class.
        /// </summary>
        /// <param name="passwordVerifier">The password verifier.</param>
        public PasswordInputForm(IPasswordVerifier passwordVerifier)
        {
            this.InitializeComponent();

            this.Icon = Properties.Resources.JournaleyIcon;
            this.PasswordVerifier = passwordVerifier;
        }

        /// <summary>
        /// Gets or sets the password verifier.
        /// </summary>
        /// <value>
        /// The password verifier.
        /// </value>
        private IPasswordVerifier PasswordVerifier { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [wrong password].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [wrong password]; otherwise, <c>false</c>.
        /// </value>
        private bool WrongPassword { get; set; }

        /// <summary>
        /// Handles the KeyDown event of the textBoxPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        if (this.PasswordVerifier.VerifyPassword(this.textBoxPassword.Text))
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            this.pictureBoxPressEnter.BackgroundImage =
                                Properties.Resources.password_ui_wrong_password;
                            this.WrongPassword = true;

                            this.textBoxPassword.Text = string.Empty;
                            this.textBoxPassword.Focus();
                        }

                        e.Handled = true;
                        break;
                    }

                case Keys.Escape:
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.Close();

                        e.Handled = true;
                        break;
                    }

                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the KeyPress event of the textBoxPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void TextBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                case (char)Keys.Escape:
                    e.Handled = true;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the textBoxPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TextBoxPassword_TextChanged(object sender, System.EventArgs e)
        {
            this.pictureBoxPressEnter.Visible = this.WrongPassword ||
                !string.IsNullOrEmpty(this.textBoxPassword.Text);
        }
    }
}
