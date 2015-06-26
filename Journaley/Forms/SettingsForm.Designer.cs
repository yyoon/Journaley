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
            this.buttonEnablePassword = new Journaley.Controls.ColorButton();
            this.buttonRemovePassword = new Journaley.Controls.ColorButton();
            this.buttonChangePassword = new Journaley.Controls.ColorButton();
            this.labelPasswordStatus = new System.Windows.Forms.Label();
            this.textFolder = new System.Windows.Forms.TextBox();
            this.buttonSelectFolder = new Journaley.Controls.ImageButton();
            this.buttonOK = new Journaley.Controls.ColorButton();
            this.buttonCancel = new Journaley.Controls.ColorButton();
            this.labelFormCaption = new Journaley.Controls.TitleLabel();
            this.horizontalSeparator1 = new System.Windows.Forms.Panel();
            this.horizontalSeparator2 = new System.Windows.Forms.Panel();
            this.labelJournalLocationSection = new System.Windows.Forms.Label();
            this.labelFolderPath = new System.Windows.Forms.Label();
            this.labelPasswordSection = new System.Windows.Forms.Label();
            this.labelAppearanceSection = new System.Windows.Forms.Label();
            this.labelTextSize = new System.Windows.Forms.Label();
            this.buttonSizeSmall = new Journaley.Controls.ColorButton();
            this.buttonSizeMedium = new Journaley.Controls.ColorButton();
            this.buttonSizeLarge = new Journaley.Controls.ColorButton();
            this.panelTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).BeginInit();
            this.panelContent.SuspendLayout();
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
            this.panelContent.Controls.Add(this.buttonEnablePassword);
            this.panelContent.Controls.Add(this.buttonRemovePassword);
            this.panelContent.Controls.Add(this.buttonChangePassword);
            this.panelContent.Controls.Add(this.labelPasswordStatus);
            this.panelContent.Controls.Add(this.labelPasswordSection);
            this.panelContent.Controls.Add(this.horizontalSeparator1);
            this.panelContent.Controls.Add(this.buttonSizeLarge);
            this.panelContent.Controls.Add(this.buttonSizeMedium);
            this.panelContent.Controls.Add(this.buttonSizeSmall);
            this.panelContent.Controls.Add(this.labelTextSize);
            this.panelContent.Controls.Add(this.labelAppearanceSection);
            this.panelContent.Padding = new System.Windows.Forms.Padding(1);
            this.panelContent.Size = new System.Drawing.Size(450, 580);
            // 
            // buttonEnablePassword
            // 
            this.buttonEnablePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEnablePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonEnablePassword.BorderColor = System.Drawing.Color.Black;
            this.buttonEnablePassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonEnablePassword.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonEnablePassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnablePassword.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonEnablePassword.Location = new System.Drawing.Point(333, 200);
            this.buttonEnablePassword.Name = "buttonEnablePassword";
            this.buttonEnablePassword.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonEnablePassword.Selected = false;
            this.buttonEnablePassword.SelectedColor = System.Drawing.Color.Empty;
            this.buttonEnablePassword.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonEnablePassword.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonEnablePassword.Size = new System.Drawing.Size(100, 30);
            this.buttonEnablePassword.TabIndex = 2;
            this.buttonEnablePassword.Text = "Enable";
            this.buttonEnablePassword.Click += new System.EventHandler(this.ButtonEnablePassword_Click);
            // 
            // buttonRemovePassword
            // 
            this.buttonRemovePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemovePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonRemovePassword.BorderColor = System.Drawing.Color.Black;
            this.buttonRemovePassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonRemovePassword.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonRemovePassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemovePassword.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonRemovePassword.Location = new System.Drawing.Point(333, 200);
            this.buttonRemovePassword.Name = "buttonRemovePassword";
            this.buttonRemovePassword.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonRemovePassword.Selected = false;
            this.buttonRemovePassword.SelectedColor = System.Drawing.Color.Empty;
            this.buttonRemovePassword.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonRemovePassword.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonRemovePassword.Size = new System.Drawing.Size(100, 30);
            this.buttonRemovePassword.TabIndex = 1;
            this.buttonRemovePassword.Text = "Remove";
            this.buttonRemovePassword.Click += new System.EventHandler(this.ButtonRemovePassword_Click);
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonChangePassword.BorderColor = System.Drawing.Color.Black;
            this.buttonChangePassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonChangePassword.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonChangePassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangePassword.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonChangePassword.Location = new System.Drawing.Point(218, 200);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonChangePassword.Selected = false;
            this.buttonChangePassword.SelectedColor = System.Drawing.Color.Empty;
            this.buttonChangePassword.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonChangePassword.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonChangePassword.Size = new System.Drawing.Size(100, 30);
            this.buttonChangePassword.TabIndex = 0;
            this.buttonChangePassword.Text = "Change";
            this.buttonChangePassword.Click += new System.EventHandler(this.ButtonChangePassword_Click);
            // 
            // labelPasswordStatus
            // 
            this.labelPasswordStatus.AutoSize = true;
            this.labelPasswordStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordStatus.Location = new System.Drawing.Point(27, 212);
            this.labelPasswordStatus.Name = "labelPasswordStatus";
            this.labelPasswordStatus.Size = new System.Drawing.Size(0, 20);
            this.labelPasswordStatus.TabIndex = 3;
            // 
            // textFolder
            // 
            this.textFolder.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.textFolder.Location = new System.Drawing.Point(30, 417);
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
            this.buttonSelectFolder.Location = new System.Drawing.Point(370, 417);
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
            this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonOK.BorderColor = System.Drawing.Color.Black;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonOK.Location = new System.Drawing.Point(333, 535);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonOK.Selected = false;
            this.buttonOK.SelectedColor = System.Drawing.Color.Empty;
            this.buttonOK.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonOK.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonOK.Size = new System.Drawing.Size(100, 30);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ok";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonCancel.BorderColor = System.Drawing.Color.Black;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonCancel.Location = new System.Drawing.Point(218, 535);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonCancel.Selected = false;
            this.buttonCancel.SelectedColor = System.Drawing.Color.Empty;
            this.buttonCancel.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonCancel.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonCancel.Size = new System.Drawing.Size(100, 30);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
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
            this.labelJournalLocationSection.Location = new System.Drawing.Point(10, 359);
            this.labelJournalLocationSection.Name = "labelJournalLocationSection";
            this.labelJournalLocationSection.Size = new System.Drawing.Size(114, 20);
            this.labelJournalLocationSection.TabIndex = 6;
            this.labelJournalLocationSection.Text = "Journal Location";
            // 
            // labelFolderPath
            // 
            this.labelFolderPath.AutoSize = true;
            this.labelFolderPath.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolderPath.Location = new System.Drawing.Point(27, 395);
            this.labelFolderPath.Name = "labelFolderPath";
            this.labelFolderPath.Size = new System.Drawing.Size(89, 20);
            this.labelFolderPath.TabIndex = 7;
            this.labelFolderPath.Text = "Folder Path";
            // 
            // labelPasswordSection
            // 
            this.labelPasswordSection.AutoSize = true;
            this.labelPasswordSection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordSection.Location = new System.Drawing.Point(10, 176);
            this.labelPasswordSection.Name = "labelPasswordSection";
            this.labelPasswordSection.Size = new System.Drawing.Size(70, 20);
            this.labelPasswordSection.TabIndex = 8;
            this.labelPasswordSection.Text = "Password";
            // 
            // labelAppearanceSection
            // 
            this.labelAppearanceSection.AutoSize = true;
            this.labelAppearanceSection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppearanceSection.Location = new System.Drawing.Point(10, 15);
            this.labelAppearanceSection.Name = "labelAppearanceSection";
            this.labelAppearanceSection.Size = new System.Drawing.Size(120, 20);
            this.labelAppearanceSection.TabIndex = 9;
            this.labelAppearanceSection.Text = "Entry Appearance";
            // 
            // labelTextSize
            // 
            this.labelTextSize.AutoSize = true;
            this.labelTextSize.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextSize.Location = new System.Drawing.Point(27, 62);
            this.labelTextSize.Name = "labelTextSize";
            this.labelTextSize.Size = new System.Drawing.Size(70, 20);
            this.labelTextSize.TabIndex = 10;
            this.labelTextSize.Text = "Text Size";
            // 
            // buttonSizeSmall
            // 
            this.buttonSizeSmall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSizeSmall.BorderColor = System.Drawing.Color.Black;
            this.buttonSizeSmall.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSizeSmall.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeSmall.Font = new System.Drawing.Font("Noto Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSizeSmall.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSizeSmall.Location = new System.Drawing.Point(30, 93);
            this.buttonSizeSmall.Name = "buttonSizeSmall";
            this.buttonSizeSmall.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSizeSmall.Selected = false;
            this.buttonSizeSmall.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeSmall.SelectedDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeSmall.SelectedHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSizeSmall.Size = new System.Drawing.Size(36, 36);
            this.buttonSizeSmall.TabIndex = 11;
            this.buttonSizeSmall.Text = "T";
            this.buttonSizeSmall.Click += new System.EventHandler(this.ButtonSizeSmall_Click);
            // 
            // buttonSizeMedium
            // 
            this.buttonSizeMedium.BorderColor = System.Drawing.Color.Black;
            this.buttonSizeMedium.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSizeMedium.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeMedium.Font = new System.Drawing.Font("Noto Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSizeMedium.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSizeMedium.Location = new System.Drawing.Point(70, 93);
            this.buttonSizeMedium.Name = "buttonSizeMedium";
            this.buttonSizeMedium.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSizeMedium.Selected = true;
            this.buttonSizeMedium.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeMedium.SelectedDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeMedium.SelectedHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSizeMedium.Size = new System.Drawing.Size(36, 36);
            this.buttonSizeMedium.TabIndex = 12;
            this.buttonSizeMedium.Text = "T";
            this.buttonSizeMedium.Click += new System.EventHandler(this.ButtonSizeMedium_Click);
            // 
            // buttonSizeLarge
            // 
            this.buttonSizeLarge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSizeLarge.BorderColor = System.Drawing.Color.Black;
            this.buttonSizeLarge.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSizeLarge.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeLarge.Font = new System.Drawing.Font("Noto Sans", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSizeLarge.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSizeLarge.Location = new System.Drawing.Point(110, 93);
            this.buttonSizeLarge.Name = "buttonSizeLarge";
            this.buttonSizeLarge.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSizeLarge.Selected = false;
            this.buttonSizeLarge.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeLarge.SelectedDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeLarge.SelectedHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSizeLarge.Size = new System.Drawing.Size(36, 36);
            this.buttonSizeLarge.TabIndex = 13;
            this.buttonSizeLarge.Text = "T";
            this.buttonSizeLarge.Click += new System.EventHandler(this.ButtonSizeLarge_Click);
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
            this.RealClientSize = new System.Drawing.Size(448, 578);
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
            ((System.ComponentModel.ISupportInitialize)(this.buttonSelectFolder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPasswordStatus;
        private Controls.ColorButton buttonEnablePassword;
        private Controls.ColorButton buttonRemovePassword;
        private Controls.ColorButton buttonChangePassword;
        private System.Windows.Forms.TextBox textFolder;
        private Controls.ImageButton buttonSelectFolder;
        private Controls.ColorButton buttonOK;
        private Controls.ColorButton buttonCancel;
        protected Controls.TitleLabel labelFormCaption;
        private System.Windows.Forms.Panel horizontalSeparator1;
        private System.Windows.Forms.Panel horizontalSeparator2;
        private System.Windows.Forms.Label labelJournalLocationSection;
        private System.Windows.Forms.Label labelFolderPath;
        private System.Windows.Forms.Label labelPasswordSection;
        private System.Windows.Forms.Label labelAppearanceSection;
        private System.Windows.Forms.Label labelTextSize;
        private Controls.ColorButton buttonSizeLarge;
        private Controls.ColorButton buttonSizeMedium;
        private Controls.ColorButton buttonSizeSmall;
    }
}