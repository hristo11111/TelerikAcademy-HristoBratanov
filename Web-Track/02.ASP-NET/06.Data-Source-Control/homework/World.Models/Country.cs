using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace World.Models
{
    [DataContract]
    public class Country
    {
        [Key]
        [DataMember(Name = "countryId")]
        public int CountryId { get; set; }
        [DataMember(Name = "countryName")]
        public string CountryName { get; set; }
        [DataMember(Name = "language")]
        public string Language { get; set; }
        [DataMember(Name = "countryPopulation")]
        public ulong CountryPopulation { get; set; }
        [DataMember(Name = "continent")]
        public virtual Continent Continent { get; set; }
        [DataMember(Name = "towns")]
        public virtual ICollection<Town> Towns { get; set; }
        [DataMember(Name = "image")]
        public byte[] Image { get; set; }

        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
    }
}
