using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MusicStoreMvcApplication.Models
{
    [DataContract(IsReference = true)]
    public class AlbumModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public string Producer { get; set; }
        [DataMember]
        public IEnumerable<SongModel> Songs { get; set; }
        [DataMember]
        public IEnumerable<ArtistModel> Artists { get; set; }
    }
}
