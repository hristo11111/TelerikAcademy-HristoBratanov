using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace temp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime Year { get; set; }

        public int LeadingFemaleId { get; set; }
        public int LeadingMaleId { get; set; }

        public virtual Actor LeadingFemaleActor { get; set; }
        public virtual Actor LeadingMaleActor { get; set; }
    }
}