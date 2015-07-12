namespace Journaley.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Journaley.Core.Models;

    /// <summary>
    /// The welcome screen which will be shown to the user when Journaley is launched
    /// for the first time
    /// </summary>
    public partial class WelcomeForm : BaseJournaleyForm
    {
        /// <summary>
        /// The possible app folder names in all the different languages supported by Dropbox.
        /// </summary>
        private static readonly string[] AppFolderNames =
        {
            "Aplikasi",
            "Apl",
            "Apps",
            "Aplicaciones",
            "Applications",
            "Applicazioni",
            "Apper",
            "Aplikacje",
            "Aplicativos",
            "Приложения",
            "Applikationer",
            "Програми",
            "แอพ",
            "应用",
            "應用程式",
            "アプリ",
            "앱"
        };

        /// <summary>
        /// List of all the bottom panels
        /// </summary>
        private List<Panel> bottomPanels;

        /// <summary>
        /// The sub-messages to be shown for each bottom panel.
        /// </summary>
        private Dictionary<int, string> panelMessages;

        /// <summary>
        /// The backing field for Settings property.
        /// </summary>
        private Settings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="WelcomeForm"/> class.
        /// </summary>
        public WelcomeForm()
        {
            this.InitializeComponent();

            this.bottomPanels = new List<Panel>();
            this.bottomPanels.Add(this.bottomPanel1Init);
            this.bottomPanels.Add(this.bottomPanel2StartNewJournal);
            this.bottomPanels.Add(this.bottomPanel3LocationSelected);
            this.bottomPanels.Add(this.bottomPanel4PasswordSetting);
            this.bottomPanels.Add(this.bottomPanel5ImportJournal);
            this.bottomPanels.Add(this.bottomPanel6Complete);

            this.panelMessages = new Dictionary<int, string>();
            this.panelMessages.Add(2, "Okay.");
            this.panelMessages.Add(3, "Great!");
            this.panelMessages.Add(4, "Make sure not to forget it!");
            this.panelMessages.Add(5, "Okay.");
            this.panelMessages.Add(6, "Welcome.");

            this.ShowBottomPanel(1);
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public Settings Settings
        {
            get
            {
                if (this.settings == null)
                {
                    this.settings = new Settings();
                }

                return this.settings;
            }

            set
            {
                this.settings = value;
            }
        }

        /// <summary>
        /// Shows the bottom panel.
        /// </summary>
        /// <param name="panelIndex">Index of the panel (1 - 6).</param>
        /// <exception cref="System.IndexOutOfRangeException">thrown when the given index is out of range.</exception>
        private void ShowBottomPanel(int panelIndex)
        {
            if (panelIndex < 1 || panelIndex > this.bottomPanels.Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (panelIndex == 1)
            {
                this.ShowGreetings();
            }
            else
            {
                this.labelMainMessage.Text = this.panelMessages[panelIndex];
            }

            for (int i = 0; i < this.bottomPanels.Count; ++i)
            {
                this.bottomPanels[i].Visible = i + 1 == panelIndex;
            }
        }

        /// <summary>
        /// Shows the greetings message depending on the current time.
        /// [00:00, 12:00) : Good morning.
        /// [12:00, 17:00) : Good afternoon.
        /// [17:00, 24:00) : Good evening.
        /// </summary>
        private void ShowGreetings()
        {
            DateTime now = DateTime.Now;

            if (0 <= now.Hour && now.Hour < 12)
            {
                this.labelMainMessage.Text = "Good morning.";
            }
            else if (now.Hour < 17)
            {
                this.labelMainMessage.Text = "Good afternoon.";
            }
            else
            {
                this.labelMainMessage.Text = "Good evening.";
            }
        }

        /// <summary>
        /// Finds the Dropbox folder location.
        /// </summary>
        /// <returns>the Dropbox folder location if found, null otherwise.</returns>
        private string FindDropboxLocation()
        {
            // Code taken from Stackoverflow.
            // http://stackoverflow.com/questions/9660280/
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var hostDBPath = Path.Combine(appDataPath, @"Dropbox\host.db");

            if (!File.Exists(hostDBPath))
            {
                return null;
            }

            var lines = File.ReadAllLines(hostDBPath);
            var base64Text = Convert.FromBase64String(lines[1]);
            var folderPath = Encoding.UTF8.GetString(base64Text);

            return folderPath;
        }

        /// <summary>
        /// Finds the Day One app folder location under Dropbox.
        /// </summary>
        /// <returns>
        /// the Day One app folder location if found, null otherwise.
        /// </returns>
        private string FindDropboxDayOneLocation()
        {
            var dropboxFolder = this.FindDropboxLocation();
            if (dropboxFolder == null)
            {
                return null;
            }

            foreach (var appFolder in AppFolderNames)
            {
                var targetFolder = Path.Combine(dropboxFolder, appFolder, "Day One", "Journal.dayone");
                if (Directory.Exists(targetFolder))
                {
                    return targetFolder;
                }
            }

            return null;
        }

        /// <summary>
        /// Lets the user browse to their existing journal.
        /// </summary>
        private void BrowseToExistingJournal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lets the user browse to a new journal location.
        /// </summary>
        private void BrowseToNewJournal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles the Click event of the buttonImportJournal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonImportJournal_Click(object sender, EventArgs e)
        {
            // "Import Your Journal" button clicked from panel 1.
            // Determine if Dropbox is installed in the current machine and if Day One is installed
            // under Dropbox. If so, move to panel 5.
            // Otherwise, show the folder selection dialog and
            // let the user browse to the existing Journal location.
            if (this.FindDropboxDayOneLocation() != null)
            {
                this.ShowBottomPanel(5);
            }
            else
            {
                this.BrowseToExistingJournal();
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonStartNewJournal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonStartNewJournal_Click(object sender, EventArgs e)
        {
            // "Start a New Journal" button clicked from panel 1.
            // Determine if Dropbox is installed in the current machine.
            // If so, move to panel 2.
            // Otherwise, show the folder selection dialog and
            // let the user browse to the new journal location.
            if (this.FindDropboxLocation() != null)
            {
                this.ShowBottomPanel(2);
            }
            else
            {
                this.BrowseToNewJournal();
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonPanel2Browse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonPanel2Browse_Click(object sender, EventArgs e)
        {
            this.BrowseToNewJournal();
        }

        /// <summary>
        /// Handles the Click event of the buttonDropboxJournaley control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonDropboxJournaley_Click(object sender, EventArgs e)
        {
            this.Settings.DayOneFolderPath = Path.Combine(this.FindDropboxLocation(), "Journaley");
            this.labelJournalLocation.Text = this.Settings.DayOneFolderPath;
            this.ShowBottomPanel(3);
        }
    }
}
