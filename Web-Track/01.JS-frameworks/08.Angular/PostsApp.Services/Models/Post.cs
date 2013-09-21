using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PostsApp.Services.Models
{
    [DataContract]
    public class Post
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "content")]
        public string Content { get; set; }
        [DataMember(Name = "dateCreated")]
        public DateTime DateCreated { get; set; }
    }
}