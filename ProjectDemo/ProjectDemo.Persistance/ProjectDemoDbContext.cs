using Microsoft.EntityFrameworkCore;
using ProjectDemo.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDemo.Persistance
{
    public class ProjectDemoDbContext : DbContext
    {
        public ProjectDemoDbContext(DbContextOptions<ProjectDemoDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
        }
    }
}
