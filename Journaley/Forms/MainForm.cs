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
    public partial class MainForm : Form, IEntryTextProvider
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
        /// The backing field for PhotoExpanded.
        /// </summary>
        private bool photoExpanded;

        /// <summary>
        /// The backing field for markdown object.
        /// </summary>
        private Markdown markdown;

        /// <summary>
        /// Internal field to indicate whether to suppress the entry update process.
        /// </summary>
        private bool suppressEntryUpdate = false;

        /// <summary>
        /// Indicates whether to add new entry on form load
        /// </summary>
        private bool addNewEntryOnLoad = false;

        /// <summary>
        /// The Noto Sans font family
        /// </summary>
        private FontFamily fontFamilyNotoSansRegular;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm() : this(false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        /// <param name="newEntry">if set to <c>true</c> [new entry].</param>
        public MainForm(bool newEntry)
        {
            this.InitializeComponent();

            this.Icon = Journaley.Properties.Resources.JournaleyIcon;
            this.FormLoaded = false;

            // Read embedded fonts.
            this.fontFamilyNotoSansRegular = FontReader.ReadEmbeddedFont(
                "NotoSans_Regular.ttf",
                Journaley.Properties.Resources.NotoSans_Regular);

            // Set the font of the text entry box.
            this.spellCheckedEntryText.Font = new Font(
                this.FontFamilyOpenSansRegular,
                this.spellCheckedEntryText.Font.Size,
                this.spellCheckedEntryText.Font.Style);

            this.spellCheckedEntryText.Initialize();

            foreach (var entryListBox in this.GetAllEntryLists())
            {
                entryListBox.EntryTextProvider = this;
            }

            // Back / Popout button labels.
            this.transparentImageButtonBack.PropertyChanged += (e, args) =>
            {
                this.transparentPictureBoxLabelBack.Image = this.transparentImageButtonBack.Hover
                    ? Journaley.Properties.Resources.picture_lbl_back
                    : null;

                // Repaint the background?
                this.panelEntryPhotoArea.Invalidate(this.transparentPictureBoxLabelBack.Bounds, true);
                this.panelEntryPhotoArea.Invalidate(this.transparentImageButtonBack.Bounds, true);
                this.panelEntryPhotoArea.Update();
            };

            this.transparentImageButtonPopout.PropertyChanged += (e, args) =>
            {
                this.transparentPictureBoxLabelPopout.Image = this.transparentImageButtonPopout.Hover
                    ? Journaley.Properties.Resources.picture_lbl_popout
                    : null;

                // Repaint the background?
                this.panelEntryPhotoArea.Invalidate(this.transparentPictureBoxLabelPopout.Bounds, true);
                this.panelEntryPhotoArea.Invalidate(this.transparentImageButtonPopout.Bounds, true);
                this.panelEntryPhotoArea.Update();
            };

            // Jump List
            JumpListBuilder.BuildJumpList(this.Handle);

            this.addNewEntryOnLoad = newEntry;
        }

        /// <summary>
        /// Gets or sets the new entry message ID to be used by the JumpList communication.
        /// </summary>
        /// <value>
        /// The new entry message.
        /// </value>
        public static int NewEntryMessage { get; set; }

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

                    this.UpdateDateAndTextFromEntry();
                    this.UpdateWebBrowser();
                }
                else
                {
                    this.isEditing = false;
                }

                this.UpdateStar();
                this.UpdatePhotoButton();

                this.PhotoExpanded = false;

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
        /// Gets or sets a value indicating whether [photo expanded].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [photo expanded]; otherwise, <c>false</c>.
        /// </value>
        private bool PhotoExpanded
        {
            get
            {
                return this.photoExpanded;
            }

            set
            {
                this.photoExpanded = value;
                this.UpdatePhotoArea();
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
        /// Gets the Open Sans font family.
        /// </summary>
        /// <value>
        /// The Open Sans font family.
        /// </value>
        private FontFamily FontFamilyOpenSansRegular
        {
            get
            {
                return this.fontFamilyNotoSansRegular;
            }
        }

        /// <summary>
        /// Gets or sets the first day of week.
        /// </summary>
        /// <value>
        /// The first day of week.
        /// </value>
        private DayOfWeek FirstDayOfWeek { get; set; }

        /// <summary>
        /// Gets the entry text for the provided journal entry.
        /// If the entry is currently selected and being edited,
        /// the text being edited should be returned.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <returns>
        /// The entry text to be previewed.
        /// </returns>
        public string GetTextForEntry(Entry entry)
        {
            if (entry == null)
            {
                return string.Empty;
            }

            if (this.SelectedEntry == entry && this.IsEditing)
            {
                return this.spellCheckedEntryText.Text.Replace(Environment.NewLine, "\n");
            }
            else
            {
                return entry.EntryText;
            }
        }

        /// <summary>
        /// For capturing NewEntry Message.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NewEntryMessage)
            {
                this.AddNewEntry();
                this.Activate();
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        /// <summary>
        /// Updates the web browser content with the Markdown-processed journal entry.
        /// </summary>
        private void UpdateWebBrowser()
        {
            this.webBrowser.DocumentText =
                string.Format(
                    "<style type=\"text/css\">\n{0}\n</style><html><body><div>{1}</div></body></html>",
                    Journaley.Properties.Resources.JournaleyCSS,
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

            this.SelectedEntry.EntryText = this.spellCheckedEntryText.Text.Replace(Environment.NewLine, "\n");

            if (this.SelectedEntry.IsDirty)
            {
                this.SelectedEntry.Save(this.Settings.EntryFolderPath);

                // Update the EntryList items as well.
                this.InvalidateEntryInEntryList(this.SelectedEntry);

                // Update the stats, too.
                this.UpdateStats();
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
            yield return this.entryListBoxAll;
            yield return this.entryListBoxCalendar;
            yield return this.entryListBoxTags;
        }

        /// <summary>
        /// Updates the UI.
        /// Enables / Disables buttons, depending upon the selected entry.
        /// </summary>
        private void UpdateUI()
        {
            bool noEntry = this.SelectedEntry == null;

            this.dateTimePicker.CustomFormat = noEntry ? " " : "MMM d, yyyy hh:mm tt";
            this.buttonEdit.Enabled = !noEntry;
            this.buttonDone.Enabled = !noEntry;
            this.buttonCancel.Enabled = !noEntry;
            this.buttonStar.Enabled = !noEntry;
            this.buttonPhoto.Enabled = !noEntry;
            this.buttonTag.Enabled = !noEntry;
            this.buttonDelete.Enabled = !noEntry;
            this.spellCheckedEntryText.Enabled = !noEntry;

            if (noEntry)
            {
                this.spellCheckedEntryText.Text = string.Empty;
                this.webBrowser.DocumentText = string.Format(
                    "<style type=\"text/css\">\n{0}\n</style><html><body></body></html>",
                    Journaley.Properties.Resources.JournaleyCSS);
            }

            this.tableLayoutSidebar.Visible = !noEntry;

            this.dateTimePicker.Enabled = this.IsEditing;
            this.toolTip.SetToolTip(this.buttonEdit, this.IsEditing ? "Save" : "Edit");
            this.spellCheckedEntryText.ReadOnly = !this.IsEditing;

            if (this.IsEditing && this.flowLayoutSidebarTopButtons.Controls.Contains(this.buttonEdit))
            {
                this.flowLayoutSidebarTopButtons.Controls.Clear();
                this.flowLayoutSidebarTopButtons.Controls.Add(this.buttonDone);
                this.flowLayoutSidebarTopButtons.Controls.Add(this.buttonCancel);
            }
            else if (!this.IsEditing && !this.flowLayoutSidebarTopButtons.Controls.Contains(this.buttonEdit))
            {
                this.flowLayoutSidebarTopButtons.Controls.Clear();
                this.flowLayoutSidebarTopButtons.Controls.Add(this.buttonEdit);
            }

            this.spellCheckedEntryText.Visible = this.IsEditing;
            this.panelWebBrowserWrapper.Visible = this.webBrowser.Visible = noEntry || !this.IsEditing;
        }

        /// <summary>
        /// Updates the star button's look.
        /// </summary>
        private void UpdateStar()
        {
            this.buttonStar.Selected = this.SelectedEntry != null && this.SelectedEntry.Starred;
        }

        /// <summary>
        /// Updates the photo button's look.
        /// </summary>
        private void UpdatePhotoButton()
        {
            this.buttonPhoto.Selected = this.SelectedEntry != null && this.SelectedEntry.PhotoPath != null;
        }

        /// <summary>
        /// Updates the tag button's look.
        /// </summary>
        private void UpdateTag()
        {
            this.buttonTag.Selected = this.SelectedEntry != null && this.SelectedEntry.Tags.Any();
        }

        /// <summary>
        /// Updates everything from scratch.
        /// </summary>
        private void UpdateFromScratch()
        {
            this.flowLayoutSidebarTopButtons.Controls.Clear();

            this.UpdateStats();
            this.UpdateAllEntryLists();
            this.UpdateUI();
        }

        /// <summary>
        /// Updates the statistics (number of entries).
        /// </summary>
        private void UpdateStats()
        {
            // Entries count first.
            int entriesCount = this.GetAllEntriesCount();
            this.labelEntries.Text = entriesCount.ToString();
            this.labelEntriesLabel.Text = entriesCount == 1 ? "ENTRY" : "ENTRIES";

            // Others.
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

            int diff = now.DayOfWeek - this.FirstDayOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            DateTime basis = now.AddDays(-diff).Date;

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
        /// Updates the date and text from entry.
        /// </summary>
        private void UpdateDateAndTextFromEntry()
        {
            this.dateTimePicker.Value = this.selectedEntry.LocalTime;
            this.spellCheckedEntryText.Text = this.selectedEntry.EntryText.Replace("\n", Environment.NewLine);
        }

        /// <summary>
        /// Updates all the entry lists.
        /// </summary>
        private void UpdateAllEntryLists()
        {
            this.UpdateEntryListBoxAll();
            this.UpdateEntryListBoxTags();
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
                string entryText = this.IsEditing ? this.spellCheckedEntryText.Text : this.SelectedEntry.EntryText;

                // Words Count.
                int wordsCount = entryText.Split(delim, StringSplitOptions.RemoveEmptyEntries).Length;
                this.labelWords.Text = wordsCount.ToString();

                this.labelWordsTitle.Text = wordsCount == 1 ? "WORD" : "WORDS";

                // Characters Count.
                int charactersCount = entryText.Count(x => !delim.Contains(x));
                this.labelCharacters.Text = charactersCount.ToString();

                this.labelCharactersTitle.Text = charactersCount == 1 ? "CHARACTER" : "CHARACTERS";
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
            this.HighlightSelectedEntryInCalendar();

            foreach (var list in this.GetAllEntryLists())
            {
                this.HighlightSelectedEntry(list);
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
                        bool prevSuppressEntryUpdate = this.suppressEntryUpdate;
                        this.suppressEntryUpdate = true;

                        list.SelectedIndex = index;

                        this.suppressEntryUpdate = prevSuppressEntryUpdate;

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

        /// <summary>
        /// Starts editing the currently selected item.
        /// </summary>
        private void StartEditing()
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when editing/saving.");
            Debug.Assert(this.IsEditing == false, "Must not be in the edit mode.");

            this.IsEditing = true;

            // Puts focus on textbox and moves cursor to end of entry
            this.spellCheckedEntryText.Focus();
            this.spellCheckedEntryText.Select(this.spellCheckedEntryText.Text.Length, 0);
        }

        /// <summary>
        /// Saves the entry and finish editing.
        /// </summary>
        private void SaveAndFinishEditing()
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when editing/saving.");
            Debug.Assert(this.IsEditing == true, "Must be in the edit mode.");

            this.SaveSelectedEntry();
            this.IsEditing = false;

            this.UpdateWebBrowser();
            this.UpdateUI();
        }

        /// <summary>
        /// Adds a new entry.
        /// </summary>
        private void AddNewEntry()
        {
            Entry newEntry = new Entry();
            this.Entries.Add(newEntry);

            this.SelectedEntry = newEntry;
            this.UpdateAllEntryLists();
            this.UpdateStats();
            this.spellCheckedEntryText.Focus();
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
            this.UpdatePhotoArea();
            this.InvalidateEntryInEntryList(this.SelectedEntry);
        }

        /// <summary>
        /// Updates the photo area layout.
        /// </summary>
        private void UpdatePhotoArea()
        {
            if (this.SelectedEntry == null || this.SelectedEntry.PhotoPath == null)
            {
                this.tableLayoutEntryArea.RowStyles[0] = new RowStyle { Height = 0, SizeType = SizeType.Absolute };
                this.tableLayoutEntryArea.RowStyles[1] = new RowStyle { Height = 100, SizeType = SizeType.Percent };
            }
            else
            {
                using (Image image = Image.FromFile(this.SelectedEntry.PhotoPath))
                {
                    Image copyImage = new Bitmap(image);
                    this.pictureBoxEntryPhoto.BackgroundImage = copyImage;
                }

                if (this.PhotoExpanded)
                {
                    this.tableLayoutEntryArea.RowStyles[0] = new RowStyle { Height = 100, SizeType = SizeType.Percent };
                    this.tableLayoutEntryArea.RowStyles[1] = new RowStyle { Height = 0, SizeType = SizeType.Absolute };

                    this.tableLayoutPanelEntryPhotoButtons.Visible = true;
                    this.panelEntryPhotoArea.Refresh();
                }
                else
                {
                    this.tableLayoutEntryArea.RowStyles[0] = new RowStyle { Height = 38, SizeType = SizeType.Percent };
                    this.tableLayoutEntryArea.RowStyles[1] = new RowStyle { Height = 62, SizeType = SizeType.Percent };

                    this.tableLayoutPanelEntryPhotoButtons.Visible = false;
                }
            }
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
        /// Reloads the entries from the currently specified folder, and updates everything from scratch.
        /// </summary>
        private void ReloadEntries()
        {
            this.SelectedEntry = null;
            this.Entries = Enumerable.Empty<Entry>().ToList();
            this.UpdateAllEntryLists();

            this.LoadEntries();

            // Select the latest entry by default.
            if (this.Entries.Any())
            {
                this.SelectedEntry = this.Entries.OrderByDescending(x => x.UTCDateTime).First();
            }

            this.UpdateFromScratch();
        }

        #region Event Handlers

        /// <summary>
        /// Handles the Load event of this form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Remembre the system settings.
            this.FirstDayOfWeek = Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek;

            // Set Current Culture for the spell checking.
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

            this.ReloadEntries();

            // Trick to bring this form to the front
            this.TopMost = true;
            this.TopMost = false;

            // Finished Loading
            this.FormLoaded = true;

            // Show new entry?
            if (this.addNewEntryOnLoad)
            {
                this.AddNewEntry();
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                if (this.SelectedEntry != null && this.IsEditing == false)
                {
                    this.StartEditing();
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
                bool dayOneFolderChanged = this.Settings.DayOneFolderPath != form.Settings.DayOneFolderPath;

                this.Settings = form.Settings;
                this.Settings.Save();

                if (dayOneFolderChanged)
                {
                    this.ReloadEntries();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            this.StartEditing();
        }

        /// <summary>
        /// Handles the Click event of the buttonDone control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonDone_Click(object sender, EventArgs e)
        {
            this.SaveAndFinishEditing();
        }

        /// <summary>
        /// Handles the Click event of the buttonCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when cancelling.");
            Debug.Assert(this.IsEditing == true, "Must be in the edit mode.");

            this.IsEditing = false;
            this.UpdateDateAndTextFromEntry();
            this.UpdateUI();
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

            if (this.SelectedEntry.PhotoPath != null)
            {
                this.contextMenuStripPhotoWithPhoto.Show(
                    this.buttonPhoto, new Point(), ToolStripDropDownDirection.BelowLeft);
            }
            else
            {
                this.AskToChooseExistingPhoto();
            }
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
            tagEditForm.Location = this.buttonTag.PointToScreen(new Point(-tagEditForm.Width, -8));

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
            this.AddNewEntry();
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

            bool prevSuppressEntryUpdate = this.suppressEntryUpdate;

            this.suppressEntryUpdate = true;

            this.SelectedEntry = entryListBox.Items[entryListBox.SelectedIndex] as Entry;

            this.suppressEntryUpdate = prevSuppressEntryUpdate;
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
            this.panelTimeline.Visible = true;
            this.panelCalendar.Visible = false;
            this.panelTags.Visible = false;
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
            this.panelTimeline.Visible = false;
            this.panelCalendar.Visible = true;
            this.panelTags.Visible = false;
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
            this.panelTimeline.Visible = false;
            this.panelCalendar.Visible = false;
            this.panelTags.Visible = true;
            this.buttonMainTimeline.Selected = false;
            this.buttonMainCalendar.Selected = false;
            this.buttonMainTags.Selected = true;
        }

        /// <summary>
        /// Handles the TextChanged event of the spellCheckedEntryText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SpellCheckedEntryText_TextChanged(object sender, EventArgs e)
        {
            this.UpdateWordCounts();

            // Live update text in entry list
            if (this.SelectedEntry != null)
            {
                this.InvalidateEntryInEntryList(this.SelectedEntry);
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the spellCheckedEntryText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void SpellCheckedEntryText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                this.SaveAndFinishEditing();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the pictureBoxEntryPicture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PictureBoxEntryPicture_Click(object sender, EventArgs e)
        {
            if (this.PhotoExpanded == false)
            {
                this.PhotoExpanded = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the transparentImageButtonBack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TransparentImageButtonBack_Click(object sender, EventArgs e)
        {
            this.PhotoExpanded = false;
        }

        /// <summary>
        /// Handles the Click event of the transparentImageButtonPopout control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TransparentImageButtonPopout_Click(object sender, EventArgs e)
        {
            PhotoDisplayForm photoForm = new PhotoDisplayForm();

            Image image = new Bitmap(Image.FromFile(this.SelectedEntry.PhotoPath));
            photoForm.Image = image;
            photoForm.ClientSize = new System.Drawing.Size(image.Width, image.Height);

            Screen currentScreen = Screen.FromControl(this);
            int screenWidth = currentScreen.Bounds.Width;
            int screenHeight = currentScreen.Bounds.Height;

            double threshold = 0.8;
            int maxWidth = (int)(screenWidth * threshold);
            int maxHeight = (int)(screenHeight * threshold);

            photoForm.Width = Math.Min(photoForm.Width, maxWidth);
            photoForm.Height = Math.Min(photoForm.Height, maxHeight);

            photoForm.StartPosition = FormStartPosition.CenterScreen;
            photoForm.Show();

            this.PhotoExpanded = false;
        }

        /// <summary>
        /// Handles the MouseMove event of the pictureBoxEntryPhoto control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PictureBoxEntryPhoto_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.pictureBoxEntryPhoto.Image == null)
            {
                this.pictureBoxEntryPhoto.Image = Journaley.Properties.Resources.picture_pane_hoverMask;
            }
        }

        /// <summary>
        /// Handles the MouseLeave event of the pictureBoxEntryPhoto control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PictureBoxEntryPhoto_MouseLeave(object sender, EventArgs e)
        {
            if (this.pictureBoxEntryPhoto.Image != null)
            {
                this.pictureBoxEntryPhoto.Image = null;
            }
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
            /// <summary>
            /// Initializes a new instance of the <see cref="StarredCountEntry"/> class.
            /// </summary>
            /// <param name="count">The count.</param>
            public StarredCountEntry(int count)
                : base("Starred", count)
            {
            }
        }

        #endregion
    }
}
