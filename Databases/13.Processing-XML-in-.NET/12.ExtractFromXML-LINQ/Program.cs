using System;
using System.Linq;
using System.Xml.Linq;

namespace _12.ExtractFromXML_LINQ
{
    class Program
    {
        static void Main()
        {
            string fileLocation = @"..\..\catalog.xml";
            XDocument xmlDoc = XDocument.Load(fileLocation);
            XName albumTitle = "name";
            int currentYear = DateTime.Now.Year;

            var albums =
               from album in xmlDoc.Descendants("Album")
               where ((currentYear - int.Parse(album.Element("Year").Value)) <= 5)
               select new
               {
                   Title = album.Attribute(albumTitle).Value,
                   Year = int.Parse(album.Element("Year").Value)
               };

            foreach (var album in albums)
            {
                Console.WriteLine("{0},{1}", album.Title, album.Year);
            }
        }
    }
}
