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

namespace DayOneWindowsClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Icon = Resources.MainIcon;
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
                }
                else
                {
                    _isEditing = false;
                }

                UpdateStar();
                UpdateUI();
            }
        }

        private void SaveSelectedEntry()
        {
            if (this.SelectedEntry == null)
                return;

            this.SelectedEntry.EntryText = this.textEntryText.Text.Replace(Environment.NewLine, "\n");

            if (this.SelectedEntry.IsDirty)
                this.SelectedEntry.Save(this.Settings.DayOneFolderPath);
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
                this.textEntryText.Text = "";

            this.dateTimePicker.Enabled = this.IsEditing;
            this.buttonEditSave.Image = this.IsEditing ? Properties.Resources.Save_32x32 : Properties.Resources.Edit_32x32;
            this.toolTip.SetToolTip(this.buttonEditSave, this.IsEditing ? "Save" : "Edit");
            this.textEntryText.ReadOnly = !this.IsEditing;
        }

        private void UpdateStar()
        {
            this.buttonStar.Image = (this.SelectedEntry != null && this.SelectedEntry.Starred) ?
                Properties.Resources.StarYellow_32x32 : Properties.Resources.StarGray_32x32;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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

            LoadEntries();

            UpdateFromScratch();
        }

        private void UpdateFromScratch()
        {
            UpdateStats();
            UpdateAllEntryLists();
            UpdateUI();
        }

        private void UpdateStats()
        {
            this.labelEntries.Text = this.Entries.Count.ToString();
            this.labelDays.Text = this.Entries.Select(x => x.LocalTime.ToString("yyyyMMdd")).Distinct().Count().ToString();
            this.labelToday.Text = this.Entries.Where(x => x.LocalTime.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd")).Count().ToString();
        }

        private void UpdateEntryListBoxAll()
        {
            // Clear everything.
            this.entryListBoxAll.Items.Clear();

            // Reverse sort and group by month.
            var groupedEntries = this.Entries
                .OrderByDescending(x => x.UTCDateTime)
                .GroupBy(x => new DateTime(x.LocalTime.Year, x.LocalTime.Month, 1));

            foreach (var group in groupedEntries)
            {
                this.entryListBoxAll.Items.Add(group.Key);
                this.entryListBoxAll.Items.AddRange(group.ToArray());
            }

            // If there is a selected entry, select it!
            if (this.SelectedEntry != null)
            {
                int index = this.entryListBoxAll.Items.IndexOf(this.SelectedEntry);
                if (index != -1)
                {
                    this.entryListBoxAll.SelectedIndex = index;
                    this.entryListBoxAll.TopIndex = index;
                }
            }
        }

        private void UpdateAllEntryLists()
        {
            UpdateEntryListBoxAll();
        }

        private void LoadEntries()
        {
            LoadEntries(this.Settings.DayOneFolderPath);
        }

        private void LoadEntries(string path)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);
            FileInfo[] files = dinfo.GetFiles("*.doentry");

            this.Entries = files.Select(x => Entry.LoadFromFile(x.FullName)).ToList();
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
    }
}
