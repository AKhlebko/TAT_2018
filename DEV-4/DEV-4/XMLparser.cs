using System.Text.RegularExpressions;

namespace TaskDEV4
{
    /// <summary>
    /// Class's for parsing XML files
    /// </summary>
    class XMLparser
    {
        /// <summary>
        /// Recursive method for depth parsing XML file
        /// Starts from the top and goes deeper to
        /// find every tag and it's data
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
                // All variables needed to parse this tag and it's body
                string foundElement = Regex.Match(xmlString, openTagPattern).ToString();
                string tagName = GetTagName(foundElement);
                string closeTagName = GetCloseTag(tagName);
                int bodyStartPoint = xmlString.IndexOf(foundElement) + foundElement.Length;
                int bodyEndPoint = xmlString.IndexOf(closeTagName);

                string foundTagBody = xmlString.Substring(bodyStartPoint, bodyEndPoint - bodyStartPoint).Trim();
                XmlElement newXmlElement = new XmlElement(tagName);
                AddAttrIntoElement(foundElement, newXmlElement);
                if (Regex.IsMatch(foundTagBody, openTagPattern))
                {
                    DepthXMLParse(newXmlElement, foundTagBody);
                    xmlString = RemoveParsedBody(bodyStartPoint, bodyEndPoint, foundElement, tagName, xmlString);
                }
                else
                {
                    newXmlElement.SetBody(foundTagBody);
                    xmlString = RemoveParsedBody(bodyStartPoint, bodyEndPoint, foundElement, tagName, xmlString);
                }
                headElement.AddNested(newXmlElement);
            }
        }
        
        /// <summary>
        /// Makes close tag based on the tag name
        /// </summary>
        /// <param name="openTagName">
        /// Name of the tag
        /// </param>
        /// <returns>
        /// Returns closing tag
        /// </returns>
        public string GetCloseTag(string openTagName)
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
        private void AddAttrIntoElement(string elementString, XmlElement xmlElement)
        {
            elementString = elementString.Replace(xmlElement.tagName, string.Empty).Trim();
            char attrBorders = (char)34;
            while (elementString.Contains("="))
            {
                int startPoint = 1;
                int endPoint = elementString.IndexOf(attrBorders) + 1;
                string attrName = elementString.Substring(startPoint, elementString.IndexOf("=") - 1);
                string attrValue = string.Empty;

                while(!elementString[endPoint].Equals(attrBorders))
                {
                    attrValue += elementString[endPoint];
                    endPoint++;
                }

                xmlElement.AddAttr(attrName, attrValue);
                elementString = elementString.Remove(startPoint, endPoint);
            }
        }

        /// <summary>
        /// Gets tagName from the line containing 
        /// tag's name and all it's attributes
        /// </summary>
        /// <param name="elementString">
        /// String which contains tagNames and it's attributes
        /// </param>
        /// <returns>
        /// Returns tag's name
        /// </returns>
        public string GetTagName(string elementString)
        {
            int startPoint = 1;
            int endPoint = elementString.IndexOf(' ');
            if (endPoint == -1)
            {
                return elementString.Substring(startPoint, elementString.IndexOf(">") - 1);
            }
            else
            {
                return elementString.Substring(startPoint, elementString.IndexOf(' '));
            }
        }

        private string RemoveParsedBody(int bodyStartPoint, int bodyEndPoint, string foundElement, string tagName, string xmlString)
        {
            int startPos = bodyStartPoint - foundElement.Length;
            int endPoint = bodyEndPoint - bodyStartPoint + foundElement.Length + GetCloseTag(tagName).Length;
            return xmlString.Remove(startPos, endPoint).Trim();
        }
    }
}
