namespace Journaley.Forms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Journaley.Controls;
    using Journaley.Core.Models;

    /// <summary>
    /// A form used for adjusting various settings.
    /// </summary>
    public partial class SettingsForm : BaseJournaleyForm
    {
        /// <summary>
        /// The text size small
        /// </summary>
        public static readonly float TextSizeSmall = 10.0f;

        /// <summary>
        /// The text size medium
        /// </summary>
        public static readonly float TextSizeMedium = 13.0f;

        /// <summary>
        /// The text size large
        /// </summary>
        public static readonly float TextSizeLarge = 16.0f;

        /// <summary>
        /// The backing field for Settings property.
        /// </summary>
        private Settings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsForm"/> class.
        /// </summary>
        public SettingsForm()
        {
            this.InitializeComponent();

            this.buttonSizeSmall.Tag = TextSizeSmall;
            this.buttonSizeMedium.Tag = TextSizeMedium;
            this.buttonSizeLarge.Tag = TextSizeLarge;
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
        /// Gets or sets a value indicating whether [disable cancel].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [disable cancel]; otherwise, <c>false</c>.
        /// </value>
        private bool DisableCancel { get; set; }

        /// <summary>
        /// Gets all the text size buttons.
        /// </summary>
        /// <returns>All the text size buttons.</returns>
        private IEnumerable<Control> GetAllSizeButtons()
        {
            yield return this.buttonSizeSmall;
            yield return this.buttonSizeMedium;
            yield return this.buttonSizeLarge;
        }

        /// <summary>
        /// Updates the text size interface.
        /// Highlight the currently used text size.
        /// </summary>
        private void UpdateTextSizeInterface()
        {
            if (this.Settings.TextSize == 0.0)
            {
                this.Settings.TextSize = TextSizeMedium;
            }

            foreach (Control sizeButton in this.GetAllSizeButtons())
            {
                if (sizeButton is ISelectable && sizeButton.Tag != null)
                {
                    ((ISelectable)sizeButton).Selected = sizeButton.Tag.Equals(this.Settings.TextSize);
                }
            }
        }

        /// <summary>
        /// Updates the password interface.
        /// </summary>
        private void UpdatePasswordInterface()
        {
            bool passwordEnabled = this.Settings.HasPassword;

            this.checkBoxEnablePassword.Checked = passwordEnabled;
            this.buttonChangePassword.Enabled = passwordEnabled;

            // this.buttonChangePassword.Visible = passwordEnabled;
            // this.buttonEnablePassword.Visible = !passwordEnabled;
            // this.buttonRemovePassword.Visible = passwordEnabled;
        }

        /// <summary>
        /// Updates the folder interface.
        /// </summary>
        private void UpdateFolderInterface()
        {
            this.textFolder.Text = this.Settings.DayOneFolderPath;
            this.buttonOK.Enabled = Directory.Exists(this.Settings.DayOneFolderPath);
        }

        /// <summary>
        /// Handles the Load event of the SettingsForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (this.settings == null)
            {
                this.DisableCancel = true;
                this.buttonCancel.Enabled = false;
            }

            if (this.Settings.TextSize == 0.0)
            {
                this.Settings.TextSize = TextSizeMedium;
            }

            this.UpdateTextSizeInterface();
            this.UpdatePasswordInterface();
            this.UpdateFolderInterface();
        }

        /// <summary>
        /// Handles the Click event of the buttonSizeSmall control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSizeSmall_Click(object sender, EventArgs e)
        {
            this.Settings.TextSize = TextSizeSmall;
            this.UpdateTextSizeInterface();
        }

        /// <summary>
        /// Handles the Click event of the buttonSizeMedium control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSizeMedium_Click(object sender, EventArgs e)
        {
            this.Settings.TextSize = TextSizeMedium;
            this.UpdateTextSizeInterface();
        }

        /// <summary>
        /// Handles the Click event of the buttonSizeLarge control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSizeLarge_Click(object sender, EventArgs e)
        {
            this.Settings.TextSize = TextSizeLarge;
            this.UpdateTextSizeInterface();
        }

        /// <summary>
        /// Handles the Click event of the buttonChangePassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            /*
            ChangePasswordForm form = new ChangePasswordForm(this.Settings);

            DialogResult result = form.ShowDialog(this);

            if (result != DialogResult.Cancel)
            {
                this.Settings.Password = form.NewPassword;
            }
            */

            this.UpdatePasswordInterface();
        }

        /// <summary>
        /// Handles the Click event of the buttonSelectFolder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSelectFolder_Click(object sender, EventArgs e)
        {
            while (true)
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.SelectedPath = this.Settings.DayOneFolderPath;
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
                this.UpdateFolderInterface();

                break;
            }
        }
    }
}
