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
        private Entry SelectedEntry { get; set; }

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

            UpdateStats();
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

        private void UpdateStats()
        {
            this.labelEntries.Text = this.Entries.Count.ToString();
            this.labelDays.Text = this.Entries.Select(x => x.LocalTime.ToString("yyyyMMdd")).Distinct().Count().ToString();

            DateTime now = DateTime.Now;
            now = now.ToLocalTime();

            this.labelToday.Text = this.Entries.Where(x => x.LocalTime.Year == now.Year && x.LocalTime.Month == now.Month && x.LocalTime.Day == now.Day).Count().ToString();
        }

        private void UpdateEntryListBoxAll()
        {
            // Clear everything.
            this.entryListBoxAll.Items.Clear();

            var groupedEntries = this.Entries
                .OrderByDescending(x => x.UTCDateTime)
                .GroupBy(x => new DateTime(x.LocalTime.Year, x.LocalTime.Month, 1));

            foreach (var group in groupedEntries)
            {
                this.entryListBoxAll.Items.Add(group.Key);
                this.entryListBoxAll.Items.AddRange(group.ToArray());
            }
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
    }
}
