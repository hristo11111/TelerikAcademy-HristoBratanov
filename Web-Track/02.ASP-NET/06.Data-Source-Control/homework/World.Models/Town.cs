using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace World.Models
{
    [DataContract]
    public class Town
    {
        [DataMember(Name = "townId")]
        public int TownId { get; set; }
        [DataMember(Name = "townName")]
        public string TownName { get; set; }
        [DataMember(Name = "townPopulation")]
        public ulong TownPopulation { get; set; }
        [DataMember(Name = "country")]
        public virtual Country Country { get; set; }
    }
}
