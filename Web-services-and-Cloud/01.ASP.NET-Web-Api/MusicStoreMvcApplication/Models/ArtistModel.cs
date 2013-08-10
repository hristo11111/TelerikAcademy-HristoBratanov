using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MusicStoreMvcApplication.Models
{
    [DataContract(IsReference = true)]
    public class ArtistModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }
        [DataMember]
        public IEnumerable<SongModel> Songs { get; set; }
        [DataMember]
        public IEnumerable<AlbumModel> Albums { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
}
