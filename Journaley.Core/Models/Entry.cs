namespace Journaley.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml;
    using Journaley.Core.PList;
    using Journaley.Core.Utilities;

    /// <summary>
    /// A class representing a journal entry.
    /// </summary>
    public class Entry : IEquatable<Entry>
    {
        /// <summary>
        /// The supported photo formats
        /// </summary>
        public static readonly string[] SupportedPhotoFormats = { "jpg" };

        /// <summary>
        /// The invalid characters not allowed in XML.
        /// </summary>
        private static readonly char[] InvalidCharacters = { '\u0000', '\u001C', '\u001D' };

        /// <summary>
        /// The UTC date time
        /// </summary>
        private DateTime utcDateTime;

        /// <summary>
        /// The entry text
        /// </summary>
        private string entryText;

        /// <summary>
        /// Indicates whether this entry is starred or not
        /// </summary>
        private bool starred;

        /// <summary>
        /// The unknown key values
        /// </summary>
        private Dictionary<XmlNode, XmlNode> unknownKeyValues = new Dictionary<XmlNode, XmlNode>();

        /// <summary>
        /// The tags
        /// </summary>
        private List<string> tags = new List<string>();

        /// <summary>
        /// The path of the associated photo.
        /// </summary>
        private string photoPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="Entry"/> class.
        /// </summary>
        public Entry()
            : this(DateTime.UtcNow)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entry"/> class.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        public Entry(DateTime dateTime)
            : this(dateTime, Guid.NewGuid())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entry"/> class.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        public Entry(Guid uuid)
            : this(DateTime.UtcNow, uuid)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entry"/> class.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="uuid">The UUID.</param>
        public Entry(DateTime dateTime, Guid uuid)
            : this(dateTime, string.Empty, false, uuid, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entry"/> class.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="entryText">The entry text.</param>
        /// <param name="starred">if set to <c>true</c> [starred].</param>
        /// <param name="uuid">The UUID.</param>
        /// <param name="isDirty">if set to <c>true</c> [is dirty].</param>
        public Entry(DateTime dateTime, string entryText, bool starred, Guid uuid, bool isDirty)
        {
            this.UTCDateTime = dateTime;
            this.EntryText = entryText;
            this.Starred = starred;
            this.UUID = uuid;

            this.IsDirty = isDirty;
        }

        /// <summary>
        /// Event handler for PhotoChanged.
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void PhotoChangedHandler(Entry sender);

        /// <summary>
        /// Occurs when the attached photo is changed.
        /// </summary>
        public event PhotoChangedHandler PhotoChanged; 

        /// <summary>
        /// Gets or sets the UTC date time.
        /// </summary>
        /// <value>
        /// The UTC date time.
        /// </value>
        public DateTime UTCDateTime
        {
            get
            {
                return this.utcDateTime;
            }

            set
            {
                DateTime temp = value;
                temp = temp.AddTicks(-(temp.Ticks % 10000000));

                if (temp.Kind != DateTimeKind.Utc)
                {
                    temp.ToUniversalTime();
                }

                if (this.utcDateTime != temp)
                {
                    this.utcDateTime = temp;
                    this.IsDirty = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the entry text.
        /// </summary>
        /// <value>
        /// The entry text.
        /// </value>
        public string EntryText
        {
            get
            {
                return this.entryText;
            }

            set
            {
                if (this.entryText != value)
                {
                    this.entryText = value;
                    this.IsDirty = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Entry"/> is starred.
        /// </summary>
        /// <value>
        ///   <c>true</c> if starred; otherwise, <c>false</c>.
        /// </value>
        public bool Starred
        {
            get
            {
                return this.starred;
            }

            set
            {
                if (this.starred != value)
                {
                    this.starred = value;
                    this.IsDirty = true;
                }
            }
        }

        /// <summary>
        /// Gets the UUID.
        /// Once set, should never be changed.
        /// </summary>
        /// <value>
        /// The UUID.
        /// </value>
        public Guid UUID { get; private set; }

        /// <summary>
        /// Gets the local time.
        /// </summary>
        /// <value>
        /// The local time.
        /// </value>
        public DateTime LocalTime
        {
            get
            {
                return this.UTCDateTime.ToLocalTime();
            }
        }

        /// <summary>
        /// Gets the creation date as string.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public string CreationDate
        {
            get
            {
                return this.UTCDateTime.ToString("u").Replace(' ', 'T');
            }
        }

        /// <summary>
        /// Gets the UUID string.
        /// </summary>
        /// <value>
        /// The UUID string.
        /// </value>
        public string UUIDString
        {
            get
            {
                return this.UUID.ToString("N").ToUpper();
            }
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName
        {
            get
            {
                return this.UUIDString + ".doentry";
            }
        }

        /// <summary>
        /// Gets the unknown key values.
        /// </summary>
        /// <value>
        /// The unknown key values.
        /// </value>
        public Dictionary<XmlNode, XmlNode> UnknownKeyValues
        {
            get
            {
                return this.unknownKeyValues;
            }
        }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public IEnumerable<string> Tags
        {
            get
            {
                return this.tags.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets or sets the photo path associated with this entry.
        /// </summary>
        /// <value>
        /// The photo path.
        /// </value>
        public string PhotoPath
        {
            get
            {
                return this.photoPath;
            }

            set
            {
                this.photoPath = value;
                this.OnPhotoChanged();
            }
        }

        /// <summary>
        /// Gets the location where the entry was written.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public PListDictionary Location { get; private set; }

        /// <summary>
        /// Gets the weather information.
        /// </summary>
        /// <value>
        /// The weather.
        /// </value>
        public PListDictionary Weather { get; private set; }

        /// <summary>
        /// Gets the creator information.
        /// </summary>
        /// <value>
        /// The creator.
        /// </value>
        public PListDictionary Creator { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is dirty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is dirty; otherwise, <c>false</c>.
        /// </value>
        public bool IsDirty { get; private set; }

        /// <summary>
        /// Loads an entry from the given filename.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>An <see cref="Entry"/> object representing the given file.</returns>
        public static Entry LoadFromFile(string path)
        {
            return LoadFromFile(path, null, false);
        }

        /// <summary>
        /// Loads an entry from the given filename.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="settings">The settings object, which can be null.</param>
        /// <returns>An <see cref="Entry" /> object representing the given file.</returns>
        public static Entry LoadFromFile(string path, Settings settings)
        {
            return LoadFromFile(path, settings, false);
        }

        /// <summary>
        /// Loads an entry from the given filename.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="settings">The settings object, which can be null.</param>
        /// <param name="throwExceptions">if set to <c>true</c> [throw exceptions].</param>
        /// <returns>
        /// An <see cref="Entry" /> object representing the given file.
        /// </returns>
        public static Entry LoadFromFile(string path, Settings settings, bool throwExceptions)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    Entry newEntry = new Entry();

                    string fileContent = sr.ReadToEnd().TrimStart();

                    // Remove all the invalid characters, if any.
                    foreach (char ch in InvalidCharacters)
                    {
                        fileContent = fileContent.Replace(ch.ToString(), string.Empty);
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.XmlResolver = null;
                    doc.LoadXml(fileContent);

                    XmlNode dictNode = doc.SelectSingleNode("//dict");
                    Debug.Assert(dictNode.ChildNodes.Count % 2 == 0, "A dict node must have even number of children (key, value)");
                    for (int i = 0; i < dictNode.ChildNodes.Count; i += 2)
                    {
                        XmlNode keyNode = dictNode.ChildNodes[i];
                        Debug.Assert(keyNode.Name == "key", "key element must appear");

                        XmlNode valueNode = keyNode.NextSibling;

                        LoadKeyValue(newEntry, keyNode, valueNode);
                    }

                    // Check for some existing photo.
                    if (settings != null)
                    {
                        newEntry.CheckExistingPhoto(settings.PhotoFolderPath);
                    }

                    newEntry.IsDirty = false;

                    return newEntry;
                }
            }
            catch (Exception e)
            {
                if (throwExceptions)
                {
                    throw e;
                }

                // Write to a log file.
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("An error occurred while reading entry \"" + path + "\"");
                builder.AppendLine(e.Message);
                builder.AppendLine(e.StackTrace);

                Logger.Log(builder.ToString());

                return null;
            }
        }

        /// <summary>
        /// Adds the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>true if the tag was successfully added, false if there was already the tag</returns>
        public bool AddTag(string tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException("tag");
            }

            if (!this.tags.Contains(tag))
            {
                this.tags.Add(tag);
                this.IsDirty = true;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>true if the tag was removed successfully, false if the given tag was not found.</returns>
        public bool RemoveTag(string tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException("tag");
            }

            if (this.tags.Contains(tag))
            {
                this.tags.Remove(tag);
                this.IsDirty = true;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Clears the tags list.
        /// </summary>
        public void ClearTags()
        {
            if (this.tags.Any())
            {
                this.tags.Clear();
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Determines whether this entry is empty.
        /// An empty entry should contain no text, and no attached photo.
        /// </summary>
        /// <returns>true if this entry has neither text nor photo. false otherwise.</returns>
        public bool IsEmptyEntry()
        {
            return this.EntryText == string.Empty && this.PhotoPath == null;
        }

        /// <summary>
        /// Saves this entry into the specified folder path.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        public void Save(string folderPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.XmlResolver = null;

            // <?xml ...?>
            var decl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(decl);

            // <!DOCTYPE ...>
            var doctype = doc.CreateDocumentType(
                "plist",
                "-//Apple//DTD PLIST 1.0//EN",
                "http://www.apple.com/DTDs/PropertyList-1.0.dtd",
                null);
            doc.AppendChild(doctype);

            // <plist version="1.0">
            var root = doc.CreateElement("plist");
            doc.AppendChild(root);

            var attrVersion = doc.CreateAttribute("version");
            root.Attributes.Append(attrVersion);
            attrVersion.Value = "1.0";

            // <dict>
            var dict = doc.CreateElement("dict");
            root.AppendChild(dict);

            // Core key values
            this.AppendKeyValue(doc, dict, "Creation Date", "date", this.CreationDate);
            this.AppendKeyValue(doc, dict, "Entry Text", "string", this.EntryText);
            this.AppendKeyValue(doc, dict, "Starred", this.Starred.ToString().ToLower(), null);
            this.AppendKeyValue(doc, dict, "UUID", "string", this.UUIDString);

            if (this.Creator != null)
            {
                this.AppendKeyValue(doc, dict, "Creator", this.Creator);
            }

            if (this.Location != null)
            {
                this.AppendKeyValue(doc, dict, "Location", this.Location);
            }

            if (this.Weather != null)
            {
                this.AppendKeyValue(doc, dict, "Weather", this.Weather);
            }

            // Store the tags
            if (this.Tags.Any())
            {
                this.AppendArrayKeyValue(doc, dict, "Tags", this.Tags);
            }

            // Handle unknown key values. (just keep them.)
            foreach (var kvp in this.UnknownKeyValues)
            {
                this.AppendKeyValue(doc, dict, kvp.Key, kvp.Value);
            }

            // Write to the stringbuilder first, and then write it to the file.
            StringBuilder builder = new StringBuilder();
            using (StringWriter stringWriter = new UTF8StringWriter(builder))
            {
                stringWriter.NewLine = "\n";
                doc.Save(stringWriter);

                // Some tricks to make the result exactly the same as the original one.
                stringWriter.WriteLine();
                builder.Replace("utf-8", "UTF-8");
                builder.Replace("            <", "\t\t\t\t\t<");
                builder.Replace("          <", "\t\t\t\t<");
                builder.Replace("        <", "\t\t\t<");
                builder.Replace("      <", "\t\t<");
                builder.Replace("    <", "\t<");
                builder.Replace("  <", "<");

                using (StreamWriter streamWriter = new StreamWriter(Path.Combine(folderPath, this.FileName), false, new UTF8Encoding()))
                {
                    streamWriter.Write(builder.ToString());

                    // Now it's not dirty!
                    this.IsDirty = false;
                }
            }
        }

        /// <summary>
        /// Deletes this entry from the specified folder path.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        public void Delete(string folderPath)
        {
            string path = Path.Combine(folderPath, this.FileName);

            FileInfo finfo = new FileInfo(path);
            if (finfo.Exists)
            {
                finfo.Delete();
            }
        }

        /// <summary>
        /// Checks for an existing photo for this entry.
        /// Meant to be called only when there is no PhotoPath already assigned.
        /// </summary>
        /// <param name="photoFolderPath">The photo folder path.</param>
        public void CheckExistingPhoto(string photoFolderPath)
        {
            // If there is a photo already, don't do anything.
            if (this.PhotoPath != null && File.Exists(this.PhotoPath))
            {
                return;
            }

            this.PhotoPath = null;
            foreach (var format in SupportedPhotoFormats)
            {
                string candidatePhotoPath = Path.Combine(photoFolderPath, this.UUIDString + "." + format);
                if (File.Exists(candidatePhotoPath))
                {
                    this.PhotoPath = candidatePhotoPath;
                    return;
                }
            }
        }

        #region object level members

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="right">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, right))
            {
                return true;
            }

            if (this.GetType() != right.GetType())
            {
                return false;
            }

            return this.Equals(right as Entry);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.UUID.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Date: {0}, Entry Text: \"{1}\"", this.CreationDate, this.EntryText);
        }

        #region IEquatable<Entry> Members

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="right">The <see cref="Entry" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="Entry" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Entry right)
        {
            if (this.UTCDateTime != right.UTCDateTime)
            {
                return false;
            }

            if (this.EntryText != right.EntryText)
            {
                return false;
            }

            if (this.Starred != right.Starred)
            {
                return false;
            }

            if (this.UUID != right.UUID)
            {
                return false;
            }

            return true;
        }

        #endregion

        /// <summary>
        /// Called when the attached photo is changed.
        /// </summary>
        protected virtual void OnPhotoChanged()
        {
            if (this.PhotoChanged != null)
            {
                this.PhotoChanged(this);
            }
        }

        #endregion

        /// <summary>
        /// Loads the key value pair and store the information in the entry object..
        /// </summary>
        /// <param name="newEntry">The new entry object.</param>
        /// <param name="keyNode">The key node.</param>
        /// <param name="valueNode">The value node.</param>
        private static void LoadKeyValue(Entry newEntry, XmlNode keyNode, XmlNode valueNode)
        {
            switch (keyNode.InnerText)
            {
                case "Creation Date":
                    newEntry.UTCDateTime = DateTime.Parse(valueNode.InnerText).ToUniversalTime();
                    break;

                case "Creator":
                    newEntry.Creator = (PListDictionary)PListLoader.LoadFromXmlNode(valueNode);
                    break;

                case "Entry Text":
                    newEntry.EntryText = valueNode.InnerText;
                    break;

                case "Location":
                    newEntry.Location = (PListDictionary)PListLoader.LoadFromXmlNode(valueNode);
                    break;

                case "Starred":
                    newEntry.Starred = valueNode.Name == "true";
                    break;

                case "Tags":
                    LoadTags(newEntry, valueNode);
                    break;

                case "UUID":
                    newEntry.UUID = new Guid(valueNode.InnerText);
                    break;

                case "Weather":
                    newEntry.Weather = (PListDictionary)PListLoader.LoadFromXmlNode(valueNode);
                    break;

                default:
                    newEntry.UnknownKeyValues.Add(keyNode, valueNode);
                    break;
            }
        }

        /// <summary>
        /// Loads the tags.
        /// </summary>
        /// <param name="newEntry">The new entry object.</param>
        /// <param name="valueNode">The value node.</param>
        private static void LoadTags(Entry newEntry, XmlNode valueNode)
        {
            foreach (XmlNode tagNode in valueNode.ChildNodes)
            {
                newEntry.AddTag(tagNode.InnerText);
            }
        }

        /// <summary>
        /// Appends the key value.
        /// </summary>
        /// <param name="doc">The xml document.</param>
        /// <param name="dict">The xml element corresponding to dictionary part.</param>
        /// <param name="keyString">The key string.</param>
        /// <param name="valueType">Type of the value.</param>
        /// <param name="valueString">The value string.</param>
        private void AppendKeyValue(XmlDocument doc, XmlElement dict, string keyString, string valueType, string valueString)
        {
            var key = doc.CreateElement("key");
            dict.AppendChild(key);
            key.InnerText = keyString;

            var value = doc.CreateElement(valueType);
            dict.AppendChild(value);
            if (valueString != null)
            {
                value.InnerText = valueString;
            }
        }

        /// <summary>
        /// Appends the key value.
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <param name="dict">The dictionary.</param>
        /// <param name="keyString">The key string.</param>
        /// <param name="data">The data.</param>
        private void AppendKeyValue(XmlDocument doc, XmlElement dict, string keyString, IPListElement data)
        {
            var key = doc.CreateElement("key");
            key.InnerText = keyString;
            dict.AppendChild(key);

            data.SaveToXml(dict);
        }

        /// <summary>
        /// Appends the array typed key values.
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <param name="dict">The dictionary.</param>
        /// <param name="keyString">The key string.</param>
        /// <param name="values">The values.</param>
        private void AppendArrayKeyValue(XmlDocument doc, XmlElement dict, string keyString, IEnumerable<string> values)
        {
            var key = doc.CreateElement("key");
            dict.AppendChild(key);
            key.InnerText = keyString;

            var value = doc.CreateElement("array");
            dict.AppendChild(value);
            foreach (var s in values)
            {
                var stringElem = doc.CreateElement("string");
                value.AppendChild(stringElem);
                stringElem.InnerText = s;
            }
        }

        /// <summary>
        /// Appends the key value. Used to preserve the unknown key values existed in the original entries.
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <param name="dict">The dictionary.</param>
        /// <param name="keyNodeFromOtherDoc">The key node from other document.</param>
        /// <param name="valueNodeFromOtherDoc">The value node from other document.</param>
        private void AppendKeyValue(XmlDocument doc, XmlElement dict, XmlNode keyNodeFromOtherDoc, XmlNode valueNodeFromOtherDoc)
        {
            var key = doc.ImportNode(keyNodeFromOtherDoc, true);
            var value = doc.ImportNode(valueNodeFromOtherDoc, true);

            dict.AppendChild(key);
            dict.AppendChild(value);
        }
    }
}
