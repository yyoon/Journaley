using Journaley.Controls;
namespace Journaley.Forms
{
    partial class MainForm
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutStats = new System.Windows.Forms.TableLayoutPanel();
            this.labelEntries = new System.Windows.Forms.Label();
            this.labelThisWeek = new System.Windows.Forms.Label();
            this.labelToday = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonShare = new System.Windows.Forms.Button();
            this.buttonEditSave = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonStar = new System.Windows.Forms.Button();
            this.buttonTag = new System.Windows.Forms.Button();
            this.buttonPhoto = new System.Windows.Forms.Button();
            this.contextMenuStripShare = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailThisEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textEntryText = new System.Windows.Forms.TextBox();
            this.panelWebBrowserWrapper = new System.Windows.Forms.Panel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.contextMenuStripPhotoWithoutPhoto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chooseExistingPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripPhotoWithPhoto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replaceWithAnotherPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.pictureBoxSidebarSeperatorBottom = new System.Windows.Forms.PictureBox();
            this.tableLayoutBottom = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxBottomSeparator = new System.Windows.Forms.PictureBox();
            this.labelWordsTitle = new System.Windows.Forms.Label();
            this.labelCharactersTitle = new System.Windows.Forms.Label();
            this.labelWords = new System.Windows.Forms.Label();
            this.labelCharacters = new System.Windows.Forms.Label();
            this.tableLayoutDate = new System.Windows.Forms.TableLayoutPanel();
            this.panelDateLeft = new System.Windows.Forms.Panel();
            this.panelDateRight = new System.Windows.Forms.Panel();
            this.buttonSettings = new Journaley.Controls.ImageButton();
            this.buttonMainTags = new Journaley.Controls.ImageButton();
            this.buttonMainCalendar = new Journaley.Controls.ImageButton();
            this.buttonMainTimeline = new Journaley.Controls.ImageButton();
            this.buttonAddEntry = new Journaley.Controls.ImageButton();
            this.panelEntryListArea = new Journaley.Controls.EntryListAreaPanel();
            this.panelTimeline = new System.Windows.Forms.Panel();
            this.entryListBoxAll = new Journaley.Controls.EntryListBox();
            this.panelCalendar = new System.Windows.Forms.Panel();
            this.entryListBoxCalendar = new Journaley.Controls.EntryListBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.panelTags = new System.Windows.Forms.Panel();
            this.entryListBoxTags = new Journaley.Controls.EntryListBox();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.tableLayoutStats.SuspendLayout();
            this.contextMenuStripShare.SuspendLayout();
            this.panelWebBrowserWrapper.SuspendLayout();
            this.contextMenuStripPhotoWithoutPhoto.SuspendLayout();
            this.contextMenuStripPhotoWithPhoto.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSidebarSeperatorBottom)).BeginInit();
            this.tableLayoutBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomSeparator)).BeginInit();
            this.tableLayoutDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMainTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMainCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMainTimeline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddEntry)).BeginInit();
            this.panelEntryListArea.SuspendLayout();
            this.panelTimeline.SuspendLayout();
            this.panelCalendar.SuspendLayout();
            this.panelTags.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            label5.Location = new System.Drawing.Point(159, 11);
            label5.Margin = new System.Windows.Forms.Padding(0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(48, 13);
            label5.TabIndex = 4;
            label5.Text = "ENTRIES";
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            label7.Location = new System.Drawing.Point(79, 11);
            label7.Margin = new System.Windows.Forms.Padding(0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(61, 13);
            label7.TabIndex = 6;
            label7.Text = "THIS WEEK";
            // 
            // label8
            // 
            label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label8.AutoSize = true;
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            label8.Location = new System.Drawing.Point(19, 11);
            label8.Margin = new System.Windows.Forms.Padding(0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(41, 13);
            label8.TabIndex = 7;
            label8.Text = "TODAY";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker.CustomFormat = "MMMM dd, yyyy hh:mm tt";
            this.dateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(228, 3);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 4;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // tableLayoutStats
            // 
            this.tableLayoutStats.BackgroundImage = global::Journaley.Properties.Resources.main_pane_entriesStat_background;
            this.tableLayoutStats.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutStats.ColumnCount = 7;
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutStats.Controls.Add(this.labelEntries, 5, 0);
            this.tableLayoutStats.Controls.Add(this.labelThisWeek, 3, 0);
            this.tableLayoutStats.Controls.Add(this.labelToday, 1, 0);
            this.tableLayoutStats.Controls.Add(label5, 5, 1);
            this.tableLayoutStats.Controls.Add(label7, 3, 1);
            this.tableLayoutStats.Controls.Add(label8, 1, 1);
            this.tableLayoutStats.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutStats.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutStats.Name = "tableLayoutStats";
            this.tableLayoutStats.RowCount = 2;
            this.tableLayoutStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tableLayoutStats.Size = new System.Drawing.Size(229, 25);
            this.tableLayoutStats.TabIndex = 1;
            // 
            // labelEntries
            // 
            this.labelEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEntries.AutoSize = true;
            this.labelEntries.BackColor = System.Drawing.Color.Transparent;
            this.labelEntries.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntries.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(225)))));
            this.labelEntries.Location = new System.Drawing.Point(159, 0);
            this.labelEntries.Margin = new System.Windows.Forms.Padding(0);
            this.labelEntries.Name = "labelEntries";
            this.labelEntries.Size = new System.Drawing.Size(0, 11);
            this.labelEntries.TabIndex = 0;
            // 
            // labelThisWeek
            // 
            this.labelThisWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelThisWeek.AutoSize = true;
            this.labelThisWeek.BackColor = System.Drawing.Color.Transparent;
            this.labelThisWeek.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThisWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(225)))));
            this.labelThisWeek.Location = new System.Drawing.Point(79, 0);
            this.labelThisWeek.Margin = new System.Windows.Forms.Padding(0);
            this.labelThisWeek.Name = "labelThisWeek";
            this.labelThisWeek.Size = new System.Drawing.Size(0, 11);
            this.labelThisWeek.TabIndex = 2;
            // 
            // labelToday
            // 
            this.labelToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelToday.AutoSize = true;
            this.labelToday.BackColor = System.Drawing.Color.Transparent;
            this.labelToday.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(225)))));
            this.labelToday.Location = new System.Drawing.Point(19, 0);
            this.labelToday.Margin = new System.Windows.Forms.Padding(0);
            this.labelToday.Name = "labelToday";
            this.labelToday.Size = new System.Drawing.Size(0, 11);
            this.labelToday.TabIndex = 3;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Image = global::Journaley.Properties.Resources.Delete_32x32;
            this.buttonDelete.Location = new System.Drawing.Point(4, 324);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(40, 40);
            this.buttonDelete.TabIndex = 10;
            this.toolTip.SetToolTip(this.buttonDelete, "Delete");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonShare
            // 
            this.buttonShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShare.Image = global::Journaley.Properties.Resources.Copy_32x32;
            this.buttonShare.Location = new System.Drawing.Point(4, 278);
            this.buttonShare.Name = "buttonShare";
            this.buttonShare.Size = new System.Drawing.Size(40, 40);
            this.buttonShare.TabIndex = 9;
            this.toolTip.SetToolTip(this.buttonShare, "Share");
            this.buttonShare.UseVisualStyleBackColor = true;
            this.buttonShare.Click += new System.EventHandler(this.ButtonShare_Click);
            // 
            // buttonEditSave
            // 
            this.buttonEditSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditSave.Image = global::Journaley.Properties.Resources.Edit_32x32;
            this.buttonEditSave.Location = new System.Drawing.Point(3, 94);
            this.buttonEditSave.Name = "buttonEditSave";
            this.buttonEditSave.Size = new System.Drawing.Size(40, 40);
            this.buttonEditSave.TabIndex = 5;
            this.toolTip.SetToolTip(this.buttonEditSave, "Edit");
            this.buttonEditSave.UseVisualStyleBackColor = true;
            this.buttonEditSave.Click += new System.EventHandler(this.ButtonEditSave_Click);
            // 
            // buttonStar
            // 
            this.buttonStar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStar.Image = global::Journaley.Properties.Resources.StarGray_32x32;
            this.buttonStar.Location = new System.Drawing.Point(4, 140);
            this.buttonStar.Name = "buttonStar";
            this.buttonStar.Size = new System.Drawing.Size(40, 40);
            this.buttonStar.TabIndex = 6;
            this.toolTip.SetToolTip(this.buttonStar, "Star");
            this.buttonStar.UseVisualStyleBackColor = true;
            this.buttonStar.Click += new System.EventHandler(this.ButtonStar_Click);
            // 
            // buttonTag
            // 
            this.buttonTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTag.Image = global::Journaley.Properties.Resources.TagWhite_32x32;
            this.buttonTag.Location = new System.Drawing.Point(4, 232);
            this.buttonTag.Name = "buttonTag";
            this.buttonTag.Size = new System.Drawing.Size(40, 40);
            this.buttonTag.TabIndex = 8;
            this.toolTip.SetToolTip(this.buttonTag, "Tag");
            this.buttonTag.UseVisualStyleBackColor = true;
            this.buttonTag.Click += new System.EventHandler(this.ButtonTag_Click);
            // 
            // buttonPhoto
            // 
            this.buttonPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPhoto.Image = global::Journaley.Properties.Resources.ImageGray_32x32;
            this.buttonPhoto.Location = new System.Drawing.Point(4, 186);
            this.buttonPhoto.Name = "buttonPhoto";
            this.buttonPhoto.Size = new System.Drawing.Size(40, 40);
            this.buttonPhoto.TabIndex = 7;
            this.toolTip.SetToolTip(this.buttonPhoto, "Photo");
            this.buttonPhoto.UseVisualStyleBackColor = true;
            this.buttonPhoto.Click += new System.EventHandler(this.ButtonPhoto_Click);
            // 
            // contextMenuStripShare
            // 
            this.contextMenuStripShare.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem,
            this.emailThisEntryToolStripMenuItem});
            this.contextMenuStripShare.Name = "contextMenuStripShare";
            this.contextMenuStripShare.Size = new System.Drawing.Size(172, 48);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyToClipboardToolStripMenuItem_Click);
            // 
            // emailThisEntryToolStripMenuItem
            // 
            this.emailThisEntryToolStripMenuItem.Name = "emailThisEntryToolStripMenuItem";
            this.emailThisEntryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.emailThisEntryToolStripMenuItem.Text = "Email this entry";
            this.emailThisEntryToolStripMenuItem.Click += new System.EventHandler(this.EmailThisEntryToolStripMenuItem_Click);
            // 
            // textEntryText
            // 
            this.textEntryText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEntryText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEntryText.Location = new System.Drawing.Point(228, 24);
            this.textEntryText.Margin = new System.Windows.Forms.Padding(0);
            this.textEntryText.Multiline = true;
            this.textEntryText.Name = "textEntryText";
            this.textEntryText.Size = new System.Drawing.Size(656, 508);
            this.textEntryText.TabIndex = 9;
            this.textEntryText.TextChanged += new System.EventHandler(this.TextEntryText_TextChanged);
            // 
            // panelWebBrowserWrapper
            // 
            this.panelWebBrowserWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWebBrowserWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWebBrowserWrapper.Controls.Add(this.webBrowser);
            this.panelWebBrowserWrapper.Location = new System.Drawing.Point(228, 24);
            this.panelWebBrowserWrapper.Margin = new System.Windows.Forms.Padding(0);
            this.panelWebBrowserWrapper.Name = "panelWebBrowserWrapper";
            this.panelWebBrowserWrapper.Size = new System.Drawing.Size(656, 508);
            this.panelWebBrowserWrapper.TabIndex = 11;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(654, 506);
            this.webBrowser.TabIndex = 0;
            // 
            // contextMenuStripPhotoWithoutPhoto
            // 
            this.contextMenuStripPhotoWithoutPhoto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseExistingPhotoToolStripMenuItem});
            this.contextMenuStripPhotoWithoutPhoto.Name = "contextMenuStripPhotoWithoutPhoto";
            this.contextMenuStripPhotoWithoutPhoto.Size = new System.Drawing.Size(223, 26);
            // 
            // chooseExistingPhotoToolStripMenuItem
            // 
            this.chooseExistingPhotoToolStripMenuItem.Name = "chooseExistingPhotoToolStripMenuItem";
            this.chooseExistingPhotoToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.chooseExistingPhotoToolStripMenuItem.Text = "Choose an Exsisting Photo...";
            this.chooseExistingPhotoToolStripMenuItem.Click += new System.EventHandler(this.ChooseExistingPhotoToolStripMenuItem_Click);
            // 
            // contextMenuStripPhotoWithPhoto
            // 
            this.contextMenuStripPhotoWithPhoto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceWithAnotherPhotoToolStripMenuItem,
            this.deletePhotoToolStripMenuItem});
            this.contextMenuStripPhotoWithPhoto.Name = "contextMenuStripPhotoWithPhoto";
            this.contextMenuStripPhotoWithPhoto.Size = new System.Drawing.Size(232, 48);
            // 
            // replaceWithAnotherPhotoToolStripMenuItem
            // 
            this.replaceWithAnotherPhotoToolStripMenuItem.Name = "replaceWithAnotherPhotoToolStripMenuItem";
            this.replaceWithAnotherPhotoToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.replaceWithAnotherPhotoToolStripMenuItem.Text = "Replace with Another Photo...";
            this.replaceWithAnotherPhotoToolStripMenuItem.Click += new System.EventHandler(this.ReplaceWithAnotherPhotoToolStripMenuItem_Click);
            // 
            // deletePhotoToolStripMenuItem
            // 
            this.deletePhotoToolStripMenuItem.Name = "deletePhotoToolStripMenuItem";
            this.deletePhotoToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.deletePhotoToolStripMenuItem.Text = "Delete Photo";
            this.deletePhotoToolStripMenuItem.Click += new System.EventHandler(this.DeletePhotoToolStripMenuItem_Click);
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackgroundImage = global::Journaley.Properties.Resources.main_pane_sidebar_background;
            this.panelSidebar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSidebar.Controls.Add(this.pictureBoxSidebarSeperatorBottom);
            this.panelSidebar.Controls.Add(this.buttonDelete);
            this.panelSidebar.Controls.Add(this.buttonShare);
            this.panelSidebar.Controls.Add(this.buttonTag);
            this.panelSidebar.Controls.Add(this.buttonPhoto);
            this.panelSidebar.Controls.Add(this.buttonStar);
            this.panelSidebar.Controls.Add(this.buttonEditSave);
            this.panelSidebar.Controls.Add(this.buttonSettings);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSidebar.Location = new System.Drawing.Point(883, 0);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(47, 573);
            this.panelSidebar.TabIndex = 12;
            // 
            // pictureBoxSidebarSeperatorBottom
            // 
            this.pictureBoxSidebarSeperatorBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxSidebarSeperatorBottom.Image = global::Journaley.Properties.Resources.sidebar_seperator_bottom;
            this.pictureBoxSidebarSeperatorBottom.Location = new System.Drawing.Point(0, 531);
            this.pictureBoxSidebarSeperatorBottom.Name = "pictureBoxSidebarSeperatorBottom";
            this.pictureBoxSidebarSeperatorBottom.Size = new System.Drawing.Size(47, 1);
            this.pictureBoxSidebarSeperatorBottom.TabIndex = 11;
            this.pictureBoxSidebarSeperatorBottom.TabStop = false;
            // 
            // tableLayoutBottom
            // 
            this.tableLayoutBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutBottom.BackgroundImage = global::Journaley.Properties.Resources.main_frame_bottom_background;
            this.tableLayoutBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutBottom.ColumnCount = 5;
            this.tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBottom.Controls.Add(this.pictureBoxBottomSeparator, 2, 0);
            this.tableLayoutBottom.Controls.Add(this.labelWordsTitle, 1, 1);
            this.tableLayoutBottom.Controls.Add(this.labelCharactersTitle, 3, 1);
            this.tableLayoutBottom.Controls.Add(this.labelWords, 1, 0);
            this.tableLayoutBottom.Controls.Add(this.labelCharacters, 3, 0);
            this.tableLayoutBottom.Location = new System.Drawing.Point(229, 532);
            this.tableLayoutBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutBottom.Name = "tableLayoutBottom";
            this.tableLayoutBottom.RowCount = 2;
            this.tableLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBottom.Size = new System.Drawing.Size(654, 41);
            this.tableLayoutBottom.TabIndex = 16;
            // 
            // pictureBoxBottomSeparator
            // 
            this.pictureBoxBottomSeparator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxBottomSeparator.Image = global::Journaley.Properties.Resources.main_frame_bottom_separator;
            this.pictureBoxBottomSeparator.Location = new System.Drawing.Point(326, 6);
            this.pictureBoxBottomSeparator.Name = "pictureBoxBottomSeparator";
            this.tableLayoutBottom.SetRowSpan(this.pictureBoxBottomSeparator, 2);
            this.pictureBoxBottomSeparator.Size = new System.Drawing.Size(1, 29);
            this.pictureBoxBottomSeparator.TabIndex = 0;
            this.pictureBoxBottomSeparator.TabStop = false;
            // 
            // labelWordsTitle
            // 
            this.labelWordsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWordsTitle.AutoSize = true;
            this.labelWordsTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelWordsTitle.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWordsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(20)))));
            this.labelWordsTitle.Location = new System.Drawing.Point(313, 20);
            this.labelWordsTitle.Name = "labelWordsTitle";
            this.labelWordsTitle.Size = new System.Drawing.Size(0, 13);
            this.labelWordsTitle.TabIndex = 1;
            // 
            // labelCharactersTitle
            // 
            this.labelCharactersTitle.AutoSize = true;
            this.labelCharactersTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelCharactersTitle.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCharactersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(20)))));
            this.labelCharactersTitle.Location = new System.Drawing.Point(340, 20);
            this.labelCharactersTitle.Name = "labelCharactersTitle";
            this.labelCharactersTitle.Size = new System.Drawing.Size(0, 13);
            this.labelCharactersTitle.TabIndex = 2;
            // 
            // labelWords
            // 
            this.labelWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWords.AutoSize = true;
            this.labelWords.BackColor = System.Drawing.Color.Transparent;
            this.labelWords.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(225)))));
            this.labelWords.Location = new System.Drawing.Point(313, 7);
            this.labelWords.Name = "labelWords";
            this.labelWords.Size = new System.Drawing.Size(0, 13);
            this.labelWords.TabIndex = 3;
            // 
            // labelCharacters
            // 
            this.labelCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCharacters.AutoSize = true;
            this.labelCharacters.BackColor = System.Drawing.Color.Transparent;
            this.labelCharacters.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCharacters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(225)))));
            this.labelCharacters.Location = new System.Drawing.Point(340, 7);
            this.labelCharacters.Name = "labelCharacters";
            this.labelCharacters.Size = new System.Drawing.Size(0, 13);
            this.labelCharacters.TabIndex = 4;
            // 
            // tableLayoutDate
            // 
            this.tableLayoutDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutDate.BackgroundImage = global::Journaley.Properties.Resources.main_pane_date_background_center;
            this.tableLayoutDate.ColumnCount = 3;
            this.tableLayoutDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutDate.Controls.Add(this.panelDateLeft, 0, 0);
            this.tableLayoutDate.Controls.Add(this.panelDateRight, 2, 0);
            this.tableLayoutDate.Controls.Add(this.dateTimePicker, 1, 0);
            this.tableLayoutDate.Location = new System.Drawing.Point(228, 0);
            this.tableLayoutDate.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutDate.Name = "tableLayoutDate";
            this.tableLayoutDate.RowCount = 1;
            this.tableLayoutDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutDate.Size = new System.Drawing.Size(656, 25);
            this.tableLayoutDate.TabIndex = 17;
            // 
            // panelDateLeft
            // 
            this.panelDateLeft.BackgroundImage = global::Journaley.Properties.Resources.main_pane_date_background_left;
            this.panelDateLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDateLeft.Location = new System.Drawing.Point(0, 0);
            this.panelDateLeft.Margin = new System.Windows.Forms.Padding(0);
            this.panelDateLeft.Name = "panelDateLeft";
            this.panelDateLeft.Size = new System.Drawing.Size(100, 25);
            this.panelDateLeft.TabIndex = 0;
            // 
            // panelDateRight
            // 
            this.panelDateRight.BackgroundImage = global::Journaley.Properties.Resources.main_pane_date_background_right;
            this.panelDateRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDateRight.Location = new System.Drawing.Point(556, 0);
            this.panelDateRight.Margin = new System.Windows.Forms.Padding(0);
            this.panelDateRight.Name = "panelDateRight";
            this.panelDateRight.Size = new System.Drawing.Size(100, 25);
            this.panelDateRight.TabIndex = 1;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSettings.DownImage = global::Journaley.Properties.Resources.sidebar_btn_setting_down;
            this.buttonSettings.HoverImage = global::Journaley.Properties.Resources.sidebar_btn_setting_over;
            this.buttonSettings.Image = global::Journaley.Properties.Resources.sidebar_btn_setting_norm;
            this.buttonSettings.Location = new System.Drawing.Point(0, 532);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.NormalImage = global::Journaley.Properties.Resources.sidebar_btn_setting_norm;
            this.buttonSettings.Selected = false;
            this.buttonSettings.SelectedImage = null;
            this.buttonSettings.Size = new System.Drawing.Size(47, 41);
            this.buttonSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.TabStop = false;
            this.toolTip.SetToolTip(this.buttonSettings, "Settings");
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // buttonMainTags
            // 
            this.buttonMainTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMainTags.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonMainTags.DownImage = global::Journaley.Properties.Resources.main_btn_tag_down;
            this.buttonMainTags.HoverImage = global::Journaley.Properties.Resources.main_btn_tag_over;
            this.buttonMainTags.Image = global::Journaley.Properties.Resources.main_btn_tag_norm;
            this.buttonMainTags.Location = new System.Drawing.Point(152, 491);
            this.buttonMainTags.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMainTags.Name = "buttonMainTags";
            this.buttonMainTags.NormalImage = global::Journaley.Properties.Resources.main_btn_tag_norm;
            this.buttonMainTags.Selected = false;
            this.buttonMainTags.SelectedImage = global::Journaley.Properties.Resources.main_btn_tag_down;
            this.buttonMainTags.Size = new System.Drawing.Size(77, 40);
            this.buttonMainTags.TabIndex = 15;
            this.buttonMainTags.TabStop = false;
            this.buttonMainTags.Click += new System.EventHandler(this.ButtonMainTags_Click);
            // 
            // buttonMainCalendar
            // 
            this.buttonMainCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMainCalendar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonMainCalendar.DownImage = global::Journaley.Properties.Resources.main_btn_calendar_down;
            this.buttonMainCalendar.HoverImage = global::Journaley.Properties.Resources.main_btn_calendar_over;
            this.buttonMainCalendar.Image = global::Journaley.Properties.Resources.main_btn_calendar_norm;
            this.buttonMainCalendar.Location = new System.Drawing.Point(76, 491);
            this.buttonMainCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMainCalendar.Name = "buttonMainCalendar";
            this.buttonMainCalendar.NormalImage = global::Journaley.Properties.Resources.main_btn_calendar_norm;
            this.buttonMainCalendar.Selected = false;
            this.buttonMainCalendar.SelectedImage = global::Journaley.Properties.Resources.main_btn_calendar_down;
            this.buttonMainCalendar.Size = new System.Drawing.Size(76, 40);
            this.buttonMainCalendar.TabIndex = 14;
            this.buttonMainCalendar.TabStop = false;
            this.buttonMainCalendar.Click += new System.EventHandler(this.ButtonMainCalendar_Click);
            // 
            // buttonMainTimeline
            // 
            this.buttonMainTimeline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMainTimeline.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonMainTimeline.DownImage = global::Journaley.Properties.Resources.main_btn_timeline_down;
            this.buttonMainTimeline.HoverImage = global::Journaley.Properties.Resources.main_btn_timeline_over;
            this.buttonMainTimeline.Image = global::Journaley.Properties.Resources.main_btn_timeline_down;
            this.buttonMainTimeline.Location = new System.Drawing.Point(0, 491);
            this.buttonMainTimeline.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMainTimeline.Name = "buttonMainTimeline";
            this.buttonMainTimeline.NormalImage = global::Journaley.Properties.Resources.main_btn_timeline_norm;
            this.buttonMainTimeline.Selected = true;
            this.buttonMainTimeline.SelectedImage = global::Journaley.Properties.Resources.main_btn_timeline_down;
            this.buttonMainTimeline.Size = new System.Drawing.Size(76, 40);
            this.buttonMainTimeline.TabIndex = 13;
            this.buttonMainTimeline.TabStop = false;
            this.buttonMainTimeline.Click += new System.EventHandler(this.ButtonMainTimeline_Click);
            // 
            // buttonAddEntry
            // 
            this.buttonAddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddEntry.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonAddEntry.DownImage = global::Journaley.Properties.Resources.main_btn_entry_down;
            this.buttonAddEntry.HoverImage = global::Journaley.Properties.Resources.main_btn_entry_over;
            this.buttonAddEntry.Image = global::Journaley.Properties.Resources.main_btn_entry_norm;
            this.buttonAddEntry.Location = new System.Drawing.Point(0, 531);
            this.buttonAddEntry.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddEntry.Name = "buttonAddEntry";
            this.buttonAddEntry.NormalImage = global::Journaley.Properties.Resources.main_btn_entry_norm;
            this.buttonAddEntry.Selected = false;
            this.buttonAddEntry.SelectedImage = null;
            this.buttonAddEntry.Size = new System.Drawing.Size(229, 42);
            this.buttonAddEntry.TabIndex = 0;
            this.buttonAddEntry.TabStop = false;
            this.toolTip.SetToolTip(this.buttonAddEntry, "Add a new entry");
            this.buttonAddEntry.Click += new System.EventHandler(this.ButtonAddEntry_Click);
            // 
            // panelEntryListArea
            // 
            this.panelEntryListArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelEntryListArea.Controls.Add(this.panelTimeline);
            this.panelEntryListArea.Controls.Add(this.panelCalendar);
            this.panelEntryListArea.Controls.Add(this.panelTags);
            this.panelEntryListArea.Location = new System.Drawing.Point(0, 24);
            this.panelEntryListArea.Margin = new System.Windows.Forms.Padding(0);
            this.panelEntryListArea.Name = "panelEntryListArea";
            this.panelEntryListArea.Padding = new System.Windows.Forms.Padding(1);
            this.panelEntryListArea.Size = new System.Drawing.Size(229, 468);
            this.panelEntryListArea.TabIndex = 18;
            // 
            // panelTimeline
            // 
            this.panelTimeline.Controls.Add(this.entryListBoxAll);
            this.panelTimeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTimeline.Location = new System.Drawing.Point(1, 1);
            this.panelTimeline.Name = "panelTimeline";
            this.panelTimeline.Size = new System.Drawing.Size(227, 466);
            this.panelTimeline.TabIndex = 0;
            // 
            // entryListBoxAll
            // 
            this.entryListBoxAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.entryListBoxAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryListBoxAll.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.entryListBoxAll.FormattingEnabled = true;
            this.entryListBoxAll.Location = new System.Drawing.Point(0, 0);
            this.entryListBoxAll.Name = "entryListBoxAll";
            this.entryListBoxAll.ScrollAlwaysVisible = true;
            this.entryListBoxAll.Size = new System.Drawing.Size(227, 466);
            this.entryListBoxAll.TabIndex = 0;
            this.entryListBoxAll.SelectedIndexChanged += new System.EventHandler(this.EntryListBox_SelectedIndexChanged);
            // 
            // panelCalendar
            // 
            this.panelCalendar.Controls.Add(this.entryListBoxCalendar);
            this.panelCalendar.Controls.Add(this.monthCalendar);
            this.panelCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCalendar.Location = new System.Drawing.Point(1, 1);
            this.panelCalendar.Name = "panelCalendar";
            this.panelCalendar.Size = new System.Drawing.Size(227, 466);
            this.panelCalendar.TabIndex = 1;
            this.panelCalendar.Visible = false;
            // 
            // entryListBoxCalendar
            // 
            this.entryListBoxCalendar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.entryListBoxCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryListBoxCalendar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.entryListBoxCalendar.FormattingEnabled = true;
            this.entryListBoxCalendar.IntegralHeight = false;
            this.entryListBoxCalendar.Location = new System.Drawing.Point(0, 162);
            this.entryListBoxCalendar.Name = "entryListBoxCalendar";
            this.entryListBoxCalendar.ScrollAlwaysVisible = true;
            this.entryListBoxCalendar.Size = new System.Drawing.Size(227, 304);
            this.entryListBoxCalendar.TabIndex = 1;
            this.entryListBoxCalendar.SelectedIndexChanged += new System.EventHandler(this.EntryListBox_SelectedIndexChanged);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.monthCalendar.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar_DateChanged);
            // 
            // panelTags
            // 
            this.panelTags.Controls.Add(this.entryListBoxTags);
            this.panelTags.Controls.Add(this.listBoxTags);
            this.panelTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTags.Location = new System.Drawing.Point(1, 1);
            this.panelTags.Name = "panelTags";
            this.panelTags.Size = new System.Drawing.Size(227, 466);
            this.panelTags.TabIndex = 2;
            this.panelTags.Visible = false;
            // 
            // entryListBoxTags
            // 
            this.entryListBoxTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.entryListBoxTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryListBoxTags.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.entryListBoxTags.FormattingEnabled = true;
            this.entryListBoxTags.Location = new System.Drawing.Point(0, 52);
            this.entryListBoxTags.Name = "entryListBoxTags";
            this.entryListBoxTags.ScrollAlwaysVisible = true;
            this.entryListBoxTags.Size = new System.Drawing.Size(227, 414);
            this.entryListBoxTags.TabIndex = 0;
            this.entryListBoxTags.SelectedIndexChanged += new System.EventHandler(this.EntryListBox_SelectedIndexChanged);
            // 
            // listBoxTags
            // 
            this.listBoxTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxTags.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(0, 0);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(227, 52);
            this.listBoxTags.TabIndex = 0;
            this.listBoxTags.SelectedIndexChanged += new System.EventHandler(this.ListBoxTags_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Journaley.Properties.Resources.main_frame_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(930, 573);
            this.Controls.Add(this.tableLayoutDate);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.tableLayoutBottom);
            this.Controls.Add(this.buttonMainTags);
            this.Controls.Add(this.buttonMainCalendar);
            this.Controls.Add(this.buttonMainTimeline);
            this.Controls.Add(this.panelWebBrowserWrapper);
            this.Controls.Add(this.textEntryText);
            this.Controls.Add(this.buttonAddEntry);
            this.Controls.Add(this.tableLayoutStats);
            this.Controls.Add(this.panelEntryListArea);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Journaley";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutStats.ResumeLayout(false);
            this.tableLayoutStats.PerformLayout();
            this.contextMenuStripShare.ResumeLayout(false);
            this.panelWebBrowserWrapper.ResumeLayout(false);
            this.contextMenuStripPhotoWithoutPhoto.ResumeLayout(false);
            this.contextMenuStripPhotoWithPhoto.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSidebarSeperatorBottom)).EndInit();
            this.tableLayoutBottom.ResumeLayout(false);
            this.tableLayoutBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomSeparator)).EndInit();
            this.tableLayoutDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMainTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMainCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMainTimeline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddEntry)).EndInit();
            this.panelEntryListArea.ResumeLayout(false);
            this.panelTimeline.ResumeLayout(false);
            this.panelCalendar.ResumeLayout(false);
            this.panelTags.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutStats;
        private System.Windows.Forms.Label labelEntries;
        private System.Windows.Forms.Label labelThisWeek;
        private System.Windows.Forms.Label labelToday;
        private Journaley.Controls.ImageButton buttonAddEntry;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonShare;
        private System.Windows.Forms.Button buttonEditSave;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonStar;
        private Journaley.Controls.ImageButton buttonSettings;
        private EntryListBox entryListBoxAll;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private EntryListBox entryListBoxCalendar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripShare;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailThisEntryToolStripMenuItem;
        private System.Windows.Forms.TextBox textEntryText;
        private System.Windows.Forms.Panel panelWebBrowserWrapper;
        private System.Windows.Forms.WebBrowser webBrowser;
        private EntryListBox entryListBoxTags;
        private System.Windows.Forms.ListBox listBoxTags;
        private System.Windows.Forms.Button buttonTag;
        private System.Windows.Forms.Button buttonPhoto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPhotoWithoutPhoto;
        private System.Windows.Forms.ToolStripMenuItem chooseExistingPhotoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPhotoWithPhoto;
        private System.Windows.Forms.ToolStripMenuItem replaceWithAnotherPhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePhotoToolStripMenuItem;
        private System.Windows.Forms.Panel panelSidebar;
        private ImageButton buttonMainTimeline;
        private ImageButton buttonMainCalendar;
        private ImageButton buttonMainTags;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBottom;
        private System.Windows.Forms.PictureBox pictureBoxBottomSeparator;
        private System.Windows.Forms.Label labelWordsTitle;
        private System.Windows.Forms.Label labelCharactersTitle;
        private System.Windows.Forms.Label labelWords;
        private System.Windows.Forms.Label labelCharacters;
        private System.Windows.Forms.TableLayoutPanel tableLayoutDate;
        private System.Windows.Forms.Panel panelDateLeft;
        private System.Windows.Forms.Panel panelDateRight;
        private System.Windows.Forms.PictureBox pictureBoxSidebarSeperatorBottom;
        private System.Windows.Forms.Panel panelTimeline;
        private System.Windows.Forms.Panel panelTags;
        private System.Windows.Forms.Panel panelCalendar;
        private EntryListAreaPanel panelEntryListArea;
    }
}

