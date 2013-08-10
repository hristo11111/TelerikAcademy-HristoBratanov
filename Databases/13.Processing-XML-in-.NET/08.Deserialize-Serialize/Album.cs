using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace _08.Deserialize_Serialize
{
    [XmlRoot("album")]
    public class Album
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("artist")]
        public string Artist { get; set; }

        //[XmlElement("year")]
        //public DateTime Year { get; set; }

        //[XmlElement("producer")]
        //public string Producer { get; set; }

        //[XmlElement("price")]
        //public double Price { get; set; }

        //[XmlArray("songs")]
        //[XmlArrayItem("song", typeof(Song))]
        //public Song[] Songs { get; set; }
    }
}
