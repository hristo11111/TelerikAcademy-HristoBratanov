using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace LibrarySystem.Data
{
    interface IDataContext
    {
        IDbSet<Category> Categories { get; set; }
        IDbSet<Book> Books { get; set; }
    }
}
