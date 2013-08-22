using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data
{
    public class BlogSystemContext : DbContext
    {
        public BlogSystemContext()
            : base("BlogSystemDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.UserName).IsUnicode(true);
            modelBuilder.Entity<User>().Property(x => x.DisplayName).IsUnicode(true);
            modelBuilder.Entity<Tag>().Property(x => x.Name).IsUnicode(true);
            modelBuilder.Entity<Tag>().Property(x => x.Name).HasColumnType("nvarchar");

            base.OnModelCreating(modelBuilder);
        }
    }
}
