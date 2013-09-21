using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models
{
    [DataContract]
    public class Category
    {
        [Key]
        [DataMember(Name = "categoryId")]
        public int CategoryId { get; set; }
        [DataMember(Name = "categoryName")]
        public string CategoryName { get; set; }
        [DataMember(Name = "todos")]
        public virtual ICollection<TodoItem> Todos { get; set; }

        public Category()
        {
            this.Todos = new HashSet<TodoItem>();
        }
    }
}
