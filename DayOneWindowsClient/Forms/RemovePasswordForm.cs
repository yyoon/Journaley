using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DayOneWindowsClient.Forms
{
    public partial class RemovePasswordForm : Form
    {
        public RemovePasswordForm(IPasswordVerifier passwordVerifier)
        {
            InitializeComponent();

            this.PasswordVerifier = passwordVerifier;
        }

        public string CurrentPassword
        {
            get
            {
                return this.textCurrentPassword.Text;
            }
        }

        private IPasswordVerifier PasswordVerifier;

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
