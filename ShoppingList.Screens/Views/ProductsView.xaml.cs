using ShoppingList.Domain.ViewModels;
using ShoppingList.Screens.ViewModels;
using System;
using System.Collections.Generic;
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
    public sealed partial class ProductsView : Page
    {
        public ProductsViewModel ViewModel;

        public ProductsView()
        {
            this.InitializeComponent();            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = new ProductsViewModel(App.Service);
            ViewModel.StartUpListProducts();
            base.OnNavigatedTo(e);
        }
    }
}
