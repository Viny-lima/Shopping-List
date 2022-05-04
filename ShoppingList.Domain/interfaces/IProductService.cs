using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Domain.Interfaces
{
    public interface IProductService
    {
        Task<Product> FindById(int id);
        Task<List<Product>> FindAll();
        Task<Product> Registered(Product product);
        Task Delete(Product product);
        Task Update(Product product);

    }
}
