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
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            this.tabLeftPanel = new System.Windows.Forms.TabControl();
            this.tabPageAllEntries = new System.Windows.Forms.TabPage();
            this.entryListBoxAll = new Journaley.Controls.EntryListBox();
            this.tabPageStarred = new System.Windows.Forms.TabPage();
            this.entryListBoxStarred = new Journaley.Controls.EntryListBox();
            this.tabPageTags = new System.Windows.Forms.TabPage();
            this.panelTagsEntryListWrapper = new System.Windows.Forms.Panel();
            this.entryListBoxTags = new Journaley.Controls.EntryListBox();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.tabPageEntriesByYear = new System.Windows.Forms.TabPage();
            this.panelYearEntryListWrapper = new System.Windows.Forms.Panel();
            this.entryListBoxYear = new Journaley.Controls.EntryListBox();
            this.listBoxYear = new System.Windows.Forms.ListBox();
            this.tabPageCalendar = new System.Windows.Forms.TabPage();
            this.entryListBoxCalendar = new Journaley.Controls.EntryListBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutStats = new System.Windows.Forms.TableLayoutPanel();
            this.labelEntries = new System.Windows.Forms.Label();
            this.labelDays = new System.Windows.Forms.Label();
            this.labelThisWeek = new System.Windows.Forms.Label();
            this.labelToday = new System.Windows.Forms.Label();
            this.buttonAddEntry = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonShare = new System.Windows.Forms.Button();
            this.buttonEditSave = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonStar = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
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
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.tabLeftPanel.SuspendLayout();
            this.tabPageAllEntries.SuspendLayout();
            this.tabPageStarred.SuspendLayout();
            this.tabPageTags.SuspendLayout();
            this.panelTagsEntryListWrapper.SuspendLayout();
            this.tabPageEntriesByYear.SuspendLayout();
            this.panelYearEntryListWrapper.SuspendLayout();
            this.tabPageCalendar.SuspendLayout();
            this.tableLayoutStats.SuspendLayout();
            this.contextMenuStripShare.SuspendLayout();
            this.panelWebBrowserWrapper.SuspendLayout();
            this.contextMenuStripPhotoWithoutPhoto.SuspendLayout();
            this.contextMenuStripPhotoWithPhoto.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(0, 15);
            label5.Margin = new System.Windows.Forms.Padding(0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(49, 14);
            label5.TabIndex = 4;
            label5.Text = "ENTRIES";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(64, 15);
            label6.Margin = new System.Windows.Forms.Padding(0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(33, 14);
            label6.TabIndex = 5;
            label6.Text = "DAYS";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(128, 15);
            label7.Margin = new System.Windows.Forms.Padding(0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(63, 14);
            label7.TabIndex = 6;
            label7.Text = "THIS WEEK";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(192, 15);
            label8.Margin = new System.Windows.Forms.Padding(0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(41, 14);
            label8.TabIndex = 7;
            label8.Text = "TODAY";
            // 
            // tabLeftPanel
            // 
            this.tabLeftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabLeftPanel.Controls.Add(this.tabPageAllEntries);
            this.tabLeftPanel.Controls.Add(this.tabPageStarred);
            this.tabLeftPanel.Controls.Add(this.tabPageTags);
            this.tabLeftPanel.Controls.Add(this.tabPageEntriesByYear);
            this.tabLeftPanel.Controls.Add(this.tabPageCalendar);
            this.tabLeftPanel.Location = new System.Drawing.Point(12, 94);
            this.tabLeftPanel.Name = "tabLeftPanel";
            this.tabLeftPanel.SelectedIndex = 0;
            this.tabLeftPanel.Size = new System.Drawing.Size(259, 467);
            this.tabLeftPanel.TabIndex = 2;
            // 
            // tabPageAllEntries
            // 
            this.tabPageAllEntries.Controls.Add(this.entryListBoxAll);
            this.tabPageAllEntries.Location = new System.Drawing.Point(4, 22);
            this.tabPageAllEntries.Name = "tabPageAllEntries";
            this.tabPageAllEntries.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAllEntries.Size = new System.Drawing.Size(251, 441);
            this.tabPageAllEntries.TabIndex = 0;
            this.tabPageAllEntries.Text = "All";
            this.tabPageAllEntries.UseVisualStyleBackColor = true;
            // 
            // entryListBoxAll
            // 
            this.entryListBoxAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryListBoxAll.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.entryListBoxAll.FormattingEnabled = true;
            this.entryListBoxAll.Location = new System.Drawing.Point(3, 3);
            this.entryListBoxAll.Name = "entryListBoxAll";
            this.entryListBoxAll.ScrollAlwaysVisible = true;
            this.entryListBoxAll.Size = new System.Drawing.Size(245, 435);
            this.entryListBoxAll.TabIndex = 0;
            this.entryListBoxAll.SelectedIndexChanged += new System.EventHandler(this.EntryListBox_SelectedIndexChanged);
            // 
            // tabPageStarred
            // 
            this.tabPageStarred.Controls.Add(this.entryListBoxStarred);
            this.tabPageStarred.Location = new System.Drawing.Point(4, 22);
            this.tabPageStarred.Name = "tabPageStarred";
            this.tabPageStarred.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStarred.Size = new System.Drawing.Size(251, 441);
            this.tabPageStarred.TabIndex = 1;
            this.tabPageStarred.Text = "Starred";
            this.tabPageStarred.UseVisualStyleBackColor = true;
            // 
            // entryListBoxStarred
            // 
            this.entryListBoxStarred.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryListBoxStarred.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.entryListBoxStarred.FormattingEnabled = true;
            this.entryListBoxStarred.Location = new System.Drawing.Point(3, 3);
            this.entryListBoxStarred.Name = "entryListBoxStarred";
            this.entryListBoxStarred.ScrollAlwaysVisible = true;
            this.entryListBoxStarred.Size = new System.Drawing.Size(245, 435);
            this.entryListBoxStarred.TabIndex = 0;
            this.entryListBoxStarred.SelectedIndexChanged += new System.EventHandler(this.EntryListBox_SelectedIndexChanged);
            // 
            // tabPageTags
            // 
            this.tabPageTags.Controls.Add(this.panelTagsEntryListWrapper);
            this.tabPageTags.Controls.Add(this.listBoxTags);
            this.tabPageTags.Location = new System.Drawing.Point(4, 22);
            this.tabPageTags.Name = "tabPageTags";
            this.tabPageTags.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTags.Size = new System.Drawing.Size(251, 441);
            this.tabPageTags.TabIndex = 4;
            this.tabPageTags.Text = "Tags";
            this.tabPageTags.UseVisualStyleBackColor = true;
            // 
            // panelTagsEntryListWrapper
            // 
            this.panelTagsEntryListWrapper.Controls.Add(this.entryListBoxTags);
            this.panelTagsEntryListWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTagsEntryListWrapper.Location = new System.Drawing.Point(3, 85);
            this.panelTagsEntryListWrapper.Name = "panelTagsEntryListWrapper";
            this.panelTagsEntryListWrapper.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panelTagsEntryListWrapper.Size = new System.Drawing.Size(245, 353);
            this.panelTagsEntryListWrapper.TabIndex = 1;
            // 
            // entryListBoxTags
            // 
            this.entryListBoxTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryListBoxTags.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.entryListBoxTags.FormattingEnabled = true;
            this.entryListBoxTags.Location = new System.Drawing.Point(0, 3);
            this.entryListBoxTags.Name = "entryListBoxTags";
            this.entryListBoxTags.ScrollAlwaysVisible = true;
            this.entryListBoxTags.Size = new System.Drawing.Size(245, 350);
            this.entryListBoxTags.TabIndex = 0;
            this.entryListBoxTags.SelectedIndexChanged += new System.EventHandler(this.EntryListBox_SelectedIndexChanged);
            // 
            // listBoxTags
            // 
            this.listBoxTags.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(3, 3);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(245, 82);
            this.listBoxTags.TabIndex = 0;
            this.listBoxTags.SelectedIndexChanged += new System.EventHandler(this.ListBoxTags_SelectedIndexChanged);
            // 
            // tabPageEntriesByYear
            // 
            this.tabPageEntriesByYear.Controls.Add(this.panelYearEntryListWrapper);
            this.tabPageEntriesByYear.Controls.Add(this.listBoxYear);
            this.tabPageEntriesByYear.Location = new System.Drawing.Point(4, 22);
            this.tabPageEntriesByYear.Name = "tabPageEntriesByYear";
            this.tabPageEntriesByYear.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEntriesByYear.Size = new System.Drawing.Size(251, 441);
            this.tabPageEntriesByYear.TabIndex = 2;
            this.tabPageEntriesByYear.Text = "Years";
            this.tabPageEntriesByYear.UseVisualStyleBackColor = true;
            // 
            // panelYearEntryListWrapper
            // 
            this.panelYearEntryListWrapper.Controls.Add(this.entryListBoxYear);
            this.panelYearEntryListWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelYearEntryListWrapper.Location = new System.Drawing.Point(3, 85);
            this.panelYearEntryListWrapper.Name = "panelYearEntryListWrapper";
            this.panelYearEntryListWrapper.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panelYearEntryListWrapper.Size = new System.Drawing.Size(245, 353);
            this.panelYearEntryListWrapper.TabIndex = 1;
            // 
            // entryListBoxYear
            // 
            this.entryListBoxYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryListBoxYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.entryListBoxYear.FormattingEnabled = true;
            this.entryListBoxYear.Location = new System.Drawing.Point(0, 3);
            this.entryListBoxYear.Name = "entryListBoxYear";
            this.entryListBoxYear.ScrollAlwaysVisible = true;
            this.entryListBoxYear.Size = new System.Drawing.Size(245, 350);
            this.entryListBoxYear.TabIndex = 0;
            this.entryListBoxYear.SelectedIndexChanged += new System.EventHandler(this.EntryListBox_SelectedIndexChanged);
            // 
            // listBoxYear
            // 
            this.listBoxYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxYear.FormattingEnabled = true;
            this.listBoxYear.Location = new System.Drawing.Point(3, 3);
            this.listBoxYear.Name = "listBoxYear";
            this.listBoxYear.Size = new System.Drawing.Size(245, 82);
            this.listBoxYear.TabIndex = 0;
            this.listBoxYear.SelectedIndexChanged += new System.EventHandler(this.ListBoxYear_SelectedIndexChanged);
            // 
            // tabPageCalendar
            // 
            this.tabPageCalendar.Controls.Add(this.entryListBoxCalendar);
            this.tabPageCalendar.Controls.Add(this.monthCalendar);
            this.tabPageCalendar.Location = new System.Drawing.Point(4, 22);
            this.tabPageCalendar.Name = "tabPageCalendar";
            this.tabPageCalendar.Size = new System.Drawing.Size(251, 441);
            this.tabPageCalendar.TabIndex = 3;
            this.tabPageCalendar.Text = "Calendar";
            this.tabPageCalendar.UseVisualStyleBackColor = true;
            // 
            // entryListBoxCalendar
            // 
            this.entryListBoxCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryListBoxCalendar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.entryListBoxCalendar.FormattingEnabled = true;
            this.entryListBoxCalendar.IntegralHeight = false;
            this.entryListBoxCalendar.Location = new System.Drawing.Point(3, 186);
            this.entryListBoxCalendar.Name = "entryListBoxCalendar";
            this.entryListBoxCalendar.ScrollAlwaysVisible = true;
            this.entryListBoxCalendar.Size = new System.Drawing.Size(245, 252);
            this.entryListBoxCalendar.TabIndex = 1;
            this.entryListBoxCalendar.SelectedIndexChanged += new System.EventHandler(this.EntryListBox_SelectedIndexChanged);
            // 
            // monthCalendar
            // 
            this.monthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.monthCalendar.Location = new System.Drawing.Point(12, 12);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar_DateChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.CustomFormat = "MMMM dd, yyyy hh:mm tt";
            this.dateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(430, 32);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 4;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // tableLayoutStats
            // 
            this.tableLayoutStats.ColumnCount = 4;
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutStats.Controls.Add(this.labelEntries, 0, 0);
            this.tableLayoutStats.Controls.Add(this.labelDays, 1, 0);
            this.tableLayoutStats.Controls.Add(this.labelThisWeek, 2, 0);
            this.tableLayoutStats.Controls.Add(this.labelToday, 3, 0);
            this.tableLayoutStats.Controls.Add(label5, 0, 1);
            this.tableLayoutStats.Controls.Add(label6, 1, 1);
            this.tableLayoutStats.Controls.Add(label7, 2, 1);
            this.tableLayoutStats.Controls.Add(label8, 3, 1);
            this.tableLayoutStats.Location = new System.Drawing.Point(12, 58);
            this.tableLayoutStats.Name = "tableLayoutStats";
            this.tableLayoutStats.RowCount = 2;
            this.tableLayoutStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutStats.Size = new System.Drawing.Size(259, 30);
            this.tableLayoutStats.TabIndex = 1;
            // 
            // labelEntries
            // 
            this.labelEntries.AutoSize = true;
            this.labelEntries.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntries.Location = new System.Drawing.Point(0, 0);
            this.labelEntries.Margin = new System.Windows.Forms.Padding(0);
            this.labelEntries.Name = "labelEntries";
            this.labelEntries.Size = new System.Drawing.Size(0, 14);
            this.labelEntries.TabIndex = 0;
            // 
            // labelDays
            // 
            this.labelDays.AutoSize = true;
            this.labelDays.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDays.Location = new System.Drawing.Point(64, 0);
            this.labelDays.Margin = new System.Windows.Forms.Padding(0);
            this.labelDays.Name = "labelDays";
            this.labelDays.Size = new System.Drawing.Size(0, 14);
            this.labelDays.TabIndex = 1;
            // 
            // labelThisWeek
            // 
            this.labelThisWeek.AutoSize = true;
            this.labelThisWeek.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThisWeek.Location = new System.Drawing.Point(128, 0);
            this.labelThisWeek.Margin = new System.Windows.Forms.Padding(0);
            this.labelThisWeek.Name = "labelThisWeek";
            this.labelThisWeek.Size = new System.Drawing.Size(0, 14);
            this.labelThisWeek.TabIndex = 2;
            // 
            // labelToday
            // 
            this.labelToday.AutoSize = true;
            this.labelToday.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToday.Location = new System.Drawing.Point(192, 0);
            this.labelToday.Margin = new System.Windows.Forms.Padding(0);
            this.labelToday.Name = "labelToday";
            this.labelToday.Size = new System.Drawing.Size(0, 14);
            this.labelToday.TabIndex = 3;
            // 
            // buttonAddEntry
            // 
            this.buttonAddEntry.Image = global::Journaley.Properties.Resources.Plus_32x32;
            this.buttonAddEntry.Location = new System.Drawing.Point(12, 12);
            this.buttonAddEntry.Name = "buttonAddEntry";
            this.buttonAddEntry.Size = new System.Drawing.Size(259, 40);
            this.buttonAddEntry.TabIndex = 0;
            this.toolTip.SetToolTip(this.buttonAddEntry, "Add a new entry");
            this.buttonAddEntry.UseVisualStyleBackColor = true;
            this.buttonAddEntry.Click += new System.EventHandler(this.ButtonAddEntry_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Image = global::Journaley.Properties.Resources.Delete_32x32;
            this.buttonDelete.Location = new System.Drawing.Point(866, 12);
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
            this.buttonShare.Location = new System.Drawing.Point(820, 12);
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
            this.buttonEditSave.Location = new System.Drawing.Point(636, 12);
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
            this.buttonStar.Location = new System.Drawing.Point(682, 12);
            this.buttonStar.Name = "buttonStar";
            this.buttonStar.Size = new System.Drawing.Size(40, 40);
            this.buttonStar.TabIndex = 6;
            this.toolTip.SetToolTip(this.buttonStar, "Star");
            this.buttonStar.UseVisualStyleBackColor = true;
            this.buttonStar.Click += new System.EventHandler(this.ButtonStar_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Image = global::Journaley.Properties.Resources.Settings_32x32;
            this.buttonSettings.Location = new System.Drawing.Point(277, 12);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(40, 40);
            this.buttonSettings.TabIndex = 3;
            this.toolTip.SetToolTip(this.buttonSettings, "Settings");
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // buttonTag
            // 
            this.buttonTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTag.Image = global::Journaley.Properties.Resources.TagWhite_32x32;
            this.buttonTag.Location = new System.Drawing.Point(774, 12);
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
            this.buttonPhoto.Location = new System.Drawing.Point(728, 12);
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
            this.textEntryText.Location = new System.Drawing.Point(277, 58);
            this.textEntryText.Multiline = true;
            this.textEntryText.Name = "textEntryText";
            this.textEntryText.Size = new System.Drawing.Size(629, 503);
            this.textEntryText.TabIndex = 9;
            // 
            // panelWebBrowserWrapper
            // 
            this.panelWebBrowserWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWebBrowserWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWebBrowserWrapper.Controls.Add(this.webBrowser);
            this.panelWebBrowserWrapper.Location = new System.Drawing.Point(277, 58);
            this.panelWebBrowserWrapper.Name = "panelWebBrowserWrapper";
            this.panelWebBrowserWrapper.Size = new System.Drawing.Size(629, 503);
            this.panelWebBrowserWrapper.TabIndex = 11;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(627, 501);
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
            this.contextMenuStripPhotoWithPhoto.Size = new System.Drawing.Size(232, 70);
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
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(918, 573);
            this.Controls.Add(this.buttonPhoto);
            this.Controls.Add(this.buttonTag);
            this.Controls.Add(this.panelWebBrowserWrapper);
            this.Controls.Add(this.textEntryText);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonStar);
            this.Controls.Add(this.buttonEditSave);
            this.Controls.Add(this.buttonShare);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAddEntry);
            this.Controls.Add(this.tableLayoutStats);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.tabLeftPanel);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Journaley";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabLeftPanel.ResumeLayout(false);
            this.tabPageAllEntries.ResumeLayout(false);
            this.tabPageStarred.ResumeLayout(false);
            this.tabPageTags.ResumeLayout(false);
            this.panelTagsEntryListWrapper.ResumeLayout(false);
            this.tabPageEntriesByYear.ResumeLayout(false);
            this.panelYearEntryListWrapper.ResumeLayout(false);
            this.tabPageCalendar.ResumeLayout(false);
            this.tableLayoutStats.ResumeLayout(false);
            this.tableLayoutStats.PerformLayout();
            this.contextMenuStripShare.ResumeLayout(false);
            this.panelWebBrowserWrapper.ResumeLayout(false);
            this.contextMenuStripPhotoWithoutPhoto.ResumeLayout(false);
            this.contextMenuStripPhotoWithPhoto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabLeftPanel;
        private System.Windows.Forms.TabPage tabPageAllEntries;
        private System.Windows.Forms.TabPage tabPageStarred;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutStats;
        private System.Windows.Forms.Label labelEntries;
        private System.Windows.Forms.Label labelDays;
        private System.Windows.Forms.Label labelThisWeek;
        private System.Windows.Forms.Label labelToday;
        private System.Windows.Forms.Button buttonAddEntry;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonShare;
        private System.Windows.Forms.Button buttonEditSave;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonStar;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.TabPage tabPageEntriesByYear;
        private System.Windows.Forms.TabPage tabPageCalendar;
        private EntryListBox entryListBoxAll;
        private EntryListBox entryListBoxStarred;
        private System.Windows.Forms.Panel panelYearEntryListWrapper;
        private EntryListBox entryListBoxYear;
        private System.Windows.Forms.ListBox listBoxYear;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private EntryListBox entryListBoxCalendar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripShare;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailThisEntryToolStripMenuItem;
        private System.Windows.Forms.TextBox textEntryText;
        private System.Windows.Forms.Panel panelWebBrowserWrapper;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TabPage tabPageTags;
        private System.Windows.Forms.Panel panelTagsEntryListWrapper;
        private EntryListBox entryListBoxTags;
        private System.Windows.Forms.ListBox listBoxTags;
        private System.Windows.Forms.Button buttonTag;
        private System.Windows.Forms.Button buttonPhoto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPhotoWithoutPhoto;
        private System.Windows.Forms.ToolStripMenuItem chooseExistingPhotoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPhotoWithPhoto;
        private System.Windows.Forms.ToolStripMenuItem replaceWithAnotherPhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePhotoToolStripMenuItem;
    }
}

