using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Journaley.Core.Models;
using System.IO;
using MahApps.Metro.Controls;

namespace Journaley.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public List<Entry> Entries { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.DayOneFolderPath = @"C:\Users\pinajo\Downloads\Journal.dayone\Journal.dayone";
            DirectoryInfo dinfo = new DirectoryInfo(settings.EntryFolderPath);
            FileInfo[] files = dinfo.GetFiles("*.doentry");

            Entries = files.Select(x => Entry.LoadFromFile(x.FullName, settings)).Where(x => x != null).ToList();
            listViewEntries.ItemsSource = Entries;
        }

    }
}
