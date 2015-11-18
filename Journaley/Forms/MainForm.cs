namespace Journaley.Forms
{
    extern alias MDS;

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using BlackBeltCoder;
    using Journaley.Controls;
    using Journaley.Core.Models;
    using Journaley.Core.Utilities;
    using Journaley.Core.Watcher;
    using Journaley.Utilities;
    using MDS.MarkdownSharp;
    using Pabo.Calendar;
    using Squirrel;

    /// <summary>
    /// The Main Form of the application. Contains the entry list, preview, buttons, etc.
    /// </summary>
    public partial class MainForm : BaseJournaleyForm, IEntryTextProvider
    {
        /// <summary>
        /// The auto save threshold in milliseconds.
        /// </summary>
        private static readonly int AutoSaveThreshold = 3000;

        /// <summary>
        /// The custom CSS file name.
        /// </summary>
        private static readonly string CustomCSSFileName = "Custom.css";

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
        /// The backing field for html to text object.
        /// </summary>
        private HtmlToText htmlToText;

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
        /// The Noto Sans font family
        /// </summary>
        private FontFamily fontFamilyNotoSerifRegular;

        /// <summary>
        /// The Noto Sans font family for WPF
        /// </summary>
        private System.Windows.Media.FontFamily fontFamilyNotoSansWPF;

        /// <summary>
        /// The Noto Serif font family for WPF
        /// </summary>
        private System.Windows.Media.FontFamily fontFamilyNotoSerifWPF;

        /// <summary>
        /// Backing field for UpdateAvailable property.
        /// </summary>
        private bool updateAvailable = false;

        /// <summary>
        /// The update process count
        /// </summary>
        private int updateProcessCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm() : this(false, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        /// <param name="newEntry">if set to <c>true</c> [new entry].</param>
        /// <param name="createJumpList">if set to <c>true</c> [create jump list].</param>
        public MainForm(bool newEntry, bool createJumpList)
        {
            this.EntryList = new EntryList();

            this.InitializeComponent();

            this.Icon = Journaley.Properties.Resources.JournaleyIcon;
            this.FormLoaded = false;

            // Read embedded fonts.
            this.fontFamilyNotoSansRegular = FontReader.ReadEmbeddedFont(
                "NotoSans_Regular.ttf",
                Journaley.Properties.Resources.NotoSans_Regular);

            this.fontFamilyNotoSerifRegular = FontReader.ReadEmbeddedFont(
                "NotoSerif_Regular.ttf",
                Journaley.Properties.Resources.NotoSerif_Regular);

            this.fontFamilyNotoSansWPF = FontReader.ReadEmbeddedFont("NotoSans_Regular.ttf", "Noto Sans");
            this.fontFamilyNotoSerifWPF = FontReader.ReadEmbeddedFont("NotoSerif_Regular.ttf", "Noto Serif");

            this.spellCheckedEntryText.Initialize();

            foreach (var entryListBox in this.GetAllEntryLists())
            {
                entryListBox.EntryTextProvider = this;
            }

            this.SetupAutoSaveTimer();

            this.UpdateMaximizeRestoreButtonImage();

            foreach (ContextMenuStrip menu in new ContextMenuStrip[]
            {
                this.contextMenuStripPhotoWithoutPhoto,
                this.contextMenuStripPhotoWithPhoto
            })
            {
                menu.Renderer = new ToolStripProfessionalRenderer(new PhotoMenuColorTable());

                foreach (ToolStripMenuItem menuItem in menu.Items)
                {
                    menuItem.MouseMove += this.ToolStripMenuItem_MouseMove;
                    menuItem.MouseLeave += this.ToolStripMenuItem_MouseLeave;
                }
            }

            // Jump List
            if (createJumpList)
            {
                JumpListBuilder.BuildJumpList(this.Handle);
            }

            // Remember to create a new entry!
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
        /// Gets the Open Sans font family.
        /// </summary>
        /// <value>
        /// The Open Sans font family.
        /// </value>
        internal FontFamily FontFamilyNotoSansRegular
        {
            get
            {
                return this.fontFamilyNotoSansRegular;
            }
        }

        /// <summary>
        /// Gets the Open Sans font family.
        /// </summary>
        /// <value>
        /// The Open Sans font family.
        /// </value>
        internal FontFamily FontFamilyNotoSerifRegular
        {
            get
            {
                return this.fontFamilyNotoSerifRegular;
            }
        }

        /// <summary>
        /// Gets the Noto Sans font family for WPF.
        /// </summary>
        /// <value>
        /// The Noto Sans font family for WPF.
        /// </value>
        internal System.Windows.Media.FontFamily FontFamilyNotoSansWPF
        {
            get
            {
                return this.fontFamilyNotoSansWPF;
            }
        }

        /// <summary>
        /// Gets the Noto Serif font family for WPF.
        /// </summary>
        /// <value>
        /// The Noto Serif font family for WPF.
        /// </value>
        internal System.Windows.Media.FontFamily FontFamilyNotoSerifWPF
        {
            get
            {
                return this.fontFamilyNotoSerifWPF;
            }
        }

        /// <summary>
        /// Gets or sets the currently installed version.
        /// </summary>
        /// <value>
        /// The currently installed version.
        /// </value>
        internal Version CurrentlyInstalledVersion { get; set; }

        /// <summary>
        /// Gets or sets the update information.
        /// </summary>
        /// <value>
        /// The update information.
        /// </value>
        internal UpdateInfo UpdateInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether there is an available update.
        /// </summary>
        /// <value>
        /// <c>true</c> if there is an available update; otherwise, <c>false</c>.
        /// </value>
        internal bool UpdateAvailable
        {
            get
            {
                return this.updateAvailable;
            }

            set
            {
                this.updateAvailable = value;
                this.UpdateSettingsButton();
            }
        }

        /// <summary>
        /// Gets or sets the update process count.
        /// </summary>
        /// <value>
        /// The update process count.
        /// </value>
        internal int UpdateProcessCount
        {
            get
            {
                return this.updateProcessCount;
            }

            set
            {
                this.updateProcessCount = value;
                if (value == 0 && this.DeferredClosing)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Adds the sizing borders to the frame.
        /// </summary>
        /// <returns>A <see cref="T:System.Windows.Forms.CreateParams" /> that contains the required creation parameters when the handle to the control is created.</returns>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000;        // WS_MINIMIZEBOX

                return cp;
            }
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        private Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets the entry list.
        /// </summary>
        /// <value>
        /// The entry list.
        /// </value>
        private EntryList EntryList { get; set; }

        /// <summary>
        /// Gets the entries.
        /// </summary>
        /// <value>
        /// The entries.
        /// </value>
        private Dictionary<Guid, Entry> Entries
        {
            get
            {
                return this.EntryList.Entries;
            }
        }

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
                    // The second if condition is necessary,
                    // because when the selected entry is set due to an external change (c.f. Watcher_EntryChanged method)
                    // the entry should NOT be saved.
                    if (this.Entries.ContainsKey(this.selectedEntry.UUID) && this.Entries[this.selectedEntry.UUID] == this.selectedEntry)
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
                this.UpdatePhoto();
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
                if (this.isEditing != value)
                {
                    this.isEditing = value;
                }

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

                // Intentionally changing this value later.
                this.entryPhotoArea.Expanded = value;
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
                    ((MarkdownOptions)this.markdown.Options).AutoNewLines = true;
                }

                return this.markdown;
            }
        }

        /// <summary>
        /// Gets the HTML to text object.
        /// </summary>
        /// <value>
        /// The HTML to text object.
        /// </value>
        private HtmlToText HtmlToText
        {
            get
            {
                if (this.htmlToText == null)
                {
                    this.htmlToText = new HtmlToText();
                }

                return this.htmlToText;
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
        /// Gets or sets the auto save timer.
        /// </summary>
        /// <value>
        /// The auto save timer.
        /// </value>
        private System.Timers.Timer AutoSaveTimer { get; set; }

        /// <summary>
        /// Gets or sets the watcher.
        /// </summary>
        /// <value>
        /// The entry watcher for monitoring file changes within the data folders.
        /// </value>
        private EntryWatcher Watcher { get; set; }

        /// <summary>
        /// Gets or sets the custom CSS rules defined by the user.
        /// </summary>
        /// <value>
        /// The custom CSS rules defined by the user.
        /// </value>
        private string CustomCSS { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [deferred closing].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [deferred closing]; otherwise, <c>false</c>.
        /// </value>
        private bool DeferredClosing { get; set; }

        /// <summary>
        /// Gets the entry text for the provided journal entry.
        /// If the entry is currently selected and being edited,
        /// the text being edited should be returned.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <returns>
        /// The entry text to be previewed.
        /// </returns>
        public Tuple<string, string> GetTextForEntry(Entry entry)
        {
            if (entry == null)
            {
                return new Tuple<string, string>(null, string.Empty);
            }

            string sourceText = (this.SelectedEntry == entry && this.IsEditing)
                ? this.spellCheckedEntryText.Text.Replace(Environment.NewLine, "\n")
                : entry.EntryText;

            return FirstSentenceExtractor.ExtractTitleAndFirstSentence(HtmlToText.Convert(Markdown.Transform(sourceText)));
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

                return;
            }

            switch ((PInvoke.WindowsMessages)m.Msg)
            {
                case PInvoke.WindowsMessages.WM_NCHITTEST:
                    this.OnNCHitTest(ref m);
                    break;

                case PInvoke.WindowsMessages.WM_GETMINMAXINFO:
                    this.OnGetMinMaxInfo(ref m);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// Processes the WM_NCHITTEST message.
        /// This is needed to specify the caption area / resize area.
        /// </summary>
        /// <param name="m">The Windows message object.</param>
        private void OnNCHitTest(ref Message m)
        {
            int screenX = (int)m.LParam & 0xFFFF;
            int screenY = (int)m.LParam >> 16;

            Point p = this.PointToClient(new Point(screenX, screenY));
            if (p.Y < 20)
            {
                m.Result = (IntPtr)PInvoke.HitTestValues.HTCAPTION;
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        /// <summary>
        /// Processes the WM_GETMINMAXINFO message.
        /// This is needed to correctly specify the maximized window size.
        /// </summary>
        /// <param name="m">The Windows message object.</param>
        private void OnGetMinMaxInfo(ref Message m)
        {
            // Here, adjust the maximized window position / size to be the entire working area of the primary monitor.
            // Otherwise, Windows will assume that there is the sizing border, and clip some portion of the client rectangle unexpectedly.
            PInvoke.MINMAXINFO mm = (PInvoke.MINMAXINFO)m.GetLParam(typeof(PInvoke.MINMAXINFO));

            mm.ptMaxPosition = new PInvoke.POINT(0, 0);
            mm.ptMaxSize = new PInvoke.POINT(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            mm.ptMinTrackSize = new PInvoke.POINT(this.MinimumSize.Width, this.MinimumSize.Height);

            Marshal.StructureToPtr(mm, m.LParam, true);
        }

        /// <summary>
        /// Updates the web browser content with the Markdown-processed journal entry.
        /// </summary>
        private void UpdateWebBrowser()
        {

            String formatedString = string.Format(
                    "<style type=\"text/css\">\n<!-- Font CSS -->\n{0}\n<!-- Size CSS -->\n{1}\n<!-- Custom CSS -->\n{2}\n</style><html><body><div>{3}</div></body></html>",
                    this.GetWebBrowserTypefaceCSS(),
                    this.GetWebBrowserSizeCSS(),
                    this.CustomCSS ?? string.Empty,
                    Markdown.Transform(this.SelectedEntry.EntryText));

            // Hack to fix #114
            if (formatedString.Contains("<ul>"))
            {
                String unorderListString = formatedString.Substring(formatedString.IndexOf("<ul>"), formatedString.LastIndexOf("</ul>") - formatedString.IndexOf("<ul>"));
                formatedString = formatedString.Replace(unorderListString, unorderListString.Replace("<br />", ""));
            }

            this.webBrowser.DocumentText = formatedString;
              

        }

        /// <summary>
        /// Gets the CSS text containing the typeface to be used in the web browser control.
        /// </summary>
        /// <returns>CSS text</returns>
        private string GetWebBrowserTypefaceCSS()
        {
            string result = Journaley.Properties.Resources.JournaleyCSSNotoSans;

            if (this.Settings.Typeface == "Noto Serif")
            {
                result = Journaley.Properties.Resources.JournaleyCSSNotoSerif;
            }

            return result;
        }

        /// <summary>
        /// Gets the CSS text containing the font sizes to be used in the web browser control.
        /// </summary>
        /// <returns>CSS text</returns>
        private string GetWebBrowserSizeCSS()
        {
            string result = Journaley.Properties.Resources.JournaleyCSSMedium;

            if (this.Settings.TextSize == SettingsForm.TextSizeSmall)
            {
                result = Journaley.Properties.Resources.JournaleyCSSSmall;
            }
            else if (this.Settings.TextSize == SettingsForm.TextSizeLarge)
            {
                result = Journaley.Properties.Resources.JournaleyCSSLarge;
            }

            return result;
        }

        /// <summary>
        /// Saves the selected entry.
        /// </summary>
        private void SaveSelectedEntry()
        {
            this.SaveSelectedEntry(true);
        }

        /// <summary>
        /// Saves the selected entry.
        /// </summary>
        /// <param name="applyTextFromTextBox">if set to <c>true</c> [apply text from text box].</param>
        private void SaveSelectedEntry(bool applyTextFromTextBox)
        {
            if (this.SelectedEntry == null)
            {
                return;
            }

            if (applyTextFromTextBox)
            {
                this.SelectedEntry.EntryText = this.spellCheckedEntryText.Text.Replace(Environment.NewLine, "\n");
            }

            if (this.SelectedEntry.IsDirty)
            {
                // Disable the file watcher temporarily, and make sure that it turns back on after saving.
                try
                {
                    this.Watcher.EnableRaisingEvents = false;

                    this.SelectedEntry.Save(this.Settings.EntryFolderPath);
                }
                finally
                {
                    this.Watcher.EnableRaisingEvents = true;
                }

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
                    this.GetWebBrowserSizeCSS());
            }

            this.tableLayoutSidebar.Visible = !noEntry;

            this.dateTimePicker.Enabled = this.IsEditing;
            this.spellCheckedEntryText.ReadOnly = !this.IsEditing;

            if (this.IsEditing && this.flowLayoutSidebarTopButtons.Controls.Contains(this.buttonEdit))
            {
                this.flowLayoutSidebarTopButtons.Controls.Clear();
                this.flowLayoutSidebarTopButtons.Controls.Add(this.buttonDone);
            }
            else if (!this.IsEditing && !this.flowLayoutSidebarTopButtons.Controls.Contains(this.buttonEdit))
            {
                this.flowLayoutSidebarTopButtons.Controls.Clear();
                this.flowLayoutSidebarTopButtons.Controls.Add(this.buttonEdit);
            }

            this.panelEntryTextWrapper.Visible = this.IsEditing;
            this.panelWebBrowserWrapper.Visible = noEntry || !this.IsEditing;
            this.webBrowser.Visible = this.panelWebBrowserWrapper.Visible;

            this.UpdateMaximizeRestoreButtonImage();
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

            this.UpdateSpellCheckedEntryTextSize();
            this.UpdateSpellCheckedEntryTypeface();
            this.UpdateStats();
            this.UpdateAllEntryLists();
            this.UpdateUI();
            this.UpdatePhotoArea();
        }

        /// <summary>
        /// Updates the statistics (number of entries).
        /// </summary>
        private void UpdateStats()
        {
            // Entries count first.
            int entriesCount = this.EntryList.GetAllEntriesCount();
            this.labelEntries.Text = entriesCount.ToString();
            this.labelEntriesLabel.Text = entriesCount == 1 ? "ENTRY" : "ENTRIES";

            // Others.
            this.labelThisWeek.Text = this.EntryList.GetThisWeekCount(DateTime.Now, this.FirstDayOfWeek).ToString();
            this.labelToday.Text = this.EntryList.GetTodayCount(DateTime.Now).ToString();
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
            this.UpdateEntryList(this.Entries.Values, this.entryListBoxAll);
        }

        /// <summary>
        /// Updates the entry list box of "Tags" tab.
        /// </summary>
        private void UpdateEntryListBoxTags()
        {
            // Save the currently selected tag, if any.
            TagCountEntry selected = this.listBoxTags.SelectedItem as TagCountEntry;
            string selectedTagName = selected != null ? selected.Tag : null;

            // Clear everything.
            this.listBoxTags.Items.Clear();
            this.listBoxTags.SelectedIndex = -1;

            // First, display all the starred entries.
            int starredCount = this.Entries.Values.Count(e => e.Starred);
            if (starredCount > 0)
            {
                this.listBoxTags.Items.Add(new StarredCountEntry(starredCount));
            }

            // Then, collect all the tags.
            var tags = this.Entries.Values
                .SelectMany(x => x.Tags)
                .Distinct();

            var tagsAndCounts = tags
                .Select(x => new TagCountEntry(x, this.Entries.Values.Count(e => e.Tags.Contains(x))))
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Tag);

            // If there is any entry,
            if (tagsAndCounts.Any())
            {
                // Add to the top list box first.
                this.listBoxTags.Items.AddRange(tagsAndCounts.ToArray());
            }

            // Select the previously selected item.
            if (selectedTagName != null)
            {
                for (int i = 0; i < this.listBoxTags.Items.Count; ++i)
                {
                    TagCountEntry tagAndCount = this.listBoxTags.Items[i] as TagCountEntry;
                    if (tagAndCount.Tag == selectedTagName)
                    {
                        this.listBoxTags.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (this.listBoxTags.SelectedIndex == -1 && this.listBoxTags.Items.Count > 0)
            {
                this.listBoxTags.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Updates the entry list box of "Calendar" tab.
        /// </summary>
        private void UpdateEntryListBoxCalendar()
        {
            // Update the bold dates
            this.monthCalendar.Refresh();

            if (this.monthCalendar.SelectedDates.Count == 0)
            {
                this.entryListBoxCalendar.Items.Clear();
            }
            else
            {
                this.UpdateEntryList(
                    this.Entries.Values.Where(x => x.LocalTime.ToShortDateString() == this.monthCalendar.SelectedDates[0].ToShortDateString()),
                    this.entryListBoxCalendar);
            }
        }

        /// <summary>
        /// Updates the given entry list with the given entries.
        /// Used by other Update methods.
        /// </summary>
        /// <param name="entries">The entries to be filled in the list.</param>
        /// <param name="list">The EntryListBox list.</param>
        private void UpdateEntryList(IEnumerable<Entry> entries, EntryListBox list)
        {
            this.UpdateEntryList(entries, list, true);
        }

        /// <summary>
        /// Updates the given entry list with the given entries.
        /// Used by other Update methods.
        /// </summary>
        /// <param name="entries">The entries to be filled in the list.</param>
        /// <param name="list">The EntryListBox list.</param>
        /// <param name="dateSeparator">if set to <c>true</c> display the date separators.</param>
        private void UpdateEntryList(IEnumerable<Entry> entries, EntryListBox list, bool dateSeparator)
        {
            // Clear everything.
            list.Items.Clear();

            if (dateSeparator)
            {
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
            }
            else
            {
                list.Items.AddRange(entries.ToArray());
            }

            this.HighlightSelectedEntry(list);
        }

        /// <summary>
        /// Gets the active entry list.
        /// </summary>
        /// <returns>the currently active entry list box object.</returns>
        private EntryListBox GetActiveEntryList()
        {
            if (this.panelTimeline.Visible)
            {
                return this.entryListBoxAll;
            }
            else if (this.panelCalendar.Visible)
            {
                return this.entryListBoxCalendar;
            }
            else if (this.panelTags.Visible)
            {
                return this.entryListBoxTags;
            }

            return null;
        }

        /// <summary>
        /// Determines whether the main form is in calendar view.
        /// </summary>
        /// <returns>true if in calendar mode, false otherwise.</returns>
        private bool IsInCalendarView()
        {
            return this.GetActiveEntryList() == this.entryListBoxCalendar;
        }

        /// <summary>
        /// Determines whether the main form is in tags view.
        /// </summary>
        /// <returns>true if in tags mode, false otherwise.</returns>
        private bool IsInTagsView()
        {
            return this.GetActiveEntryList() == this.entryListBoxTags;
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
        /// Updates the settings button, depending on the update availability.
        /// </summary>
        private void UpdateSettingsButton()
        {
            bool indicator = this.UpdateAvailable && !this.Settings.AutoUpdate;

            this.buttonSettings.NormalImage = indicator
                ? Properties.Resources.sidebar_btn_setting_update_norm
                : Properties.Resources.sidebar_btn_setting_norm;

            this.buttonSettings.HoverImage = indicator
                ? Properties.Resources.sidebar_btn_setting_update_over
                : Properties.Resources.sidebar_btn_setting_over;

            this.buttonSettings.DownImage = indicator
                ? Properties.Resources.sidebar_btn_setting_update_down
                : Properties.Resources.sidebar_btn_setting_down;

            this.buttonSettings.UpdateImage();
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
                this.monthCalendar.ClearSelection();
                this.monthCalendar.SelectDate(this.SelectedEntry.LocalTime);
            }
            else
            {
                this.monthCalendar.ClearSelection();
                this.monthCalendar.SelectDate(DateTime.Now);
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
        /// Starts editing the currently selected item.
        /// </summary>
        private void StartEditing()
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when editing/saving.");
            Debug.Assert(this.IsEditing == false, "Must not be in the edit mode.");

            this.IsEditing = true;

            // Puts focus on textbox
            this.spellCheckedEntryText.Focus();
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
            this.UpdatePhotoArea();
        }

        /// <summary>
        /// Adds a new entry.
        /// </summary>
        private void AddNewEntry()
        {
            Entry newEntry = null;

            if (this.IsInCalendarView() && this.monthCalendar.SelectedDates.Count == 1)
            {
                DateTime now = DateTime.Now;
                DateTime selected = this.monthCalendar.SelectedDates[0];

                // Overwrite the "Date" portion of the entry with the currently selected date.
                DateTime date = new DateTime(
                    selected.Year,
                    selected.Month,
                    selected.Day,
                    now.Hour,
                    now.Minute,
                    now.Second,
                    now.Millisecond,
                    DateTimeKind.Local);

                do
                {
                    newEntry = new Entry(date.ToUniversalTime());
                }
                while (this.Entries.ContainsKey(newEntry.UUID));
            }
            else if (this.IsInTagsView() && this.listBoxTags.SelectedIndex != -1)
            {
                do
                {
                    newEntry = new Entry();
                }
                while (this.Entries.ContainsKey(newEntry.UUID));

                if (this.listBoxTags.SelectedItem is StarredCountEntry)
                {
                    newEntry.Starred = true;
                }
                else if (this.listBoxTags.SelectedItem is TagCountEntry)
                {
                    newEntry.AddTag(((TagCountEntry)this.listBoxTags.SelectedItem).Tag);
                }
            }
            else
            {
                do
                {
                    newEntry = new Entry();
                }
                while (this.Entries.ContainsKey(newEntry.UUID));
            }

            this.Entries.Add(newEntry.UUID, newEntry);

            this.SelectedEntry = newEntry;

            // Check if there are any "empty" entries on the same day.
            var entriesToDelete = this.Entries.Values
                .Where(x => x != newEntry)
                .Where(x => x.LocalTime.Date == newEntry.LocalTime.Date)
                .Where(x => x.IsEmptyEntry())
                .ToList();  // Make it a list to avoid concurrent modification exception.

            // Delete those, if any.
            foreach (var entryToDelete in entriesToDelete)
            {
                // Protect against the occasional exception dialog. (GitHub Issue #40).
                try
                {
                    entryToDelete.Delete(this.Settings.EntryFolderPath);
                }
                catch (IOException e)
                {
                    Logger.Log(e.Message);
                    Logger.Log(e.StackTrace);
                }

                this.Entries.Remove(entryToDelete.UUID);
            }

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
                        "Your journal folder contains a file named \"photos\", which is preventing Journaley from creating the photo directory.",
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
                bool success = this.SavePhotoForSelectedEntry(
                    Image.FromFile(openDialog.FileName),
                    targetFullPath,
                    "Error reading the selected photo.");

                if (!success)
                {
                    return;
                }
            }

            // Assign the photo path to the selected entry.
            this.SelectedEntry.PhotoPath = targetFullPath;

            // Update the UIs related to photo.
            this.UpdatePhotoUIs();

            // Reset the auto save timer.
            this.AutoSaveTimer.Stop();
            this.AutoSaveTimer.Start();
        }

        /// <summary>
        /// Adds the photo from clipboard.
        /// </summary>
        private void AddPhotoFromClipboard()
        {
            string targetFileName = Path.ChangeExtension(this.SelectedEntry.UUIDString, "jpg");
            string targetFullPath = Path.Combine(this.Settings.PhotoFolderPath, targetFileName);

            bool success = this.SavePhotoForSelectedEntry(
                Clipboard.GetImage(),
                targetFullPath,
                "Error reading the photo from clipboard.");

            if (!success)
            {
                return;
            }

            // Assign the photo path to the selected entry.
            this.SelectedEntry.PhotoPath = targetFullPath;

            // Update the UIs related to photo.
            this.UpdatePhotoUIs();

            // Reset the auto save timer.
            this.AutoSaveTimer.Stop();
            this.AutoSaveTimer.Start();
        }

        /// <summary>
        /// Saves the photo for selected entry.
        /// </summary>
        /// <param name="imageSource">The image source.</param>
        /// <param name="targetFullPath">The target full path.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>true if saving succeeds, false otherwise.</returns>
        private bool SavePhotoForSelectedEntry(Image imageSource, string targetFullPath, string errorMessage)
        {
            try
            {
                using (Image image = imageSource)
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

                            try
                            {
                                this.Watcher.EnableRaisingEvents = false;
                                b.Save(targetFullPath, jpgEncoder, encoderParameters);
                            }
                            finally
                            {
                                this.Watcher.EnableRaisingEvents = true;
                            }
                        }
                        else
                        {
                            try
                            {
                                // Just use the default save method with 75% quality in case the encoder object is not found.
                                this.Watcher.EnableRaisingEvents = false;
                                b.Save(targetFullPath, ImageFormat.Jpeg);
                            }
                            finally
                            {
                                this.Watcher.EnableRaisingEvents = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    errorMessage,
                    "Failed to add photo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
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

            this.UpdatePhoto();
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
                if (this.PhotoExpanded)
                {
                    this.tableLayoutEntryArea.RowStyles[0] = new RowStyle { Height = 100, SizeType = SizeType.Percent };
                    this.tableLayoutEntryArea.RowStyles[1] = new RowStyle { Height = 0, SizeType = SizeType.Absolute };
                }
                else
                {
                    bool imageEmphasize = this.SelectedEntry.EntryText.Trim() == string.Empty;
                    this.tableLayoutEntryArea.RowStyles[0] = new RowStyle { Height = imageEmphasize ? 62 : 38, SizeType = SizeType.Percent };
                    this.tableLayoutEntryArea.RowStyles[1] = new RowStyle { Height = imageEmphasize ? 38 : 62, SizeType = SizeType.Percent };
                }
            }
        }

        /// <summary>
        /// Updates the photo.
        /// </summary>
        private void UpdatePhoto()
        {
            if (this.SelectedEntry != null && this.SelectedEntry.PhotoPath != null)
            {
                using (Image image = Image.FromFile(this.SelectedEntry.PhotoPath))
                {
                    Image copyImage = new Bitmap(image);
                    this.entryPhotoArea.Image = copyImage;
                }
            }
            else
            {
                this.entryPhotoArea.Image = null;
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
            // Detach the EntryWatcher, if it is already set.
            if (this.Watcher != null)
            {
                this.Watcher.EnableRaisingEvents = false;
                this.Watcher.Dispose();
                this.Watcher = null;
            }

            // Clear the current entries.
            this.SelectedEntry = null;
            this.EntryList.ResetEntries();
            this.UpdateAllEntryLists();

            // Load the entries.
            this.EntryList.LoadEntries(this.Settings);

            // Before adding the EntryWatcher, create the "photos" directory if it doesn't exist.
            if (!Directory.Exists(this.Settings.PhotoFolderPath))
            {
                Directory.CreateDirectory(this.Settings.PhotoFolderPath);
            }

            // Set the EntryWatcher.
            this.Watcher = new EntryWatcher(this.Settings.EntryFolderPath, this.Settings.PhotoFolderPath, this);

            this.Watcher.EntryAdded += new EntryEventHandler(this.Watcher_EntryChanged);
            this.Watcher.EntryChanged += new EntryEventHandler(this.Watcher_EntryChanged);
            this.Watcher.EntryDeleted += new EntryEventHandler(this.Watcher_EntryDeleted);
            this.Watcher.PhotoAdded += new EntryEventHandler(this.Watcher_PhotoChanged);
            this.Watcher.PhotoChanged += new EntryEventHandler(this.Watcher_PhotoChanged);
            this.Watcher.PhotoDeleted += new EntryEventHandler(this.Watcher_PhotoDeleted);

            this.Watcher.EnableRaisingEvents = true;

            // Select the latest entry by default.
            if (this.Entries.Any())
            {
                this.SelectedEntry = this.Entries.Values.OrderByDescending(x => x.UTCDateTime).First();
            }

            // Update all the UIs.
            this.UpdateFromScratch();

            // Enable the watcher.
            this.Watcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Removes the selected entry from the database and select next item.
        /// </summary>
        private void RemoveSelectedAndSelectNext()
        {
            // Retrieve the index.
            var sortedEntries = this.Entries.Values.OrderByDescending(x => x.UTCDateTime).ToList();
            int selectedIndex = sortedEntries.IndexOf(this.SelectedEntry);

            // What to select next?
            int nextIndex = selectedIndex == 0 ? selectedIndex + 1 : selectedIndex - 1;

            // Remove from the database.
            this.Entries.Remove(this.SelectedEntry.UUID);

            // After deleting, select the next item.
            if (this.Entries.Any())
            {
                this.SelectedEntry = sortedEntries[nextIndex];
            }
            else
            {
                this.SelectedEntry = null;
            }
        }

        /// <summary>
        /// Sets up the auto save timer.
        /// </summary>
        private void SetupAutoSaveTimer()
        {
            this.AutoSaveTimer = new System.Timers.Timer(AutoSaveThreshold);
            this.AutoSaveTimer.AutoReset = false;
            this.AutoSaveTimer.SynchronizingObject = this;
            this.AutoSaveTimer.Elapsed += this.AutoSaveTimer_Elapsed;
        }

        /// <summary>
        /// Updates the culture information for spell checking.
        /// </summary>
        private void UpdateCultureInfo()
        {
            string culture = this.Settings.SpellCheckLanguage;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
        }

        /// <summary>
        /// Updates the spell check language.
        /// </summary>
        private void UpdateSpellCheckLanguage()
        {
            this.spellCheckedEntryText.SpellCheckLanguage = this.Settings.SpellCheckLanguage;
        }

        /// <summary>
        /// Updates the spell checker enabled status.
        /// </summary>
        private void UpdateSpellCheckEnabled()
        {
            this.spellCheckedEntryText.SpellCheckEnabled = this.Settings.SpellCheckEnabled;
        }

        /// <summary>
        /// Updates the spell checked entry typeface.
        /// </summary>
        private void UpdateSpellCheckedEntryTypeface()
        {
            if (this.Settings.Typeface == null)
            {
                this.Settings.Typeface = "Noto Sans";
                this.Settings.Save();
            }

            switch (this.Settings.Typeface)
            {
                case "Noto Sans":
                    this.spellCheckedEntryText.FontFamily = this.FontFamilyNotoSansWPF;
                    break;

                case "Noto Serif":
                    this.spellCheckedEntryText.FontFamily = this.FontFamilyNotoSerifWPF;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Updates the size of the spell checked entry text.
        /// </summary>
        private void UpdateSpellCheckedEntryTextSize()
        {
            if (this.Settings.TextSize == 0.0f)
            {
                this.Settings.TextSize = SettingsForm.TextSizeMedium;
                this.Settings.Save();
            }

            this.spellCheckedEntryText.Font = new Font(
                this.spellCheckedEntryText.Font.FontFamily,
                this.Settings.TextSize,
                this.spellCheckedEntryText.Font.Style);

            this.spellCheckedEntryText.Initialize();
        }

        /// <summary>
        /// Determines whether the given mouse location relative to the month calendar
        /// is in the header label area.
        /// </summary>
        /// <param name="location">The mouse location relative to the month calendar.</param>
        /// <returns>
        /// true if the cursor is in the label area, false otherwise.
        /// </returns>
        private bool IsCursorInHeaderLabel(Point location)
        {
            int calendarWidth = this.monthCalendar.Width;
            int labelWidth = 100;
            int headerHeight = 30;

            return (calendarWidth - labelWidth) / 2 <= location.X &&
                    location.X < ((calendarWidth - labelWidth) / 2) + labelWidth &&
                    0 <= location.Y &&
                    location.Y < headerHeight;
        }

        /// <summary>
        /// Reads the custom CSS file if one exists.
        /// </summary>
        private void ReadCustomCSS()
        {
            var filePath = Settings.GetFilePathUnderApplicationData(CustomCSSFileName);
            if (File.Exists(filePath))
            {
                this.CustomCSS = File.ReadAllText(filePath);
            }
        }

        #region Event Handlers

        /// <summary>
        /// Handles the Load event of this form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Remember the system settings.
            this.FirstDayOfWeek = Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek;

            // Disable the click sound of the web browser for this process.
            // http://stackoverflow.com/questions/393166/how-to-disable-click-sound-in-webbrowser-control
            PInvoke.CoInternetSetFeatureEnabled(
                21,     // FEATURE_DISABLE_NAVIGATION_SOUNDS
                2,      // SET_FEATURE_ON_PROCESS
                true);  // Enable

            // Set up the initial location of the main form.
            this.CenterToScreen();

            // Get the settings file.
            this.Settings = Settings.Default;

            if (this.Settings == null)
            {
                // When there is no settings file, show up the welcome dialog first.
                WelcomeForm welcomeForm = new WelcomeForm();
                DialogResult result = welcomeForm.ShowDialog(this);

                // If the user cancels the initial settings dialog, just close the whole application.
                if (result != DialogResult.OK)
                {
                    this.Close();
                    return;
                }

                Debug.Assert(result == DialogResult.OK, "When running the application for the first time, you must choose the settings.");

                Debug.Assert(Directory.Exists(welcomeForm.Settings.DayOneFolderPath), "The selected path must exist");
                this.Settings = welcomeForm.Settings;
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

            // Read custom CSS override file if one exists.
            this.ReadCustomCSS();

            this.buttonMainTimeline.UpdateImage();

            this.UpdateCultureInfo();
            this.UpdateSpellCheckLanguage();
            this.UpdateSpellCheckEnabled();
            this.UpdateSpellCheckedEntryTextSize();
            this.UpdateSpellCheckedEntryTypeface();

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
        /// Handles the Shown event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MainForm_Shown(object sender, EventArgs e)
        {
            string updateUrl = @"http://journaley.s3.amazonaws.com/stable";

            string updateSrcFile = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "UpdateSource");

            if (File.Exists(updateSrcFile))
            {
                updateUrl = File.ReadAllText(updateSrcFile, System.Text.Encoding.UTF8).Trim();
            }

            // Update Check
            ++this.UpdateProcessCount;

            try
            {
                using (var mgr = new UpdateManager(updateUrl))
                {
                    // Disable update check when in develop mode.
                    if (!mgr.IsInstalledApp)
                    {
                        return;
                    }

                    this.CurrentlyInstalledVersion = mgr.CurrentlyInstalledVersion();

                    var updateInfo = await mgr.CheckForUpdate();

                    if (updateInfo == null)
                    {
                        return;
                    }

                    if (updateInfo.ReleasesToApply.Any())
                    {
                        await mgr.DownloadReleases(updateInfo.ReleasesToApply);

                        // First, if the user already checked the auto-update option,
                        // simply apply them.
                        if (this.Settings.AutoUpdate)
                        {
                            await mgr.ApplyReleases(updateInfo);
                            return;
                        }

                        // Save the updateInfo and indicate that there is an available update.
                        this.UpdateInfo = updateInfo;
                        this.UpdateAvailable = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                Logger.Log(ex.StackTrace);
            }
            finally
            {
                --this.UpdateProcessCount;
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
                                this.UpdateEntryList(this.Entries.Values.Where(x => x.Starred), this.entryListBoxTags);
                            }
                            else
                            {
                                this.UpdateEntryList(this.Entries.Values.Where(x => x.Tags.Contains(entry.Tag)), this.entryListBoxTags);
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
        /// Handles the DaySelected event of the monthCalendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DaySelectedEventArgs"/> instance containing the event data.</param>
        private void MonthCalendar_DaySelected(object sender, DaySelectedEventArgs e)
        {
            Debug.Assert(this.monthCalendar.SelectedDates.Count == 1, "There must be a single selected date.");
            this.UpdateEntryListBoxCalendar();
        }

        /// <summary>
        /// Handles the DayQueryInfo event of the monthCalendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DayQueryInfoEventArgs"/> instance containing the event data.</param>
        private void MonthCalendar_DayQueryInfo(object sender, DayQueryInfoEventArgs e)
        {
            e.Info.BoldedDate = this.Entries.Values.Any(x => x.LocalTime.Date == e.Date);
            e.OwnerDraw = true;
        }

        /// <summary>
        /// Handles the HeaderMouseLeave event of the monthCalendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MonthCalendar_HeaderMouseLeave(object sender, EventArgs e)
        {
            this.monthCalendar.Header.TextColor = Color.FromArgb(200, 200, 200);
            this.monthCalendar.Header.ShowMonth = true;
        }

        /// <summary>
        /// Handles the MouseMove event of the monthCalendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void MonthCalendar_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsCursorInHeaderLabel(e.Location))
            {
                this.monthCalendar.Header.TextColor = Color.FromArgb(0, 163, 0);
                this.monthCalendar.Header.ShowMonth = false;
            }
            else
            {
                this.monthCalendar.Header.TextColor = Color.FromArgb(200, 200, 200);
                this.monthCalendar.Header.ShowMonth = true;
            }
        }

        /// <summary>
        /// Handles the HeaderClick event of the monthCalendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ClickEventArgs"/> instance containing the event data.</param>
        private void MonthCalendar_HeaderClick(object sender, ClickEventArgs e)
        {
            Point location = this.monthCalendar.PointToClient(Control.MousePosition);
            if (this.IsCursorInHeaderLabel(location))
            {
                this.monthCalendar.SelectDate(DateTime.Today);
            }
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
            form.UpdateAvailable = this.UpdateAvailable;
            form.CurrentVersion = this.CurrentlyInstalledVersion;

            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                bool dayOneFolderChanged = this.Settings.DayOneFolderPath != form.Settings.DayOneFolderPath;
                bool spellCheckEnabledChanged = this.Settings.SpellCheckEnabled != form.Settings.SpellCheckEnabled;
                bool languageChanged = this.Settings.SpellCheckLanguage != form.Settings.SpellCheckLanguage;
                bool typefaceChanged = this.Settings.Typeface != form.Settings.Typeface;
                bool textSizeChanged = this.Settings.TextSize != form.Settings.TextSize;

                this.Settings = form.Settings;
                this.Settings.Save();

                if (spellCheckEnabledChanged)
                {
                    this.UpdateSpellCheckEnabled();
                }

                if (languageChanged)
                {
                    this.UpdateSpellCheckLanguage();
                }

                if (textSizeChanged)
                {
                    // Update the text editor font size.
                    this.UpdateSpellCheckedEntryTextSize();

                    // Update the web browser font size.
                    this.UpdateWebBrowser();
                }

                if (typefaceChanged)
                {
                    this.UpdateSpellCheckedEntryTypeface();
                    this.UpdateWebBrowser();
                }

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
                this.replaceWithTheClipboardImageToolStripMenuItem.Visible = Clipboard.ContainsImage();

                this.contextMenuStripPhotoWithPhoto.Show(
                    this.buttonPhoto, new Point(), ToolStripDropDownDirection.BelowLeft);
            }
            else if (Clipboard.ContainsImage())
            {
                this.contextMenuStripPhotoWithoutPhoto.Show(
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
            tagEditForm.OtherTags.AddRange(this.Entries.Values.SelectMany(x => x.Tags).Distinct().Where(x => !this.SelectedEntry.Tags.Contains(x)).OrderBy(x => x));

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

            // Actually perform the deletion.
            this.SelectedEntry.Delete(this.Settings.EntryFolderPath);

            this.RemoveSelectedAndSelectNext();

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

                this.AutoSaveTimer.Stop();
                this.AutoSaveTimer.Start();
            }
        }

        /// <summary>
        /// Handles the Click event of the replaceWithTheClipboardImageToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ReplaceWithTheClipboardImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "By replacing with the clipboard image, the current photo will be deleted." + Environment.NewLine + "Would you like to continue?",
                "Replace Photo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            this.AddPhotoFromClipboard();
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

            // Reset the auto save timer.
            this.AutoSaveTimer.Stop();
            this.AutoSaveTimer.Start();
        }

        /// <summary>
        /// Handles the Click event of the addFromClipboardToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddPhotoFromClipboard();
        }

        /// <summary>
        /// Handles the Click event of the addFromFileExplorerToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddFromFileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AskToChooseExistingPhoto();
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

                this.AutoSaveTimer.Stop();
                this.AutoSaveTimer.Start();
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
        /// Handles the MouseDown event of the pictureBoxResize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PictureBoxResize_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PInvoke.ReleaseCapture();
                PInvoke.SendMessage(this.Handle, (int)PInvoke.WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)PInvoke.HitTestValues.HTBOTTOMRIGHT, IntPtr.Zero);
            }
        }

        /// <summary>
        /// Handles the ImageClick event of the entryPhotoArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EntryPhotoArea_ImageClick(object sender, EventArgs e)
        {
            if (this.PhotoExpanded == false)
            {
                this.PhotoExpanded = true;
            }
        }

        /// <summary>
        /// Handles the BackButtonClick event of the entryPhotoArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EntryPhotoArea_BackButtonClick(object sender, EventArgs e)
        {
            this.PhotoExpanded = false;
        }

        /// <summary>
        /// Handles the PopoutButtonClick event of the entryPhotoArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EntryPhotoArea_PopoutButtonClick(object sender, EventArgs e)
        {
            Image image = new Bitmap(Image.FromFile(this.SelectedEntry.PhotoPath));

            PhotoDisplayForm photoForm = new PhotoDisplayForm(image, Screen.FromControl(this));
            photoForm.Show();

            this.PhotoExpanded = false;
        }

        /// <summary>
        /// Handles the Elapsed event of the AutoSaveTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void AutoSaveTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.SelectedEntry != null && this.IsEditing)
            {
                this.SaveSelectedEntry();
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the tableLayoutStats control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void TableLayoutStats_MouseDown(object sender, MouseEventArgs e)
        {
            EntryListBox activeEntryList = this.GetActiveEntryList();
            if (activeEntryList != null)
            {
                PInvoke.SCROLLINFO scrollInfo = new PInvoke.SCROLLINFO();
                scrollInfo.fMask = (int)PInvoke.ScrollInfoMask.SIF_ALL;

                PInvoke.GetScrollInfo(activeEntryList.Handle, (int)PInvoke.SBFlags.SB_VERT, ref scrollInfo);

                // Divide into 100 scrolls.
                for (int i = 1; i <= 100; ++i)
                {
                    if (i == 100)
                    {
                        PInvoke.SendMessage(
                            activeEntryList.Handle,
                            (int)PInvoke.WindowsMessages.WM_VSCROLL,
                            (IntPtr)PInvoke.ScrollBarCommands.SB_TOP,
                            IntPtr.Zero);
                    }
                    else
                    {
                        int pos = (int)(scrollInfo.nPos - (scrollInfo.nPos * i / 100.0));
                        PInvoke.SendMessage(
                            activeEntryList.Handle,
                            (int)PInvoke.WindowsMessages.WM_VSCROLL,
                            (IntPtr)((pos << 16) | (int)PInvoke.ScrollBarCommands.SB_THUMBPOSITION),
                            IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the EntryChanged event of the Watcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EntryEventArgs"/> instance containing the event data.</param>
        private void Watcher_EntryChanged(object sender, EntryEventArgs e)
        {
            Entry newEntry = Entry.LoadFromFile(e.FullPath, this.Settings);

            // See if this entry is being edited in the current window.
            if (this.IsEditing && this.SelectedEntry.UUID == e.UUID)
            {
                // Stop the auto save timer here.
                this.AutoSaveTimer.Stop();

                string message = "The current entry has been changed outside Journaley.\n"
                    + "Would you like to reload the entry?\n"
                    + "(If you do, you will lose your local changes to this entry)";

                // Ask if the user wants to reload the entry, or keep the current version.
                DialogResult result = MessageBox.Show(
                    message,
                    "Change detected",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    // Re-enable the auto save timer.
                    this.AutoSaveTimer.Start();

                    return;
                }

                // Here, cancel the edit mode, replace the entry, and replace the selected entry as well.
                this.IsEditing = false;
            }

            // If there was an existing entry with the same ID
            if (this.Entries.ContainsKey(e.UUID))
            {
                Entry oldEntry = this.Entries[e.UUID];

                this.Entries[e.UUID] = newEntry;

                // If the local time remains unchanged, just invalidate the item in the entry list.
                // Otherwise, just refresh the entire list.
                if (oldEntry.LocalTime == newEntry.LocalTime)
                {
                    foreach (var entryList in this.GetAllEntryLists())
                    {
                        int oldIndex = entryList.Items.IndexOf(oldEntry);
                        if (oldIndex >= 0)
                        {
                            entryList.Items[oldIndex] = newEntry;
                        }
                    }

                    this.InvalidateEntryInEntryList(newEntry);
                }
                else
                {
                    this.UpdateAllEntryLists();
                }
            }
            else
            {
                int prevTopIndex = this.GetActiveEntryList().TopIndex;

                this.Entries.Add(e.UUID, newEntry);

                this.UpdateAllEntryLists();

                this.GetActiveEntryList().TopIndex = prevTopIndex;
            }

            if (this.SelectedEntry != null && this.SelectedEntry.UUID == e.UUID)
            {
                this.SelectedEntry = newEntry;
            }
        }

        /// <summary>
        /// Handles the EntryDeleted event of the Watcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EntryEventArgs"/> instance containing the event data.</param>
        private void Watcher_EntryDeleted(object sender, EntryEventArgs e)
        {
            // See if the UUID exists in the database at all.
            if (!this.Entries.ContainsKey(e.UUID))
            {
                // Do nothing.
                return;
            }

            // See if this entry is being edited in the current window.
            if (this.IsEditing && this.SelectedEntry.UUID == e.UUID)
            {
                // Stop the auto save timer here.
                this.AutoSaveTimer.Stop();

                string message = "The current entry has been deleted outside Journaley.\n"
                    + "Would you like to delete the entry?\n"
                    + "(If you do, you will lose your local changes to this entry)";

                // Ask if the user wants to delete this entry, or keep it.
                DialogResult result = MessageBox.Show(
                    message,
                    "Deletion detected",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    // Re-enable the auto save timer.
                    this.AutoSaveTimer.Start();

                    return;
                }

                // Here, cancel the edit mode, and remove the entry.
                this.IsEditing = false;
            }

            // Select next entry.
            if (this.SelectedEntry != null && this.SelectedEntry.UUID == e.UUID)
            {
                this.RemoveSelectedAndSelectNext();
            }
            else if (this.Entries.ContainsKey(e.UUID))
            {
                this.Entries.Remove(e.UUID);
            }
            else
            {
                return;
            }

            this.UpdateFromScratch();
        }

        /// <summary>
        /// Handles the PhotoChanged event of the Watcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EntryEventArgs"/> instance containing the event data.</param>
        private void Watcher_PhotoChanged(object sender, EntryEventArgs e)
        {
            // Ignore this event, in case the associated entry does not exist in the current database.
            if (!this.Entries.ContainsKey(e.UUID))
            {
                return;
            }

            Entry entry = this.Entries[e.UUID];

            // Assign the photo path to the entry.
            entry.PhotoPath = e.FullPath;

            // Update the UIs related to photo.
            if (this.SelectedEntry == entry)
            {
                this.UpdatePhotoUIs();

                // Reset the auto save timer.
                if (this.IsEditing)
                {
                    this.AutoSaveTimer.Stop();
                    this.AutoSaveTimer.Start();
                }
            }
            else
            {
                this.InvalidateEntryInEntryList(entry);
            }
        }

        /// <summary>
        /// Handles the PhotoDeleted event of the Watcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EntryEventArgs"/> instance containing the event data.</param>
        private void Watcher_PhotoDeleted(object sender, EntryEventArgs e)
        {
            // Ignore this event, in case the associated entry does not exist in the current database.
            if (!this.Entries.ContainsKey(e.UUID))
            {
                return;
            }

            Entry entry = this.Entries[e.UUID];

            entry.PhotoPath = null;

            // Update the UIs related to photo.
            if (this.SelectedEntry == entry)
            {
                this.UpdatePhotoUIs();

                // Reset the auto save timer.
                if (this.IsEditing)
                {
                    this.AutoSaveTimer.Stop();
                    this.AutoSaveTimer.Start();
                }
            }
            else
            {
                this.InvalidateEntryInEntryList(entry);
            }
        }

        /// <summary>
        /// Handles the Click event of the imageButtonFormClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ImageButtonFormClose_Click(object sender, EventArgs e)
        {
            if (this.UpdateProcessCount > 0)
            {
                this.DeferredClosing = true;
                this.Hide();
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Handles the MouseMove event of all the scrollable controls.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void Scrollable_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            if (control == null || this.IsEditing || Form.ActiveForm != this)
            {
                return;
            }

            control.Focus();
        }

        /// <summary>
        /// Handles the DocumentCompleted event of the webBrowser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="WebBrowserDocumentCompletedEventArgs"/> instance containing the event data.</param>
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.webBrowser.Document.MouseMove += delegate(object s, HtmlElementEventArgs a)
            {
                if (!this.IsEditing && Form.ActiveForm == this)
                {
                    this.webBrowser.Document.Focus();
                }
            };
        }

        /// <summary>
        /// Handles the MouseMove event of the ToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem == null)
            {
                return;
            }

            menuItem.ForeColor = Color.FromArgb(57, 51, 49);
        }

        /// <summary>
        /// Handles the MouseLeave event of the ToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem == null)
            {
                return;
            }

            menuItem.ForeColor = SystemColors.ControlLightLight;
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

        /// <summary>
        /// Custom color table for the photo menus.
        /// </summary>
        private class PhotoMenuColorTable : ProfessionalColorTable
        {
            /// <summary>
            /// Gets the solid color to use when a <see cref="T:System.Windows.Forms.ToolStripMenuItem" /> other than the top-level <see cref="T:System.Windows.Forms.ToolStripMenuItem" /> is selected.
            /// </summary>
            public override Color MenuItemSelected
            {
                get
                {
                    return Color.FromArgb(41, 161, 249);
                }
            }
        }

        #endregion
    }
}
