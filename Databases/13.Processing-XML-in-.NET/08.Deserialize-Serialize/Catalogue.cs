using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _08.Deserialize_Serialize
{
    [XmlRoot("catalogue")]
    public class Catalogue
    {
        [XmlElement(ElementName="album")]
        public List<Album> Albums { get; set; }
    }
}
