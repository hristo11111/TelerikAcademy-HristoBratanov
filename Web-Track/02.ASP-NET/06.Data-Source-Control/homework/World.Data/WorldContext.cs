using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Models;

namespace World.Data
{
    public class WorldContext : DbContext
    {
        public WorldContext()
            : base("WorldDb")
        {
        }

        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }
    }
}
