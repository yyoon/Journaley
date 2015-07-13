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
    /// The welcome UI which will be shown to the user when Journaley is launched for the first time.
    /// This class follows the storyboard described in "WelcomeUI_Storyboard" image file.
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
        /// The normal border color for the password textboxes.
        /// </summary>
        private static readonly Color BorderColorNormal = Color.FromArgb(100, 100, 100);

        /// <summary>
        /// The red border color for the password textboxes indicating an error.
        /// </summary>
        private static readonly Color BorderColorError = Color.FromArgb(218, 36, 36);

        /// <summary>
        /// The color of the retype message in its normal state.
        /// </summary>
        private static readonly Color RetypeMessageColorNormal = SystemColors.ControlText;

        /// <summary>
        /// The color of the retype message in its error state.
        /// </summary>
        private static readonly Color RetypeMessageColorError = Color.FromArgb(218, 36, 36);

        /// <summary>
        /// The retype message shown once the passwords in both boxes didn't match
        /// </summary>
        private static readonly string RetypeMessageError = "Retype password to confirm";

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
            while (true)
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                DialogResult result = folderDialog.ShowDialog(this);

                if (result == DialogResult.Cancel)
                {
                    break;
                }

                // Does the folder exist?
                if (!Directory.Exists(folderDialog.SelectedPath))
                {
                    MessageBox.Show(
                        this,
                        "The provided folder does not exist.\nPlease select another folder.",
                        "Journaley",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    continue;
                }

                string entriesPath = Path.Combine(folderDialog.SelectedPath, "entries");

                // Is it an empty folder?
                if (!Directory.EnumerateFileSystemEntries(folderDialog.SelectedPath).Any())
                {
                    // Ask the user if she wants to create Journaley files there.
                    DialogResult createDirectoryResult = MessageBox.Show(
                        this,
                        "The selected folder is empty.\nWould you like to use this folder to store your data?",
                        "Journaley",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (createDirectoryResult == DialogResult.Yes)
                    {
                        // Create "entries" folder.
                        try
                        {
                            Directory.CreateDirectory(entriesPath);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(
                                this,
                                "Failed to create subfolders.\nPlease select another folder.",
                                "Journaley",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                // Is it a valid Journaley / Day One folder?
                if (!Directory.Exists(entriesPath))
                {
                    DialogResult createDirectoryResult = MessageBox.Show(
                        this,
                        "The selected folder is not a Journaley folder.\nWould you like to create a subfolder named \"Journaley\" and use it to store your data?",
                        "Journaley",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);

                    if (createDirectoryResult == DialogResult.Yes)
                    {
                        // Create "Journaley\entries" folder.
                        try
                        {
                            Directory.CreateDirectory(Path.Combine(folderDialog.SelectedPath, "Journaley"));
                            folderDialog.SelectedPath = Path.Combine(folderDialog.SelectedPath, "Journaley");
                            Directory.CreateDirectory(Path.Combine(folderDialog.SelectedPath, "entries"));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(
                                this,
                                "Failed to create subfolders.\nPlease select another folder.",
                                "Journaley",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                this.Settings.DayOneFolderPath = folderDialog.SelectedPath;
                this.ShowBottomPanel(3);

                break;
            }
        }

        /// <summary>
        /// Lets the user browse to a new journal location.
        /// </summary>
        private void BrowseToNewJournal()
        {
            while (true)
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                DialogResult result = folderDialog.ShowDialog(this);
                DialogResult createDirectoryResult;

                if (result == DialogResult.Cancel)
                {
                    break;
                }

                // Does the folder exist?
                if (!Directory.Exists(folderDialog.SelectedPath))
                {
                    MessageBox.Show(
                        this,
                        "The provided folder does not exist.\nPlease select another folder.",
                        "Journaley",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    continue;
                }

                string entriesPath = Path.Combine(folderDialog.SelectedPath, "entries");

                // Is it an empty folder?
                if (!Directory.EnumerateFileSystemEntries(folderDialog.SelectedPath).Any())
                {
                    // Ask the user if she wants to create Journaley files there.
                    createDirectoryResult = MessageBox.Show(
                        this,
                        "The selected folder is empty.\nWould you like to use this folder to store your data?",
                        "Journaley",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (createDirectoryResult == DialogResult.Yes)
                    {
                        // Create "entries" folder.
                        try
                        {
                            Directory.CreateDirectory(entriesPath);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(
                                this,
                                "Failed to create subfolders.\nPlease select another folder.",
                                "Journaley",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                createDirectoryResult = MessageBox.Show(
                    this,
                    "The selected folder is not empty.\nWould you like to create a subfolder named \"Journaley\" and use it to store your data?",
                    "Journaley",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);

                if (createDirectoryResult == DialogResult.Yes)
                {
                    // Create "Journaley\entries" folder.
                    try
                    {
                        Directory.CreateDirectory(Path.Combine(folderDialog.SelectedPath, "Journaley"));
                        folderDialog.SelectedPath = Path.Combine(folderDialog.SelectedPath, "Journaley");
                        Directory.CreateDirectory(Path.Combine(folderDialog.SelectedPath, "entries"));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            this,
                            "Failed to create subfolders.\nPlease select another folder.",
                            "Journaley",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        continue;
                    }
                }
                else
                {
                    continue;
                }

                this.Settings.DayOneFolderPath = folderDialog.SelectedPath;
                this.ShowBottomPanel(3);

                break;
            }
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
            var dropboxFolder = this.FindDropboxLocation();
            this.Settings.DayOneFolderPath = Path.Combine(dropboxFolder, "Journaley");

            try
            {
                Directory.CreateDirectory(Path.Combine(dropboxFolder, "Journaley"));
                Directory.CreateDirectory(Path.Combine(dropboxFolder, "Journaley", "entries"));
            }
            catch (Exception)
            {
                MessageBox.Show(
                    this,
                    "Failed to create subfolders.\nPlease select another folder.",
                    "Journaley",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            this.ShowBottomPanel(3);
        }

        /// <summary>
        /// Handles the Click event of the buttonSetupPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSetupPassword_Click(object sender, EventArgs e)
        {
            this.ShowBottomPanel(4);
        }

        /// <summary>
        /// Handles the Click event of the buttonLaunchJournaley control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonLaunchJournaley_Click(object sender, EventArgs e)
        {
            this.ShowBottomPanel(6);
        }

        /// <summary>
        /// Handles the TextChanged event of the textPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TextPassword_TextChanged(object sender, EventArgs e)
        {
            if (this.borderPassword.BackColor == BorderColorError)
            {
                this.borderPassword.BackColor = BorderColorNormal;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the textPasswordConfirm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TextPasswordConfirm_TextChanged(object sender, EventArgs e)
        {
            if (this.labelPasswordConfirm.ForeColor == RetypeMessageColorError)
            {
                this.labelPasswordConfirm.ForeColor = RetypeMessageColorNormal;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonSavePassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSavePassword_Click(object sender, EventArgs e)
        {
            // First, check if the password box is empty.
            if (string.IsNullOrEmpty(this.textPassword.Text))
            {
                this.borderPassword.BackColor = BorderColorError;
                this.textPassword.Focus();

                return;
            }

            // Next, check if the password matches with the one in the confirm box.
            if (this.textPassword.Text != this.textPasswordConfirm.Text)
            {
                this.labelPasswordConfirm.ForeColor = RetypeMessageColorError;
                this.labelPasswordConfirm.Text = RetypeMessageError;

                this.textPasswordConfirm.SelectAll();
                this.textPasswordConfirm.Focus();

                return;
            }

            // Finally, set the password and move to panel 6.
            this.Settings.Password = this.textPassword.Text;
            this.ShowBottomPanel(6);
        }

        /// <summary>
        /// Handles the Click event of the buttonPanel5Browse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonPanel5Browse_Click(object sender, EventArgs e)
        {
            this.BrowseToExistingJournal();
        }

        /// <summary>
        /// Handles the Click event of the buttonDropboxDayOne control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonDropboxDayOne_Click(object sender, EventArgs e)
        {
            this.Settings.DayOneFolderPath = this.FindDropboxDayOneLocation();
            this.ShowBottomPanel(3);
        }

        /// <summary>
        /// Handles the Click event of the buttonOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles the VisibleChanged event of the bottomPanel3LocationSelected control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BottomPanel3LocationSelected_VisibleChanged(object sender, EventArgs e)
        {
            this.labelJournalLocation.Text = this.Settings.DayOneFolderPath;
        }
    }
}
