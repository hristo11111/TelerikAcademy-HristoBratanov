using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Students.Models
{
    [DataContract]
    public class Student
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "age")]
        public int Age { get; set; }
        [DataMember(Name = "avatar")]
        public string AvatarUrl { get; set; }
    }
}