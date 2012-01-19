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
            : this(DateTime.UtcNow)
        {
        }

        public Entry(DateTime utcDateTime)
            : this(utcDateTime, Guid.NewGuid())
        {
        }

        public Entry(Guid uuid)
            : this(DateTime.UtcNow, uuid)
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
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                Entry newEntry = new Entry();

                XmlDocument doc = new XmlDocument();
                doc.Load(sr);

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
        }

        private DateTime _utcDateTime;
        public DateTime UTCDateTime
        {
            get
            {
                return _utcDateTime;
            }
            set
            {
                _utcDateTime = value;

                // clean everything beyond the seconds
                _utcDateTime = _utcDateTime.AddTicks(-(_utcDateTime.Ticks % 10000000));

                // turn it into UTC if it's not
                if (_utcDateTime.Kind != DateTimeKind.Utc)
                {
                    _utcDateTime = _utcDateTime.ToUniversalTime();
                }

                this.IsDirty = true;
            }
        }
        public string EntryText { get; set; }
        public bool Starred { get; set; }
        public Guid UUID { get; private set; }

        public DateTime LocalTime
        {
            get
            {
                return this.UTCDateTime.ToLocalTime();
            }
        }

        public string CreationDate
        {
            get
            {
                return this.UTCDateTime.ToString("u").Replace(' ', 'T');
            }
        }

        public string UUIDString
        {
            get
            {
                return this.UUID.ToString("N").ToUpper();
            }
        }

        public string FileName
        {
            get
            {
                return this.UUIDString + ".doentry";
            }
        }

        public bool IsDirty { get; private set; }

        public void Save()
        {
            XmlDocument doc = new XmlDocument();

            // <?xml ...?>
            var decl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(decl);

            // <!DOCTYPE ...>
            var doctype = doc.CreateDocumentType("plist", "-//Apple//DTD PLIST 1.0//EN",
                "http://www.apple.com/DTDs/PropertyList-1.0.dtd", null);
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

            // key values
            AppendKeyValue(doc, dict, "Creation Date", "date", this.CreationDate);
            AppendKeyValue(doc, dict, "Entry Text", "string", this.EntryText);
            AppendKeyValue(doc, dict, "Starred", this.Starred.ToString().ToLower(), null);
            AppendKeyValue(doc, dict, "UUID", "string", this.UUIDString);

            // Write to the stringbuilder first, and then write it to the file.
            StringBuilder builder = new StringBuilder();
            using (StringWriter stringWriter = new UTF8StringWriter(builder))
            {
                stringWriter.NewLine = "\n";
                doc.Save(stringWriter);

                // Some tricks to make the result exactly the same as the original one.
                stringWriter.WriteLine();
                builder.Replace("utf-8", "UTF-8");
                builder.Replace("    <", "\t<");
                builder.Replace("  <", "<");

                using (StreamWriter streamWriter = new StreamWriter(this.FileName, false, Encoding.UTF8))
                {
                    streamWriter.Write(builder.ToString());

                    // Now it's not dirty!
                    this.IsDirty = false;
                }
            }
        }

        private void AppendKeyValue(XmlDocument doc, XmlElement dict, string keyString, string valueType, string valueString)
        {
            var key = doc.CreateElement("key");
            dict.AppendChild(key);
            key.InnerText = keyString;

            var value = doc.CreateElement(valueType);
            dict.AppendChild(value);
            if (valueString != null)
                value.InnerText = valueString;
        }

        #region object level members

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

            return true;
        }

        #endregion

        #endregion
    }
}
