using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.MainScreen.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Product> ListProducts { get; set; }

        private readonly IProductService service;

        public MainViewModel(IProductService service)
        {
            this.service = service;
            StartUpListProducts();
        }

        private void StartUpListProducts()
        {
            foreach (var item in service.FindAll().Result)
            {
                ListProducts.Add(item);
            }
        }
    }
}
