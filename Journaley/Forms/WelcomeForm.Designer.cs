namespace Journaley.Forms
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.horizontalSeparator = new System.Windows.Forms.Panel();
            this.labelMainMessage = new System.Windows.Forms.Label();
            this.bottomPanel1Init = new Journaley.Controls.BorderPanel();
            this.buttonStartNewJournal = new Journaley.Controls.ColorButton();
            this.buttonImportJournal = new Journaley.Controls.ColorButton();
            this.labelPanel1Message = new System.Windows.Forms.Label();
            this.bottomPanel2StartNewJournal = new Journaley.Controls.BorderPanel();
            this.buttonDropboxJournaley = new Journaley.Controls.ImageButton();
            this.buttonPanel2Browse = new Journaley.Controls.ImageButton();
            this.labelPanel2Message = new System.Windows.Forms.Label();
            this.bottomPanel3LocationSelected = new Journaley.Controls.BorderPanel();
            this.buttonLaunchJournaley = new Journaley.Controls.ColorButton();
            this.buttonSetupPassword = new Journaley.Controls.ColorButton();
            this.labelJournalLocation = new System.Windows.Forms.Label();
            this.labelJournalLocationBorder = new System.Windows.Forms.Label();
            this.labelPanel3Message = new System.Windows.Forms.Label();
            this.bottomPanel4PasswordSetting = new Journaley.Controls.BorderPanel();
            this.buttonSavePassword = new Journaley.Controls.ColorButton();
            this.textPasswordConfirm = new System.Windows.Forms.TextBox();
            this.paddingPasswordConfirm = new System.Windows.Forms.Label();
            this.borderPasswordConfirm = new System.Windows.Forms.Label();
            this.labelPasswordConfirm = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.paddingTextPassword = new System.Windows.Forms.Label();
            this.borderPassword = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.bottomPanel5ImportJournal = new Journaley.Controls.BorderPanel();
            this.buttonDropboxDayOne = new Journaley.Controls.ImageButton();
            this.buttonPanel5Browse = new Journaley.Controls.ImageButton();
            this.labelPanel5Message = new System.Windows.Forms.Label();
            this.bottomPanel6Complete = new Journaley.Controls.BorderPanel();
            this.buttonOK = new Journaley.Controls.ColorButton();
            this.labelPanel6Message = new System.Windows.Forms.Label();
            this.panelTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.bottomPanel1Init.SuspendLayout();
            this.bottomPanel2StartNewJournal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDropboxJournaley)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPanel2Browse)).BeginInit();
            this.bottomPanel3LocationSelected.SuspendLayout();
            this.bottomPanel4PasswordSetting.SuspendLayout();
            this.bottomPanel5ImportJournal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDropboxDayOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPanel5Browse)).BeginInit();
            this.bottomPanel6Complete.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitlebar
            // 
            this.panelTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.panelTitlebar.Size = new System.Drawing.Size(450, 21);
            // 
            // imageButtonFormClose
            // 
            this.imageButtonFormClose.DownImage = global::Journaley.Properties.Resources.welcome_btn_close_down;
            this.imageButtonFormClose.HoverImage = global::Journaley.Properties.Resources.welcome_btn_close_over;
            this.imageButtonFormClose.Image = global::Journaley.Properties.Resources.welcome_btn_close_norm;
            this.imageButtonFormClose.Location = new System.Drawing.Point(403, 0);
            this.imageButtonFormClose.NormalImage = global::Journaley.Properties.Resources.welcome_btn_close_norm;
            this.imageButtonFormClose.Size = new System.Drawing.Size(47, 21);
            // 
            // imageButtonFormMinimize
            // 
            this.imageButtonFormMinimize.DownImage = global::Journaley.Properties.Resources.welcome_btn_minimize_down;
            this.imageButtonFormMinimize.HoverImage = global::Journaley.Properties.Resources.welcome_btn_minimize_over;
            this.imageButtonFormMinimize.Image = global::Journaley.Properties.Resources.welcome_btn_minimize_norm;
            this.imageButtonFormMinimize.Location = new System.Drawing.Point(311, 0);
            this.imageButtonFormMinimize.NormalImage = global::Journaley.Properties.Resources.welcome_btn_minimize_norm;
            this.imageButtonFormMinimize.Size = new System.Drawing.Size(46, 21);
            // 
            // imageButtonFormMaximize
            // 
            this.imageButtonFormMaximize.Location = new System.Drawing.Point(357, 0);
            this.imageButtonFormMaximize.Size = new System.Drawing.Size(46, 21);
            this.imageButtonFormMaximize.Visible = false;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.bottomPanel1Init);
            this.panelContent.Controls.Add(this.bottomPanel2StartNewJournal);
            this.panelContent.Controls.Add(this.bottomPanel3LocationSelected);
            this.panelContent.Controls.Add(this.bottomPanel4PasswordSetting);
            this.panelContent.Controls.Add(this.bottomPanel5ImportJournal);
            this.panelContent.Controls.Add(this.bottomPanel6Complete);
            this.panelContent.Controls.Add(this.labelMainMessage);
            this.panelContent.Controls.Add(this.horizontalSeparator);
            this.panelContent.Controls.Add(this.pictureBoxLogo);
            this.panelContent.ForeColor = System.Drawing.Color.Black;
            this.panelContent.Location = new System.Drawing.Point(0, 21);
            this.panelContent.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.panelContent.Size = new System.Drawing.Size(450, 579);
            // 
            // pictureBoxFormIcon
            // 
            this.pictureBoxFormIcon.Visible = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Image = global::Journaley.Properties.Resources.welcome_journaley;
            this.pictureBoxLogo.Location = new System.Drawing.Point(86, 9);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(278, 212);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // horizontalSeparator
            // 
            this.horizontalSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(148)))), ((int)(((byte)(144)))));
            this.horizontalSeparator.Location = new System.Drawing.Point(1, 240);
            this.horizontalSeparator.Name = "horizontalSeparator";
            this.horizontalSeparator.Size = new System.Drawing.Size(448, 1);
            this.horizontalSeparator.TabIndex = 1;
            // 
            // labelMainMessage
            // 
            this.labelMainMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMainMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(249)))));
            this.labelMainMessage.Location = new System.Drawing.Point(10, 295);
            this.labelMainMessage.Name = "labelMainMessage";
            this.labelMainMessage.Size = new System.Drawing.Size(430, 30);
            this.labelMainMessage.TabIndex = 2;
            this.labelMainMessage.Text = "Good evening.";
            this.labelMainMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bottomPanel1Init
            // 
            this.bottomPanel1Init.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel1Init.BorderWidth = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.bottomPanel1Init.Controls.Add(this.buttonStartNewJournal);
            this.bottomPanel1Init.Controls.Add(this.buttonImportJournal);
            this.bottomPanel1Init.Controls.Add(this.labelPanel1Message);
            this.bottomPanel1Init.IgnoreSetCursor = false;
            this.bottomPanel1Init.Location = new System.Drawing.Point(0, 330);
            this.bottomPanel1Init.Name = "bottomPanel1Init";
            this.bottomPanel1Init.Size = new System.Drawing.Size(450, 249);
            this.bottomPanel1Init.TabIndex = 3;
            // 
            // buttonStartNewJournal
            // 
            this.buttonStartNewJournal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonStartNewJournal.BorderColor = System.Drawing.Color.Black;
            this.buttonStartNewJournal.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonStartNewJournal.DisabledColor = System.Drawing.Color.Empty;
            this.buttonStartNewJournal.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonStartNewJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartNewJournal.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonStartNewJournal.Location = new System.Drawing.Point(95, 180);
            this.buttonStartNewJournal.Name = "buttonStartNewJournal";
            this.buttonStartNewJournal.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonStartNewJournal.Selected = false;
            this.buttonStartNewJournal.SelectedColor = System.Drawing.Color.Empty;
            this.buttonStartNewJournal.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonStartNewJournal.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonStartNewJournal.Size = new System.Drawing.Size(260, 42);
            this.buttonStartNewJournal.TabIndex = 2;
            this.buttonStartNewJournal.Text = "Start a New Journal";
            this.buttonStartNewJournal.Click += new System.EventHandler(this.ButtonStartNewJournal_Click);
            // 
            // buttonImportJournal
            // 
            this.buttonImportJournal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.buttonImportJournal.BorderColor = System.Drawing.Color.Black;
            this.buttonImportJournal.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonImportJournal.DisabledColor = System.Drawing.Color.Empty;
            this.buttonImportJournal.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonImportJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImportJournal.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonImportJournal.Location = new System.Drawing.Point(95, 120);
            this.buttonImportJournal.Name = "buttonImportJournal";
            this.buttonImportJournal.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.buttonImportJournal.Selected = false;
            this.buttonImportJournal.SelectedColor = System.Drawing.Color.Empty;
            this.buttonImportJournal.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonImportJournal.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonImportJournal.Size = new System.Drawing.Size(260, 42);
            this.buttonImportJournal.TabIndex = 1;
            this.buttonImportJournal.Text = "Import Your Journal";
            this.buttonImportJournal.Click += new System.EventHandler(this.ButtonImportJournal_Click);
            // 
            // labelPanel1Message
            // 
            this.labelPanel1Message.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanel1Message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.labelPanel1Message.Location = new System.Drawing.Point(95, 28);
            this.labelPanel1Message.Name = "labelPanel1Message";
            this.labelPanel1Message.Size = new System.Drawing.Size(260, 50);
            this.labelPanel1Message.TabIndex = 0;
            this.labelPanel1Message.Text = "Do you have a\nJournaley or Day One journal?";
            this.labelPanel1Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bottomPanel2StartNewJournal
            // 
            this.bottomPanel2StartNewJournal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel2StartNewJournal.BorderWidth = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.bottomPanel2StartNewJournal.Controls.Add(this.buttonDropboxJournaley);
            this.bottomPanel2StartNewJournal.Controls.Add(this.buttonPanel2Browse);
            this.bottomPanel2StartNewJournal.Controls.Add(this.labelPanel2Message);
            this.bottomPanel2StartNewJournal.IgnoreSetCursor = false;
            this.bottomPanel2StartNewJournal.Location = new System.Drawing.Point(0, 330);
            this.bottomPanel2StartNewJournal.Name = "bottomPanel2StartNewJournal";
            this.bottomPanel2StartNewJournal.Size = new System.Drawing.Size(450, 249);
            this.bottomPanel2StartNewJournal.TabIndex = 4;
            // 
            // buttonDropboxJournaley
            // 
            this.buttonDropboxJournaley.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonDropboxJournaley.DownImage = global::Journaley.Properties.Resources.welcome_btn_dropboxJournaley_down;
            this.buttonDropboxJournaley.HoverImage = global::Journaley.Properties.Resources.welcome_btn_dropboxJournaley_over;
            this.buttonDropboxJournaley.Image = global::Journaley.Properties.Resources.welcome_btn_dropboxJournaley_norm;
            this.buttonDropboxJournaley.Location = new System.Drawing.Point(95, 180);
            this.buttonDropboxJournaley.Name = "buttonDropboxJournaley";
            this.buttonDropboxJournaley.NormalImage = global::Journaley.Properties.Resources.welcome_btn_dropboxJournaley_norm;
            this.buttonDropboxJournaley.Selected = false;
            this.buttonDropboxJournaley.SelectedDownImage = null;
            this.buttonDropboxJournaley.SelectedHoverImage = null;
            this.buttonDropboxJournaley.SelectedImage = null;
            this.buttonDropboxJournaley.Size = new System.Drawing.Size(260, 42);
            this.buttonDropboxJournaley.TabIndex = 3;
            this.buttonDropboxJournaley.TabStop = false;
            this.buttonDropboxJournaley.Click += new System.EventHandler(this.ButtonDropboxJournaley_Click);
            // 
            // buttonPanel2Browse
            // 
            this.buttonPanel2Browse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonPanel2Browse.DownImage = global::Journaley.Properties.Resources.welcome_btn_browse_down;
            this.buttonPanel2Browse.HoverImage = global::Journaley.Properties.Resources.welcome_btn_browse_over;
            this.buttonPanel2Browse.Image = global::Journaley.Properties.Resources.welcome_btn_browse_norm;
            this.buttonPanel2Browse.Location = new System.Drawing.Point(95, 120);
            this.buttonPanel2Browse.Name = "buttonPanel2Browse";
            this.buttonPanel2Browse.NormalImage = global::Journaley.Properties.Resources.welcome_btn_browse_norm;
            this.buttonPanel2Browse.Selected = false;
            this.buttonPanel2Browse.SelectedDownImage = null;
            this.buttonPanel2Browse.SelectedHoverImage = null;
            this.buttonPanel2Browse.SelectedImage = null;
            this.buttonPanel2Browse.Size = new System.Drawing.Size(260, 42);
            this.buttonPanel2Browse.TabIndex = 2;
            this.buttonPanel2Browse.TabStop = false;
            this.buttonPanel2Browse.Click += new System.EventHandler(this.ButtonPanel2Browse_Click);
            // 
            // labelPanel2Message
            // 
            this.labelPanel2Message.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanel2Message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.labelPanel2Message.Location = new System.Drawing.Point(95, 28);
            this.labelPanel2Message.Name = "labelPanel2Message";
            this.labelPanel2Message.Size = new System.Drawing.Size(260, 50);
            this.labelPanel2Message.TabIndex = 1;
            this.labelPanel2Message.Text = "Where would you like to save\nyour journal?";
            this.labelPanel2Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bottomPanel3LocationSelected
            // 
            this.bottomPanel3LocationSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel3LocationSelected.BorderWidth = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.bottomPanel3LocationSelected.Controls.Add(this.buttonLaunchJournaley);
            this.bottomPanel3LocationSelected.Controls.Add(this.buttonSetupPassword);
            this.bottomPanel3LocationSelected.Controls.Add(this.labelJournalLocation);
            this.bottomPanel3LocationSelected.Controls.Add(this.labelJournalLocationBorder);
            this.bottomPanel3LocationSelected.Controls.Add(this.labelPanel3Message);
            this.bottomPanel3LocationSelected.IgnoreSetCursor = false;
            this.bottomPanel3LocationSelected.Location = new System.Drawing.Point(0, 330);
            this.bottomPanel3LocationSelected.Name = "bottomPanel3LocationSelected";
            this.bottomPanel3LocationSelected.Size = new System.Drawing.Size(450, 249);
            this.bottomPanel3LocationSelected.TabIndex = 5;
            this.bottomPanel3LocationSelected.VisibleChanged += new System.EventHandler(this.BottomPanel3LocationSelected_VisibleChanged);
            // 
            // buttonLaunchJournaley
            // 
            this.buttonLaunchJournaley.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonLaunchJournaley.BorderColor = System.Drawing.Color.Black;
            this.buttonLaunchJournaley.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonLaunchJournaley.DisabledColor = System.Drawing.Color.Empty;
            this.buttonLaunchJournaley.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonLaunchJournaley.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLaunchJournaley.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonLaunchJournaley.Location = new System.Drawing.Point(95, 180);
            this.buttonLaunchJournaley.Name = "buttonLaunchJournaley";
            this.buttonLaunchJournaley.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonLaunchJournaley.Selected = false;
            this.buttonLaunchJournaley.SelectedColor = System.Drawing.Color.Empty;
            this.buttonLaunchJournaley.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonLaunchJournaley.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonLaunchJournaley.Size = new System.Drawing.Size(260, 42);
            this.buttonLaunchJournaley.TabIndex = 4;
            this.buttonLaunchJournaley.Text = "Launch Journaley";
            this.buttonLaunchJournaley.Click += new System.EventHandler(this.ButtonLaunchJournaley_Click);
            // 
            // buttonSetupPassword
            // 
            this.buttonSetupPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.buttonSetupPassword.BorderColor = System.Drawing.Color.Black;
            this.buttonSetupPassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSetupPassword.DisabledColor = System.Drawing.Color.Empty;
            this.buttonSetupPassword.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSetupPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetupPassword.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSetupPassword.Location = new System.Drawing.Point(95, 120);
            this.buttonSetupPassword.Name = "buttonSetupPassword";
            this.buttonSetupPassword.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.buttonSetupPassword.Selected = false;
            this.buttonSetupPassword.SelectedColor = System.Drawing.Color.Empty;
            this.buttonSetupPassword.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonSetupPassword.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonSetupPassword.Size = new System.Drawing.Size(260, 42);
            this.buttonSetupPassword.TabIndex = 3;
            this.buttonSetupPassword.Text = "Setup a Password";
            this.buttonSetupPassword.Click += new System.EventHandler(this.ButtonSetupPassword_Click);
            // 
            // labelJournalLocation
            // 
            this.labelJournalLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.labelJournalLocation.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.labelJournalLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.labelJournalLocation.Location = new System.Drawing.Point(1, 73);
            this.labelJournalLocation.Name = "labelJournalLocation";
            this.labelJournalLocation.Size = new System.Drawing.Size(448, 31);
            this.labelJournalLocation.TabIndex = 6;
            this.labelJournalLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelJournalLocationBorder
            // 
            this.labelJournalLocationBorder.BackColor = System.Drawing.Color.Black;
            this.labelJournalLocationBorder.Location = new System.Drawing.Point(1, 72);
            this.labelJournalLocationBorder.Name = "labelJournalLocationBorder";
            this.labelJournalLocationBorder.Size = new System.Drawing.Size(448, 33);
            this.labelJournalLocationBorder.TabIndex = 5;
            // 
            // labelPanel3Message
            // 
            this.labelPanel3Message.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanel3Message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.labelPanel3Message.Location = new System.Drawing.Point(95, 9);
            this.labelPanel3Message.Name = "labelPanel3Message";
            this.labelPanel3Message.Size = new System.Drawing.Size(260, 50);
            this.labelPanel3Message.TabIndex = 1;
            this.labelPanel3Message.Text = "Your journal entries will be\nsafely located here:";
            this.labelPanel3Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bottomPanel4PasswordSetting
            // 
            this.bottomPanel4PasswordSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel4PasswordSetting.BorderWidth = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.bottomPanel4PasswordSetting.Controls.Add(this.buttonSavePassword);
            this.bottomPanel4PasswordSetting.Controls.Add(this.textPasswordConfirm);
            this.bottomPanel4PasswordSetting.Controls.Add(this.paddingPasswordConfirm);
            this.bottomPanel4PasswordSetting.Controls.Add(this.borderPasswordConfirm);
            this.bottomPanel4PasswordSetting.Controls.Add(this.labelPasswordConfirm);
            this.bottomPanel4PasswordSetting.Controls.Add(this.textPassword);
            this.bottomPanel4PasswordSetting.Controls.Add(this.paddingTextPassword);
            this.bottomPanel4PasswordSetting.Controls.Add(this.borderPassword);
            this.bottomPanel4PasswordSetting.Controls.Add(this.labelPassword);
            this.bottomPanel4PasswordSetting.IgnoreSetCursor = false;
            this.bottomPanel4PasswordSetting.Location = new System.Drawing.Point(0, 330);
            this.bottomPanel4PasswordSetting.Name = "bottomPanel4PasswordSetting";
            this.bottomPanel4PasswordSetting.Size = new System.Drawing.Size(450, 249);
            this.bottomPanel4PasswordSetting.TabIndex = 6;
            // 
            // buttonSavePassword
            // 
            this.buttonSavePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSavePassword.BorderColor = System.Drawing.Color.Black;
            this.buttonSavePassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSavePassword.DisabledColor = System.Drawing.Color.Empty;
            this.buttonSavePassword.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonSavePassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSavePassword.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonSavePassword.Location = new System.Drawing.Point(95, 180);
            this.buttonSavePassword.Name = "buttonSavePassword";
            this.buttonSavePassword.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonSavePassword.Selected = false;
            this.buttonSavePassword.SelectedColor = System.Drawing.Color.Empty;
            this.buttonSavePassword.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonSavePassword.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonSavePassword.Size = new System.Drawing.Size(260, 42);
            this.buttonSavePassword.TabIndex = 25;
            this.buttonSavePassword.Text = "Save Password";
            this.buttonSavePassword.Click += new System.EventHandler(this.ButtonSavePassword_Click);
            // 
            // textPasswordConfirm
            // 
            this.textPasswordConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.textPasswordConfirm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPasswordConfirm.Font = new System.Drawing.Font("Segoe UI", 18.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.textPasswordConfirm.Location = new System.Drawing.Point(98, 107);
            this.textPasswordConfirm.Name = "textPasswordConfirm";
            this.textPasswordConfirm.Size = new System.Drawing.Size(254, 25);
            this.textPasswordConfirm.TabIndex = 18;
            this.textPasswordConfirm.UseSystemPasswordChar = true;
            this.textPasswordConfirm.TextChanged += new System.EventHandler(this.TextPasswordConfirm_TextChanged);
            // 
            // paddingPasswordConfirm
            // 
            this.paddingPasswordConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.paddingPasswordConfirm.Location = new System.Drawing.Point(96, 105);
            this.paddingPasswordConfirm.Name = "paddingPasswordConfirm";
            this.paddingPasswordConfirm.Size = new System.Drawing.Size(258, 29);
            this.paddingPasswordConfirm.TabIndex = 24;
            // 
            // borderPasswordConfirm
            // 
            this.borderPasswordConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.borderPasswordConfirm.Location = new System.Drawing.Point(95, 104);
            this.borderPasswordConfirm.Name = "borderPasswordConfirm";
            this.borderPasswordConfirm.Size = new System.Drawing.Size(260, 31);
            this.borderPasswordConfirm.TabIndex = 22;
            // 
            // labelPasswordConfirm
            // 
            this.labelPasswordConfirm.AutoSize = true;
            this.labelPasswordConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordConfirm.Location = new System.Drawing.Point(91, 84);
            this.labelPasswordConfirm.Name = "labelPasswordConfirm";
            this.labelPasswordConfirm.Size = new System.Drawing.Size(52, 19);
            this.labelPasswordConfirm.TabIndex = 20;
            this.labelPasswordConfirm.Text = "Retype";
            // 
            // textPassword
            // 
            this.textPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.textPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPassword.Font = new System.Drawing.Font("Segoe UI", 18.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.textPassword.Location = new System.Drawing.Point(98, 47);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(254, 25);
            this.textPassword.TabIndex = 17;
            this.textPassword.UseSystemPasswordChar = true;
            this.textPassword.TextChanged += new System.EventHandler(this.TextPassword_TextChanged);
            // 
            // paddingTextPassword
            // 
            this.paddingTextPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.paddingTextPassword.Location = new System.Drawing.Point(96, 45);
            this.paddingTextPassword.Name = "paddingTextPassword";
            this.paddingTextPassword.Size = new System.Drawing.Size(258, 29);
            this.paddingTextPassword.TabIndex = 23;
            // 
            // borderPassword
            // 
            this.borderPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.borderPassword.Location = new System.Drawing.Point(95, 44);
            this.borderPassword.Name = "borderPassword";
            this.borderPassword.Size = new System.Drawing.Size(260, 31);
            this.borderPassword.TabIndex = 21;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(91, 24);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(68, 19);
            this.labelPassword.TabIndex = 19;
            this.labelPassword.Text = "Password";
            // 
            // bottomPanel5ImportJournal
            // 
            this.bottomPanel5ImportJournal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel5ImportJournal.BorderWidth = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.bottomPanel5ImportJournal.Controls.Add(this.buttonDropboxDayOne);
            this.bottomPanel5ImportJournal.Controls.Add(this.buttonPanel5Browse);
            this.bottomPanel5ImportJournal.Controls.Add(this.labelPanel5Message);
            this.bottomPanel5ImportJournal.IgnoreSetCursor = false;
            this.bottomPanel5ImportJournal.Location = new System.Drawing.Point(0, 330);
            this.bottomPanel5ImportJournal.Name = "bottomPanel5ImportJournal";
            this.bottomPanel5ImportJournal.Size = new System.Drawing.Size(450, 249);
            this.bottomPanel5ImportJournal.TabIndex = 7;
            // 
            // buttonDropboxDayOne
            // 
            this.buttonDropboxDayOne.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonDropboxDayOne.DownImage = global::Journaley.Properties.Resources.welcome_btn_dropboxDayOne_down;
            this.buttonDropboxDayOne.HoverImage = global::Journaley.Properties.Resources.welcome_btn_dropboxDayOne_over;
            this.buttonDropboxDayOne.Image = global::Journaley.Properties.Resources.welcome_btn_dropboxDayOne_norm;
            this.buttonDropboxDayOne.Location = new System.Drawing.Point(95, 180);
            this.buttonDropboxDayOne.Name = "buttonDropboxDayOne";
            this.buttonDropboxDayOne.NormalImage = global::Journaley.Properties.Resources.welcome_btn_dropboxDayOne_norm;
            this.buttonDropboxDayOne.Selected = false;
            this.buttonDropboxDayOne.SelectedDownImage = null;
            this.buttonDropboxDayOne.SelectedHoverImage = null;
            this.buttonDropboxDayOne.SelectedImage = null;
            this.buttonDropboxDayOne.Size = new System.Drawing.Size(260, 42);
            this.buttonDropboxDayOne.TabIndex = 6;
            this.buttonDropboxDayOne.TabStop = false;
            this.buttonDropboxDayOne.Click += new System.EventHandler(this.ButtonDropboxDayOne_Click);
            // 
            // buttonPanel5Browse
            // 
            this.buttonPanel5Browse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonPanel5Browse.DownImage = global::Journaley.Properties.Resources.welcome_btn_browse_down;
            this.buttonPanel5Browse.HoverImage = global::Journaley.Properties.Resources.welcome_btn_browse_over;
            this.buttonPanel5Browse.Image = global::Journaley.Properties.Resources.welcome_btn_browse_norm;
            this.buttonPanel5Browse.Location = new System.Drawing.Point(95, 120);
            this.buttonPanel5Browse.Name = "buttonPanel5Browse";
            this.buttonPanel5Browse.NormalImage = global::Journaley.Properties.Resources.welcome_btn_browse_norm;
            this.buttonPanel5Browse.Selected = false;
            this.buttonPanel5Browse.SelectedDownImage = null;
            this.buttonPanel5Browse.SelectedHoverImage = null;
            this.buttonPanel5Browse.SelectedImage = null;
            this.buttonPanel5Browse.Size = new System.Drawing.Size(260, 42);
            this.buttonPanel5Browse.TabIndex = 5;
            this.buttonPanel5Browse.TabStop = false;
            this.buttonPanel5Browse.Click += new System.EventHandler(this.ButtonPanel5Browse_Click);
            // 
            // labelPanel5Message
            // 
            this.labelPanel5Message.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanel5Message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.labelPanel5Message.Location = new System.Drawing.Point(95, 27);
            this.labelPanel5Message.Name = "labelPanel5Message";
            this.labelPanel5Message.Size = new System.Drawing.Size(260, 50);
            this.labelPanel5Message.TabIndex = 4;
            this.labelPanel5Message.Text = "Where is your journal?";
            this.labelPanel5Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bottomPanel6Complete
            // 
            this.bottomPanel6Complete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel6Complete.BorderWidth = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.bottomPanel6Complete.Controls.Add(this.buttonOK);
            this.bottomPanel6Complete.Controls.Add(this.labelPanel6Message);
            this.bottomPanel6Complete.IgnoreSetCursor = false;
            this.bottomPanel6Complete.Location = new System.Drawing.Point(0, 330);
            this.bottomPanel6Complete.Name = "bottomPanel6Complete";
            this.bottomPanel6Complete.Size = new System.Drawing.Size(450, 249);
            this.bottomPanel6Complete.TabIndex = 8;
            this.bottomPanel6Complete.VisibleChanged += new System.EventHandler(this.BottomPanel6Complete_VisibleChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonOK.BorderColor = System.Drawing.Color.Black;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonOK.DisabledColor = System.Drawing.Color.Empty;
            this.buttonOK.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonOK.Location = new System.Drawing.Point(95, 180);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonOK.Selected = false;
            this.buttonOK.SelectedColor = System.Drawing.Color.Empty;
            this.buttonOK.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonOK.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonOK.Size = new System.Drawing.Size(260, 42);
            this.buttonOK.TabIndex = 26;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // labelPanel6Message
            // 
            this.labelPanel6Message.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanel6Message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.labelPanel6Message.Location = new System.Drawing.Point(95, 27);
            this.labelPanel6Message.Name = "labelPanel6Message";
            this.labelPanel6Message.Size = new System.Drawing.Size(260, 75);
            this.labelPanel6Message.TabIndex = 5;
            this.labelPanel6Message.Text = "Write what you think.\nClear your mind.\nNever worry.";
            this.labelPanel6Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 600);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "WelcomeForm";
            this.RealClientSize = new System.Drawing.Size(448, 578);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WelcomeForm";
            this.panelTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.bottomPanel1Init.ResumeLayout(false);
            this.bottomPanel2StartNewJournal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonDropboxJournaley)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPanel2Browse)).EndInit();
            this.bottomPanel3LocationSelected.ResumeLayout(false);
            this.bottomPanel4PasswordSetting.ResumeLayout(false);
            this.bottomPanel4PasswordSetting.PerformLayout();
            this.bottomPanel5ImportJournal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonDropboxDayOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPanel5Browse)).EndInit();
            this.bottomPanel6Complete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel horizontalSeparator;
        private System.Windows.Forms.Label labelMainMessage;
        private Controls.BorderPanel bottomPanel1Init;
        private Controls.BorderPanel bottomPanel2StartNewJournal;
        private System.Windows.Forms.Label labelPanel1Message;
        private Controls.ColorButton buttonImportJournal;
        private Controls.ColorButton buttonStartNewJournal;
        private Controls.BorderPanel bottomPanel3LocationSelected;
        private System.Windows.Forms.Label labelPanel2Message;
        private Controls.ImageButton buttonPanel2Browse;
        private Controls.ImageButton buttonDropboxJournaley;
        private Controls.BorderPanel bottomPanel6Complete;
        private Controls.BorderPanel bottomPanel4PasswordSetting;
        private Controls.BorderPanel bottomPanel5ImportJournal;
        private System.Windows.Forms.Label labelPanel3Message;
        private Controls.ColorButton buttonSetupPassword;
        private Controls.ColorButton buttonLaunchJournaley;
        private System.Windows.Forms.Label labelPasswordConfirm;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textPasswordConfirm;
        private System.Windows.Forms.Label paddingPasswordConfirm;
        private System.Windows.Forms.Label borderPasswordConfirm;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label paddingTextPassword;
        private System.Windows.Forms.Label borderPassword;
        private Controls.ColorButton buttonSavePassword;
        private Controls.ImageButton buttonDropboxDayOne;
        private Controls.ImageButton buttonPanel5Browse;
        private System.Windows.Forms.Label labelPanel5Message;
        private System.Windows.Forms.Label labelPanel6Message;
        private Controls.ColorButton buttonOK;
        private System.Windows.Forms.Label labelJournalLocationBorder;
        private System.Windows.Forms.Label labelJournalLocation;
    }
}