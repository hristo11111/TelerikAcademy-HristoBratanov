using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CatalogProcessorXPath
{
    class Program
    {
        static void Main()
        {
            //Task3
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            string xPathQuery = "catalogue/album";

            XmlNodeList albums = doc.SelectNodes(xPathQuery);
            Hashtable artists = new Hashtable();

            foreach (XmlNode album in albums)
            {
                foreach (XmlNode tag in album.ChildNodes)
                {
                    if (tag.Name == "artist")
                    {
                        if (artists.ContainsKey(tag.InnerText))
                        {
                            int counter = (int)artists[tag.InnerText];
                            artists[tag.InnerText] = counter + 1;
                        }
                        else
                        {
                            artists.Add(tag.InnerText, 1);
                        }
                    }
                }
            }

            Console.WriteLine("Artists and albums:");
            foreach (DictionaryEntry item in artists)
            {
                Console.WriteLine(item.Key + " has " + item.Value + " albums.");
            }

            //Task5
            Console.WriteLine("\nTitles:");
            string songPath = "catalogue/album/songs/song";
            XmlNodeList songs = doc.SelectNodes(songPath);

            foreach (XmlNode song in songs)
            {
                foreach (XmlNode tag in song)
                {
                    if (tag.Name == "title")
                    {
                        Console.WriteLine(tag.InnerText);
                    }
                }
            }

            //Task6
            Console.WriteLine("\nTitles:");
            XDocument xmlDoc = XDocument.Load("../../../catalogue.xml");

            var titles =
                from title in xmlDoc.Descendants("song")
                select title.Element("title").Value;

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
