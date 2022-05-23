using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Service.Events
{
    public static class ShoppingListEvents
    {
        public delegate void UpdateProduct(Product product);
        public static event UpdateProduct Update;

        public delegate void DeleteProduct(Product product);
        public static event DeleteProduct Delete;

        public delegate void AddProduct(Product product);
        public static event AddProduct Add;

        public delegate void LoadListProduct();
        public static event LoadListProduct RefreshList;

        public static void OnRefreshList()
        {
            RefreshList?.Invoke();
        }

        public static void OnUpdateProduct(Product product)
        {
            Update?.Invoke(product);
            RefreshList?.Invoke();
        }

        public static void OnDeleteProduct(Product product)
        {
            Delete?.Invoke(product);
            RefreshList?.Invoke();
        }

        public static void OnAddProduct(Product product)
        {
            Add?.Invoke(product);
            RefreshList?.Invoke();
        }
    }
}
