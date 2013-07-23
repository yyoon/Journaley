using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DayOneWindowsClient.Properties;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Globalization;
using MarkdownSharp;
using DayOneWindowsClient.Utilities;
using DayOneWindowsClient.Controls;

namespace DayOneWindowsClient.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Icon = Resources.MainIcon;

            this.FormLoaded = false;
        }

        private Settings Settings { get; set; }

        private List<Entry> Entries { get; set; }

        private Entry _selectedEntry;
        private Entry SelectedEntry
        {
            get { return _selectedEntry; }
            set
            {
                if (_selectedEntry == value)
                    return;

                // Save / Cleanup
                if (_selectedEntry != null)
                {
                    // If this is still in the Entries list, it's alive.
                    if (this.Entries.Contains(_selectedEntry))
                    {
                        SaveSelectedEntry();
                    }
                }

                _selectedEntry = value;

                if (_selectedEntry != null)
                {
                    _isEditing = _selectedEntry.IsDirty;

                    this.dateTimePicker.Value = _selectedEntry.LocalTime;
                    this.textEntryText.Text = _selectedEntry.EntryText.Replace("\n", Environment.NewLine);
                    UpdateWebBrowser();
                }
                else
                {
                    _isEditing = false;
                }

                UpdateStar();
                UpdateUI();

                HighlightSelectedEntry();
            }
        }

        private void UpdateWebBrowser()
        {
            this.webBrowser.DocumentText =
                string.Format(
                "<html style='margin:0;padding:2px'><body style='font-family:sans-serif;font-size:9pt'>{0}</body></html>",
                Markdown.Transform(this.SelectedEntry.EntryText)
                );
        }

        private void SaveSelectedEntry()
        {
            if (this.SelectedEntry == null)
                return;

            this.SelectedEntry.EntryText = this.textEntryText.Text.Replace(Environment.NewLine, "\n");

            if (this.SelectedEntry.IsDirty)
            {
                this.SelectedEntry.Save(this.Settings.DayOneFolderPath);

                // Update the EntryList items as well.
                foreach (var list in GetAllEntryLists())
                {
                    int index = list.Items.IndexOf(this.SelectedEntry);
                    if (index != -1)
                    {
                        list.Invalidate(list.GetItemRectangle(index));
                    }
                }
            }
        }

        private IEnumerable<EntryListBox> GetAllEntryLists()
        {
            foreach (TabPage page in this.tabLeftPanel.TabPages)
            {
                foreach (var list in page.Controls.OfType<EntryListBox>())
                    yield return list;
            }
        }

        private bool _isEditing;
        private bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                UpdateUI();
            }
        }

        private bool FormLoaded { get; set; }

        private Markdown _markdown;
        private Markdown Markdown
        {
            get
            {
                if (_markdown == null)
                {
                    _markdown = new Markdown();
                    _markdown.AutoNewLines = true;
                }

                return _markdown;
            }
        }

        private void UpdateUI()
        {
            bool noEntry = this.SelectedEntry == null;

            this.dateTimePicker.CustomFormat = noEntry ? " " : "MMM d, yyyy hh:mm tt";
            this.buttonEditSave.Enabled = !noEntry;
            this.buttonStar.Enabled = !noEntry;
            this.buttonShare.Enabled = !noEntry;
            this.buttonDelete.Enabled = !noEntry;
            this.textEntryText.Enabled = !noEntry;

            if (noEntry)
            {
                this.textEntryText.Text = "";
                this.webBrowser.DocumentText = "";
            }

            this.dateTimePicker.Enabled = this.IsEditing;
            this.buttonEditSave.Image = this.IsEditing ? Properties.Resources.Save_32x32 : Properties.Resources.Edit_32x32;
            this.toolTip.SetToolTip(this.buttonEditSave, this.IsEditing ? "Save" : "Edit");
            this.textEntryText.ReadOnly = !this.IsEditing;

            this.textEntryText.Visible = this.IsEditing;
            this.panelWebBrowserWrapper.Visible = this.webBrowser.Visible = noEntry || !this.IsEditing;
        }

        private void UpdateStar()
        {
            this.buttonStar.Image = (this.SelectedEntry != null && this.SelectedEntry.Starred) ?
                Properties.Resources.StarYellow_32x32 : Properties.Resources.StarGray_32x32;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set Current Culture
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");

            // Disable the click sound of the web browser for this process.
            // http://stackoverflow.com/questions/393166/how-to-disable-click-sound-in-webbrowser-control
            PInvoke.CoInternetSetFeatureEnabled(
                21,     // FEATURE_DISABLE_NAVIGATION_SOUNDS
                2,      // SET_FEATURE_ON_PROCESS
                true    // Enable
                );

            // Get the settings file.
            this.Settings = Settings.GetSettingsFile();

            // When there is no settings file, show up the settings dialog first.
            if (this.Settings == null)
            {
                SettingsForm settingsForm = new SettingsForm();
                DialogResult result = settingsForm.ShowDialog();
                Debug.Assert(result == DialogResult.OK);

                Debug.Assert(Directory.Exists(settingsForm.Settings.DayOneFolderPath));
                this.Settings = settingsForm.Settings;
                this.Settings.Save();
            }
            // If there was a password set, ask it before showing the main form!
            else if (this.Settings.HasPassword)
            {
                PasswordInputForm form = new PasswordInputForm(this.Settings);
                DialogResult result = form.ShowDialog();

                // If the user cancels the password input dialog, just close the whole application.
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    Close();
                    return;
                }
            }

            Debug.Assert(this.Settings != null);

            LoadEntries();

            UpdateFromScratch();

            // Trick to bring this form to the front
            this.TopMost = true;
            this.TopMost = false;

            // Finished Loading
            this.FormLoaded = true;
        }

        protected void OnActivateApp(bool activate)
        {
            if (activate == false)
                return;

            if (this.FormLoaded == false)
                return;

            if (this.Settings.HasPassword)
            {
                // Hide the main form first.
                Hide();

                // Show the password input dialog
                PasswordInputForm form = new PasswordInputForm(this.Settings);
                DialogResult result = form.ShowDialog();

                // If the user cancels the password input dialog, just close the whole application.
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    Close();
                    return;
                }
                else
                {
                    Show();
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x001C:    // WM_ACTIVATEAPP
                    OnActivateApp(m.WParam != IntPtr.Zero);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void UpdateFromScratch()
        {
            UpdateStats();
            UpdateAllEntryLists();
            UpdateUI();
        }

        private void UpdateStats()
        {
            this.labelEntries.Text = GetAllEntriesCount().ToString();
            this.labelDays.Text = GetDaysCount().ToString();
            this.labelThisWeek.Text = GetThisWeekCount(DateTime.Now).ToString();
            this.labelToday.Text = GetTodayCount(DateTime.Now).ToString();
        }

        private int GetAllEntriesCount()
        {
            return this.Entries.Count;
        }

        private int GetDaysCount()
        {
            return this.Entries.Select(x => x.LocalTime.Date).Distinct().Count();
        }

        private int GetThisWeekCount(DateTime now)
        {
            Debug.Assert(now.Kind == DateTimeKind.Local);

            int offsetFromSunday = now.DayOfWeek - DayOfWeek.Sunday;
            DateTime basis = now.AddDays(-offsetFromSunday).Date;

            return this.Entries.Where(x => basis <= x.LocalTime.Date && x.LocalTime <= now).Count();
        }

        private int GetTodayCount(DateTime now)
        {
            Debug.Assert(now.Kind == DateTimeKind.Local);

            return this.Entries.Where(x => x.LocalTime.Date == now.Date).Count();
        }

        private void UpdateAllEntryLists()
        {
            UpdateEntryListBoxAll();
            UpdateEntryListBoxStarred();
            UpdateEntryListBoxYear();
            UpdateEntryListBoxCalendar();
        }

        private void UpdateEntryListBoxAll()
        {
            UpdateEntryList(this.Entries, this.entryListBoxAll);
        }

        private void UpdateEntryListBoxStarred()
        {
            UpdateEntryList(this.Entries.Where(x => x.Starred), this.entryListBoxStarred);
        }

        private class YearCountEntry
        {
            public YearCountEntry(int year, int count)
            {
                this.Year = year;
                this.Count = count;
            }

            public int Year { get; set; }
            public int Count { get; set; }

            public override string ToString()
            {
                return string.Format("Year of {0} ({1} entries)", Year, Count);
            }
        }

        private void UpdateEntryListBoxYear()
        {
            // Clear everything.
            this.listBoxYear.Items.Clear();
            this.listBoxYear.SelectedIndex = -1;

            // First item is always "all years"
            this.listBoxYear.Items.Add("All Years");

            // Get the years and entry count for each year, in reverse order.
            var yearsAndCounts = this.Entries
                .GroupBy(x => x.LocalTime.Year)
                .Select(x => new YearCountEntry(x.Key, x.Count()))
                .OrderByDescending(x => x.Year);

            // If there is any entry,
            if (yearsAndCounts.Any())
            {
                // Add to the top list box first.
                this.listBoxYear.Items.AddRange(yearsAndCounts.ToArray());

                // Select the second item (this will invoke the event handler and eventually the entry list box will be filled)
                this.listBoxYear.SelectedIndex = 1;
            }
            else
            {
                // Select the first item
                this.listBoxYear.SelectedIndex = 0;
            }

            // Resize the upper list box
            this.listBoxYear.Height = this.listBoxYear.PreferredHeight;
        }

        private void listBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Assert(sender == this.listBoxYear);

            switch (this.listBoxYear.SelectedIndex)
            {
                case -1:
                    this.entryListBoxYear.Items.Clear();
                    break;

                case 0:
                    UpdateEntryList(this.Entries, this.entryListBoxYear);
                    break;

                default:
                    {
                        YearCountEntry entry = this.listBoxYear.SelectedItem as YearCountEntry;
                        if (entry != null)
                        {
                            UpdateEntryList(this.Entries.Where(x => x.LocalTime.Year == entry.Year), this.entryListBoxYear);
                        }
                        else
                        {
                            // This should not happen.
                            Debug.Assert(false);
                        }
                    }
                    break;
            }
        }

        private void UpdateEntryListBoxCalendar()
        {
            // Update the bold dates
            this.monthCalendar.BoldedDates = this.Entries.Select(x => x.LocalTime.Date).Distinct().ToArray();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            Debug.Assert(sender == this.monthCalendar);
            Debug.Assert(e.Start.ToShortDateString() == e.End.ToShortDateString());

            UpdateEntryList(this.Entries.Where(x => x.LocalTime.ToShortDateString() == e.Start.ToShortDateString()), this.entryListBoxCalendar);
        }

        private void UpdateEntryList(IEnumerable<Entry> entries, EntryListBox list)
        {
            // Clear everything.
            list.Items.Clear();

            // Reverse sort and group by month.
            var groupedEntries = entries
                .OrderByDescending(x => x.UTCDateTime)
                .GroupBy(x => new DateTime(x.LocalTime.Year, x.LocalTime.Month, 1));

            // Add the list items
            foreach (var group in groupedEntries)
            {
                // Add the month group bar
                list.Items.Add(group.Key);
                list.Items.AddRange(group.ToArray());
            }

            HighlightSelectedEntry(list);
        }

        private void HighlightSelectedEntry()
        {
            HighlightSelectedYearInList();
            HighlightSelectedEntryInCalendar();

            foreach (var list in GetAllEntryLists())
                HighlightSelectedEntry(list);
        }

        private void HighlightSelectedYearInList()
        {
            if (this.SelectedEntry != null)
            {
                int index = -1;
                for (int i = 1; i < this.listBoxYear.Items.Count; ++i)
                {
                    YearCountEntry entry = this.listBoxYear.Items[i] as YearCountEntry;
                    if (entry == null) { continue; }

                    if (this.SelectedEntry.LocalTime.Year == entry.Year)
                    {
                        index = i;
                        break;
                    }
                }

                if (index != -1)
                {
                    this.listBoxYear.SelectedIndex = index;
                }
            }
        }

        private void HighlightSelectedEntryInCalendar()
        {
            if (this.SelectedEntry != null)
            {
                this.monthCalendar.SelectionStart = this.monthCalendar.SelectionEnd = this.SelectedEntry.LocalTime.Date;
            }
        }

        private void HighlightSelectedEntry(EntryListBox list)
        {
            // If there is already a selected entry, select it!
            if (this.SelectedEntry != null)
            {
                int index = list.Items.IndexOf(this.SelectedEntry);
                if (list.SelectedIndex != index)
                {
                    if (index != -1)
                    {
                        list.SelectedIndex = index;
                        if (index > 0 && list.Items[index - 1] is DateTime)
                        {
                            list.TopIndex = index - 1;
                        }
                        else
                        {
                            list.TopIndex = index;
                        }
                    }
                    else
                    {
                        list.SelectedIndex = -1;
                    }
                }
            }
        }

        private void LoadEntries()
        {
            LoadEntries(this.Settings.DayOneFolderPath);
        }

        private void LoadEntries(string path)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);
            FileInfo[] files = dinfo.GetFiles("*.doentry");

            this.Entries = files.Select(x => Entry.LoadFromFile(x.FullName)).Where(x => x != null).ToList();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.Settings = new Settings(this.Settings);    // pass a copied settings object
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                // TODO: Update something. maybe load everything from scratch if the directory has been changed.
                this.Settings = form.Settings;
                this.Settings.Save();
            }
        }

        private void entryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Highlight the entries that represents the currently selected journal entry
            // in all the entry list boxes.
            EntryListBox entryListBox = sender as EntryListBox;
            if (entryListBox == null)
                return;

            if (entryListBox.SelectedIndex == -1)
            {
                this.SelectedEntry = null;
                return;
            }

            this.SelectedEntry = entryListBox.Items[entryListBox.SelectedIndex] as Entry;
        }

        private void buttonEditSave_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null);

            if (this.IsEditing)
            {
                SaveSelectedEntry();
                this.IsEditing = false;

                UpdateWebBrowser();
                UpdateUI();
            }
            else
            {
                this.IsEditing = true;
                this.textEntryText.Focus();
            }
        }

        private void buttonStar_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null);

            this.SelectedEntry.Starred ^= true;
            SaveSelectedEntry();

            UpdateStar();
            UpdateEntryListBoxStarred();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null);

            DialogResult result = MessageBox.Show(
                "Do you really want to delete this journal entry?",
                "Delete entry",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
                );

            if (result == System.Windows.Forms.DialogResult.No)
                return;

            this.Entries.Remove(this.SelectedEntry);
            this.SelectedEntry.Delete(this.Settings.DayOneFolderPath);

            UpdateFromScratch();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null);

            if (this.IsEditing)
            {
                this.SelectedEntry.UTCDateTime = this.dateTimePicker.Value.ToUniversalTime();
                UpdateAllEntryLists();
            }
        }

        private void buttonAddEntry_Click(object sender, EventArgs e)
        {
            Entry newEntry = new Entry();
            this.Entries.Add(newEntry);

            this.SelectedEntry = newEntry;
            UpdateAllEntryLists();
        }

        private void buttonShare_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null);
            Debug.Assert(sender == this.buttonShare);

            this.contextMenuStripShare.Show(
                this.buttonShare,
                new Point { X = this.buttonShare.Width, Y = this.buttonShare.Height },
                ToolStripDropDownDirection.BelowLeft
                );
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null);

            Clipboard.SetDataObject(this.textEntryText.Text, true);
            MessageBox.Show(this, "The entry text has been successfully copied to the clipboard.", "Copy to Clipboard", MessageBoxButtons.OK);
        }

        private void emailThisEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null);

            string encodedBody = Uri.EscapeUriString(this.textEntryText.Text);
            string link = string.Format("mailto:?body={0}", encodedBody);

            Process.Start(link);
        }
    }
}
