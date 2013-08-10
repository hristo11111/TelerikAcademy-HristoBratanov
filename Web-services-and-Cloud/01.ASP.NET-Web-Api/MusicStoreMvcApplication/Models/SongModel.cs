using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MusicStoreMvcApplication.Models
{
    [DataContract(IsReference = true)]
    public class SongModel
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public int ArtistId { get; set; }
        [DataMember]
        public string Genre { get; set; }
        [DataMember]
        public int AlbumId { get; set; }
        [DataMember]
        public string SongArtist { get; set; }
        [DataMember]
        public string AlbumTitle { get; set; }
    }
}
