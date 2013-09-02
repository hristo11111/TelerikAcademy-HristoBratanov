using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PostsApp.Services.Models
{
    [DataContract]
    public class Category
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "posts")]
        public IEnumerable<Post> Posts { get; set; }
    }
}