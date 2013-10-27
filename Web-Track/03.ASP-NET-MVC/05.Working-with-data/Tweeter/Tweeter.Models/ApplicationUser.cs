using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweeter.Models
{
    public class ApplicationUser : User
    {
        public string Fullname { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}
