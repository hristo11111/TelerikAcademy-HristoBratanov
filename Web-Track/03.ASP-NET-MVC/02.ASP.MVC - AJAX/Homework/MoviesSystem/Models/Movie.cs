using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesSystem.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime Year { get; set; }
        public virtual Actor LeadingFemaleRole { get; set; }
        public virtual Actor LeadingMaleRole { get; set; }
    }
}