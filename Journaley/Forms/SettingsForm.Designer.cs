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
            this.components = new System.ComponentModel.Container();
            this.buttonChangePassword = new Journaley.Controls.ColorButton();
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
            this.panelPasswordNormal = new System.Windows.Forms.Panel();
            this.checkBoxEnablePassword = new System.Windows.Forms.CheckBox();
            this.panelPasswordSetting = new System.Windows.Forms.Panel();
            this.labelPasswordConfirm = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textPasswordConfirm = new Journaley.Controls.EnterTextBox();
            this.paddingPasswordConfirm = new System.Windows.Forms.Label();
            this.borderPasswordConfirm = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.paddingTextPassword = new System.Windows.Forms.Label();
            this.borderPassword = new System.Windows.Forms.Label();
            this.buttonCancelPassword = new Journaley.Controls.ColorButton();
            this.buttonSetPassword = new Journaley.Controls.ColorButton();
            this.comboSpellcheckLanguages = new System.Windows.Forms.ComboBox();
            this.labelSpellChecker = new System.Windows.Forms.Label();
            this.checkBoxEnableSpellCheck = new System.Windows.Forms.CheckBox();
            this.horizontalSeparator3 = new System.Windows.Forms.Panel();
            this.labelUpdates = new System.Windows.Forms.Label();
            this.checkBoxAutoUpdate = new System.Windows.Forms.CheckBox();
            this.buttonUpdate = new Journaley.Controls.ColorButton();
            this.pictureUpdateIndicator = new System.Windows.Forms.PictureBox();
            this.horizontalSeparator4 = new System.Windows.Forms.Panel();
            this.labelCurrentVersion = new System.Windows.Forms.Label();
            this.linkVersionNumber = new System.Windows.Forms.LinkLabel();
            this.buttonAbout = new Journaley.Controls.ImageButton();
            this.panelAbout = new Journaley.Controls.PaddingBorderPanel();
            this.linkMITLicense = new System.Windows.Forms.LinkLabel();
            this.labelLicensedUnder = new System.Windows.Forms.Label();
            this.linkGitHub = new System.Windows.Forms.LinkLabel();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.labelSupport = new System.Windows.Forms.Label();
            this.horizontalSeparator6 = new System.Windows.Forms.Panel();
            this.linkSquirrelWindowsLicense = new System.Windows.Forms.LinkLabel();
            this.labelSquirrelWindowsAuthor = new System.Windows.Forms.Label();
            this.labelSquirrelWindowsTitle = new System.Windows.Forms.Label();
            this.linkMarkdownSharpLicense = new System.Windows.Forms.LinkLabel();
            this.labelMarkdownSharpAuthor3 = new System.Windows.Forms.Label();
            this.labelMarkdownSharpAuthor2 = new System.Windows.Forms.Label();
            this.labelMarkdownSharpAuthor1 = new System.Windows.Forms.Label();
            this.labelMarkdownSharpTitle = new System.Windows.Forms.Label();
            this.linkAnotherMonthCalendarLicense = new System.Windows.Forms.LinkLabel();
            this.labelAnotherMonthCalendarAuthor = new System.Windows.Forms.Label();
            this.labelAnotherMonthCalendarTitle = new System.Windows.Forms.Label();
            this.linkNotoSansLicense = new System.Windows.Forms.LinkLabel();
            this.labelNotoSansAuthor = new System.Windows.Forms.Label();
            this.labelNotoSansTitle = new System.Windows.Forms.Label();
            this.labelOpenSourceLicense = new System.Windows.Forms.Label();
            this.horizontalSeparator5 = new System.Windows.Forms.Panel();
            this.linkSammyGuergachi = new System.Windows.Forms.LinkLabel();
            this.labelDesignedBy = new System.Windows.Forms.Label();
            this.linkYoungSeokYoon = new System.Windows.Forms.LinkLabel();
            this.labelDevelopedBy = new System.Windows.Forms.Label();
            this.labelCredits = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSelectFolder)).BeginInit();
            this.panelPasswordNormal.SuspendLayout();
            this.panelPasswordSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUpdateIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAbout)).BeginInit();
            this.panelAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitlebar
            // 
            this.panelTitlebar.Controls.Add(this.labelFormCaption);
            this.panelTitlebar.Size = new System.Drawing.Size(450, 20);
            this.panelTitlebar.TabIndex = 0;
            this.panelTitlebar.Controls.SetChildIndex(this.pictureBoxFormIcon, 0);
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
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.Controls.Add(this.buttonAbout);
            this.panelContent.Controls.Add(this.linkVersionNumber);
            this.panelContent.Controls.Add(this.labelCurrentVersion);
            this.panelContent.Controls.Add(this.horizontalSeparator4);
            this.panelContent.Controls.Add(this.pictureUpdateIndicator);
            this.panelContent.Controls.Add(this.buttonUpdate);
            this.panelContent.Controls.Add(this.checkBoxAutoUpdate);
            this.panelContent.Controls.Add(this.labelUpdates);
            this.panelContent.Controls.Add(this.horizontalSeparator3);
            this.panelContent.Controls.Add(this.buttonOK);
            this.panelContent.Controls.Add(this.buttonCancel);
            this.panelContent.Controls.Add(this.buttonSelectFolder);
            this.panelContent.Controls.Add(this.textFolder);
            this.panelContent.Controls.Add(this.labelFolderPath);
            this.panelContent.Controls.Add(this.labelJournalLocationSection);
            this.panelContent.Controls.Add(this.horizontalSeparator2);
            this.panelContent.Controls.Add(this.labelPasswordSection);
            this.panelContent.Controls.Add(this.panelPasswordNormal);
            this.panelContent.Controls.Add(this.panelPasswordSetting);
            this.panelContent.Controls.Add(this.horizontalSeparator1);
            this.panelContent.Controls.Add(this.comboSpellcheckLanguages);
            this.panelContent.Controls.Add(this.checkBoxEnableSpellCheck);
            this.panelContent.Controls.Add(this.labelSpellChecker);
            this.panelContent.Controls.Add(this.buttonSizeLarge);
            this.panelContent.Controls.Add(this.buttonSizeMedium);
            this.panelContent.Controls.Add(this.buttonSizeSmall);
            this.panelContent.Controls.Add(this.labelTextSize);
            this.panelContent.Controls.Add(this.labelAppearanceSection);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.None;
            this.panelContent.Padding = new System.Windows.Forms.Padding(1);
            this.panelContent.Size = new System.Drawing.Size(450, 580);
            this.panelContent.TabIndex = 1;
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonChangePassword.BorderColor = System.Drawing.Color.Black;
            this.buttonChangePassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonChangePassword.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(83)))), ((int)(((byte)(89)))));
            this.buttonChangePassword.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonChangePassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangePassword.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonChangePassword.Location = new System.Drawing.Point(30, 87);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonChangePassword.Selected = false;
            this.buttonChangePassword.SelectedColor = System.Drawing.Color.Empty;
            this.buttonChangePassword.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonChangePassword.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonChangePassword.Size = new System.Drawing.Size(140, 30);
            this.buttonChangePassword.TabIndex = 1;
            this.buttonChangePassword.Text = "Change Password";
            this.buttonChangePassword.Click += new System.EventHandler(this.ButtonChangePassword_Click);
            // 
            // textFolder
            // 
            this.textFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.textFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textFolder.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.textFolder.Location = new System.Drawing.Point(30, 356);
            this.textFolder.Name = "textFolder";
            this.textFolder.ReadOnly = true;
            this.textFolder.Size = new System.Drawing.Size(334, 27);
            this.textFolder.TabIndex = 12;
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectFolder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSelectFolder.DownImage = global::Journaley.Properties.Resources.settings_folder_btn_down;
            this.buttonSelectFolder.HoverImage = global::Journaley.Properties.Resources.settings_folder_btn_over;
            this.buttonSelectFolder.Image = global::Journaley.Properties.Resources.settings_folder_btn_norm;
            this.buttonSelectFolder.Location = new System.Drawing.Point(370, 356);
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
            this.buttonOK.DisabledColor = System.Drawing.Color.Empty;
            this.buttonOK.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.buttonOK.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonOK.Location = new System.Drawing.Point(221, 542);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonOK.Selected = false;
            this.buttonOK.SelectedColor = System.Drawing.Color.Empty;
            this.buttonOK.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonOK.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonOK.Size = new System.Drawing.Size(100, 30);
            this.buttonOK.TabIndex = 15;
            this.buttonOK.Text = "Done";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.buttonCancel.BorderColor = System.Drawing.Color.Black;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.DisabledColor = System.Drawing.Color.Empty;
            this.buttonCancel.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCancel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonCancel.Location = new System.Drawing.Point(337, 542);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.buttonCancel.Selected = false;
            this.buttonCancel.SelectedColor = System.Drawing.Color.Empty;
            this.buttonCancel.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonCancel.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonCancel.Size = new System.Drawing.Size(100, 30);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            // 
            // labelFormCaption
            // 
            this.labelFormCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFormCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.labelFormCaption.Location = new System.Drawing.Point(31, 1);
            this.labelFormCaption.Name = "labelFormCaption";
            this.labelFormCaption.Size = new System.Drawing.Size(63, 17);
            this.labelFormCaption.TabIndex = 6;
            this.labelFormCaption.Text = "Settings";
            this.labelFormCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // horizontalSeparator1
            // 
            this.horizontalSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(148)))), ((int)(((byte)(144)))));
            this.horizontalSeparator1.Location = new System.Drawing.Point(1, 144);
            this.horizontalSeparator1.Margin = new System.Windows.Forms.Padding(0);
            this.horizontalSeparator1.Name = "horizontalSeparator1";
            this.horizontalSeparator1.Size = new System.Drawing.Size(448, 1);
            this.horizontalSeparator1.TabIndex = 5;
            // 
            // horizontalSeparator2
            // 
            this.horizontalSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(148)))), ((int)(((byte)(144)))));
            this.horizontalSeparator2.Location = new System.Drawing.Point(1, 285);
            this.horizontalSeparator2.Margin = new System.Windows.Forms.Padding(0);
            this.horizontalSeparator2.Name = "horizontalSeparator2";
            this.horizontalSeparator2.Size = new System.Drawing.Size(448, 1);
            this.horizontalSeparator2.TabIndex = 9;
            // 
            // labelJournalLocationSection
            // 
            this.labelJournalLocationSection.AutoSize = true;
            this.labelJournalLocationSection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJournalLocationSection.Location = new System.Drawing.Point(10, 302);
            this.labelJournalLocationSection.Name = "labelJournalLocationSection";
            this.labelJournalLocationSection.Size = new System.Drawing.Size(114, 20);
            this.labelJournalLocationSection.TabIndex = 10;
            this.labelJournalLocationSection.Text = "Journal Location";
            // 
            // labelFolderPath
            // 
            this.labelFolderPath.AutoSize = true;
            this.labelFolderPath.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolderPath.Location = new System.Drawing.Point(27, 335);
            this.labelFolderPath.Name = "labelFolderPath";
            this.labelFolderPath.Size = new System.Drawing.Size(80, 19);
            this.labelFolderPath.TabIndex = 11;
            this.labelFolderPath.Text = "Folder Path";
            // 
            // labelPasswordSection
            // 
            this.labelPasswordSection.AutoSize = true;
            this.labelPasswordSection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordSection.Location = new System.Drawing.Point(10, 158);
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
            this.labelAppearanceSection.Size = new System.Drawing.Size(111, 20);
            this.labelAppearanceSection.TabIndex = 0;
            this.labelAppearanceSection.Text = "Entry Preference";
            // 
            // labelTextSize
            // 
            this.labelTextSize.AutoSize = true;
            this.labelTextSize.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextSize.Location = new System.Drawing.Point(27, 52);
            this.labelTextSize.Name = "labelTextSize";
            this.labelTextSize.Size = new System.Drawing.Size(65, 19);
            this.labelTextSize.TabIndex = 1;
            this.labelTextSize.Text = "Text Size";
            // 
            // buttonSizeSmall
            // 
            this.buttonSizeSmall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSizeSmall.BorderColor = System.Drawing.Color.Black;
            this.buttonSizeSmall.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSizeSmall.DisabledColor = System.Drawing.Color.Empty;
            this.buttonSizeSmall.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSizeSmall.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSizeSmall.Location = new System.Drawing.Point(30, 83);
            this.buttonSizeSmall.Name = "buttonSizeSmall";
            this.buttonSizeSmall.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSizeSmall.Selected = false;
            this.buttonSizeSmall.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeSmall.SelectedDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeSmall.SelectedHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeSmall.Size = new System.Drawing.Size(36, 36);
            this.buttonSizeSmall.TabIndex = 2;
            this.buttonSizeSmall.Text = "T";
            this.buttonSizeSmall.Click += new System.EventHandler(this.ButtonSizeSmall_Click);
            // 
            // buttonSizeMedium
            // 
            this.buttonSizeMedium.BorderColor = System.Drawing.Color.Black;
            this.buttonSizeMedium.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSizeMedium.DisabledColor = System.Drawing.Color.Empty;
            this.buttonSizeMedium.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSizeMedium.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSizeMedium.Location = new System.Drawing.Point(70, 83);
            this.buttonSizeMedium.Name = "buttonSizeMedium";
            this.buttonSizeMedium.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSizeMedium.Selected = true;
            this.buttonSizeMedium.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeMedium.SelectedDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeMedium.SelectedHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeMedium.Size = new System.Drawing.Size(36, 36);
            this.buttonSizeMedium.TabIndex = 3;
            this.buttonSizeMedium.Text = "T";
            this.buttonSizeMedium.Click += new System.EventHandler(this.ButtonSizeMedium_Click);
            // 
            // buttonSizeLarge
            // 
            this.buttonSizeLarge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSizeLarge.BorderColor = System.Drawing.Color.Black;
            this.buttonSizeLarge.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSizeLarge.DisabledColor = System.Drawing.Color.Empty;
            this.buttonSizeLarge.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSizeLarge.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSizeLarge.Location = new System.Drawing.Point(110, 83);
            this.buttonSizeLarge.Name = "buttonSizeLarge";
            this.buttonSizeLarge.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSizeLarge.Selected = false;
            this.buttonSizeLarge.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeLarge.SelectedDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeLarge.SelectedHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSizeLarge.Size = new System.Drawing.Size(36, 36);
            this.buttonSizeLarge.TabIndex = 4;
            this.buttonSizeLarge.Text = "T";
            this.buttonSizeLarge.Click += new System.EventHandler(this.ButtonSizeLarge_Click);
            // 
            // panelPasswordNormal
            // 
            this.panelPasswordNormal.Controls.Add(this.buttonChangePassword);
            this.panelPasswordNormal.Controls.Add(this.checkBoxEnablePassword);
            this.panelPasswordNormal.Location = new System.Drawing.Point(1, 145);
            this.panelPasswordNormal.Margin = new System.Windows.Forms.Padding(0);
            this.panelPasswordNormal.Name = "panelPasswordNormal";
            this.panelPasswordNormal.Size = new System.Drawing.Size(448, 140);
            this.panelPasswordNormal.TabIndex = 7;
            // 
            // checkBoxEnablePassword
            // 
            this.checkBoxEnablePassword.AutoSize = true;
            this.checkBoxEnablePassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEnablePassword.Location = new System.Drawing.Point(30, 50);
            this.checkBoxEnablePassword.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxEnablePassword.Name = "checkBoxEnablePassword";
            this.checkBoxEnablePassword.Size = new System.Drawing.Size(213, 24);
            this.checkBoxEnablePassword.TabIndex = 0;
            this.checkBoxEnablePassword.Text = "Enable password protection";
            this.checkBoxEnablePassword.UseVisualStyleBackColor = true;
            this.checkBoxEnablePassword.Click += new System.EventHandler(this.CheckBoxEnablePassword_Click);
            // 
            // panelPasswordSetting
            // 
            this.panelPasswordSetting.Controls.Add(this.labelPasswordConfirm);
            this.panelPasswordSetting.Controls.Add(this.labelPassword);
            this.panelPasswordSetting.Controls.Add(this.textPasswordConfirm);
            this.panelPasswordSetting.Controls.Add(this.paddingPasswordConfirm);
            this.panelPasswordSetting.Controls.Add(this.borderPasswordConfirm);
            this.panelPasswordSetting.Controls.Add(this.textPassword);
            this.panelPasswordSetting.Controls.Add(this.paddingTextPassword);
            this.panelPasswordSetting.Controls.Add(this.borderPassword);
            this.panelPasswordSetting.Controls.Add(this.buttonCancelPassword);
            this.panelPasswordSetting.Controls.Add(this.buttonSetPassword);
            this.panelPasswordSetting.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.panelPasswordSetting.Location = new System.Drawing.Point(1, 145);
            this.panelPasswordSetting.Margin = new System.Windows.Forms.Padding(0);
            this.panelPasswordSetting.Name = "panelPasswordSetting";
            this.panelPasswordSetting.Size = new System.Drawing.Size(448, 140);
            this.panelPasswordSetting.TabIndex = 6;
            this.panelPasswordSetting.Visible = false;
            // 
            // labelPasswordConfirm
            // 
            this.labelPasswordConfirm.AutoSize = true;
            this.labelPasswordConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordConfirm.Location = new System.Drawing.Point(189, 77);
            this.labelPasswordConfirm.Name = "labelPasswordConfirm";
            this.labelPasswordConfirm.Size = new System.Drawing.Size(52, 19);
            this.labelPasswordConfirm.TabIndex = 12;
            this.labelPasswordConfirm.Text = "Retype";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(189, 24);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(68, 19);
            this.labelPassword.TabIndex = 11;
            this.labelPassword.Text = "Password";
            // 
            // textPasswordConfirm
            // 
            this.textPasswordConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.textPasswordConfirm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPasswordConfirm.Font = new System.Drawing.Font("Segoe UI", 18.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.textPasswordConfirm.Location = new System.Drawing.Point(196, 99);
            this.textPasswordConfirm.Name = "textPasswordConfirm";
            this.textPasswordConfirm.Size = new System.Drawing.Size(234, 25);
            this.textPasswordConfirm.TabIndex = 3;
            this.textPasswordConfirm.UseSystemPasswordChar = true;
            this.textPasswordConfirm.TextChanged += new System.EventHandler(this.TextPasswordConfirm_TextChanged);
            this.textPasswordConfirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextPasswordConfirm_KeyDown);
            this.textPasswordConfirm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextPasswordConfirm_KeyPress);
            // 
            // paddingPasswordConfirm
            // 
            this.paddingPasswordConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.paddingPasswordConfirm.Location = new System.Drawing.Point(194, 97);
            this.paddingPasswordConfirm.Name = "paddingPasswordConfirm";
            this.paddingPasswordConfirm.Size = new System.Drawing.Size(238, 29);
            this.paddingPasswordConfirm.TabIndex = 16;
            // 
            // borderPasswordConfirm
            // 
            this.borderPasswordConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.borderPasswordConfirm.Location = new System.Drawing.Point(193, 96);
            this.borderPasswordConfirm.Name = "borderPasswordConfirm";
            this.borderPasswordConfirm.Size = new System.Drawing.Size(240, 31);
            this.borderPasswordConfirm.TabIndex = 14;
            // 
            // textPassword
            // 
            this.textPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.textPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPassword.Font = new System.Drawing.Font("Segoe UI", 18.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.textPassword.Location = new System.Drawing.Point(196, 46);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(234, 25);
            this.textPassword.TabIndex = 2;
            this.textPassword.UseSystemPasswordChar = true;
            this.textPassword.TextChanged += new System.EventHandler(this.TextPassword_TextChanged);
            // 
            // paddingTextPassword
            // 
            this.paddingTextPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.paddingTextPassword.Location = new System.Drawing.Point(194, 44);
            this.paddingTextPassword.Name = "paddingTextPassword";
            this.paddingTextPassword.Size = new System.Drawing.Size(238, 29);
            this.paddingTextPassword.TabIndex = 15;
            // 
            // borderPassword
            // 
            this.borderPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.borderPassword.Location = new System.Drawing.Point(193, 43);
            this.borderPassword.Name = "borderPassword";
            this.borderPassword.Size = new System.Drawing.Size(240, 31);
            this.borderPassword.TabIndex = 13;
            // 
            // buttonCancelPassword
            // 
            this.buttonCancelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.buttonCancelPassword.BorderColor = System.Drawing.Color.Black;
            this.buttonCancelPassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonCancelPassword.DisabledColor = System.Drawing.Color.Empty;
            this.buttonCancelPassword.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonCancelPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelPassword.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonCancelPassword.Location = new System.Drawing.Point(30, 87);
            this.buttonCancelPassword.Name = "buttonCancelPassword";
            this.buttonCancelPassword.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.buttonCancelPassword.Selected = false;
            this.buttonCancelPassword.SelectedColor = System.Drawing.Color.Empty;
            this.buttonCancelPassword.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonCancelPassword.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonCancelPassword.Size = new System.Drawing.Size(140, 30);
            this.buttonCancelPassword.TabIndex = 1;
            this.buttonCancelPassword.Text = "Cancel";
            this.buttonCancelPassword.Click += new System.EventHandler(this.ButtonCancelPassword_Click);
            // 
            // buttonSetPassword
            // 
            this.buttonSetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSetPassword.BorderColor = System.Drawing.Color.Black;
            this.buttonSetPassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSetPassword.DisabledColor = System.Drawing.Color.Empty;
            this.buttonSetPassword.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSetPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetPassword.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSetPassword.Location = new System.Drawing.Point(30, 46);
            this.buttonSetPassword.Name = "buttonSetPassword";
            this.buttonSetPassword.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSetPassword.Selected = false;
            this.buttonSetPassword.SelectedColor = System.Drawing.Color.Empty;
            this.buttonSetPassword.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonSetPassword.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonSetPassword.Size = new System.Drawing.Size(140, 30);
            this.buttonSetPassword.TabIndex = 0;
            this.buttonSetPassword.Text = "Set Password";
            this.buttonSetPassword.Click += new System.EventHandler(this.ButtonSetPassword_Click);
            // 
            // comboSpellcheckLanguages
            // 
            this.comboSpellcheckLanguages.BackColor = System.Drawing.Color.White;
            this.comboSpellcheckLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSpellcheckLanguages.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSpellcheckLanguages.FormattingEnabled = true;
            this.comboSpellcheckLanguages.Location = new System.Drawing.Point(298, 105);
            this.comboSpellcheckLanguages.Name = "comboSpellcheckLanguages";
            this.comboSpellcheckLanguages.Size = new System.Drawing.Size(100, 23);
            this.comboSpellcheckLanguages.TabIndex = 16;
            // 
            // labelSpellChecker
            // 
            this.labelSpellChecker.AutoSize = true;
            this.labelSpellChecker.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpellChecker.Location = new System.Drawing.Point(295, 52);
            this.labelSpellChecker.Name = "labelSpellChecker";
            this.labelSpellChecker.Size = new System.Drawing.Size(94, 19);
            this.labelSpellChecker.TabIndex = 17;
            this.labelSpellChecker.Text = "Spell Checker";
            // 
            // checkBoxEnableSpellCheck
            // 
            this.checkBoxEnableSpellCheck.AutoSize = true;
            this.checkBoxEnableSpellCheck.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEnableSpellCheck.Location = new System.Drawing.Point(298, 79);
            this.checkBoxEnableSpellCheck.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxEnableSpellCheck.Name = "checkBoxEnableSpellCheck";
            this.checkBoxEnableSpellCheck.Size = new System.Drawing.Size(73, 24);
            this.checkBoxEnableSpellCheck.TabIndex = 18;
            this.checkBoxEnableSpellCheck.Text = "Enable";
            this.checkBoxEnableSpellCheck.UseVisualStyleBackColor = true;
            this.checkBoxEnableSpellCheck.Click += new System.EventHandler(this.CheckBoxEnableSpellCheck_Click);
            // 
            // horizontalSeparator3
            // 
            this.horizontalSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(148)))), ((int)(((byte)(144)))));
            this.horizontalSeparator3.Location = new System.Drawing.Point(1, 400);
            this.horizontalSeparator3.Margin = new System.Windows.Forms.Padding(0);
            this.horizontalSeparator3.Name = "horizontalSeparator3";
            this.horizontalSeparator3.Size = new System.Drawing.Size(448, 1);
            this.horizontalSeparator3.TabIndex = 19;
            // 
            // labelUpdates
            // 
            this.labelUpdates.AutoSize = true;
            this.labelUpdates.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpdates.Location = new System.Drawing.Point(10, 413);
            this.labelUpdates.Name = "labelUpdates";
            this.labelUpdates.Size = new System.Drawing.Size(61, 20);
            this.labelUpdates.TabIndex = 20;
            this.labelUpdates.Text = "Updates";
            // 
            // checkBoxAutoUpdate
            // 
            this.checkBoxAutoUpdate.AutoSize = true;
            this.checkBoxAutoUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAutoUpdate.Location = new System.Drawing.Point(30, 446);
            this.checkBoxAutoUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
            this.checkBoxAutoUpdate.Size = new System.Drawing.Size(290, 24);
            this.checkBoxAutoUpdate.TabIndex = 21;
            this.checkBoxAutoUpdate.Text = "Check and install updates automatically";
            this.checkBoxAutoUpdate.UseVisualStyleBackColor = true;
            this.checkBoxAutoUpdate.Click += new System.EventHandler(this.CheckBoxAutoUpdate_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonUpdate.BorderColor = System.Drawing.Color.Black;
            this.buttonUpdate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonUpdate.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(83)))), ((int)(((byte)(89)))));
            this.buttonUpdate.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonUpdate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonUpdate.Location = new System.Drawing.Point(30, 478);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonUpdate.Selected = false;
            this.buttonUpdate.SelectedColor = System.Drawing.Color.Empty;
            this.buttonUpdate.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonUpdate.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonUpdate.Size = new System.Drawing.Size(140, 30);
            this.buttonUpdate.TabIndex = 22;
            this.buttonUpdate.Text = "Check for Update";
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // pictureUpdateIndicator
            // 
            this.pictureUpdateIndicator.BackColor = System.Drawing.Color.Transparent;
            this.pictureUpdateIndicator.Image = global::Journaley.Properties.Resources.settings_updateIndicator;
            this.pictureUpdateIndicator.Location = new System.Drawing.Point(13, 489);
            this.pictureUpdateIndicator.Name = "pictureUpdateIndicator";
            this.pictureUpdateIndicator.Size = new System.Drawing.Size(9, 8);
            this.pictureUpdateIndicator.TabIndex = 23;
            this.pictureUpdateIndicator.TabStop = false;
            this.pictureUpdateIndicator.Visible = false;
            // 
            // horizontalSeparator4
            // 
            this.horizontalSeparator4.BackColor = System.Drawing.Color.Black;
            this.horizontalSeparator4.Location = new System.Drawing.Point(1, 527);
            this.horizontalSeparator4.Margin = new System.Windows.Forms.Padding(0);
            this.horizontalSeparator4.Name = "horizontalSeparator4";
            this.horizontalSeparator4.Size = new System.Drawing.Size(448, 1);
            this.horizontalSeparator4.TabIndex = 20;
            // 
            // labelCurrentVersion
            // 
            this.labelCurrentVersion.AutoSize = true;
            this.labelCurrentVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentVersion.Location = new System.Drawing.Point(184, 483);
            this.labelCurrentVersion.Name = "labelCurrentVersion";
            this.labelCurrentVersion.Size = new System.Drawing.Size(109, 19);
            this.labelCurrentVersion.TabIndex = 24;
            this.labelCurrentVersion.Text = "Current Version:";
            // 
            // linkVersionNumber
            // 
            this.linkVersionNumber.AutoSize = true;
            this.linkVersionNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkVersionNumber.Location = new System.Drawing.Point(288, 483);
            this.linkVersionNumber.Name = "linkVersionNumber";
            this.linkVersionNumber.Size = new System.Drawing.Size(59, 19);
            this.linkVersionNumber.TabIndex = 25;
            this.linkVersionNumber.TabStop = true;
            this.linkVersionNumber.Text = "Develop";
            this.toolTip.SetToolTip(this.linkVersionNumber, "Change Log (Opens Browser)");
            this.linkVersionNumber.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // buttonAbout
            // 
            this.buttonAbout.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonAbout.DownImage = global::Journaley.Properties.Resources.settings_btn_about_up_down;
            this.buttonAbout.HoverImage = global::Journaley.Properties.Resources.settings_btn_about_up_over;
            this.buttonAbout.Image = global::Journaley.Properties.Resources.settings_btn_about_up_norm;
            this.buttonAbout.Location = new System.Drawing.Point(13, 542);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.NormalImage = global::Journaley.Properties.Resources.settings_btn_about_up_norm;
            this.buttonAbout.Selected = false;
            this.buttonAbout.SelectedDownImage = global::Journaley.Properties.Resources.settings_btn_about_down_down;
            this.buttonAbout.SelectedHoverImage = global::Journaley.Properties.Resources.settings_btn_about_down_over;
            this.buttonAbout.SelectedImage = global::Journaley.Properties.Resources.settings_btn_about_down_norm;
            this.buttonAbout.Size = new System.Drawing.Size(121, 30);
            this.buttonAbout.TabIndex = 26;
            this.buttonAbout.TabStop = false;
            this.buttonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);
            this.buttonAbout.DoubleClick += new System.EventHandler(this.ButtonAbout_Click);
            // 
            // panelAbout
            // 
            this.panelAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.panelAbout.Controls.Add(this.linkMITLicense);
            this.panelAbout.Controls.Add(this.labelLicensedUnder);
            this.panelAbout.Controls.Add(this.linkGitHub);
            this.panelAbout.Controls.Add(this.labelFeedback);
            this.panelAbout.Controls.Add(this.labelSupport);
            this.panelAbout.Controls.Add(this.horizontalSeparator6);
            this.panelAbout.Controls.Add(this.linkSquirrelWindowsLicense);
            this.panelAbout.Controls.Add(this.labelSquirrelWindowsAuthor);
            this.panelAbout.Controls.Add(this.labelSquirrelWindowsTitle);
            this.panelAbout.Controls.Add(this.linkMarkdownSharpLicense);
            this.panelAbout.Controls.Add(this.labelMarkdownSharpAuthor3);
            this.panelAbout.Controls.Add(this.labelMarkdownSharpAuthor2);
            this.panelAbout.Controls.Add(this.labelMarkdownSharpAuthor1);
            this.panelAbout.Controls.Add(this.labelMarkdownSharpTitle);
            this.panelAbout.Controls.Add(this.linkAnotherMonthCalendarLicense);
            this.panelAbout.Controls.Add(this.labelAnotherMonthCalendarAuthor);
            this.panelAbout.Controls.Add(this.labelAnotherMonthCalendarTitle);
            this.panelAbout.Controls.Add(this.linkNotoSansLicense);
            this.panelAbout.Controls.Add(this.labelNotoSansAuthor);
            this.panelAbout.Controls.Add(this.labelNotoSansTitle);
            this.panelAbout.Controls.Add(this.labelOpenSourceLicense);
            this.panelAbout.Controls.Add(this.horizontalSeparator5);
            this.panelAbout.Controls.Add(this.linkSammyGuergachi);
            this.panelAbout.Controls.Add(this.labelDesignedBy);
            this.panelAbout.Controls.Add(this.linkYoungSeokYoon);
            this.panelAbout.Controls.Add(this.labelDevelopedBy);
            this.panelAbout.Controls.Add(this.labelCredits);
            this.panelAbout.IgnoreSetCursor = false;
            this.panelAbout.Location = new System.Drawing.Point(0, 20);
            this.panelAbout.Name = "panelAbout";
            this.panelAbout.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.panelAbout.Size = new System.Drawing.Size(450, 527);
            this.panelAbout.TabIndex = 2;
            this.panelAbout.Visible = false;
            // 
            // linkMITLicense
            // 
            this.linkMITLicense.AutoSize = true;
            this.linkMITLicense.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkMITLicense.Location = new System.Drawing.Point(300, 477);
            this.linkMITLicense.Name = "linkMITLicense";
            this.linkMITLicense.Size = new System.Drawing.Size(81, 19);
            this.linkMITLicense.TabIndex = 48;
            this.linkMITLicense.TabStop = true;
            this.linkMITLicense.Text = "MIT License";
            this.linkMITLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // labelLicensedUnder
            // 
            this.labelLicensedUnder.AutoSize = true;
            this.labelLicensedUnder.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLicensedUnder.Location = new System.Drawing.Point(300, 459);
            this.labelLicensedUnder.Name = "labelLicensedUnder";
            this.labelLicensedUnder.Size = new System.Drawing.Size(103, 19);
            this.labelLicensedUnder.TabIndex = 47;
            this.labelLicensedUnder.Text = "Licensed under";
            // 
            // linkGitHub
            // 
            this.linkGitHub.AutoSize = true;
            this.linkGitHub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkGitHub.Location = new System.Drawing.Point(37, 477);
            this.linkGitHub.Name = "linkGitHub";
            this.linkGitHub.Size = new System.Drawing.Size(53, 19);
            this.linkGitHub.TabIndex = 46;
            this.linkGitHub.TabStop = true;
            this.linkGitHub.Text = "GitHub";
            this.linkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // labelFeedback
            // 
            this.labelFeedback.AutoSize = true;
            this.labelFeedback.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeedback.Location = new System.Drawing.Point(37, 459);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(208, 19);
            this.labelFeedback.TabIndex = 45;
            this.labelFeedback.Text = "For feedback, bugs or questions";
            // 
            // labelSupport
            // 
            this.labelSupport.AutoSize = true;
            this.labelSupport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSupport.Location = new System.Drawing.Point(10, 420);
            this.labelSupport.Name = "labelSupport";
            this.labelSupport.Size = new System.Drawing.Size(58, 20);
            this.labelSupport.TabIndex = 44;
            this.labelSupport.Text = "Support";
            // 
            // horizontalSeparator6
            // 
            this.horizontalSeparator6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(148)))), ((int)(((byte)(144)))));
            this.horizontalSeparator6.Location = new System.Drawing.Point(1, 404);
            this.horizontalSeparator6.Margin = new System.Windows.Forms.Padding(0);
            this.horizontalSeparator6.Name = "horizontalSeparator6";
            this.horizontalSeparator6.Size = new System.Drawing.Size(448, 1);
            this.horizontalSeparator6.TabIndex = 22;
            // 
            // linkSquirrelWindowsLicense
            // 
            this.linkSquirrelWindowsLicense.AutoSize = true;
            this.linkSquirrelWindowsLicense.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSquirrelWindowsLicense.Location = new System.Drawing.Point(200, 322);
            this.linkSquirrelWindowsLicense.Name = "linkSquirrelWindowsLicense";
            this.linkSquirrelWindowsLicense.Size = new System.Drawing.Size(53, 19);
            this.linkSquirrelWindowsLicense.TabIndex = 43;
            this.linkSquirrelWindowsLicense.TabStop = true;
            this.linkSquirrelWindowsLicense.Text = "License";
            this.linkSquirrelWindowsLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // labelSquirrelWindowsAuthor
            // 
            this.labelSquirrelWindowsAuthor.AutoSize = true;
            this.labelSquirrelWindowsAuthor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSquirrelWindowsAuthor.Location = new System.Drawing.Point(200, 304);
            this.labelSquirrelWindowsAuthor.Name = "labelSquirrelWindowsAuthor";
            this.labelSquirrelWindowsAuthor.Size = new System.Drawing.Size(198, 19);
            this.labelSquirrelWindowsAuthor.TabIndex = 42;
            this.labelSquirrelWindowsAuthor.Text = "Copyright © 2012 GitHub, Inc.";
            // 
            // labelSquirrelWindowsTitle
            // 
            this.labelSquirrelWindowsTitle.AutoSize = true;
            this.labelSquirrelWindowsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSquirrelWindowsTitle.Location = new System.Drawing.Point(200, 286);
            this.labelSquirrelWindowsTitle.Name = "labelSquirrelWindowsTitle";
            this.labelSquirrelWindowsTitle.Size = new System.Drawing.Size(120, 19);
            this.labelSquirrelWindowsTitle.TabIndex = 41;
            this.labelSquirrelWindowsTitle.Text = "Squirrel.Windows";
            // 
            // linkMarkdownSharpLicense
            // 
            this.linkMarkdownSharpLicense.AutoSize = true;
            this.linkMarkdownSharpLicense.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkMarkdownSharpLicense.Location = new System.Drawing.Point(10, 358);
            this.linkMarkdownSharpLicense.Name = "linkMarkdownSharpLicense";
            this.linkMarkdownSharpLicense.Size = new System.Drawing.Size(81, 19);
            this.linkMarkdownSharpLicense.TabIndex = 40;
            this.linkMarkdownSharpLicense.TabStop = true;
            this.linkMarkdownSharpLicense.Text = "MIT License";
            this.linkMarkdownSharpLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // labelMarkdownSharpAuthor3
            // 
            this.labelMarkdownSharpAuthor3.AutoSize = true;
            this.labelMarkdownSharpAuthor3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarkdownSharpAuthor3.Location = new System.Drawing.Point(10, 340);
            this.labelMarkdownSharpAuthor3.Name = "labelMarkdownSharpAuthor3";
            this.labelMarkdownSharpAuthor3.Size = new System.Drawing.Size(85, 19);
            this.labelMarkdownSharpAuthor3.TabIndex = 39;
            this.labelMarkdownSharpAuthor3.Text = "John Gruber";
            // 
            // labelMarkdownSharpAuthor2
            // 
            this.labelMarkdownSharpAuthor2.AutoSize = true;
            this.labelMarkdownSharpAuthor2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarkdownSharpAuthor2.Location = new System.Drawing.Point(10, 322);
            this.labelMarkdownSharpAuthor2.Name = "labelMarkdownSharpAuthor2";
            this.labelMarkdownSharpAuthor2.Size = new System.Drawing.Size(105, 19);
            this.labelMarkdownSharpAuthor2.TabIndex = 38;
            this.labelMarkdownSharpAuthor2.Text = "Milan Negovan,";
            // 
            // labelMarkdownSharpAuthor1
            // 
            this.labelMarkdownSharpAuthor1.AutoSize = true;
            this.labelMarkdownSharpAuthor1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarkdownSharpAuthor1.Location = new System.Drawing.Point(10, 304);
            this.labelMarkdownSharpAuthor1.Name = "labelMarkdownSharpAuthor1";
            this.labelMarkdownSharpAuthor1.Size = new System.Drawing.Size(84, 19);
            this.labelMarkdownSharpAuthor1.TabIndex = 37;
            this.labelMarkdownSharpAuthor1.Text = "Jeff Atwood,";
            // 
            // labelMarkdownSharpTitle
            // 
            this.labelMarkdownSharpTitle.AutoSize = true;
            this.labelMarkdownSharpTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarkdownSharpTitle.Location = new System.Drawing.Point(10, 286);
            this.labelMarkdownSharpTitle.Name = "labelMarkdownSharpTitle";
            this.labelMarkdownSharpTitle.Size = new System.Drawing.Size(112, 19);
            this.labelMarkdownSharpTitle.TabIndex = 36;
            this.labelMarkdownSharpTitle.Text = "MarkdownSharp";
            // 
            // linkAnotherMonthCalendarLicense
            // 
            this.linkAnotherMonthCalendarLicense.AutoSize = true;
            this.linkAnotherMonthCalendarLicense.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAnotherMonthCalendarLicense.Location = new System.Drawing.Point(200, 250);
            this.linkAnotherMonthCalendarLicense.Name = "linkAnotherMonthCalendarLicense";
            this.linkAnotherMonthCalendarLicense.Size = new System.Drawing.Size(199, 19);
            this.linkAnotherMonthCalendarLicense.TabIndex = 35;
            this.linkAnotherMonthCalendarLicense.TabStop = true;
            this.linkAnotherMonthCalendarLicense.Text = "The Code Project Open License";
            this.linkAnotherMonthCalendarLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // labelAnotherMonthCalendarAuthor
            // 
            this.labelAnotherMonthCalendarAuthor.AutoSize = true;
            this.labelAnotherMonthCalendarAuthor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnotherMonthCalendarAuthor.Location = new System.Drawing.Point(200, 232);
            this.labelAnotherMonthCalendarAuthor.Name = "labelAnotherMonthCalendarAuthor";
            this.labelAnotherMonthCalendarAuthor.Size = new System.Drawing.Size(219, 19);
            this.labelAnotherMonthCalendarAuthor.TabIndex = 34;
            this.labelAnotherMonthCalendarAuthor.Text = "Copyright © 2005, Patrik Bohman";
            // 
            // labelAnotherMonthCalendarTitle
            // 
            this.labelAnotherMonthCalendarTitle.AutoSize = true;
            this.labelAnotherMonthCalendarTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnotherMonthCalendarTitle.Location = new System.Drawing.Point(200, 214);
            this.labelAnotherMonthCalendarTitle.Name = "labelAnotherMonthCalendarTitle";
            this.labelAnotherMonthCalendarTitle.Size = new System.Drawing.Size(164, 19);
            this.labelAnotherMonthCalendarTitle.TabIndex = 33;
            this.labelAnotherMonthCalendarTitle.Text = "Another Month Calendar";
            // 
            // linkNotoSansLicense
            // 
            this.linkNotoSansLicense.AutoSize = true;
            this.linkNotoSansLicense.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkNotoSansLicense.Location = new System.Drawing.Point(10, 250);
            this.linkNotoSansLicense.Name = "linkNotoSansLicense";
            this.linkNotoSansLicense.Size = new System.Drawing.Size(176, 19);
            this.linkNotoSansLicense.TabIndex = 32;
            this.linkNotoSansLicense.TabStop = true;
            this.linkNotoSansLicense.Text = "Apache License, version 2.0";
            this.linkNotoSansLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // labelNotoSansAuthor
            // 
            this.labelNotoSansAuthor.AutoSize = true;
            this.labelNotoSansAuthor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotoSansAuthor.Location = new System.Drawing.Point(10, 232);
            this.labelNotoSansAuthor.Name = "labelNotoSansAuthor";
            this.labelNotoSansAuthor.Size = new System.Drawing.Size(53, 19);
            this.labelNotoSansAuthor.TabIndex = 31;
            this.labelNotoSansAuthor.Text = "Google";
            // 
            // labelNotoSansTitle
            // 
            this.labelNotoSansTitle.AutoSize = true;
            this.labelNotoSansTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotoSansTitle.Location = new System.Drawing.Point(10, 214);
            this.labelNotoSansTitle.Name = "labelNotoSansTitle";
            this.labelNotoSansTitle.Size = new System.Drawing.Size(106, 19);
            this.labelNotoSansTitle.TabIndex = 30;
            this.labelNotoSansTitle.Text = "Noto Sans Font";
            // 
            // labelOpenSourceLicense
            // 
            this.labelOpenSourceLicense.AutoSize = true;
            this.labelOpenSourceLicense.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpenSourceLicense.Location = new System.Drawing.Point(10, 173);
            this.labelOpenSourceLicense.Name = "labelOpenSourceLicense";
            this.labelOpenSourceLicense.Size = new System.Drawing.Size(145, 20);
            this.labelOpenSourceLicense.TabIndex = 29;
            this.labelOpenSourceLicense.Text = "Open Source Licenses";
            // 
            // horizontalSeparator5
            // 
            this.horizontalSeparator5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(148)))), ((int)(((byte)(144)))));
            this.horizontalSeparator5.Location = new System.Drawing.Point(1, 154);
            this.horizontalSeparator5.Margin = new System.Windows.Forms.Padding(0);
            this.horizontalSeparator5.Name = "horizontalSeparator5";
            this.horizontalSeparator5.Size = new System.Drawing.Size(448, 1);
            this.horizontalSeparator5.TabIndex = 21;
            // 
            // linkSammyGuergachi
            // 
            this.linkSammyGuergachi.AutoSize = true;
            this.linkSammyGuergachi.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSammyGuergachi.Location = new System.Drawing.Point(212, 88);
            this.linkSammyGuergachi.Name = "linkSammyGuergachi";
            this.linkSammyGuergachi.Size = new System.Drawing.Size(129, 20);
            this.linkSammyGuergachi.TabIndex = 28;
            this.linkSammyGuergachi.TabStop = true;
            this.linkSammyGuergachi.Text = "Sammy Guergachi";
            this.linkSammyGuergachi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // labelDesignedBy
            // 
            this.labelDesignedBy.AutoSize = true;
            this.labelDesignedBy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesignedBy.Location = new System.Drawing.Point(116, 89);
            this.labelDesignedBy.Name = "labelDesignedBy";
            this.labelDesignedBy.Size = new System.Drawing.Size(86, 19);
            this.labelDesignedBy.TabIndex = 27;
            this.labelDesignedBy.Text = "Designed by";
            // 
            // linkYoungSeokYoon
            // 
            this.linkYoungSeokYoon.AutoSize = true;
            this.linkYoungSeokYoon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkYoungSeokYoon.Location = new System.Drawing.Point(212, 56);
            this.linkYoungSeokYoon.Name = "linkYoungSeokYoon";
            this.linkYoungSeokYoon.Size = new System.Drawing.Size(121, 20);
            this.linkYoungSeokYoon.TabIndex = 26;
            this.linkYoungSeokYoon.TabStop = true;
            this.linkYoungSeokYoon.Text = "YoungSeok Yoon";
            this.linkYoungSeokYoon.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // labelDevelopedBy
            // 
            this.labelDevelopedBy.AutoSize = true;
            this.labelDevelopedBy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDevelopedBy.Location = new System.Drawing.Point(108, 57);
            this.labelDevelopedBy.Name = "labelDevelopedBy";
            this.labelDevelopedBy.Size = new System.Drawing.Size(94, 19);
            this.labelDevelopedBy.TabIndex = 25;
            this.labelDevelopedBy.Text = "Developed by";
            // 
            // labelCredits
            // 
            this.labelCredits.AutoSize = true;
            this.labelCredits.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCredits.Location = new System.Drawing.Point(10, 15);
            this.labelCredits.Name = "labelCredits";
            this.labelCredits.Size = new System.Drawing.Size(54, 20);
            this.labelCredits.TabIndex = 24;
            this.labelCredits.Text = "Credits";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(450, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panelAbout);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SettingsForm";
            this.RealClientSize = new System.Drawing.Size(448, 578);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.Controls.SetChildIndex(this.panelTitlebar, 0);
            this.Controls.SetChildIndex(this.panelAbout, 0);
            this.Controls.SetChildIndex(this.panelContent, 0);
            this.panelTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSelectFolder)).EndInit();
            this.panelPasswordNormal.ResumeLayout(false);
            this.panelPasswordNormal.PerformLayout();
            this.panelPasswordSetting.ResumeLayout(false);
            this.panelPasswordSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUpdateIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAbout)).EndInit();
            this.panelAbout.ResumeLayout(false);
            this.panelAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Panel panelPasswordNormal;
        private System.Windows.Forms.Panel panelPasswordSetting;
        private System.Windows.Forms.CheckBox checkBoxEnablePassword;
        private Controls.ColorButton buttonCancelPassword;
        private Controls.ColorButton buttonSetPassword;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label labelPasswordConfirm;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label borderPassword;
        private System.Windows.Forms.Label borderPasswordConfirm;
        private System.Windows.Forms.Label paddingTextPassword;
        private System.Windows.Forms.Label paddingPasswordConfirm;
        private Controls.EnterTextBox textPasswordConfirm;
        private System.Windows.Forms.ComboBox comboSpellcheckLanguages;
        private System.Windows.Forms.Label labelSpellChecker;
        private System.Windows.Forms.CheckBox checkBoxEnableSpellCheck;
        private System.Windows.Forms.Label labelUpdates;
        private System.Windows.Forms.Panel horizontalSeparator3;
        private System.Windows.Forms.CheckBox checkBoxAutoUpdate;
        private Controls.ColorButton buttonUpdate;
        private System.Windows.Forms.PictureBox pictureUpdateIndicator;
        private System.Windows.Forms.Panel horizontalSeparator4;
        private System.Windows.Forms.Label labelCurrentVersion;
        private System.Windows.Forms.LinkLabel linkVersionNumber;
        private Controls.ImageButton buttonAbout;
        private Controls.PaddingBorderPanel panelAbout;
        private System.Windows.Forms.Panel horizontalSeparator5;
        private System.Windows.Forms.Panel horizontalSeparator6;
        private System.Windows.Forms.Label labelCredits;
        private System.Windows.Forms.LinkLabel linkYoungSeokYoon;
        private System.Windows.Forms.Label labelDevelopedBy;
        private System.Windows.Forms.Label labelDesignedBy;
        private System.Windows.Forms.LinkLabel linkSammyGuergachi;
        private System.Windows.Forms.Label labelOpenSourceLicense;
        private System.Windows.Forms.Label labelNotoSansTitle;
        private System.Windows.Forms.LinkLabel linkNotoSansLicense;
        private System.Windows.Forms.Label labelNotoSansAuthor;
        private System.Windows.Forms.Label labelAnotherMonthCalendarAuthor;
        private System.Windows.Forms.Label labelAnotherMonthCalendarTitle;
        private System.Windows.Forms.LinkLabel linkAnotherMonthCalendarLicense;
        private System.Windows.Forms.Label labelMarkdownSharpTitle;
        private System.Windows.Forms.Label labelMarkdownSharpAuthor1;
        private System.Windows.Forms.Label labelMarkdownSharpAuthor2;
        private System.Windows.Forms.Label labelMarkdownSharpAuthor3;
        private System.Windows.Forms.LinkLabel linkMarkdownSharpLicense;
        private System.Windows.Forms.Label labelSquirrelWindowsTitle;
        private System.Windows.Forms.Label labelSquirrelWindowsAuthor;
        private System.Windows.Forms.LinkLabel linkSquirrelWindowsLicense;
        private System.Windows.Forms.Label labelSupport;
        private System.Windows.Forms.Label labelFeedback;
        private System.Windows.Forms.LinkLabel linkGitHub;
        private System.Windows.Forms.Label labelLicensedUnder;
        private System.Windows.Forms.LinkLabel linkMITLicense;
        private System.Windows.Forms.ToolTip toolTip;
    }
}