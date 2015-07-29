namespace Journaley.Core.PList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// PList real data
    /// </summary>
    public class PListReal : IPListElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PListReal"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public PListReal(decimal value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; private set; }

        /// <summary>
        /// Saves this PList data to XML.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void SaveToXml(XmlNode parent)
        {
            var doc = parent.OwnerDocument;
            var node = doc.CreateElement("real");
            node.InnerText = this.Value.ToString();
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
            PListReal other = obj as PListReal;
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
