namespace DayOneWindowsClient
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
            this.tabPageStarred = new System.Windows.Forms.TabPage();
            this.tabPageEntriesByYear = new System.Windows.Forms.TabPage();
            this.tabPageCalendar = new System.Windows.Forms.TabPage();
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
            this.textEntryText = new System.Windows.Forms.TextBox();
            this.listBoxYear = new System.Windows.Forms.ListBox();
            this.panelYearEntryListWrapper = new System.Windows.Forms.Panel();
            this.entryListBoxAll = new DayOneWindowsClient.EntryListBox();
            this.entryListBoxStarred = new DayOneWindowsClient.EntryListBox();
            this.entryListBoxYear = new DayOneWindowsClient.EntryListBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.tabLeftPanel.SuspendLayout();
            this.tabPageAllEntries.SuspendLayout();
            this.tabPageStarred.SuspendLayout();
            this.tabPageEntriesByYear.SuspendLayout();
            this.tableLayoutStats.SuspendLayout();
            this.panelYearEntryListWrapper.SuspendLayout();
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
            // tabPageEntriesByYear
            // 
            this.tabPageEntriesByYear.Controls.Add(this.panelYearEntryListWrapper);
            this.tabPageEntriesByYear.Controls.Add(this.listBoxYear);
            this.tabPageEntriesByYear.Location = new System.Drawing.Point(4, 22);
            this.tabPageEntriesByYear.Name = "tabPageEntriesByYear";
            this.tabPageEntriesByYear.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEntriesByYear.Size = new System.Drawing.Size(251, 441);
            this.tabPageEntriesByYear.TabIndex = 2;
            this.tabPageEntriesByYear.Text = "Entries by Year";
            this.tabPageEntriesByYear.UseVisualStyleBackColor = true;
            // 
            // tabPageCalendar
            // 
            this.tabPageCalendar.Location = new System.Drawing.Point(4, 22);
            this.tabPageCalendar.Name = "tabPageCalendar";
            this.tabPageCalendar.Size = new System.Drawing.Size(251, 441);
            this.tabPageCalendar.TabIndex = 3;
            this.tabPageCalendar.Text = "Calendar";
            this.tabPageCalendar.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.CustomFormat = "MMMM dd, yyyy hh:mm tt";
            this.dateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(522, 32);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 4;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
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
            this.buttonAddEntry.Image = global::DayOneWindowsClient.Properties.Resources.Plus_32x32;
            this.buttonAddEntry.Location = new System.Drawing.Point(12, 12);
            this.buttonAddEntry.Name = "buttonAddEntry";
            this.buttonAddEntry.Size = new System.Drawing.Size(259, 40);
            this.buttonAddEntry.TabIndex = 0;
            this.toolTip.SetToolTip(this.buttonAddEntry, "Add a new entry");
            this.buttonAddEntry.UseVisualStyleBackColor = true;
            this.buttonAddEntry.Click += new System.EventHandler(this.buttonAddEntry_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Image = global::DayOneWindowsClient.Properties.Resources.Delete_32x32;
            this.buttonDelete.Location = new System.Drawing.Point(866, 12);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(40, 40);
            this.buttonDelete.TabIndex = 8;
            this.toolTip.SetToolTip(this.buttonDelete, "Delete");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonShare
            // 
            this.buttonShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShare.Image = global::DayOneWindowsClient.Properties.Resources.Copy_32x32;
            this.buttonShare.Location = new System.Drawing.Point(820, 12);
            this.buttonShare.Name = "buttonShare";
            this.buttonShare.Size = new System.Drawing.Size(40, 40);
            this.buttonShare.TabIndex = 7;
            this.toolTip.SetToolTip(this.buttonShare, "Share");
            this.buttonShare.UseVisualStyleBackColor = true;
            this.buttonShare.Click += new System.EventHandler(this.buttonShare_Click);
            // 
            // buttonEditSave
            // 
            this.buttonEditSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditSave.Image = global::DayOneWindowsClient.Properties.Resources.Edit_32x32;
            this.buttonEditSave.Location = new System.Drawing.Point(728, 12);
            this.buttonEditSave.Name = "buttonEditSave";
            this.buttonEditSave.Size = new System.Drawing.Size(40, 40);
            this.buttonEditSave.TabIndex = 5;
            this.toolTip.SetToolTip(this.buttonEditSave, "Edit");
            this.buttonEditSave.UseVisualStyleBackColor = true;
            this.buttonEditSave.Click += new System.EventHandler(this.buttonEditSave_Click);
            // 
            // buttonStar
            // 
            this.buttonStar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStar.Image = global::DayOneWindowsClient.Properties.Resources.StarGray_32x32;
            this.buttonStar.Location = new System.Drawing.Point(774, 12);
            this.buttonStar.Name = "buttonStar";
            this.buttonStar.Size = new System.Drawing.Size(40, 40);
            this.buttonStar.TabIndex = 6;
            this.toolTip.SetToolTip(this.buttonStar, "Star");
            this.buttonStar.UseVisualStyleBackColor = true;
            this.buttonStar.Click += new System.EventHandler(this.buttonStar_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Image = global::DayOneWindowsClient.Properties.Resources.Settings_32x32;
            this.buttonSettings.Location = new System.Drawing.Point(277, 12);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(40, 40);
            this.buttonSettings.TabIndex = 3;
            this.toolTip.SetToolTip(this.buttonSettings, "Settings");
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
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
            // listBoxYear
            // 
            this.listBoxYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxYear.FormattingEnabled = true;
            this.listBoxYear.Location = new System.Drawing.Point(3, 3);
            this.listBoxYear.Name = "listBoxYear";
            this.listBoxYear.Size = new System.Drawing.Size(245, 82);
            this.listBoxYear.TabIndex = 0;
            this.listBoxYear.SelectedIndexChanged += new System.EventHandler(this.listBoxYear_SelectedIndexChanged);
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
            this.entryListBoxAll.SelectedIndexChanged += new System.EventHandler(this.entryListBox_SelectedIndexChanged);
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
            this.entryListBoxStarred.SelectedIndexChanged += new System.EventHandler(this.entryListBox_SelectedIndexChanged);
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
            this.entryListBoxYear.SelectedIndexChanged += new System.EventHandler(this.entryListBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(918, 573);
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
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Day One Windows Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabLeftPanel.ResumeLayout(false);
            this.tabPageAllEntries.ResumeLayout(false);
            this.tabPageStarred.ResumeLayout(false);
            this.tabPageEntriesByYear.ResumeLayout(false);
            this.tableLayoutStats.ResumeLayout(false);
            this.tableLayoutStats.PerformLayout();
            this.panelYearEntryListWrapper.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox textEntryText;
        private EntryListBox entryListBoxStarred;
        private System.Windows.Forms.Panel panelYearEntryListWrapper;
        private EntryListBox entryListBoxYear;
        private System.Windows.Forms.ListBox listBoxYear;
    }
}

