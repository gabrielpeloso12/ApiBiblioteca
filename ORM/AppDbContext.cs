using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ORM
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livros> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>().HasKey(u => u.Id);
            modelBuilder.Entity<Livros>().HasKey(u => u.Id);
        }
    }
}
