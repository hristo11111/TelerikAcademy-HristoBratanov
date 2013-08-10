using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _11.ExtractFromXML
{
    class Program
    {
        static void Main()
        {
            string fileLocation = @"..\..\catalog.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            string xPathQuery = "/Catalogue/Artist/Album";

            XmlNodeList albumsList = doc.SelectNodes(xPathQuery);

            foreach (XmlNode node in albumsList)
            {
                string yearStr = node.SelectSingleNode("Year").InnerText;
                int year = int.Parse(yearStr);
                if (DateTime.Now.Year - year >= 5)
                {
                    decimal price = decimal.Parse(node.SelectSingleNode("Price").InnerText);
                    Console.WriteLine(price);
                }
            }            
        }
    }
}
