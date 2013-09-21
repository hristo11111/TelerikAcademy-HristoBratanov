﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSilver.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SessionKey { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public User()
        {
            this.Products = new HashSet<Product>();
        }
    }
}
