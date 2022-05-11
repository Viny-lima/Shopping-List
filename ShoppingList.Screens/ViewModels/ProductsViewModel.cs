using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Interfaces;
using ShoppingList.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Screens.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        public ObservableCollection<ProductItemViewModel> ListProducts { get; set; }

        private readonly IProductService service;

        public ProductsViewModel(IProductService service)
        {
            this.service = service;
            ListProducts = new ObservableCollection<ProductItemViewModel>();
        }

        public void StartUpListProducts()
        {
            var listProducts = service.FindAll().Result.ToList();

            foreach (var item in listProducts)
            {
                var productViewModel = new ProductItemViewModel(item);
                ListProducts.Add(productViewModel);
            }
        }
    }
}
