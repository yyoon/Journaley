namespace Journaley.Core.Watcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Provides data for the entry change events.
    /// </summary>
    public class EntryEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the UUID of the entry or the photo.
        /// </summary>
        /// <value>
        /// The UUID.
        /// </value>
        public Guid UUID { get; set; }

        /// <summary>
        /// Gets or sets the change type.
        /// </summary>
        /// <value>
        /// The change type.
        /// </value>
        public ChangeType Type { get; set; }
    }
}
