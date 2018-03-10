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
                parser.DepthXMLParse(rootElement, xmlString);
                rootElement.Sort();
                rootElement.PrintFromRootElement();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("You haven't add path to XML file in command line args.");
            }
        }
    }
}