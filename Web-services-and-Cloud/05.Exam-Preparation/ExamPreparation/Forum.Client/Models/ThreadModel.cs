using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Client.Models
{
    public class ThreadModel
    {
        public string Title { get; set; }

        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Content { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<PostModel> Posts { get; set; }
    }
}