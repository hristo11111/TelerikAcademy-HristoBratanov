using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
