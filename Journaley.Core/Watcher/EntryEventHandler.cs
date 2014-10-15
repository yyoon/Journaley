namespace Journaley.Core.Watcher
{
    /// <summary>
    /// Represents the method that will handle the EntryWatcher events.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EntryEventArgs"/> instance containing the event data.</param>
    public delegate void EntryEventHandler(object sender, EntryEventArgs e);
}
