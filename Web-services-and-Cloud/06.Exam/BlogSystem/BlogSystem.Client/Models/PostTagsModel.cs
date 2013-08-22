using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Client.Models
{
    public class PostTagsModel
    {
        public IEnumerable<TagModel> Tags { get; set; }
    }
}