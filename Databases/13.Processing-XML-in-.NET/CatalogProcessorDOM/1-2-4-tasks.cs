using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections;

namespace CatalogProcessor
{
    class Program
    {
        static void Main()
        {
            // Task1 and Task2
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");

            Hashtable artists = new Hashtable();

            XmlNode rootNode = doc.DocumentElement;
            foreach (XmlNode item in rootNode.ChildNodes)
            {
                foreach (XmlNode node in item.ChildNodes)
                {
                    if (node.Name == "artist")
                    {
                        if (artists.ContainsKey(node.InnerText))
                        {
                            int counter = (int)artists[node.InnerText];
                            artists[node.InnerText] = counter + 1;
                        }
                        else
                        {
                            artists.Add(node.InnerText, 1);
                        }
                    }
                }
            }

            Console.WriteLine("Artists and albums: ");
            foreach (DictionaryEntry item in artists)
            {
                Console.WriteLine(item.Key + " has " + item.Value + " albums.");
            }

            //Task4
            foreach (XmlNode album in rootNode.ChildNodes)
            {
                foreach (XmlNode element in album.ChildNodes)
                {
                    if (element.Name == "price")
                    {
                        if (double.Parse(element.InnerText) > 20)
                        {
                            rootNode.RemoveChild(album);
                        }
                    }
                }
            }

            doc.Save("../../../catalogue.xml");
        }
    }
}
