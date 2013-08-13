using MusicStore.Data;
using MusicStore.Data.Migrations;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Client
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicStoreContext, Configuration>());
            
            MusicStoreContext context = new MusicStoreContext();

            Artist artist = new Artist()
            {
                Name = "Gosho",
                Country = "Bulgaria",
                DateOfBirth = new DateTime(2012, 5, 5)
            };

            context.Artists.Add(artist);
            context.SaveChanges();
        }
    }
}
