using Microsoft.EntityFrameworkCore;
using Organizaciebis_Cnobari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<MainAdmin> MainAdmin { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MainAdmin>().HasNoKey();
        }
    }
}
