using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }        

        public async Task<List<Product>> FindAll()
        {
            var listAsync = repository.FindAll().Result.ToList();

            return await Task.FromResult(listAsync);
        }

        public Task<Product> FindById(int id) => repository.FindById(id);

        public Task<Product> Registered(Product product) => repository.Add(product);

        public Task Update(Product product) => repository.Update(product);

        public Task Delete(Product product) => repository.Delete(product);
    }
}
