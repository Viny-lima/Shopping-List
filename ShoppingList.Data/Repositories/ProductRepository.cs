using ShoppingList.Data.Interfaces;
using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductDAO productDAO;

        public ProductRepository(IProductDAO productDAO)
        {
            this.productDAO = productDAO;
        }

        public async Task<Product> Add(Product product)
        {
            await productDAO.Create(product);
            var list = await productDAO.ReadAll();
            var productAdd = list.Last();
            return productAdd;
        }

        public async Task Delete(Product product)
        {
            await productDAO.Delete(product);
        }        

        public async Task<IList<Product>> FindAll()
        {
            return await productDAO.ReadAll();
        }

        public async Task<Product> FindById(int id)
        {
            try
            {
                return await productDAO.Read(id);
            }
            catch
            {
                throw new ArgumentException($"Product of Id {id} does not exist or is negative !");
            }
        }

        public async Task Update(Product product)
        {
            await productDAO.Update(product);
        }

        public void Dispose()
        {
            productDAO.Dispose();
        }
    }
}
