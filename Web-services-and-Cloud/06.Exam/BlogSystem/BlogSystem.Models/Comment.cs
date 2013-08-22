using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlogSystem.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime DateCommented { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public Comment()
        {
            this.Posts = new HashSet<Post>();
        }
    }
}
