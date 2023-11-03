using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataContext
{
    public class ChillApplicationContext : DbContext
    {
        public ChillApplicationContext (DbContextOptions<ChillApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Operator> Operator { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ScanObject> ScanObject { get; set; }
    }
}
