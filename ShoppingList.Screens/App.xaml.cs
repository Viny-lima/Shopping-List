using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Data.Connection;
using ShoppingList.Data.DAO;
using ShoppingList.Data.Interfaces;
using ShoppingList.Data.Repositories;
using ShoppingList.Domain.Interfaces;
using ShoppingList.Screens.Views;
using ShoppingList.Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ShoppingList.Screens
{
    sealed partial class App : Application
    {
        private static IServiceProvider _provider;
        public static IProductService Service { get; private set; }

        public App()
        {
            this.InitializeComponent();
            CreateDatabaseApp();
            this.Suspending += OnSuspending;

            //Dependecy Injection
            _provider = CreateServiceProvider();
            Service = _provider.GetRequiredService<IProductService>();
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection service = new ServiceCollection();

            service.AddTransient<IProductDAO, ProductDAOEntity>();
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IProductService, ProductService>();

            return service.BuildServiceProvider();
        }

        private void CreateDatabaseApp()
        {
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Database.db");
            new ManagerDatabase(path).CreateDatabase();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(ProductsView), e.Arguments);
                }

                Window.Current.Activate();
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }
    }
}
