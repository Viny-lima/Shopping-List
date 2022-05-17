using Autofac;
using Autofac.Features.ResolveAnything;
using ShoppingList.Data.Connection;
using ShoppingList.Data.DAO;
using ShoppingList.Data.Interfaces;
using ShoppingList.Data.Repositories;
using ShoppingList.Domain.Interfaces;
using ShoppingList.Main.ViewModels;
using ShoppingList.Service.Services;
using System;
using System.IO;
using System.Web.Services.Description;
using System.Windows;
using Windows.Storage;

namespace ShoppingList.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IContainer container = CreateContainer();

            new ManagerDatabase().CreateDatabase();

            MainViewModel mainViewModel = container.Resolve<MainViewModel>();
            var window = new MainWindow();

            window.DataContext = mainViewModel;

            MainWindow = window;
            MainWindow.Show();

            base.OnStartup(e);
        }

        private static IContainer CreateContainer()
        {
            //Dependency Injection
            var builder = new ContainerBuilder();

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            builder.RegisterType<ProductDAOEntity>().As<IProductDAO>().AsImplementedInterfaces();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().AsImplementedInterfaces();
            builder.RegisterType<ProductService>().As<IProductService>().AsImplementedInterfaces();

            IContainer container = builder.Build();
            return container;
        }
    }
}
