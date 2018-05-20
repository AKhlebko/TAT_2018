using System;
using System.IO;

namespace TaskDEV4
{
    class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                string xmlString = File.ReadAllText(@args[0]);
                XMLparser parser = new XMLparser();
                XmlElement rootElement = new XmlElement("Parsed XML file");
                xmlString = parser.DeleteComments(xmlString);
                parser.DepthXMLParse(rootElement, xmlString);
                rootElement.Sort();
                rootElement.PrintFromRootElement();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}