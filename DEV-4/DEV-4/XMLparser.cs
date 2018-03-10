﻿using System.Text.RegularExpressions;

namespace TaskDEV4
{
    /// <summary>
    /// Class's for parsing XML files
    /// </summary>
    class XMLparser
    {
        /// <summary>
        /// Recursive method for finding all elements 
        /// and their tags in XML file
        /// </summary>
        /// <param name="headElement">
        /// The root element for every XMLElement found on this level
        /// </param>
        /// <param name="xmlString">
        /// String in which XML file/tag's body is stored
        /// </param>
        public void DepthXMLParse(XmlElement headElement, string xmlString)
        {
            string openTagPattern = @"(<.[^(/><.)]+>)";
            while (Regex.IsMatch(xmlString, openTagPattern))
            {
                // Element's declaration, it's start tag and it's end tag 
                string foundElement = Regex.Match(xmlString, openTagPattern).ToString();
                string startTag = GetStartTag(foundElement);
                string closeTag = GetEndTag(startTag);
                // positions where element's body starts and ends
                int bodyStartPoint = xmlString.IndexOf(foundElement) + foundElement.Length;
                int bodyEndPoint = xmlString.IndexOf(closeTag);
                // main method's part
                string foundElementBody = xmlString.Substring(bodyStartPoint, bodyEndPoint - bodyStartPoint).Trim();
                XmlElement newXmlElement = new XmlElement(startTag);
                AddAttrsIntoElement(foundElement, newXmlElement);
                if (Regex.IsMatch(foundElementBody, openTagPattern))
                {
                    DepthXMLParse(newXmlElement, foundElementBody);
                    xmlString = RemoveParsedBody(bodyStartPoint, bodyEndPoint, foundElement, startTag, xmlString);
                }
                else
                {
                    newXmlElement.SetBody(foundElementBody);
                    xmlString = RemoveParsedBody(bodyStartPoint, bodyEndPoint, foundElement, startTag, xmlString);
                }
                headElement.AddNested(newXmlElement);
            }
        }
        
        /// <summary>
        /// Makes end tag based on the tag name
        /// </summary>
        /// <param name="openTagName">
        /// Name of the tag
        /// </param>
        /// <returns>
        /// Returns closing tag
        /// </returns>
        public string GetEndTag(string openTagName)
        {          
            return ("</" + openTagName.Trim() + ">");
        }

        /// <summary>
        /// Adds attribute and it's value to 
        /// the XMLElement instance
        /// </summary>
        /// <param name="elementString">
        /// Gets string with tagName and all attributes
        /// </param>
        /// <param name="xmlElement">
        /// Instance to put the attributes in
        /// </param>
        private void AddAttrsIntoElement(string elementString, XmlElement xmlElement)
        {
            elementString = elementString.Replace(xmlElement.tagName, string.Empty).Trim();
            while (elementString.Contains("="))
            {
                string attrName = GetAttrName(elementString);
                string attrValue = GetAttrValue(elementString);
                xmlElement.AddAttr(attrName, attrValue);
                int endPos = elementString.IndexOf(attrValue) + attrValue.Length;
                elementString = elementString.Remove(1, endPos);
            }
        }

        /// <summary>
        /// Gets tagName from the line containing 
        /// tag's name and all it's attributes
        /// </summary>
        /// <param name="XMLElement">
        /// String which contains tagNames and it's attributes
        /// </param>
        /// <returns>
        /// Returns tag's name
        /// </returns>
        public string GetStartTag(string XMLElement)
        {
            int startPoint = 1;
            int endPoint = XMLElement.IndexOf(' ');
            if (endPoint == -1)
            {
                return XMLElement.Substring(startPoint, XMLElement.IndexOf(">") - startPoint);
            }
            else
            {
                return XMLElement.Substring(startPoint, XMLElement.IndexOf(' ') - startPoint);
            }
        }

        private string GetAttrName(string elementString)
        {
            return elementString.Substring(1, elementString.IndexOf("=") - 1);
        }

        private string GetAttrValue(string elementString)
        {
            char quotes = '"';
            int endPos = elementString.IndexOf(quotes) + 1;
            int startPos = endPos;
            while (!elementString[endPos].Equals(quotes))
            {          
                endPos++;
            }
            return elementString.Substring(startPos, endPos - startPos);
        }

        private string RemoveParsedBody(int bodyStartPoint, int bodyEndPoint, string foundElement, string tagName, string xmlString)
        {
            int startPos = bodyStartPoint - foundElement.Length;
            int lengthToDelete = bodyEndPoint - bodyStartPoint + foundElement.Length + GetEndTag(tagName).Length;
            return xmlString.Remove(startPos, lengthToDelete).Trim();
        }
    }
}
