namespace Journaley.Core.PList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// PList dictionary data
    /// </summary>
    public class PListDictionary : IPListElement, IEnumerable<KeyValuePair<string, IPListElement>>
    {
        /// <summary>
        /// The dictionary
        /// </summary>
        private Dictionary<string, IPListElement> dict;

        /// <summary>
        /// Initializes a new instance of the <see cref="PListDictionary"/> class.
        /// </summary>
        public PListDictionary()
        {
            this.dict = new Dictionary<string, IPListElement>();
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count
        {
            get
            {
                return this.dict.Count;
            }
        }

        /// <summary>
        /// Gets the key collection.
        /// </summary>
        /// <value>
        /// The key collection.
        /// </value>
        public Dictionary<string, IPListElement>.KeyCollection Keys
        {
            get
            {
                return this.dict.Keys;
            }
        }

        /// <summary>
        /// Gets the value collection.
        /// </summary>
        /// <value>
        /// The value collection.
        /// </value>
        public Dictionary<string, IPListElement>.ValueCollection Values
        {
            get
            {
                return this.dict.Values;
            }
        }

        /// <summary>
        /// Gets the <see cref="IPListElement"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="IPListElement"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns>The <see cref="IPListElement"/> value associated with the specified key.</returns>
        public IPListElement this[string key]
        {
            get
            {
                return this.dict[key];
            }
        }

        /// <summary>
        /// Adds the specified key value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, IPListElement value)
        {
            this.dict.Add(key, value);
        }

        /// <summary>
        /// Adds the specified key value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, string value)
        {
            this.Add(key, new PListString(value));
        }

        /// <summary>
        /// Adds the specified key value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, decimal value)
        {
            this.Add(key, new PListReal(value));
        }

        /// <summary>
        /// Adds the specified key value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, int value)
        {
            this.Add(key, new PListInteger(value));
        }

        /// <summary>
        /// Adds the specified key value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, bool value)
        {
            this.Add(key, new PListBoolean(value));
        }

        /// <summary>
        /// Adds the specified key value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, DateTime value)
        {
            this.Add(key, new PListDate(value));
        }

        /// <summary>
        /// Adds the specified key value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, byte[] value)
        {
            this.Add(key, new PListData(value));
        }

        /// <summary>
        /// Saves this PList data to XML.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void SaveToXml(XmlNode parent)
        {
            var doc = parent.OwnerDocument;
            var node = doc.CreateElement("dict");

            var keysInOrder = from k in this.Keys
                              orderby k
                              select k;

            foreach (var key in keysInOrder)
            {
                var keyNode = doc.CreateElement("key");
                keyNode.InnerText = key;
                node.AppendChild(keyNode);

                this[key].SaveToXml(node);
            }

            parent.AppendChild(node);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            PListDictionary other = obj as PListDictionary;
            if (other == null)
            {
                return false;
            }

            return Enumerable.SequenceEqual(this, other);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.dict.GetHashCode();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<string, IPListElement>> GetEnumerator()
        {
            return this.dict.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
