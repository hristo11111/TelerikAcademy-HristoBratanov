using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<Category> Categories { get; }

        IRepository<Book> Books { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
