using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DayOneWindowsClient
{
    public partial class EnablePasswordForm : Form
    {
        public EnablePasswordForm()
        {
            InitializeComponent();
        }

        public string NewPassword
        {
            get
            {
                return this.textNewPassword1.Text;
            }
        }

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
