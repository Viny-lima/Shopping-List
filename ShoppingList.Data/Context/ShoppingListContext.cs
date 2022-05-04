using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Data.Connection
{
    public class ShoppingListContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=DataShoppingList.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Create Table
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name);
                entity.Property(p => p.Description);
                entity.Property(p => p.registrationData);
                entity.Property(p => p.pathImage);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
