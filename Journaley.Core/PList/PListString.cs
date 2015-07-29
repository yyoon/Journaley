namespace Journaley.Core.PList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// PList string data
    /// </summary>
    public class PListString : IPListElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PListString"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public PListString(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Saves this PList data to XML.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void SaveToXml(XmlNode parent)
        {
            var doc = parent.OwnerDocument;
            var node = doc.CreateElement("string");
            node.InnerText = this.Value;
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
            PListString other = obj as PListString;
            if (other == null)
            {
                return false;
            }

            return this.Value.Equals(other.Value);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
