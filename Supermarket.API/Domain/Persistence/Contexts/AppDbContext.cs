using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Category Entity
            builder.Entity<Category>().ToTable("categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category) //Product property
                .HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
                (
                new Category { Id = 100, Name = "Fruits and Vegetables" },
                new Category { Id = 101, Name = "Dairt" }
                );

            // Products Entity
            builder.Entity<Product>().ToTable("products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name)
                .IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage)
                .IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement)
                .IsRequired();

        }
    }
}
