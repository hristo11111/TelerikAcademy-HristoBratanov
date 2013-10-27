using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace temp.Models
{
    public class MoviesTempDbContext :DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                        .HasRequired(m => m.LeadingFemaleActor)
                        .WithMany(t => t.MoviesFemale)
                        .HasForeignKey(m => m.LeadingFemaleId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                        .HasRequired(m => m.LeadingMaleActor)
                        .WithMany(t => t.MoviesMale)
                        .HasForeignKey(m => m.LeadingMaleId)
                        .WillCascadeOnDelete(false);
        }
    }
}