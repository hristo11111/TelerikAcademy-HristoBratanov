using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace World.Models
{
    [DataContract]
    public class Continent
    {
        [Key]
        [DataMember(Name = "continentId")]
        public int ContintentId { get; set; }
        [DataMember(Name = "continentName")]
        public string ContinentName { get; set; }
        [DataMember(Name = "countries")]
        public virtual ICollection<Country> Countries { get; set; }

        public Continent()
        {
            this.Countries = new HashSet<Country>();
        }
    }
}
