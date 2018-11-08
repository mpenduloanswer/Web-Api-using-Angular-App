using Microsoft.EntityFrameworkCore;
using SportEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvent
{
    public class SportDbContext : DbContext 
    {
        public SportDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Sport> sports { get; set; } 
        public DbSet<Country> countries { get; set; }
        public DbSet<Tournament> tournaments { get; set; }
        public DbSet <Event> events { get; set; }
    }
}
