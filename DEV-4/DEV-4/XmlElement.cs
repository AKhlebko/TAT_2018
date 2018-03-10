using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TaskDEV4
{
    /// <summary>
    /// Class for storing XML tag and it's body
    /// Provides an interface for interacting with elements
    /// </summary>
    class XmlElement : IComparable<XmlElement>
    {
        private Hashtable tagAttributes;
        private List<XmlElement> nestedElements;
        private string tagBody;
        public string tagName { get; }

        public XmlElement()
        {
            tagName = string.Empty;
            tagAttributes = new Hashtable();
            nestedElements = new List<XmlElement>();
        }

        public XmlElement(string pTagName)
        {
            tagAttributes = new Hashtable();
            nestedElements = new List<XmlElement>();
            tagBody = string.Empty;
            tagName = pTagName;
        }

        private void AddHierarchyName(StringBuilder nameHierarchy)
        {
            nameHierarchy.Append(tagName);
            if (tagAttributes.Count == 0)
            {
                nameHierarchy.Append(" -> ");
            } 
        }

        private void AddElementBody(StringBuilder nameHierarchy)
        {
            nameHierarchy.Append(tagBody);
        }

        private void AddAttributes(StringBuilder nameHierarchy)
        {
            if (tagAttributes.Count != 0)
            {
                nameHierarchy.Append("{ ");
                foreach (DictionaryEntry attr in tagAttributes)
                {
                    nameHierarchy.Append($"{attr.Key} = {attr.Value}; ");
                }
                nameHierarchy.Append("} -> ");
            }
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
            tagAttributes.Add(attrName.Trim(), attrValue.Trim());
        }
        
        /// <summary>
        /// Add another nested element to this instance's
        /// nestedElements list
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
        /// String with new tagBody
        /// </param>
        public void SetBody(string pTagBody)
        {
            tagBody = pTagBody;
        }
        
        /// <summary>
        /// Sorts elements by their names and attributes
        /// </summary>
        public void Sort()
        {
            nestedElements.Sort();
            foreach (XmlElement xmlElement in nestedElements)
            {
                xmlElement.Sort();
            }
        }
        
        /// <summary>
        /// Comparer implimented from IComparer
        /// </summary>
        /// <param name="other">
        /// XMLElement to campare with
        /// </param>
        /// <returns>
        /// Return result of comparasing 2 XMLElement's instances
        /// </returns>
        public int CompareTo(XmlElement other)
        {
            return tagName.CompareTo(other.tagName);
        }

        /// <summary>
        /// Started recursive print methods for all
        /// XML elements in this file
        /// </summary>
        public void PrintFromRootElement()
        {
            foreach (XmlElement element in nestedElements)
            {
                element.Print(new StringBuilder());
            }
        }

        /// <summary>
        /// Recursively prints the element with it's body
        /// and all nested ones
        /// </summary>
        /// <param name="nameHierarchy">
        /// Full tag name, starting from the root tag
        /// </param>
        public void Print(StringBuilder nameHierarchy)
        {
            AddHierarchyName(nameHierarchy);
            AddAttributes(nameHierarchy);
            AddElementBody(nameHierarchy);
            if (!(tagBody == string.Empty))
            {
                Console.WriteLine(nameHierarchy);
            }
            foreach (XmlElement element in nestedElements)
            {
                StringBuilder nextLevelName = new StringBuilder(nameHierarchy.ToString());
                element.Print(nextLevelName);
            }
        }
    }
}
