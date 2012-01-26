using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DayOneWindowsClient
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private Settings _settings;
        public Settings Settings
        {
            get
            {
                if (_settings == null)
                    _settings = new Settings();
                return _settings;
            }
            set { _settings = value; }
        }

        private bool DisableCancel { get; set; }

        private void UpdatePasswordInterface()
        {
            bool passwordEnabled = this.Settings.HasPassword;

            this.labelPasswordStatus.Text = passwordEnabled ? "Enabled" : "Disabled";

            this.buttonChangePassword.Visible = passwordEnabled;
            this.buttonEnablePassword.Visible = !passwordEnabled;
            this.buttonRemovePassword.Visible = passwordEnabled;
        }

        private void UpdateFolderInterface()
        {
            this.textFolder.Text = this.Settings.DayOneFolderPath;
            this.buttonOK.Enabled = Directory.Exists(this.Settings.DayOneFolderPath);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (_settings == null)
            {
                DisableCancel = true;
                this.buttonCancel.Enabled = false;
            }

            UpdatePasswordInterface();
            UpdateFolderInterface();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm(this.Settings);

            DialogResult result = form.ShowDialog(this);

            if (result != DialogResult.Cancel)
            {
                this.Settings.Password = form.NewPassword;
            }

            UpdatePasswordInterface();
        }

        private void buttonEnablePassword_Click(object sender, EventArgs e)
        {
            EnablePasswordForm form = new EnablePasswordForm();

            DialogResult result = form.ShowDialog(this);

            if (result != DialogResult.Cancel)
            {
                this.Settings.Password = form.NewPassword;
            }

            UpdatePasswordInterface();
        }

        private void buttonRemovePassword_Click(object sender, EventArgs e)
        {
            RemovePasswordForm form = new RemovePasswordForm(this.Settings);

            DialogResult result = form.ShowDialog(this);

            if (result != DialogResult.Cancel)
            {
                this.Settings.PasswordHash = null;
            }

            UpdatePasswordInterface();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.SelectedPath = this.Settings.DayOneFolderPath;
            folderDialog.ShowDialog();

            this.Settings.DayOneFolderPath = folderDialog.SelectedPath;
            UpdateFolderInterface();
        }
    }
}
