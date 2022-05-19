using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Data.Interfaces
{
    public interface IProductDAO : IDAO<Product>, IDisposable
    {
    }
}
