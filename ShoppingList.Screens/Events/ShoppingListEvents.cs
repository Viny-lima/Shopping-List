using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Screens.Events
{
    public static class ShoppingListEvents
    {
        public delegate void UpdateProduct(Product product);
        public static event UpdateProduct Update;

        public delegate void DeleteProduct(Product product);
        public static event DeleteProduct Delete;

        public delegate void LoadListProduct();
        public static event LoadListProduct RefreshList;

        public delegate void HideProduct();
        public static event HideProduct HideItem;

        public static void OnUpdateProduct(Product product)
        {
            Update?.Invoke(product);
            RefreshList?.Invoke();
            HideItem?.Invoke();
        }

        public static void OnDeleteProduct(Product product)
        {
            Delete?.Invoke(product);
            RefreshList?.Invoke();
            HideItem?.Invoke();

        }
    }
}
