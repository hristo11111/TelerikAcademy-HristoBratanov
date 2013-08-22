using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Client.Models
{
    public class PostModel
    {
        public DateTime PostDate { get; set; }

        public string Content { get; set; }

        public string PostedBy { get; set; }
    }
}