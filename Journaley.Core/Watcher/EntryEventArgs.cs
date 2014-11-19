namespace Journaley.Core.Watcher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Provides data for the entry change events.
    /// </summary>
    public class EntryEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntryEventArgs"/> class.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <param name="fullPath">The full path.</param>
        /// <param name="type">The change type.</param>
        public EntryEventArgs(Guid uuid, string fullPath, ChangeType type)
        {
            this.UUID = uuid;
            this.FullPath = fullPath;
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntryEventArgs"/> class.
        /// </summary>
        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the file system event data.</param>
        /// <param name="type">The change type.</param>
        public EntryEventArgs(FileSystemEventArgs e, ChangeType type)
        {
            this.UUID = new Guid(Path.GetFileNameWithoutExtension(e.Name));
            this.FullPath = e.FullPath;
            this.Type = type;
        }

        /// <summary>
        /// Gets the UUID of the entry or the photo.
        /// </summary>
        /// <value>
        /// The UUID.
        /// </value>
        public Guid UUID { get; private set; }

        /// <summary>
        /// Gets the change type.
        /// </summary>
        /// <value>
        /// The change type.
        /// </value>
        public ChangeType Type { get; private set; }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <value>
        /// The full path.
        /// </value>
        public string FullPath { get; private set; }
    }
}
