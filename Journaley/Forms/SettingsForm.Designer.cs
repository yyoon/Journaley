namespace Journaley.Forms
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
            this.textFolder = new System.Windows.Forms.TextBox();
            this.buttonSelectFolder = new Journaley.Controls.ImageButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelFormCaption = new Journaley.Controls.TitleLabel();
            this.horizontalSeparator1 = new System.Windows.Forms.Panel();
            this.horizontalSeparator2 = new System.Windows.Forms.Panel();
            this.labelJournalLocationSection = new System.Windows.Forms.Label();
            this.labelFolderPath = new System.Windows.Forms.Label();
            this.labelPasswordSection = new System.Windows.Forms.Label();
            this.panelTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).BeginInit();
            this.panelContent.SuspendLayout();
            this.groupPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSelectFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitlebar
            // 
            this.panelTitlebar.Controls.Add(this.labelFormCaption);
            this.panelTitlebar.Size = new System.Drawing.Size(450, 20);
            this.panelTitlebar.Controls.SetChildIndex(this.labelFormCaption, 0);
            this.panelTitlebar.Controls.SetChildIndex(this.imageButtonFormClose, 0);
            this.panelTitlebar.Controls.SetChildIndex(this.imageButtonFormMaximize, 0);
            this.panelTitlebar.Controls.SetChildIndex(this.imageButtonFormMinimize, 0);
            // 
            // imageButtonFormClose
            // 
            this.imageButtonFormClose.Location = new System.Drawing.Point(403, 0);
            // 
            // imageButtonFormMinimize
            // 
            this.imageButtonFormMinimize.Location = new System.Drawing.Point(311, 0);
            this.imageButtonFormMinimize.Visible = false;
            // 
            // imageButtonFormMaximize
            // 
            this.imageButtonFormMaximize.Location = new System.Drawing.Point(357, 0);
            this.imageButtonFormMaximize.Visible = false;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.buttonOK);
            this.panelContent.Controls.Add(this.buttonCancel);
            this.panelContent.Controls.Add(this.buttonSelectFolder);
            this.panelContent.Controls.Add(this.textFolder);
            this.panelContent.Controls.Add(this.labelFolderPath);
            this.panelContent.Controls.Add(this.labelJournalLocationSection);
            this.panelContent.Controls.Add(this.horizontalSeparator2);
            this.panelContent.Controls.Add(this.labelPasswordSection);
            this.panelContent.Controls.Add(this.horizontalSeparator1);
            this.panelContent.Controls.Add(this.groupPassword);
            this.panelContent.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.panelContent.Size = new System.Drawing.Size(450, 580);
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
            this.buttonEnablePassword.Click += new System.EventHandler(this.ButtonEnablePassword_Click);
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
            this.buttonRemovePassword.Click += new System.EventHandler(this.ButtonRemovePassword_Click);
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
            this.buttonChangePassword.Click += new System.EventHandler(this.ButtonChangePassword_Click);
            // 
            // textFolder
            // 
            this.textFolder.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFolder.Location = new System.Drawing.Point(30, 416);
            this.textFolder.Name = "textFolder";
            this.textFolder.ReadOnly = true;
            this.textFolder.Size = new System.Drawing.Size(334, 27);
            this.textFolder.TabIndex = 1;
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectFolder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSelectFolder.DownImage = global::Journaley.Properties.Resources.settings_folder_btn_down;
            this.buttonSelectFolder.HoverImage = global::Journaley.Properties.Resources.settings_folder_btn_over;
            this.buttonSelectFolder.Image = global::Journaley.Properties.Resources.settings_folder_btn_norm;
            this.buttonSelectFolder.Location = new System.Drawing.Point(370, 416);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.NormalImage = global::Journaley.Properties.Resources.settings_folder_btn_norm;
            this.buttonSelectFolder.Selected = false;
            this.buttonSelectFolder.SelectedDownImage = null;
            this.buttonSelectFolder.SelectedHoverImage = null;
            this.buttonSelectFolder.SelectedImage = null;
            this.buttonSelectFolder.Size = new System.Drawing.Size(47, 27);
            this.buttonSelectFolder.TabIndex = 0;
            this.buttonSelectFolder.TabStop = false;
            this.buttonSelectFolder.Text = "...";
            this.buttonSelectFolder.Click += new System.EventHandler(this.ButtonSelectFolder_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(333, 535);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 30);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(218, 535);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 30);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelFormCaption
            // 
            this.labelFormCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFormCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelFormCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.labelFormCaption.Location = new System.Drawing.Point(83, 0);
            this.labelFormCaption.Name = "labelFormCaption";
            this.labelFormCaption.Size = new System.Drawing.Size(284, 20);
            this.labelFormCaption.TabIndex = 6;
            this.labelFormCaption.Text = "Settings";
            this.labelFormCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // horizontalSeparator1
            // 
            this.horizontalSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(148)))), ((int)(((byte)(144)))));
            this.horizontalSeparator1.Location = new System.Drawing.Point(0, 160);
            this.horizontalSeparator1.Margin = new System.Windows.Forms.Padding(0);
            this.horizontalSeparator1.Name = "horizontalSeparator1";
            this.horizontalSeparator1.Size = new System.Drawing.Size(450, 1);
            this.horizontalSeparator1.TabIndex = 4;
            // 
            // horizontalSeparator2
            // 
            this.horizontalSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(148)))), ((int)(((byte)(144)))));
            this.horizontalSeparator2.Location = new System.Drawing.Point(0, 333);
            this.horizontalSeparator2.Margin = new System.Windows.Forms.Padding(0);
            this.horizontalSeparator2.Name = "horizontalSeparator2";
            this.horizontalSeparator2.Size = new System.Drawing.Size(450, 1);
            this.horizontalSeparator2.TabIndex = 5;
            // 
            // labelJournalLocationSection
            // 
            this.labelJournalLocationSection.AutoSize = true;
            this.labelJournalLocationSection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJournalLocationSection.Location = new System.Drawing.Point(10, 358);
            this.labelJournalLocationSection.Name = "labelJournalLocationSection";
            this.labelJournalLocationSection.Size = new System.Drawing.Size(114, 20);
            this.labelJournalLocationSection.TabIndex = 6;
            this.labelJournalLocationSection.Text = "Journal Location";
            // 
            // labelFolderPath
            // 
            this.labelFolderPath.AutoSize = true;
            this.labelFolderPath.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolderPath.Location = new System.Drawing.Point(27, 394);
            this.labelFolderPath.Name = "labelFolderPath";
            this.labelFolderPath.Size = new System.Drawing.Size(89, 20);
            this.labelFolderPath.TabIndex = 7;
            this.labelFolderPath.Text = "Folder Path";
            // 
            // labelPasswordSection
            // 
            this.labelPasswordSection.AutoSize = true;
            this.labelPasswordSection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordSection.Location = new System.Drawing.Point(10, 175);
            this.labelPasswordSection.Name = "labelPasswordSection";
            this.labelPasswordSection.Size = new System.Drawing.Size(70, 20);
            this.labelPasswordSection.TabIndex = 8;
            this.labelPasswordSection.Text = "Password";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(450, 600);
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SettingsForm";
            this.RealClientSize = new System.Drawing.Size(448, 579);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panelTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.groupPassword.ResumeLayout(false);
            this.groupPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSelectFolder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPassword;
        private System.Windows.Forms.Label labelPasswordStatus;
        private System.Windows.Forms.Button buttonEnablePassword;
        private System.Windows.Forms.Button buttonRemovePassword;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.TextBox textFolder;
        private Controls.ImageButton buttonSelectFolder;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        protected Controls.TitleLabel labelFormCaption;
        private System.Windows.Forms.Panel horizontalSeparator1;
        private System.Windows.Forms.Panel horizontalSeparator2;
        private System.Windows.Forms.Label labelJournalLocationSection;
        private System.Windows.Forms.Label labelFolderPath;
        private System.Windows.Forms.Label labelPasswordSection;
    }
}