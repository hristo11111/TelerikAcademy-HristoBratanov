using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibrarySystem.Data
{
    public class DataContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Book> Books { get; set; }
    }
}
