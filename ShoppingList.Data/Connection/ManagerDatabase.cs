using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Data.Connection
{
    public class ManagerDatabase : IDisposable
    {
        private ShoppingListContext _context;

        public ManagerDatabase()
        {
            _context = new ShoppingListContext();
        }

        public async void CreateDatabase()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async void DeleteDatabase()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
