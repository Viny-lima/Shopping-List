using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Interfaces;
using ShoppingList.Domain.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShoppingList.MainScreen.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Product> ListProducts { get; set; }

        private readonly IProductService service;

        public MainViewModel(IProductService service)
        {
            this.service = service;
            ListProducts = new ObservableCollection<Product>();
            StartUpListProductsWithTwoLastItens();
        }

        private void StartUpListProductsWithTwoLastItens()
        {
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
        }
    }
}
