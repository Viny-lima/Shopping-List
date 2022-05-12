using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Interfaces;
using ShoppingList.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Screens.ViewModels
{
    public class ProductUpdateViewModel : ViewModelBase
    {
        public ProductItemViewModel Product { get; set; }
        private readonly IProductService _service;

        public ProductUpdateViewModel(IProductService service,ProductItemViewModel product)
        {
            this._service = service;
            this.Product = product;
        }

        private Product ProductItemViewModelForProduct()
        {
            var product = new Product
            {
                Id = Product.Id,
                Name = Product.Name,
                Description = Product.Description,
                RegistrationData = DateTime.Today
            };

            return product;
        }

        public async void UpdateProductSelected()
        {
            var product = ProductItemViewModelForProduct();
            await _service.Update(product);
        }

        public async void DeleteProductSelected()
        {
            var product = ProductItemViewModelForProduct();
            await _service.Update(product);
        }


    }
}
