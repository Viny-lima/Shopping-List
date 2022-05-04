using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Data.DAO;
using ShoppingList.Data.Interfaces;
using ShoppingList.Data.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Interfaces;
using ShoppingList.Infrastructure.Tests.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ShoppingList.Infrastructure.Tests
{
    [Collection("StartUpDB")]
    public class ProductServiceTests
    {
        private readonly StartDB startDB;
        private readonly IProductRepository _repository;
        public ITestOutputHelper SaidaConsole { get; }

        public ProductServiceTests(ITestOutputHelper saidaConsole)
        {
            //Arrange - Dependecy Injection
            var service = new ServiceCollection();
            service.AddTransient<IProductDAO, ProductDAOEntity>();
            service.AddTransient<IProductRepository, ProductRepository>();

            var provider = service.BuildServiceProvider();
            this._repository = provider.GetService<IProductRepository>();

            this.startDB = new StartDB();
            SaidaConsole = saidaConsole;
            SaidaConsole.WriteLine("Arrange completed successfully!");
            SaidaConsole = saidaConsole;
        }
        [Fact]
        public void NumberOfAddedEqualsTheAmountOfTheList()
        {
            //Arrange
            var numberOfAdded = 5;

            for (int i = 0; i < numberOfAdded; i++)
            {
                var newProduct = new Product()
                {
                    Name = $"Product Test {i}",
                    Description = $"Description test {1}",
                    registrationData = DateTime.Today
                };

                _repository.Add(newProduct);
            }

            //Act
            var listExpected = _repository.FindAll().Result;

            //Assert
            Assert.True(listExpected.Count >= numberOfAdded);
        }

    }
}
