namespace Journaley.Forms
{
    using System.Windows.Forms;
    using Journaley.Models;

    /// <summary>
    /// Change Password Form implementation.
    /// </summary>
    public partial class ChangePasswordForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordForm"/> class.
        /// </summary>
        /// <param name="passwordVerifier">The password verifier.</param>
        public ChangePasswordForm(IPasswordVerifier passwordVerifier)
        {
            this.InitializeComponent();

            this.PasswordVerifier = passwordVerifier;
        }

        /// <summary>
        /// Gets the current password from the textbox.
        /// </summary>
        /// <value>
        /// The current password.
        /// </value>
        public string CurrentPassword
        {
            get
            {
                return this.textCurrentPassword.Text;
            }
        }

        /// <summary>
        /// Gets the new password from the textbox.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
        public string NewPassword
        {
            get
            {
                return this.textNewPassword1.Text;
            }
        }

        /// <summary>
        /// Gets or sets the password verifier.
        /// </summary>
        /// <value>
        /// The password verifier.
        /// </value>
        private IPasswordVerifier PasswordVerifier { get; set; }

        /// <summary>
        /// Handles the FormClosing event of the ChangePasswordForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void ChangePasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (!this.PasswordVerifier.VerifyPassword(this.CurrentPassword))
                {
                    MessageBox.Show("Current password is wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textCurrentPassword.SelectAll();
                    this.textCurrentPassword.Focus();
                    e.Cancel = true;
                }
                else if (this.textNewPassword1.Text != this.textNewPassword2.Text)
                {
                    MessageBox.Show("The two passwords are different.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textNewPassword1.SelectAll();
                    this.textNewPassword1.Focus();
                    e.Cancel = true;
                }
                else if (string.IsNullOrEmpty(this.textNewPassword1.Text))
                {
                    MessageBox.Show("Please input a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textNewPassword1.SelectAll();
                    this.textNewPassword1.Focus();
                    e.Cancel = true;
                }
            }
        }
    }
}
