namespace Journaley.Core.PList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// PList data encoded in Base64 format.
    /// </summary>
    public class PListData : IPListElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PListData"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public PListData(byte[] value)
        {
            this.Value = new byte[value.Length];
            Array.Copy(value, this.Value, value.Length);

            this.Base64String = Convert.ToBase64String(this.Value);
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public byte[] Value { get; private set; }

        /// <summary>
        /// Gets the Base64 encoded string data.
        /// </summary>
        /// <value>
        /// The Base64 encoded string data.
        /// </value>
        public string Base64String { get; private set; }

        /// <summary>
        /// Saves this PList data to XML.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void SaveToXml(XmlNode parent)
        {
            var doc = parent.OwnerDocument;
            var node = doc.CreateElement("data");
            node.InnerText = this.Base64String;
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
            PListData other = obj as PListData;
            if (other == null)
            {
                return false;
            }

            return this.Base64String.Equals(other.Base64String);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.Base64String.GetHashCode();
        }
    }
}
