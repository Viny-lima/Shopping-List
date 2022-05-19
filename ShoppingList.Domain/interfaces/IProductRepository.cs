using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>, IDisposable
    {
    }
}
