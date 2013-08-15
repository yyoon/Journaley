namespace Journaley.Forms
{
    using System.Windows.Forms;

    /// <summary>
    /// The Enable Password Form implementation.
    /// </summary>
    public partial class EnablePasswordForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnablePasswordForm"/> class.
        /// </summary>
        public EnablePasswordForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the new password.
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
        /// Handles the FormClosing event of the EnablePasswordForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void EnablePasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.textNewPassword1.Text != this.textNewPassword2.Text)
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
