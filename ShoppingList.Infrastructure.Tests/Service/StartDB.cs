using Microsoft.EntityFrameworkCore;
using ShoppingList.Data.Connection;
using System;

namespace ShoppingList.Infrastructure.Tests.Service
{
    public class StartDB : IDisposable
    {
        DbContext context;

        public StartDB()
        {
            StarUpDB();
        }

        private void StarUpDB()
        {
            context = new ShoppingListContext();
            context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

    }
}