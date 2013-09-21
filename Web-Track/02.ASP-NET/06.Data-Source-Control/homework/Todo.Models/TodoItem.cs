using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Todo.Models
{
    [DataContract]
    public class TodoItem
    {
        [Key]
        [DataMember(Name = "todoId")]
        public int TodoId { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "text")]
        public string Text { get; set; }
        [DataMember(Name = "dateLastChanged")]
        public DateTime DateLastChanged { get; set; }

        [DataMember(Name = "Category")]
        public virtual Category Catefory { get; set; }
    }
}
