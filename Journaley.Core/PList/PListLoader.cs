namespace Journaley.Core.PList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// PList loader
    /// </summary>
    public static class PListLoader
    {
        /// <summary>
        /// Loads from XML node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The PList data constructed from the xml node.</returns>
        public static IPListElement LoadFromXmlNode(XmlNode node)
        {
            switch (node.Name.ToLower())
            {
                case "string":
                    return new PListString(node.InnerText);

                case "real":
                    return new PListReal(decimal.Parse(node.InnerText));

                case "integer":
                    return new PListInteger(int.Parse(node.InnerText));

                case "true":
                    return new PListBoolean(true);

                case "false":
                    return new PListBoolean(false);

                case "date":
                    return new PListDate(DateTime.Parse(node.InnerText));

                case "data":
                    return new PListData(Convert.FromBase64String(node.InnerText));

                case "array":
                    {
                        var array = new PListArray();

                        foreach (XmlNode child in node.ChildNodes)
                        {
                            array.Add(LoadFromXmlNode(child));
                        }

                        return array;
                    }

                case "dict":
                    {
                        var dict = new PListDictionary();

                        for (int i = 0; i < node.ChildNodes.Count; i += 2)
                        {
                            var keyNode = node.ChildNodes[i];
                            var key = keyNode.InnerText;

                            dict.Add(key, LoadFromXmlNode(node.ChildNodes[i + 1]));
                        }

                        return dict;
                    }

                default:
                    return null;
            }
        }
    }
}
