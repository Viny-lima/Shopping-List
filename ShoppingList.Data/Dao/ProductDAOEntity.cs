using Microsoft.EntityFrameworkCore;
using ShoppingList.Data.Connection;
using ShoppingList.Data.Interfaces;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Data.DAO
{
    public class ProductDAOEntity : IProductDAO
    {
        private readonly ShoppingListContext _context;

        public ProductDAOEntity()
        {
            this._context = new ShoppingListContext();
            _context.Database.EnsureCreated();
        }

        public async Task Create(Product product)
        {
            await _context.Set<Product>().AddAsync(product);
            await _context.SaveChangesAsync();
        }        

        public async Task<Product> Read(int id)
        {
            return await _context.Set<Product>().FindAsync(id);
        }

        public async Task<List<Product>> ReadAll()
        {
            return await _context.Set<Product>().ToListAsync();
        }

        public async Task Update(Product product)
        {
            _context.Set<Product>().Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {           
            _context.Set<Product>().Add(product);
            await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
