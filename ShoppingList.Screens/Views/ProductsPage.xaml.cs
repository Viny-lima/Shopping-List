using ShoppingList.Domain.ViewModels;
using ShoppingList.Screens.Events;
using ShoppingList.Screens.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ShoppingList.Screens.Views
{
    public sealed partial class ProductsPage : Page
    {
        public ProductItemViewModel ItemSelected;
        public ProductsViewModel ViewModel;

        public ProductsPage()
        {
            this.InitializeComponent();            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Initialize
            ViewModel = new ProductsViewModel(App.Service);
            ItemSelected = new ProductItemViewModel();

            OnConfigureEvents();
            base.OnNavigatedTo(e);
        } 

        private void OnConfigureEvents()
        {
            //Events
            ShoppingListEvents.Update += ViewModel.UpdateProductSelected;
            ShoppingListEvents.Delete += ViewModel.DeleteProductSelected;
            ShoppingListEvents.RefreshList += ViewModel.LoadListProduct;
            ShoppingListEvents.HideItem += HideItemSelected;
        }

        private void HideItemSelected()
        {
            ProductItemView.Visibility = Visibility.Collapsed;
        }

        private void ShowItemSelected()
        {
            ProductItemView.Visibility = Visibility.Visible;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var productSelected = e.ClickedItem as ProductItemViewModel;
            ForProductSelected(productSelected);
            ShowItemSelected();
        }

        private void ForProductSelected(ProductItemViewModel productSelected) 
        {
            ItemSelected.Id = productSelected.Id;
            ItemSelected.Name = productSelected.Name;
            ItemSelected.Description = productSelected.Description;
            ItemSelected.RegistrationData = productSelected.RegistrationData;
        }
    }
}
