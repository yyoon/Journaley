namespace Journaley.Forms
{
    using System.Windows.Forms;
    using Journaley.Models;

    /// <summary>
    /// A form used when the user wants to remove existing password.
    /// </summary>
    public partial class RemovePasswordForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemovePasswordForm"/> class.
        /// </summary>
        /// <param name="passwordVerifier">The password verifier.</param>
        public RemovePasswordForm(IPasswordVerifier passwordVerifier)
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
        /// Gets or sets the password verifier.
        /// </summary>
        /// <value>
        /// The password verifier.
        /// </value>
        private IPasswordVerifier PasswordVerifier { get; set; }

        /// <summary>
        /// Handles the FormClosing event of the RemovePasswordForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void RemovePasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (!this.PasswordVerifier.VerifyPassword(this.CurrentPassword))
                {
                    MessageBox.Show("Current password is wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textCurrentPassword.SelectAll();
                    this.textCurrentPassword.Focus();
                    e.Cancel = true;
                }
            }
        }
    }
}
