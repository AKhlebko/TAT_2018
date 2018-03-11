using System;

namespace TaskDEV4
{
    /// <summary>
    /// Class for storing elements attribues
    /// </summary>
    class XmlAttribute : IComparable<XmlAttribute>
    {
        public string attrName { get; }
        public string attrValue { get; }

        public XmlAttribute(string name, string value)
        {
            this.attrName = name.Trim();
            this.attrValue = value.Trim();
        }

        /// <summary>
        /// Compares two xml attributes
        /// basing comparison on build in string comparer
        /// </summary>
        /// <param name="second">
        /// XmlAttribute to compare with
        /// </param>
        /// <returns>
        /// -1 if first one is lower
        /// 0 if they are equal
        /// 1 if second one is lower
        /// </returns>
        public int CompareTo(XmlAttribute second)
        {
            return attrName.CompareTo(second.attrName);
        }
    }
}
