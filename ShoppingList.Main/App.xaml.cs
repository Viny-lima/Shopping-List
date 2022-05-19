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
        public static IContainer Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Container = CreateContainer();

            new ManagerDatabase().CreateDatabase();
            var window = new MainWindow();

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
