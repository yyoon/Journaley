namespace Journaley.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using Journaley.Controls;
    using Journaley.Models;
    using Journaley.Utilities;
    using MarkdownSharp;

    /// <summary>
    /// The Main Form of the application. Contains the entry list, preview, buttons, etc.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The backing field of selected entry
        /// </summary>
        private Entry selectedEntry;

        /// <summary>
        /// The backing field for IsEditing.
        /// </summary>
        private bool isEditing;

        /// <summary>
        /// The backing field for markdown object.
        /// </summary>
        private Markdown markdown;

        /// <summary>
        /// Internal field to indicate whether to suppress the entry update process.
        /// </summary>
        private bool suppressEntryUpdate = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.Icon = Journaley.Properties.Resources.JournaleyIcon;
            this.FormLoaded = false;
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        private Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        /// <value>
        /// The entries.
        /// </value>
        private List<Entry> Entries { get; set; }

        /// <summary>
        /// Gets or sets the selected entry.
        /// Performs some cleanup activities when setting a new selected entry.
        /// </summary>
        /// <value>
        /// The selected entry.
        /// </value>
        private Entry SelectedEntry
        {
            get
            {
                return this.selectedEntry;
            }

            set
            {
                if (this.selectedEntry == value)
                {
                    return;
                }

                // Save / Cleanup
                if (this.selectedEntry != null)
                {
                    // If this is still in the Entries list, it's alive.
                    if (this.Entries.Contains(this.selectedEntry))
                    {
                        this.SaveSelectedEntry();
                    }
                }

                this.selectedEntry = value;

                if (this.selectedEntry != null)
                {
                    this.isEditing = this.selectedEntry.IsDirty;

                    this.dateTimePicker.Value = this.selectedEntry.LocalTime;
                    this.textEntryText.Text = this.selectedEntry.EntryText.Replace("\n", Environment.NewLine);
                    this.UpdateWebBrowser();
                }
                else
                {
                    this.isEditing = false;
                }

                this.UpdateStar();
                this.UpdatePhotoButton();
                this.UpdateTag();
                this.UpdateUI();

                this.UpdateWordCounts();

                this.HighlightSelectedEntry();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a journal entry is being edited.
        /// </summary>
        /// <value>
        /// <c>true</c> if a journal entry is being edited; otherwise, <c>false</c>.
        /// </value>
        private bool IsEditing
        {
            get
            {
                return this.isEditing;
            }

            set
            {
                this.isEditing = value;
                this.UpdateUI();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this form is loaded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this form is loaded; otherwise, <c>false</c>.
        /// </value>
        private bool FormLoaded { get; set; }

        /// <summary>
        /// Gets the markdown object.
        /// </summary>
        /// <value>
        /// The markdown.
        /// </value>
        private Markdown Markdown
        {
            get
            {
                if (this.markdown == null)
                {
                    this.markdown = new Markdown();
                    ((MarkdownSharp.MarkdownOptions)this.markdown.Options).AutoNewLines = true;
                }

                return this.markdown;
            }
        }

        /// <summary>
        /// Updates the web browser content with the Markdown-processed journal entry.
        /// </summary>
        private void UpdateWebBrowser()
        {
            this.webBrowser.DocumentText =
                string.Format(
                @"<html style='margin:0;padding:2px'><body style='font-family:sans-serif;font-size:9pt'>{0}{1}</body></html>",
                this.SelectedEntry.PhotoPath == null ? string.Empty : "<img src='" + this.SelectedEntry.PhotoPath + "' style='width:100%'><br>",
                Markdown.Transform(this.SelectedEntry.EntryText));
        }

        /// <summary>
        /// Saves the selected entry.
        /// </summary>
        private void SaveSelectedEntry()
        {
            if (this.SelectedEntry == null)
            {
                return;
            }

            this.SelectedEntry.EntryText = this.textEntryText.Text.Replace(Environment.NewLine, "\n");

            if (this.SelectedEntry.IsDirty)
            {
                this.SelectedEntry.Save(this.Settings.EntryFolderPath);

                // Update the EntryList items as well.
                this.InvalidateEntryInEntryList(this.SelectedEntry);
            }
        }

        /// <summary>
        /// Invalidates the entry in all the entry lists, and forces the entry to be redrawn.
        /// </summary>
        /// <param name="entry">The entry.</param>
        private void InvalidateEntryInEntryList(Entry entry)
        {
            foreach (var list in this.GetAllEntryLists())
            {
                int index = list.Items.IndexOf(entry);
                if (index != -1)
                {
                    list.Invalidate(list.GetItemRectangle(index));
                }
            }
        }

        /// <summary>
        /// Gets all EntryList objects.
        /// </summary>
        /// <returns>All the EntryList objects</returns>
        private IEnumerable<EntryListBox> GetAllEntryLists()
        {
            foreach (TabPage page in this.tabLeftPanel.TabPages)
            {
                foreach (var list in page.Controls.OfType<EntryListBox>())
                {
                    yield return list;
                }
            }
        }

        /// <summary>
        /// Updates the UI.
        /// Enables / Disables buttons, depending upon the selected entry.
        /// </summary>
        private void UpdateUI()
        {
            bool noEntry = this.SelectedEntry == null;

            this.dateTimePicker.CustomFormat = noEntry ? " " : "MMM d, yyyy hh:mm tt";
            this.buttonEditSave.Enabled = !noEntry;
            this.buttonStar.Enabled = !noEntry;
            this.buttonPhoto.Enabled = !noEntry;
            this.buttonTag.Enabled = !noEntry;
            this.buttonShare.Enabled = !noEntry;
            this.buttonDelete.Enabled = !noEntry;
            this.textEntryText.Enabled = !noEntry;

            if (noEntry)
            {
                this.textEntryText.Text = string.Empty;
                this.webBrowser.DocumentText = string.Empty;
            }

            this.dateTimePicker.Enabled = this.IsEditing;
            this.buttonEditSave.Image = this.IsEditing ? Properties.Resources.Save_32x32 : Properties.Resources.Edit_32x32;
            this.toolTip.SetToolTip(this.buttonEditSave, this.IsEditing ? "Save" : "Edit");
            this.textEntryText.ReadOnly = !this.IsEditing;

            this.textEntryText.Visible = this.IsEditing;
            this.panelWebBrowserWrapper.Visible = this.webBrowser.Visible = noEntry || !this.IsEditing;
        }

        /// <summary>
        /// Updates the star button's look.
        /// </summary>
        private void UpdateStar()
        {
            this.buttonStar.Image = (this.SelectedEntry != null && this.SelectedEntry.Starred) ?
                Properties.Resources.StarYellow_32x32 : Properties.Resources.StarGray_32x32;
        }

        /// <summary>
        /// Updates the photo button's look.
        /// </summary>
        private void UpdatePhotoButton()
        {
            this.buttonPhoto.Image = (this.SelectedEntry != null && this.SelectedEntry.PhotoPath != null) ?
                Properties.Resources.Image_32x32 : Properties.Resources.ImageGray_32x32;
        }

        /// <summary>
        /// Updates the tag button's look.
        /// </summary>
        private void UpdateTag()
        {
            this.buttonTag.Image = (this.SelectedEntry != null && this.SelectedEntry.Tags.Any()) ?
                Properties.Resources.TagGreen_32x32 : Properties.Resources.TagWhite_32x32;
        }

        /// <summary>
        /// Updates everything from scratch.
        /// </summary>
        private void UpdateFromScratch()
        {
            this.UpdateStats();
            this.UpdateAllEntryLists();
            this.UpdateUI();
        }

        /// <summary>
        /// Updates the statistics (number of entries).
        /// </summary>
        private void UpdateStats()
        {
            this.labelEntries.Text = this.GetAllEntriesCount().ToString();
            this.labelThisWeek.Text = this.GetThisWeekCount(DateTime.Now).ToString();
            this.labelToday.Text = this.GetTodayCount(DateTime.Now).ToString();
        }

        /// <summary>
        /// Gets the number of all entries.
        /// </summary>
        /// <returns>The number of all entries</returns>
        private int GetAllEntriesCount()
        {
            return this.Entries.Count;
        }

        /// <summary>
        /// Gets the number of all days which have one or more entries.
        /// </summary>
        /// <returns>The number of all days which have one or more entries</returns>
        private int GetDaysCount()
        {
            return this.Entries.Select(x => x.LocalTime.Date).Distinct().Count();
        }

        /// <summary>
        /// Gets the number of entries written within this week count.
        /// </summary>
        /// <param name="now">A DateTime object of which kind is DateTimeKind.Local (Usually, just use DateTime.Now)</param>
        /// <returns>The number of entries written within this week count</returns>
        private int GetThisWeekCount(DateTime now)
        {
            Debug.Assert(now.Kind == DateTimeKind.Local, "\"now\" parameter must be of DateTimeKind.Local");

            int offsetFromSunday = now.DayOfWeek - DayOfWeek.Sunday;
            DateTime basis = now.AddDays(-offsetFromSunday).Date;

            return this.Entries.Where(x => basis <= x.LocalTime.Date && x.LocalTime <= now).Count();
        }

        /// <summary>
        /// Gets the number of entries of today.
        /// </summary>
        /// <param name="now">A DateTime object of which kind is DateTimeKind.Local (Usually, just use DateTime.Now)</param>
        /// <returns>The number of entries of today</returns>
        private int GetTodayCount(DateTime now)
        {
            Debug.Assert(now.Kind == DateTimeKind.Local, "\"now\" parameter must be of DateTimeKind.Local");

            return this.Entries.Where(x => x.LocalTime.Date == now.Date).Count();
        }

        /// <summary>
        /// Updates all the entry lists.
        /// </summary>
        private void UpdateAllEntryLists()
        {
            this.UpdateEntryListBoxAll();
            this.UpdateEntryListBoxTags();
            this.UpdateEntryListBoxYear();
            this.UpdateEntryListBoxCalendar();
        }

        /// <summary>
        /// Updates the entry list box of "All" tab.
        /// </summary>
        private void UpdateEntryListBoxAll()
        {
            this.UpdateEntryList(this.Entries, this.entryListBoxAll);
        }

        /// <summary>
        /// Updates the entry list box of "Tags" tab.
        /// </summary>
        private void UpdateEntryListBoxTags()
        {
            // Clear everything.
            this.listBoxTags.Items.Clear();
            this.listBoxTags.SelectedIndex = -1;

            // First, display all the starred entries.
            int starredCount = this.Entries.Count(e => e.Starred);
            if (starredCount > 0)
            {
                this.listBoxTags.Items.Add(new StarredCountEntry(starredCount));
            }

            // Then, collect all the tags.
            var tags = this.Entries
                .SelectMany(x => x.Tags)
                .Distinct();

            var tagsAndCounts = tags
                .Select(x => new TagCountEntry(x, this.Entries.Count(e => e.Tags.Contains(x))))
                .OrderByDescending(x => x.Count);

            // If there is any entry,
            if (tagsAndCounts.Any())
            {
                // Add to the top list box first.
                this.listBoxTags.Items.AddRange(tagsAndCounts.ToArray());
            }

            // Select the first item.
            if (this.listBoxTags.Items.Count > 0)
            {
                this.listBoxTags.SelectedIndex = 0;
            }

            // Resize the upper list box
            this.listBoxTags.Height = this.listBoxTags.PreferredHeight;
        }

        /// <summary>
        /// Updates the entry list box of "Entries by Year" tab.
        /// </summary>
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

        /// <summary>
        /// Updates the entry list box of "Calendar" tab.
        /// </summary>
        private void UpdateEntryListBoxCalendar()
        {
            // Update the bold dates
            this.monthCalendar.BoldedDates = this.Entries.Select(x => x.LocalTime.Date).Distinct().ToArray();

            this.UpdateEntryList(this.Entries.Where(x => x.LocalTime.ToShortDateString() == this.monthCalendar.SelectionStart.ToShortDateString()), this.entryListBoxCalendar);
        }

        /// <summary>
        /// Updates the given entry list with the given entries.
        /// Used by other Update methods.
        /// </summary>
        /// <param name="entries">The entries to be filled in the list.</param>
        /// <param name="list">The EntryListBox list.</param>
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

            this.HighlightSelectedEntry(list);
        }

        /// <summary>
        /// Updates the word counts.
        /// </summary>
        private void UpdateWordCounts()
        {
            char[] delim = new char[] { '\n', '\r', '\t', ' ' };
 
            if (this.SelectedEntry != null)
            {
                string entryText = this.IsEditing ? this.textEntryText.Text : this.SelectedEntry.EntryText;

                this.labelWords.Text = entryText
                    .Split(delim, StringSplitOptions.RemoveEmptyEntries)
                    .Length
                    .ToString();
                this.labelWordsTitle.Text = "WORDS";

                this.labelCharacters.Text = entryText
                    .Count(x => !delim.Contains(x))
                    .ToString();
                this.labelCharactersTitle.Text = "CHARACTERS";
            }
            else
            {
                this.labelWords.Text = string.Empty;
                this.labelWordsTitle.Text = string.Empty;

                this.labelCharacters.Text = string.Empty;
                this.labelCharactersTitle.Text = string.Empty;
            }
        }

        /// <summary>
        /// Highlights the selected entry.
        /// </summary>
        private void HighlightSelectedEntry()
        {
            this.HighlightSelectedYearInList();
            this.HighlightSelectedEntryInCalendar();

            foreach (var list in this.GetAllEntryLists())
            {
                this.HighlightSelectedEntry(list);
            }
        }

        /// <summary>
        /// Highlights the selected year in list.
        /// </summary>
        private void HighlightSelectedYearInList()
        {
            if (this.SelectedEntry != null)
            {
                int index = -1;
                for (int i = 1; i < this.listBoxYear.Items.Count; ++i)
                {
                    YearCountEntry entry = this.listBoxYear.Items[i] as YearCountEntry;
                    if (entry == null)
                    {
                        continue;
                    }

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

        /// <summary>
        /// Highlights the selected entry in calendar.
        /// </summary>
        private void HighlightSelectedEntryInCalendar()
        {
            if (this.SelectedEntry != null)
            {
                this.monthCalendar.SelectionStart = this.monthCalendar.SelectionEnd = this.SelectedEntry.LocalTime.Date;
            }
        }

        /// <summary>
        /// Highlights the selected entry.
        /// </summary>
        /// <param name="list">The list.</param>
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

        /// <summary>
        /// Loads the entries.
        /// </summary>
        private void LoadEntries()
        {
            this.LoadEntries(this.Settings.EntryFolderPath);
        }

        /// <summary>
        /// Loads the entries.
        /// </summary>
        /// <param name="path">The path to the entry files.</param>
        private void LoadEntries(string path)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);
            FileInfo[] files = dinfo.GetFiles("*.doentry");

            this.Entries = files.Select(x => Entry.LoadFromFile(x.FullName, this.Settings)).Where(x => x != null).ToList();
        }

        #region Event Handlers

        /// <summary>
        /// Handles the Click event of the emailThisEntryToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EmailThisEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when emailing.");

            string encodedBody = Uri.EscapeUriString(this.textEntryText.Text);
            string link = string.Format("mailto:?body={0}", encodedBody);

            Process.Start(link);
        }

        /// <summary>
        /// Handles the Load event of this form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
                true);  // Enable

            // Get the settings file.
            this.Settings = Settings.GetSettingsFile();

            if (this.Settings == null)
            {
            // When there is no settings file, show up the settings dialog first.
                SettingsForm settingsForm = new SettingsForm();
                DialogResult result = settingsForm.ShowDialog();
                Debug.Assert(result == DialogResult.OK, "When running the application for the first time, you must choose the settings.");

                Debug.Assert(Directory.Exists(settingsForm.Settings.DayOneFolderPath), "The selected path must exist");
                this.Settings = settingsForm.Settings;
                this.Settings.Save();
            }
            else if (this.Settings.HasPassword)
            {
            // If there was a password set, ask it before showing the main form!
                PasswordInputForm form = new PasswordInputForm(this.Settings);
                DialogResult result = form.ShowDialog();

                // If the user cancels the password input dialog, just close the whole application.
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.Close();
                    return;
                }
            }

            Debug.Assert(this.Settings != null, "At this point, a valid Settings object must be present.");

            this.LoadEntries();

            this.UpdateFromScratch();

            // Trick to bring this form to the front
            this.TopMost = true;
            this.TopMost = false;

            // Finished Loading
            this.FormLoaded = true;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the listBoxYear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ListBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Assert(sender == this.listBoxYear, "sender must be this.listBoxYear");

            switch (this.listBoxYear.SelectedIndex)
            {
                case -1:
                    this.entryListBoxYear.Items.Clear();
                    break;

                case 0:
                    this.UpdateEntryList(this.Entries, this.entryListBoxYear);
                    break;

                default:
                    {
                        YearCountEntry entry = this.listBoxYear.SelectedItem as YearCountEntry;
                        if (entry != null)
                        {
                            this.UpdateEntryList(this.Entries.Where(x => x.LocalTime.Year == entry.Year), this.entryListBoxYear);
                        }
                        else
                        {
                            // This should not happen.
                            Debug.Assert(false, "Unexpected control flow.");
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ListBoxTags control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ListBoxTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Assert(sender == this.listBoxTags, "sender must be this.listBoxTags");

            switch (this.listBoxTags.SelectedIndex)
            {
                case -1:
                    this.entryListBoxTags.Items.Clear();
                    break;

                default:
                    {
                        TagCountEntry entry = this.listBoxTags.SelectedItem as TagCountEntry;
                        if (entry != null)
                        {
                            if (entry is StarredCountEntry)
                            {
                                this.UpdateEntryList(this.Entries.Where(x => x.Starred), this.entryListBoxTags);
                            }
                            else
                            {
                                this.UpdateEntryList(this.Entries.Where(x => x.Tags.Contains(entry.Tag)), this.entryListBoxTags);
                            }
                        }
                        else
                        {
                            // This should not happen.
                            Debug.Assert(false, "Unexpected control flow.");
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Handles the DateChanged event of the monthCalendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DateRangeEventArgs"/> instance containing the event data.</param>
        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            Debug.Assert(sender == this.monthCalendar, "sender must be this.monthCalendar");
            Debug.Assert(e.Start.ToShortDateString() == e.End.ToShortDateString(), "e.Start must be the same as e.End");

            this.UpdateEntryList(this.Entries.Where(x => x.LocalTime.ToShortDateString() == e.Start.ToShortDateString()), this.entryListBoxCalendar);
        }

        /// <summary>
        /// Handles the Click event of the buttonSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSettings_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Handles the Click event of the buttonEditSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonEditSave_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when saving.");

            if (this.IsEditing)
            {
                this.SaveSelectedEntry();
                this.IsEditing = false;

                this.UpdateWebBrowser();
                this.UpdateUI();
            }
            else
            {
                this.IsEditing = true;
                this.textEntryText.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonStar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonStar_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when starring.");

            this.SelectedEntry.Starred ^= true;
            this.SaveSelectedEntry();

            this.UpdateStar();
            this.UpdateEntryListBoxTags();
        }

        /// <summary>
        /// Handles the Click event of the buttonPhoto control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonPhoto_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selectd entry when modifying photo.");

            ContextMenuStrip menuStrip = this.SelectedEntry.PhotoPath != null
                ? this.contextMenuStripPhotoWithPhoto
                : this.contextMenuStripPhotoWithoutPhoto;

            menuStrip.Show(
                this.buttonPhoto,
                new Point { X = this.buttonPhoto.Width, Y = this.buttonShare.Height },
                ToolStripDropDownDirection.BelowLeft);
        }

        /// <summary>
        /// Handles the Click event of the ButtonTag control.
        /// Creates a TagEditForm instance and show it right below the tag button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonTag_Click(object sender, EventArgs e)
        {
            TagEditForm tagEditForm = new TagEditForm();
            tagEditForm.StartPosition = FormStartPosition.Manual;
            tagEditForm.Location = this.PointToScreen(
                new Point(
                    this.buttonTag.Location.X + this.buttonTag.Width - tagEditForm.Width,
                    this.buttonTag.Location.Y + this.buttonTag.Height));

            tagEditForm.AssignedTags.AddRange(this.SelectedEntry.Tags.OrderBy(x => x));
            tagEditForm.OtherTags.AddRange(this.Entries.SelectMany(x => x.Tags).Distinct().Where(x => !this.SelectedEntry.Tags.Contains(x)).OrderBy(x => x));

            // Event handlers.
            tagEditForm.FormClosed += new FormClosedEventHandler(this.TagEditForm_FormClosed);

            // Show the form as modeless.
            tagEditForm.Show(this);
        }

        /// <summary>
        /// Handles the FormClosed event of the TagEditForm.
        /// Checks if any of the tags were changed. If so, update and save the entry, update the UI status.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.ArgumentException">Thrown when the sender is not TagEditForm</exception>
        private void TagEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TagEditForm tagEditForm = sender as TagEditForm;
            if (tagEditForm == null)
            {
                throw new ArgumentException();
            }

            if (this.SelectedEntry.Tags.OrderBy(x => x).SequenceEqual(tagEditForm.AssignedTags))
            {
                // Tags didn't change.
                return;
            }

            this.SelectedEntry.ClearTags();
            foreach (var tag in tagEditForm.AssignedTags)
            {
                this.SelectedEntry.AddTag(tag);
            }

            this.SaveSelectedEntry();

            this.UpdateEntryListBoxTags();
            this.UpdateTag();
        }

        /// <summary>
        /// Handles the Click event of the buttonDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when deleting.");

            DialogResult result = MessageBox.Show(
                "Do you really want to delete this journal entry?",
                "Delete entry",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            // Cancel the editing mode first.
            this.IsEditing = false;

            this.Entries.Remove(this.SelectedEntry);
            this.SelectedEntry.Delete(this.Settings.EntryFolderPath);

            // After deleting, there shouldn't be any selected entry.
            this.SelectedEntry = null;

            this.UpdateFromScratch();
        }

        /// <summary>
        /// Handles the Click event of the buttonAddEntry control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonAddEntry_Click(object sender, EventArgs e)
        {
            Entry newEntry = new Entry();
            this.Entries.Add(newEntry);

            this.SelectedEntry = newEntry;
            this.UpdateAllEntryLists();
        }

        /// <summary>
        /// Handles the Click event of the buttonShare control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonShare_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when sharing.");

            this.contextMenuStripShare.Show(
                this.buttonShare,
                new Point { X = this.buttonShare.Width, Y = this.buttonShare.Height },
                ToolStripDropDownDirection.BelowLeft);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the entryListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EntryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.suppressEntryUpdate)
            {
                return;
            }

            // Highlight the entries that represents the currently selected journal entry
            // in all the entry list boxes.
            EntryListBox entryListBox = sender as EntryListBox;
            if (entryListBox == null)
            {
                return;
            }

            if (entryListBox.SelectedIndex == -1)
            {
                this.SelectedEntry = null;
                return;
            }

            this.suppressEntryUpdate = true;

            this.SelectedEntry = entryListBox.Items[entryListBox.SelectedIndex] as Entry;

            this.suppressEntryUpdate = false;
        }

        /// <summary>
        /// Handles the ValueChanged event of the dateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when reflecting it to the calendar.");

            if (this.IsEditing)
            {
                this.SelectedEntry.UTCDateTime = this.dateTimePicker.Value.ToUniversalTime();
                this.UpdateAllEntryLists();
            }
        }

        /// <summary>
        /// Handles the Click event of the copyToClipboardToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CopyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when copying to clipboard.");

            Clipboard.SetDataObject(this.textEntryText.Text, true);
            MessageBox.Show(this, "The entry text has been successfully copied to the clipboard.", "Copy to Clipboard", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Handles the Click event of the chooseExistingPhotoToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ChooseExistingPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AskToChooseExistingPhoto();
        }

        /// <summary>
        /// Handles the Click event of the replaceWithAnotherPhotoToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ReplaceWithAnotherPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "By choosing another photo, the current photo will be deleted." + Environment.NewLine + "Would you like to continue?",
                "Replace Photo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            this.AskToChooseExistingPhoto();
        }

        /// <summary>
        /// Asks the user to choose existing photo.
        /// </summary>
        private void AskToChooseExistingPhoto()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openDialog.Filter =
                "All Supported Images (*.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tiff;*.tif)|*.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tiff;*.tif|" +
                "Bitmap Images (*.bmp)|*.bmp|" +
                "GIF Images (*.gif)|*.gif|" +
                "JPEG Images (*.jpeg;*.jpg)|*.jpeg;*.jpg|" +
                "PNG Images (*.png)|*.png|" +
                "TIFF Images (*.tiff;*.tif)|*.tiff;*.tif";
            openDialog.FilterIndex = 1;
            openDialog.RestoreDirectory = true;
            openDialog.CheckFileExists = true;
            openDialog.Multiselect = false;

            if (openDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // Does the photo folder exist at all?
            if (!Directory.Exists(this.Settings.PhotoFolderPath))
            {
                // If there is a file named the same as the photo folder,
                // show an error message.
                if (File.Exists(this.Settings.PhotoFolderPath))
                {
                    MessageBox.Show(
                        "Your Day One folder contains a file named \"photos\", which is preventing Journaley from creating the photo directory.",
                        "Error creating photo folder",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    return;
                }

                Directory.CreateDirectory(this.Settings.PhotoFolderPath);
            }

            // Delete the existing photo, if there's any.
            this.DeletePhoto();

            // Now copy the file to the photo folder if the file is in JPEG.
            // Otherwise, convert it to JPEG.
            string targetFileName = Path.ChangeExtension(this.SelectedEntry.UUIDString, "jpg");
            string targetFullPath = Path.Combine(this.Settings.PhotoFolderPath, targetFileName);

            string ext = Path.GetExtension(openDialog.FileName).ToLower();
            if (ext == ".jpg" || ext == ".jpeg")
            {
                FileInfo srcInfo = new FileInfo(openDialog.FileName);
                srcInfo.CopyTo(targetFullPath);
            }
            else
            {
                try
                {
                    using (Image image = Image.FromFile(openDialog.FileName))
                    {
                        using (Bitmap b = new Bitmap(image.Width, image.Height))
                        {
                            b.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                            using (Graphics g = Graphics.FromImage(b))
                            {
                                g.Clear(Color.White);
                                g.DrawImageUnscaled(image, 0, 0);
                            }

                            // Set the JPEG quality to 100L.
                            ImageCodecInfo jpgEncoder = this.GetEncoder(ImageFormat.Jpeg);

                            if (jpgEncoder != null)
                            {
                                Encoder encoder = Encoder.Quality;
                                EncoderParameters encoderParameters = new EncoderParameters(1);
                                encoderParameters.Param[0] = new EncoderParameter(encoder, 100L);

                                b.Save(targetFullPath, jpgEncoder, encoderParameters);
                            }
                            else
                            {
                                // Just use the default save method with 75% quality in case the encoder object is not found.
                                b.Save(targetFullPath, ImageFormat.Jpeg);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Error reading the selected photo.",
                        "Failed to add photo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
            }

            // Assign the photo path to the selected entry.
            this.SelectedEntry.PhotoPath = Path.Combine(this.Settings.PhotoFolderPath, targetFileName);

            // Update the UIs related to photo.
            this.UpdatePhotoUIs();
        }

        /// <summary>
        /// Gets the image encoder.
        /// </summary>
        /// <param name="format">The image format.</param>
        /// <returns>The image encoder for the given image format, null if not found.</returns>
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            // Not sure why GetImageDecoders() is used instead of GetImageEncoders(),
            // but I'm just following the example in MSDN
            // http://msdn.microsoft.com/en-us/library/bb882583%28v=vs.110%29.aspx
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }

        /// <summary>
        /// Updates the photo related UIs.
        /// </summary>
        private void UpdatePhotoUIs()
        {
            if (!this.IsEditing)
            {
                this.UpdateWebBrowser();
            }

            this.UpdatePhotoButton();
            this.InvalidateEntryInEntryList(this.SelectedEntry);
        }

        /// <summary>
        /// Deletes the photo associated with this entry, if there's any.
        /// This method does NOT send the photo to the recycle bin.
        /// Also, this method only deletes the file,
        /// and the caller is responsible for maintaining the entry's PhotoPath property up to date.
        /// </summary>
        private void DeletePhoto()
        {
            if (File.Exists(this.SelectedEntry.PhotoPath))
            {
                File.Delete(this.SelectedEntry.PhotoPath);
            }
        }

        /// <summary>
        /// Handles the Click event of the deletePhotoToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DeletePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Do you really want to delete the photo?",
                "Delete Photo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            this.DeletePhoto();
            this.SelectedEntry.PhotoPath = null;

            this.UpdatePhotoUIs();
        }

        /// <summary>
        /// Handles the Click event of the ButtonMainTimeline control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonMainTimeline_Click(object sender, EventArgs e)
        {
            this.tabLeftPanel.SelectTab("tabPageAllEntries");
            this.buttonMainTimeline.Selected = true;
            this.buttonMainCalendar.Selected = false;
            this.buttonMainTags.Selected = false;
        }

        /// <summary>
        /// Handles the Click event of the ButtonMainCalendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonMainCalendar_Click(object sender, EventArgs e)
        {
            this.tabLeftPanel.SelectTab("tabPageCalendar");
            this.buttonMainTimeline.Selected = false;
            this.buttonMainCalendar.Selected = true;
            this.buttonMainTags.Selected = false;
        }

        /// <summary>
        /// Handles the Click event of the ButtonMainTags control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonMainTags_Click(object sender, EventArgs e)
        {
            this.tabLeftPanel.SelectTab("tabPageTags");
            this.buttonMainTimeline.Selected = false;
            this.buttonMainCalendar.Selected = false;
            this.buttonMainTags.Selected = true;
        }

        /// <summary>
        /// Handles the TextChanged event of the textEntryText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TextEntryText_TextChanged(object sender, EventArgs e)
        {
            this.UpdateWordCounts();
        }

        #endregion

        #region Private Classes

        /// <summary>
        /// Entry class used in the "Entries by Year" tab.
        /// </summary>
        private class YearCountEntry
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="YearCountEntry"/> class.
            /// </summary>
            /// <param name="year">The year.</param>
            /// <param name="count">The count.</param>
            public YearCountEntry(int year, int count)
            {
                this.Year = year;
                this.Count = count;
            }

            /// <summary>
            /// Gets or sets the year.
            /// </summary>
            /// <value>
            /// The year.
            /// </value>
            public int Year { get; set; }

            /// <summary>
            /// Gets or sets the count.
            /// </summary>
            /// <value>
            /// The count.
            /// </value>
            public int Count { get; set; }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return string.Format("Year of {0} ({1} {2})", this.Year, this.Count, this.Count > 1 ? "entries" : "entry");
            }
        }

        /// <summary>
        /// Entry class used in the "Tags" tab.
        /// </summary>
        private class TagCountEntry
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TagCountEntry"/> class.
            /// </summary>
            /// <param name="tag">The tag.</param>
            /// <param name="count">The count.</param>
            public TagCountEntry(string tag, int count)
            {
                this.Tag = tag;
                this.Count = count;
            }

            /// <summary>
            /// Gets or sets the tag.
            /// </summary>
            /// <value>
            /// The tag.
            /// </value>
            public string Tag { get; set; }

            /// <summary>
            /// Gets or sets the count.
            /// </summary>
            /// <value>
            /// The count.
            /// </value>
            public int Count { get; set; }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return string.Format("{0} ({1} {2})", this.Tag, this.Count, this.Count > 1 ? "entries" : "entry");
            }
        }

        /// <summary>
        /// Entry class for the "Starred" entry.
        /// </summary>
        private class StarredCountEntry : TagCountEntry
        {
            public StarredCountEntry(int count)
                : base("Starred", count)
            {
            }
        }

        #endregion
    }
}
