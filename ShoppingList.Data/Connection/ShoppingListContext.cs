using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Data.Connection
{
    internal class ShoppingListContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        private static bool _onDatabasePathChange;
        private static string _path;
        public static string Path
        {
            get
            {
                if (String.IsNullOrEmpty(_path))
                {
                    throw new InvalidOperationException($"static property {nameof(Path)} not inserted in instance-static({typeof(ShoppingListContext)}).");
                }

                return _path;
            }
            set
            {
                if (!_onDatabasePathChange)
                {
                    _path = value;
                    _onDatabasePathChange = true;
                }
            }
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"DataSource={Path}");
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
                entity.Property(p => p.RegistrationData);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
