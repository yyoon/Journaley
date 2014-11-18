namespace Journaley.Core.Watcher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A utility class that monitors all the entries and photos.
    /// </summary>
    public class EntryWatcher : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntryWatcher" /> class.
        /// </summary>
        /// <param name="entryFolderPath">The entry folder path.</param>
        /// <param name="photoFolderPath">The photo folder path.</param>
        public EntryWatcher(string entryFolderPath, string photoFolderPath)
        {
            this.EntryFolderWatcher = new FileSystemWatcher(entryFolderPath);
            this.EntryFolderWatcher.NotifyFilter =
                NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size;

            this.EntryFolderWatcher.Created += new FileSystemEventHandler(this.EntryFolderWatcher_Created);
            this.EntryFolderWatcher.Changed += new FileSystemEventHandler(this.EntryFolderWatcher_Changed);
            this.EntryFolderWatcher.Deleted += new FileSystemEventHandler(this.EntryFolderWatcher_Deleted);

            this.PhotoFolderWatcher = new FileSystemWatcher(photoFolderPath);
            this.PhotoFolderWatcher.NotifyFilter =
                NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size;

            this.PhotoFolderWatcher.Created += new FileSystemEventHandler(this.PhotoFolderWatcher_Created);
            this.PhotoFolderWatcher.Changed += new FileSystemEventHandler(this.PhotoFolderWatcher_Changed);
            this.PhotoFolderWatcher.Deleted += new FileSystemEventHandler(this.PhotoFolderWatcher_Deleted);
        }

        /// <summary>
        /// Occurs when a new entry is added outside Journaley.
        /// </summary>
        public event EntryEventHandler EntryAdded;

        /// <summary>
        /// Occurs when an entry is changed outside Journaley.
        /// </summary>
        public event EntryEventHandler EntryChanged;

        /// <summary>
        /// Occurs when an entry is removed outside Journaley.
        /// </summary>
        public event EntryEventHandler EntryDeleted;

        /// <summary>
        /// Occurs when a photo is added outside Journaley.
        /// </summary>
        public event EntryEventHandler PhotoAdded;

        /// <summary>
        /// Occurs when a photo is changed outside Journaley.
        /// </summary>
        public event EntryEventHandler PhotoChanged;

        /// <summary>
        /// Occurs when a photo is removed outside Journaley.
        /// </summary>
        public event EntryEventHandler PhotoDeleted;

        /// <summary>
        /// Gets or sets a value indicating whether to enable raising events.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this watcher raises events; otherwise, <c>false</c>.
        /// </value>
        public bool EnableRaisingEvents
        {
            get
            {
                return this.EntryFolderWatcher.EnableRaisingEvents;
            }

            set
            {
                this.EntryFolderWatcher.EnableRaisingEvents = value;
                this.PhotoFolderWatcher.EnableRaisingEvents = value;
            }
        }

        /// <summary>
        /// Gets or sets the file system watcher for the entry folder.
        /// </summary>
        /// <value>
        /// The file system watcher for the entry folder.
        /// </value>
        private FileSystemWatcher EntryFolderWatcher { get; set; }

        /// <summary>
        /// Gets or sets the file system watcher for the photo folder.
        /// </summary>
        /// <value>
        /// The file system watcher for the photo folder.
        /// </value>
        private FileSystemWatcher PhotoFolderWatcher { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.EntryFolderWatcher != null)
            {
                this.EntryFolderWatcher.Dispose();
            }

            if (this.PhotoFolderWatcher != null)
            {
                this.PhotoFolderWatcher.Dispose();
            }
        }

        /// <summary>
        /// Handles the Created event of the EntryFolderWatcher control.
        /// In turn, it fires the EntryAdded event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
        private void EntryFolderWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (this.EntryAdded != null)
            {
                EntryEventArgs eea = new EntryEventArgs(e, ChangeType.EntryAdded);
                this.EntryAdded(this, eea);
            }
        }

        /// <summary>
        /// Handles the Changed event of the EntryFolderWatcher control.
        /// In turn, it fires the EntryChanged event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
        private void EntryFolderWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (this.EntryChanged != null)
            {
                EntryEventArgs eea = new EntryEventArgs(e, ChangeType.EntryChanged);
                this.EntryChanged(this, eea);
            }
        }

        /// <summary>
        /// Handles the Deleted event of the EntryFolderWatcher control.
        /// In turn, it fires the EntryDeleted event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
        private void EntryFolderWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (this.EntryDeleted != null)
            {
                EntryEventArgs eea = new EntryEventArgs(e, ChangeType.EntryDeleted);
                this.EntryDeleted(this, eea);
            }
        }

        /// <summary>
        /// Handles the Created event of the PhotoFolderWatcher control.
        /// In turn, it fires the PhotoAdded event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
        private void PhotoFolderWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (this.PhotoAdded != null)
            {
                EntryEventArgs eea = new EntryEventArgs(e, ChangeType.PhotoAdded);
                this.PhotoAdded(this, eea);
            }
        }

        /// <summary>
        /// Handles the Changed event of the PhotoFolderWatcher control.
        /// In turn, it fires the PhotoChanged event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
        private void PhotoFolderWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (this.PhotoChanged != null)
            {
                EntryEventArgs eea = new EntryEventArgs(e, ChangeType.PhotoChanged);
                this.PhotoChanged(this, eea);
            }
        }

        /// <summary>
        /// Handles the Deleted event of the PhotoFolderWatcher control.
        /// In turn, it fires the PhotoDeleted event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
        private void PhotoFolderWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (this.PhotoDeleted != null)
            {
                EntryEventArgs eea = new EntryEventArgs(e, ChangeType.PhotoDeleted);
                this.PhotoDeleted(this, eea);
            }
        }
    }
}
