namespace Journaley.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
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
        /// The normal retype message
        /// </summary>
        private static readonly string RetypeMessageNormal = "Retype";

        /// <summary>
        /// The retype message shown once the passwords in both boxes didn't match
        /// </summary>
        private static readonly string RetypeMessageError = "Retype password to confirm";

        /// <summary>
        /// The backing field for Settings property.
        /// </summary>
        private Settings settings;

        /// <summary>
        /// Indicates whether the password section is currently in the password setting mode.
        /// </summary>
        private bool settingPassword = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsForm"/> class.
        /// </summary>
        public SettingsForm()
        {
            this.InitializeComponent();

            this.buttonSizeSmall.Tag = TextSizeSmall;
            this.buttonSizeMedium.Tag = TextSizeMedium;
            this.buttonSizeLarge.Tag = TextSizeLarge;

            this.SettingPassword = false;
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
        /// Gets or sets a value indicating whether the password section is in the setting mode.
        /// When this property changes, the password UI also switches the panel shown to the user.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the password section is in the setting mode; otherwise, <c>false</c>.
        /// </value>
        public bool SettingPassword
        {
            get
            {
                return this.settingPassword;
            }

            set
            {
                this.settingPassword = value;

                this.panelPasswordNormal.Visible = !value;
                this.panelPasswordSetting.Visible = value;
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
        /// Initializes the spell check setting interface.
        /// </summary>
        private void InitializeSpellCheckInterface()
        {
            // Get all the available cultures.
            string[] supportedLanguages = new string[] { "en", "fr", "de", "es" };

            var cultureDict = supportedLanguages
                .Select(x => CultureInfo.GetCultureInfo(x))
                .OrderBy(x => x.EnglishName)
                .ToDictionary(x => x.Name, x => x.EnglishName);

            this.comboSpellcheckLanguages.DataSource = new BindingSource(cultureDict, null);
            this.comboSpellcheckLanguages.DisplayMember = "Value";
            this.comboSpellcheckLanguages.ValueMember = "Key";

            // Use en-US as the default culture used by the spell checker.
            if (string.IsNullOrEmpty(this.Settings.SpellCheckLanguage) ||
                !cultureDict.ContainsKey(this.Settings.SpellCheckLanguage))
            {
                this.Settings.SpellCheckLanguage = "en";
            }

            // Find the current culture and select it from the combo box.
            this.comboSpellcheckLanguages.SelectedItem = new KeyValuePair<string, string>(
                this.Settings.SpellCheckLanguage,
                cultureDict[this.Settings.SpellCheckLanguage]);

            // Attach the handler here, in order to suppress this event being handled while
            // populating the initial values.
            this.comboSpellcheckLanguages.SelectedIndexChanged +=
                this.ComboSpellcheckLanguages_SelectedIndexChanged;

            this.UpdateSpellCheckInterface();
        }

        /// <summary>
        /// Updates the spell check interface.
        /// </summary>
        private void UpdateSpellCheckInterface()
        {
            this.checkBoxEnableSpellCheck.Checked = this.Settings.SpellCheckEnabled;
            this.comboSpellcheckLanguages.Enabled = this.Settings.SpellCheckEnabled;
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
        /// Starts the password editing UI.
        /// </summary>
        private void StartEditingPassword()
        {
            this.textPassword.Text = null;
            this.textPasswordConfirm.Text = null;

            this.labelPasswordConfirm.ForeColor = SystemColors.ControlText;
            this.labelPasswordConfirm.Text = RetypeMessageNormal;

            this.SettingPassword = true;

            this.textPassword.Focus();
        }

        /// <summary>
        /// Tries to set password with the given values.
        /// In this process, detect user mistakes and take appropriate actions.
        /// (e.g., highlight the empty password box, change the message, ...)
        /// </summary>
        private void TrySetPassword()
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

            // Finally, set the password and get back to the normal mode.
            this.Settings.Password = this.textPassword.Text;
            this.UpdatePasswordInterface();

            this.SettingPassword = false;
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
            // Set the initial location.
            if (this.Owner != null)
            {
                this.Location = new Point(
                    this.Owner.Left + ((this.Owner.Width - this.Width) / 2) + 10,
                    this.Owner.Top + this.panelTitlebar.Height);
            }

            if (this.settings == null)
            {
                this.DisableCancel = true;
                this.buttonCancel.Enabled = false;
            }

            // Set the font of the font size buttons to Noto Serif.
            // The font family is force set to in-memory Noto Serif.
            // Other properties (size, style) will be inherited from the designer settings.
            if (this.Owner != null && this.Owner is MainForm)
            {
                var fontFamily = ((MainForm)this.Owner).FontFamilyNotoSerifRegular;

                foreach (var sizeButton in this.GetAllSizeButtons())
                {
                    sizeButton.Font = new Font(
                        fontFamily,
                        sizeButton.Font.Size,
                        sizeButton.Font.Style,
                        sizeButton.Font.Unit,
                        sizeButton.Font.GdiCharSet);
                }
            }

            if (this.Settings.TextSize == 0.0)
            {
                this.Settings.TextSize = TextSizeMedium;
            }

            this.InitializeSpellCheckInterface();

            // Update the rest of the UIs.
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
        /// Handles the Click event of the checkBoxEnableSpellCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CheckBoxEnableSpellCheck_Click(object sender, EventArgs e)
        {
            this.Settings.SpellCheckEnabled = this.checkBoxEnableSpellCheck.Checked;

            this.UpdateSpellCheckInterface();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboSpellcheckLanguages control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ComboSpellcheckLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Settings.SpellCheckLanguage = this.comboSpellcheckLanguages.SelectedValue.ToString();
        }

        /// <summary>
        /// Handles the Click event of the checkBoxEnablePassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CheckBoxEnablePassword_Click(object sender, EventArgs e)
        {
            if (this.checkBoxEnablePassword.Checked)
            {
                // Get in to the password setting mode.
                this.StartEditingPassword();
            }
            else
            {
                // Now disable the password.
                this.Settings.PasswordHash = null;
                this.UpdatePasswordInterface();
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonChangePassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            this.StartEditingPassword();
        }

        /// <summary>
        /// Handles the Click event of the buttonSetPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSetPassword_Click(object sender, EventArgs e)
        {
            this.TrySetPassword();
        }

        /// <summary>
        /// Handles the Click event of the buttonCancelPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonCancelPassword_Click(object sender, EventArgs e)
        {
            this.UpdatePasswordInterface();
            this.SettingPassword = false;
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
        /// Handles the KeyDown event of the textPasswordConfirm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void TextPasswordConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.TrySetPassword();

                    e.Handled = true;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the KeyPress event of the textPasswordConfirm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void TextPasswordConfirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    e.Handled = true;
                    break;

                default:
                    break;
            }
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
