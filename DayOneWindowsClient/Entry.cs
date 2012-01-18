using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace DayOneWindowsClient
{
    class Entry : IEquatable<Entry>
    {
        public Entry()
            : this(DateTime.Now)
        {
        }

        public Entry(DateTime utcDateTime)
            : this(utcDateTime, Guid.NewGuid())
        {
        }

        public Entry(Guid uuid)
            : this(DateTime.Now, uuid)
        {
        }

        public Entry(DateTime utcDateTime, Guid uuid)
            : this(utcDateTime, "", false, uuid, true)
        {
        }

        public Entry(DateTime utcDateTime, string entryText, bool starred, Guid uuid, bool isDirty)
        {
            this.UTCDateTime = utcDateTime;
            this.EntryText = entryText;
            this.Starred = starred;
            this.UUID = uuid;

            this.IsDirty = isDirty;
        }

        public static Entry LoadFromFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            XmlDocument doc = new XmlDocument();
            doc.Load(sr);
            sr.Close();

            Entry newEntry = new Entry();

            XmlNode dictNode = doc.SelectSingleNode("//dict");
            Debug.Assert(dictNode.ChildNodes.Count % 2 == 0);
            for (int i = 0; i < dictNode.ChildNodes.Count; i += 2)
            {
                XmlNode keyNode = dictNode.ChildNodes[i];
                Debug.Assert(keyNode.Name == "key");

                XmlNode valueNode = dictNode.ChildNodes[i + 1];

                switch (keyNode.InnerText)
                {
                    case "Creation Date":
                        {
                            newEntry.UTCDateTime = DateTime.Parse(valueNode.InnerText).ToUniversalTime();
                        }
                        break;

                    case "Entry Text":
                        {
                            newEntry.EntryText = valueNode.InnerText;
                        }
                        break;

                    case "Starred":
                        {
                            newEntry.Starred = valueNode.Name == "true";
                        }
                        break;

                    case "UUID":
                        {
                            newEntry.UUID = new Guid(valueNode.InnerText);
                        }
                        break;

                    default:
                        throw new Exception("Unknown key name in the plist dictionary");
                }
            }

            newEntry.IsDirty = false;

            return newEntry;
        }

        public DateTime UTCDateTime { get; set; }
        public string EntryText { get; set; }
        public bool Starred { get; set; }
        public Guid UUID { get; private set; }

        public bool IsDirty { get; private set; }

        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null))
                return false;

            if (object.ReferenceEquals(this, right))
                return true;

            if (this.GetType() != right.GetType())
                return false;

            return this.Equals(right as Entry);
        }

        #region IEquatable<Entry> Members

        public bool Equals(Entry right)
        {
            if (this.UTCDateTime != right.UTCDateTime)
                return false;

            if (this.EntryText != right.EntryText)
                return false;

            if (this.Starred != right.Starred)
                return false;

            if (this.UUID != right.UUID)
                return false;

            if (this.IsDirty != right.IsDirty)
                return false;

            return true;
        }

        #endregion
    }
}
