using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Data.DAO;
using ShoppingList.Data.Interfaces;
using ShoppingList.Data.Repositories;
using ShoppingList.Domain.Interfaces;
using ShoppingList.MainScreen.ViewModels;
using ShoppingList.Service.Services;
using System;
using System.Windows;

namespace ShoppingList.MainScreen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _provider;
        private IProductService productService;

        public App()
        {
            //Dependency Injection
            this._provider = CreateServiceProvider();
            this.productService = _provider.GetRequiredService<IProductService>();

            var window = new MainWindow();
            window.DataContext = new MainViewModel(productService);
            MainWindow = window;
            MainWindow.Show();
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection service = new ServiceCollection();

            service.AddTransient<IProductDAO, ProductDAOEntity>();
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IProductService, ProductService>();

            return service.BuildServiceProvider();
        }

    }
}
