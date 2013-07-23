using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DayOneWindowsClient.Models;

namespace DayOneWindowsClient.Forms
{
    public partial class PasswordInputForm : Form
    {
        public PasswordInputForm(IPasswordVerifier passwordVerifier)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.MainIcon;

            this.PasswordVerifier = passwordVerifier;
        }

        private IPasswordVerifier PasswordVerifier { get; set; }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        if (this.PasswordVerifier.VerifyPassword(this.textBoxPassword.Text))
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show(this.ParentForm, "Wrong Password!", "Day One Windows Client", MessageBoxButtons.OK);
                            this.textBoxPassword.SelectAll();
                            this.textBoxPassword.Focus();
                        }

                        e.Handled = true;
                    }
                    break;

                case Keys.Escape:
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        Close();

                        e.Handled = true;
                    }
                    break;

            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                case (char)Keys.Escape:
                    e.Handled = true;
                    break;
            }
        }
    }
}
