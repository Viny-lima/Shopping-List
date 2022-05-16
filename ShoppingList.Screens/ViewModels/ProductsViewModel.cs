using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Interfaces;
using ShoppingList.Domain.ViewModels;
using ShoppingList.Screens.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ShoppingList.Screens.ViewModels
{
    public class ProductsViewModel
    {
        private readonly IProductService _service;
        public ObservableCollection<ProductItemViewModel> ListProducts;


        public ProductsViewModel(IProductService service)
        {
            this._service = service;
            LoadListProduct();
        }

        public void LoadListProduct()
        {
            ListProducts = new ObservableCollection<ProductItemViewModel>();

            var listDatabase = App.Service.FindAll().Result
                                   .Select(product => ProductItemViewModel.Create(product))
                                   .ToList();


            foreach (var item in listDatabase)
            {
                ListProducts.Add(item);
            }
        }

        public async void UpdateProductSelected(Product product)
        {
            var productDb = _service.FindById(product.Id).Result;
            productDb.Name = product.Name;
            productDb.Description = product.Description;
            productDb.RegistrationData = product.RegistrationData;

            await _service.Update(productDb);
        }

        public async void DeleteProductSelected(Product product)
        {
            var productDb = _service.FindById(product.Id).Result;
            await _service.Delete(productDb);

        }
        
    }
}
