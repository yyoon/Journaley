﻿namespace Journaley.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Journaley.Core.Models;

    /// <summary>
    /// An entry text provider interface to be used by EntryListBox.
    /// </summary>
    internal interface IEntryTextProvider
    {
        /// <summary>
        /// Gets the entry text for the provided journal entry.
        /// If the entry is currently selected and being edited,
        /// the text being edited should be returned.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <returns>The entry text to be previewed. The first one is the optional title, and the second one is the entry.</returns>
        Tuple<string, string> GetTextForEntry(Entry entry);
    }
}
