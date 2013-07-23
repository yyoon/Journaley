namespace DayOneWindowsClient.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupPassword = new System.Windows.Forms.GroupBox();
            this.labelPasswordStatus = new System.Windows.Forms.Label();
            this.buttonEnablePassword = new System.Windows.Forms.Button();
            this.buttonRemovePassword = new System.Windows.Forms.Button();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.groupFolder = new System.Windows.Forms.GroupBox();
            this.textFolder = new System.Windows.Forms.TextBox();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupPassword.SuspendLayout();
            this.groupFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPassword
            // 
            this.groupPassword.Controls.Add(this.labelPasswordStatus);
            this.groupPassword.Controls.Add(this.buttonEnablePassword);
            this.groupPassword.Controls.Add(this.buttonRemovePassword);
            this.groupPassword.Controls.Add(this.buttonChangePassword);
            this.groupPassword.Location = new System.Drawing.Point(12, 12);
            this.groupPassword.Name = "groupPassword";
            this.groupPassword.Size = new System.Drawing.Size(260, 48);
            this.groupPassword.TabIndex = 2;
            this.groupPassword.TabStop = false;
            this.groupPassword.Text = "Password";
            // 
            // labelPasswordStatus
            // 
            this.labelPasswordStatus.AutoSize = true;
            this.labelPasswordStatus.Location = new System.Drawing.Point(6, 24);
            this.labelPasswordStatus.Name = "labelPasswordStatus";
            this.labelPasswordStatus.Size = new System.Drawing.Size(0, 13);
            this.labelPasswordStatus.TabIndex = 3;
            // 
            // buttonEnablePassword
            // 
            this.buttonEnablePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEnablePassword.Location = new System.Drawing.Point(179, 19);
            this.buttonEnablePassword.Name = "buttonEnablePassword";
            this.buttonEnablePassword.Size = new System.Drawing.Size(75, 23);
            this.buttonEnablePassword.TabIndex = 2;
            this.buttonEnablePassword.Text = "Enable";
            this.buttonEnablePassword.UseVisualStyleBackColor = true;
            this.buttonEnablePassword.Click += new System.EventHandler(this.buttonEnablePassword_Click);
            // 
            // buttonRemovePassword
            // 
            this.buttonRemovePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemovePassword.Location = new System.Drawing.Point(179, 19);
            this.buttonRemovePassword.Name = "buttonRemovePassword";
            this.buttonRemovePassword.Size = new System.Drawing.Size(75, 23);
            this.buttonRemovePassword.TabIndex = 1;
            this.buttonRemovePassword.Text = "Remove";
            this.buttonRemovePassword.UseVisualStyleBackColor = true;
            this.buttonRemovePassword.Click += new System.EventHandler(this.buttonRemovePassword_Click);
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangePassword.Location = new System.Drawing.Point(98, 19);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(75, 23);
            this.buttonChangePassword.TabIndex = 0;
            this.buttonChangePassword.Text = "Change";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // groupFolder
            // 
            this.groupFolder.Controls.Add(this.textFolder);
            this.groupFolder.Controls.Add(this.buttonSelectFolder);
            this.groupFolder.Location = new System.Drawing.Point(12, 66);
            this.groupFolder.Name = "groupFolder";
            this.groupFolder.Size = new System.Drawing.Size(260, 48);
            this.groupFolder.TabIndex = 3;
            this.groupFolder.TabStop = false;
            this.groupFolder.Text = "Day One Folder";
            // 
            // textFolder
            // 
            this.textFolder.Location = new System.Drawing.Point(6, 21);
            this.textFolder.Name = "textFolder";
            this.textFolder.ReadOnly = true;
            this.textFolder.Size = new System.Drawing.Size(212, 20);
            this.textFolder.TabIndex = 1;
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectFolder.Location = new System.Drawing.Point(224, 19);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(30, 23);
            this.buttonSelectFolder.TabIndex = 0;
            this.buttonSelectFolder.Text = "...";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(116, 120);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(197, 120);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 155);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupFolder);
            this.Controls.Add(this.groupPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupPassword.ResumeLayout(false);
            this.groupPassword.PerformLayout();
            this.groupFolder.ResumeLayout(false);
            this.groupFolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPassword;
        private System.Windows.Forms.Label labelPasswordStatus;
        private System.Windows.Forms.Button buttonEnablePassword;
        private System.Windows.Forms.Button buttonRemovePassword;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.GroupBox groupFolder;
        private System.Windows.Forms.TextBox textFolder;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}