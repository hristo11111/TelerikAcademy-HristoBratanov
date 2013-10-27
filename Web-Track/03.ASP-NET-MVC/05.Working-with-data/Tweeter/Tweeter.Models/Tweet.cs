using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweeter.Models
{
    public class Tweet
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateTweeded { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
