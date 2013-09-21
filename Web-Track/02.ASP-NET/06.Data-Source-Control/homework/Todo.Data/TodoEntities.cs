using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Data
{
    public class TodoEntities : DbContext

    {
        public TodoEntities()
            : base("TodoDb")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TodoItem> Todos { get; set; }
    }
}
