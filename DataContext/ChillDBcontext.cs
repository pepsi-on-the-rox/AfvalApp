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
        public ChillApplicationContext()
        {

        }

        public ChillApplicationContext(DbContextOptions<ChillApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ChillApplicationContext-04f542cb-7874-4345-a660-3d82a7e52118;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }

        public DbSet<Operator> Operator { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<Label> Label { get; set; }
    }
}