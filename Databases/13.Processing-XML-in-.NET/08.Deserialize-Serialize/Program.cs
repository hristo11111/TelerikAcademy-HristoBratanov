using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace _08.Deserialize_Serialize
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "../../../catalogue.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Catalogue));

            // A FileStream is needed to read the XML document.
            FileStream fs = new FileStream(filename, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);

            // Declare an object variable of the type to be deserialized.
            Catalogue catalogue;

            // Use the Deserialize method to restore the object's state.
            catalogue = (Catalogue)serializer.Deserialize(reader);
            fs.Close();

            XmlWriter writer = XmlWriter.Create("../../albums.xml");

            using (writer)
            {
                serializer.Serialize(writer, catalogue);
                writer.Close();
            }
        }
    }

    
}
