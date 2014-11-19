namespace Journaley.Core.Watcher
{
    /// <summary>
    /// External changes that might occur to a journal entry or photo.
    /// </summary>
    public enum ChangeType
    {
        /// <summary>
        /// The creation of an entry.
        /// </summary>
        EntryAdded,

        /// <summary>
        /// The change of an entry.
        /// </summary>
        EntryChanged,

        /// <summary>
        /// The deletion of an entry.
        /// </summary>
        EntryDeleted,

        /// <summary>
        /// The creation of a photo.
        /// </summary>
        PhotoAdded,

        /// <summary>
        /// The change of a photo.
        /// </summary>
        PhotoChanged,

        /// <summary>
        /// The deletion of a photo.
        /// </summary>
        PhotoDeleted,
    }
}
