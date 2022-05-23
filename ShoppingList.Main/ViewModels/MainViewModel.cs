using Microsoft.VisualStudio.PlatformUI;
using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Interfaces;
using ShoppingList.Service.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Main.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private bool _listEmpty;
        public bool IsAny
        {
            get 
            {
                return _listEmpty;
            }
            set
            {
                SetProperty(ref _listEmpty, value);
            }
        }

        public ObservableCollection<Product> ListProducts { get; set; }

        private readonly IProductService service;

        public MainViewModel(IProductService service)
        {
            this.service = service;

            ShoppingListEvents.RefreshList += isRefreshListEmpty;

            StartListWithTwoLastItens();
        }   

        private void isRefreshListEmpty()
        {
            IsAny = ListProducts.Any();
        }

        private void StartListWithTwoLastItens()
        {
            var count = 0;
            var listProducts = service.FindAll().Result.ToList();
            int indexLastButOne = listProducts.Count - 2;

            ListProducts = new ObservableCollection<Product>();

            foreach (var item in listProducts)
            {
                if (count >= indexLastButOne)
                {
                    ListProducts.Add(item);
                }

                count++;
            }

            ShoppingListEvents.OnRefreshList();
        }

        public void RefreshListWithTwoLastItens()
        {
            ListProducts.Clear();

            var count = 0;
            var listProducts = service.FindAll().Result.ToList();
            int indexLastButOne = listProducts.Count - 2;

            foreach (var item in listProducts)
            {
                if (count >= indexLastButOne)
                {
                    ListProducts.Add(item);
                }

                count++;
            }

            ShoppingListEvents.OnRefreshList();
        }
    }
}
