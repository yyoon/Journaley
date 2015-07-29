namespace Journaley.Core.PList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// PList array data
    /// </summary>
    public class PListArray : IPListElement, IEnumerable<IPListElement>
    {
        /// <summary>
        /// The array
        /// </summary>
        private List<IPListElement> array;

        /// <summary>
        /// Initializes a new instance of the <see cref="PListArray"/> class.
        /// </summary>
        public PListArray()
        {
            this.array = new List<IPListElement>();
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
                return this.array.Count;
            }
        }

        /// <summary>
        /// Gets the <see cref="IPListElement"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="IPListElement"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="IPListElement"/> element at the specified index.</returns>
        public IPListElement this[int index]
        {
            get
            {
                return this.array[index];
            }
        }

        /// <summary>
        /// Adds the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        public void Add(IPListElement element)
        {
            this.array.Add(element);
        }

        /// <summary>
        /// Saves this PList data to XML.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void SaveToXml(XmlNode parent)
        {
            var doc = parent.OwnerDocument;
            var node = doc.CreateElement("array");

            foreach (var child in this.array)
            {
                child.SaveToXml(node);
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
            PListArray other = obj as PListArray;
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
            return this.array.GetHashCode();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<IPListElement> GetEnumerator()
        {
            return this.array.GetEnumerator();
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
