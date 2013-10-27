using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data
{
    public class DatabaseInitializer : DbMigrationsConfiguration<DataContext>
    {
        public DatabaseInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
            if (context.Books.Count() > 0)
            {
                return;
            }

            Random rand = new Random();

            Category categ1 = new Category { Name = "Science fiction" };
            Category categ2 = new Category { Name = "Comics" };
            
            for (int i = 0; i < 10; i++)
            {
                Book book = new Book();
                book.Author = "Author " + rand.Next(1, 50);
                book.Title = "Title " + rand.Next(60, 100);
                book.Category = categ1;

                context.Books.Add(book);
            }

            for (int i = 0; i < 10; i++)
            {
                Book book = new Book();
                book.Author = "Author " + rand.Next(1, 50);
                book.Title = "Title " + rand.Next(60, 100);
                book.Category = categ2;

                context.Books.Add(book);
                
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
