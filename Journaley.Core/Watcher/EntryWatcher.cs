namespace Journaley.Core.Watcher
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Journaley.Core.Models;

    /// <summary>
    /// A utility class that monitors all the entries and photos.
    /// </summary>
    public class EntryWatcher : IDisposable
    {
        /// <summary>
        /// The deletion defer time
        /// </summary>
        private static readonly int DeletionDeferTime = 3000;

        /// <summary>
        /// The entry deletion timers
        /// </summary>
        private IDictionary<Guid, System.Timers.Timer> entryDeletionTimers = new ConcurrentDictionary<Guid, System.Timers.Timer>();

        /// <summary>
        /// The photo deletion timers
        /// </summary>
        private IDictionary<Guid, System.Timers.Timer> photoDeletionTimers = new ConcurrentDictionary<Guid, System.Timers.Timer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EntryWatcher" /> class.
        /// </summary>
        /// <param name="entryFolderPath">The entry folder path.</param>
        /// <param name="photoFolderPath">The photo folder path.</param>
        /// <param name="synchronizingObject">The synchronizing object. (can be null).</param>
        public EntryWatcher(string entryFolderPath, string photoFolderPath, ISynchronizeInvoke synchronizingObject)
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

            this.SynchronizingObject = synchronizingObject;
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
        /// Gets the entry deletion timers dictionary.
        /// Used to defer processing the external deletion.
        /// </summary>
        /// <value>
        /// The entry deletion timers.
        /// </value>
        private IDictionary<Guid, System.Timers.Timer> EntryDeletionTimers
        {
            get
            {
                return this.entryDeletionTimers;
            }
        }

        /// <summary>
        /// Gets the photo deletion timers dictionary.
        /// Used to defer processing the external deletion.
        /// </summary>
        /// <value>
        /// The photo deletion timers.
        /// </value>
        private IDictionary<Guid, System.Timers.Timer> PhotoDeletionTimers
        {
            get
            {
                return this.photoDeletionTimers;
            }
        }

        /// <summary>
        /// Gets or sets the synchronizing object.
        /// </summary>
        /// <value>
        /// The synchronizing object.
        /// </value>
        private ISynchronizeInvoke SynchronizingObject { get; set; }

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

            foreach (var timer in this.EntryDeletionTimers.Values)
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            }

            this.EntryDeletionTimers.Clear();

            foreach (var timer in this.PhotoDeletionTimers.Values)
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            }

            this.PhotoDeletionTimers.Clear();
        }

        /// <summary>
        /// Fires the deleted.
        /// </summary>
        /// <param name="uuid">The UUID of the entry (or photo).</param>
        /// <param name="fullPath">The full path of the deleted file.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="type">The change type.</param>
        private void FireDeleted(Guid uuid, string fullPath, EntryEventHandler handler, ChangeType type)
        {
            // Fire the event.
            if (handler != null)
            {
                EntryEventArgs e = new EntryEventArgs(uuid, fullPath, type);

                if (this.SynchronizingObject != null && this.SynchronizingObject.InvokeRequired)
                {
                    this.SynchronizingObject.Invoke(new Action(delegate() { handler(this, e); }), null);
                }
                else
                {
                    handler(this, e);
                }
            }

            // Delete the timer object from the dictionary.
            if (this.EntryDeletionTimers.ContainsKey(uuid))
            {
                this.EntryDeletionTimers[uuid].Dispose();
                this.EntryDeletionTimers.Remove(uuid);
            }
        }

        /// <summary>
        /// Stops the deletion timer.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <param name="uuid">The UUID.</param>
        private void StopDeletionTimer(IDictionary<Guid, System.Timers.Timer> dict, Guid uuid)
        {
            // See if there is a deletion timer set for this particular uuid.
            if (dict.ContainsKey(uuid))
            {
                dict[uuid].Stop();
                dict.Remove(uuid);
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
            // First, check if the filename is formatted as a valid Guid.
            Guid uuid;
            try
            {
                uuid = new Guid(Path.GetFileNameWithoutExtension(e.Name));
            }
            catch (Exception)
            {
                return;
            }

            // Second, see if the entry is parsable.
            Entry entry = null;
            try
            {
                entry = Entry.LoadFromFile(e.FullPath, null, true);
            }
            catch (Exception)
            {
                return;
            }

            this.StopDeletionTimer(this.EntryDeletionTimers, uuid);

            if (this.EntryAdded != null)
            {
                EntryEventArgs eea = new EntryEventArgs(e, ChangeType.EntryAdded);

                if (this.SynchronizingObject != null && this.SynchronizingObject.InvokeRequired)
                {
                    this.SynchronizingObject.Invoke(new Action(delegate() { this.EntryAdded(this, eea); }), null);
                }
                else
                {
                    this.EntryAdded(this, eea);
                }
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
            // First, check if the filename is formatted as a valid Guid.
            Guid uuid;
            try
            {
                uuid = new Guid(Path.GetFileNameWithoutExtension(e.Name));
            }
            catch (Exception)
            {
                return;
            }

            // Second, see if the entry is parsable.
            Entry entry = null;
            try
            {
                entry = Entry.LoadFromFile(e.FullPath, null, true);
            }
            catch (Exception)
            {
                return;
            }

            this.StopDeletionTimer(this.EntryDeletionTimers, uuid);

            if (this.EntryChanged != null)
            {
                EntryEventArgs eea = new EntryEventArgs(e, ChangeType.EntryChanged);

                if (this.SynchronizingObject != null && this.SynchronizingObject.InvokeRequired)
                {
                    this.SynchronizingObject.Invoke(new Action(delegate() { this.EntryChanged(this, eea); }), null);
                }
                else
                {
                    this.EntryChanged(this, eea);
                }
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
            // IMPORTANT NOTE ---
            //
            // Even when a deletion event is caught,
            // wait for a few more seconds and see if it is in fact a deletion.
            //
            // In case of using Dropbox synchronization,
            // A file is updated by first being deleted and then being replaced with a new file.
            // In this case, three events, (1) EntryDeleted, (2) EntryAdded, (3) EntryChanged, will occur,
            // (the second one might be omitted)
            // and we want to handle only the last EntryChanged event.
            //
            // Use a Timer object to achieve this.
            Guid uuid = new Guid(Path.GetFileNameWithoutExtension(e.Name));

            if (!this.EntryDeletionTimers.ContainsKey(uuid))
            {
                System.Timers.Timer timer = new System.Timers.Timer(DeletionDeferTime);
                timer.AutoReset = false;
                timer.SynchronizingObject = this.SynchronizingObject;
                timer.Elapsed += delegate(object s, System.Timers.ElapsedEventArgs e2)
                {
                    this.FireDeleted(uuid, e.FullPath, this.EntryDeleted, ChangeType.EntryDeleted);
                };

                this.EntryDeletionTimers.Add(uuid, timer);
                timer.Start();
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
            // First, check if the filename is formatted as a valid Guid.
            Guid uuid;
            try
            {
                uuid = new Guid(Path.GetFileNameWithoutExtension(e.Name));
            }
            catch (Exception)
            {
                return;
            }

            // Check the file extension. Now it only supports jpg or jpeg.
            string ext = Path.GetExtension(e.Name).ToLower();
            if (ext != ".jpg" && ext != ".jpeg")
            {
                return;
            }

            // Second, check if the added file size is greater than zero.
            // If this is zero-sized, then it is very likely that a subsequent change event is fired very soon.
            FileInfo finfo = new FileInfo(e.FullPath);
            if (finfo.Length == 0)
            {
                return;
            }

            this.StopDeletionTimer(this.PhotoDeletionTimers, uuid);

            if (this.PhotoAdded != null)
            {
                EntryEventArgs eea = new EntryEventArgs(e, ChangeType.PhotoAdded);

                if (this.SynchronizingObject != null && this.SynchronizingObject.InvokeRequired)
                {
                    this.SynchronizingObject.Invoke(new Action(delegate() { this.PhotoAdded(this, eea); }), null);
                }
                else
                {
                    this.PhotoAdded(this, eea);
                }
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
            // First, check if the filename is formatted as a valid Guid.
            Guid uuid;
            try
            {
                uuid = new Guid(Path.GetFileNameWithoutExtension(e.Name));
            }
            catch (Exception)
            {
                return;
            }

            // Check the file extension. Now it only supports jpg or jpeg.
            string ext = Path.GetExtension(e.Name).ToLower();
            if (ext != ".jpg" && ext != ".jpeg")
            {
                return;
            }

            this.StopDeletionTimer(this.PhotoDeletionTimers, uuid);

            if (this.PhotoChanged != null)
            {
                EntryEventArgs eea = new EntryEventArgs(e, ChangeType.PhotoChanged);

                if (this.SynchronizingObject != null && this.SynchronizingObject.InvokeRequired)
                {
                    this.SynchronizingObject.Invoke(new Action(delegate() { this.PhotoChanged(this, eea); }), null);
                }
                else
                {
                    this.PhotoChanged(this, eea);
                }
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
            // IMPORTANT NOTE ---
            //
            // (refer to the note in EntryFolderWatcher_Deleted method)
            Guid uuid = new Guid(Path.GetFileNameWithoutExtension(e.Name));

            if (!this.PhotoDeletionTimers.ContainsKey(uuid))
            {
                System.Timers.Timer timer = new System.Timers.Timer(DeletionDeferTime);
                timer.AutoReset = false;
                timer.SynchronizingObject = this.SynchronizingObject;
                timer.Elapsed += delegate(object s, System.Timers.ElapsedEventArgs e2)
                {
                    this.FireDeleted(uuid, e.FullPath, this.PhotoDeleted, ChangeType.PhotoDeleted);
                };

                this.PhotoDeletionTimers.Add(uuid, timer);
                timer.Start();
            }
        }
    }
}
