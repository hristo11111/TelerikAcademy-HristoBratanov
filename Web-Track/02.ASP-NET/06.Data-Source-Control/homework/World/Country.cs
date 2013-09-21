//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace World
{
    using System;
    using System.Collections.Generic;
    
    public partial class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
    
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Language { get; set; }
        public Nullable<int> Continent_ContintentId { get; set; }
        public byte[] Image { get; set; }
    
        public virtual Continent Continent { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
    }
}
