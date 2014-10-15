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
        /// Initializes a new instance of the <see cref="EntryWatcher"/> class.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        public EntryWatcher(string folderPath)
        {
            this.Watcher = new FileSystemWatcher(folderPath);
        }

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
                return this.Watcher.EnableRaisingEvents;
            }

            set
            {
                this.Watcher.EnableRaisingEvents = value;
            }
        }

        /// <summary>
        /// Gets or sets the file system watcher.
        /// </summary>
        /// <value>
        /// The file system watcher.
        /// </value>
        private FileSystemWatcher Watcher { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.Watcher != null)
            {
                this.Watcher.Dispose();
            }
        }
    }
}
