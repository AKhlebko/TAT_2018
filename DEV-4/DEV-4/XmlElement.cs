using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDEV4
{
    /// <summary>
    /// Class for storing XML element, it's attributes and it's body
    /// Provides an interface for interacting with elements
    /// </summary>
    class XmlElement : IComparable<XmlElement>
    {
        private List<XmlAttribute> elementAttributes;
        private List<XmlElement> nestedElements;
        private string ElementBody;
        public string TagName { get; }

        public XmlElement()
        {
            TagName = string.Empty;
            elementAttributes = new List<XmlAttribute>();
            nestedElements = new List<XmlElement>();
        }

        public XmlElement(string pTagName)
        {
            elementAttributes = new List<XmlAttribute>();
            nestedElements = new List<XmlElement>();
            ElementBody = string.Empty;
            TagName = pTagName;
        }

        /// <summary>
        /// Adds another attribute to this instance's
        /// tagAttributes Hashtable
        /// </summary>
        /// <param name="attrName">
        /// Key of new attribute
        /// </param>
        /// <param name="attrValue">
        /// Value of new attribute
        /// </param>
        public void AddAttr(string attrName, string attrValue)
        {
            XmlAttribute newAttribute = new XmlAttribute(attrName, attrValue);
            elementAttributes.Add(newAttribute);
        }
        
        /// <summary>
        /// Add another nested element to this instance's
        /// nestedElements List
        /// </summary>
        /// <param name="newNestedElement">
        /// XMLElement to add
        /// </param>
        public void AddNested(XmlElement newNestedElement)
        {
            nestedElements.Add(newNestedElement);
        }

        /// <summary>
        /// Assignes tagBody with transmitted string
        /// </summary>
        /// <param name="pTagBody">
        /// String with new tag body
        /// </param>
        public void SetBody(string pTagBody)
        {
            ElementBody = pTagBody;
        }
        
        /// <summary>
        /// Sorts the elements by their names
        /// </summary>
        public void Sort()
        {
            elementAttributes.Sort();            
            nestedElements.Sort();
            foreach (XmlElement nested in nestedElements)
            {
                nested.Sort();
            }
        }
        
        /// <summary>
        /// Comparer implimented from IComparer
        /// Standart string comparer used here
        /// </summary>
        /// <param name="other">
        /// XMLElement to campare with
        /// </param>
        /// <returns>
        /// Return result of comparasing 2 XMLElement's instances
        /// </returns>
        public int CompareTo(XmlElement other)
        {
            return TagName.CompareTo(other.TagName);
        }

        /// <summary>
        /// Started recursive print methods for all
        /// XML elements in this file
        /// </summary>
        public void PrintFromRootElement()
        {
            foreach (XmlElement nested in nestedElements)
            {
                nested.Print(new StringBuilder());
            }
        }

        /// <summary>
        /// Recursively prints the element with it's body
        /// and all nested elements
        /// </summary>
        /// <param name="elementInfo">
        /// Full tag name, starting from the root tag
        /// </param>
        public void Print(StringBuilder elementInfo)
        {
            AddToTagHierarchy(elementInfo);
            AddAttributesInfo(elementInfo);
            AddElementBodyInfo(elementInfo);
            if (!(ElementBody == string.Empty))
            {
                Console.WriteLine(elementInfo);
                return;
            }
            foreach (XmlElement nested in nestedElements)
            {
                StringBuilder infoOnNextDepth = new StringBuilder(elementInfo.ToString());
                nested.Print(infoOnNextDepth);
            }
        }

        private void AddToTagHierarchy(StringBuilder elementInfo)
        {
            elementInfo.Append(TagName);
        }

        private void AddElementBodyInfo(StringBuilder elementInfo)
        {
            elementInfo.Append(ElementBody);
        }

        private void AddAttributesInfo(StringBuilder elementInfo)
        {
            if (elementAttributes.Count != 0)
            {
                elementInfo.Append(" {");
                foreach (XmlAttribute attribute in elementAttributes)
                {
                    elementInfo.Append($" {attribute.AttrName} = {attribute.AttrValue}; ");
                }
                elementInfo.Append("}");
            }
            elementInfo.Append(" -> ");
        }
    }
}
