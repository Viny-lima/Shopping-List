using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Data.Interfaces;
using ShoppingList.Data.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Interfaces;
using ShoppingList.Infrastructure.Tests.Service;
using System;
using Xunit;
using Xunit.Abstractions;
using ShoppingList.Data.DAO;
using ShoppingList.Data.Connection;

namespace ShoppingList.Infrastructure.Tests
{
    [Collection("StartUpDB")]
    public class ProductRepositoryTests
    {
        private readonly StartDB startDB;
        private readonly IProductRepository _repository;
        private ITestOutputHelper SaidaConsole { get; }

        public ProductRepositoryTests(ITestOutputHelper _saidaConsole)
        {           
            //Arrange - Dependecy Injection
            var service = new ServiceCollection();
            service.AddTransient<IProductDAO, ProductDAOEntity>();
            service.AddTransient<IProductRepository, ProductRepository>();

            var provider = service.BuildServiceProvider();
            this._repository = provider.GetService<IProductRepository>();

            this.startDB = new StartDB();
            SaidaConsole = _saidaConsole;
            SaidaConsole.WriteLine("Arrange completed successfully!");
        }

        [Fact]
        public void AddProduct()
        {
            //Arrage
            var newProduct = new Product()
            {
                Id = 1,
                Name = "Pasta de Dente",
                Description = "Colgate - Total 12 horas de proteção",
                RegistrationData = DateTime.Today
            };

            //Act
            _repository.Add(newProduct);

            //Assert
            var expected = _repository.FindById(newProduct.Id).Result;

            Assert.Equal(expected.Name, newProduct.Name);
            Assert.Equal(expected.Description, newProduct.Description);
            Assert.Equal(expected.RegistrationData, newProduct.RegistrationData);
        }

        [Fact]
        public void DeleteProductDatabase()
        {
            //Arrange
            var newProduct = new Product()
            {
                Id = 5,
                Name = "Pasta de Dente",
                Description = "Colgate - Total 12 horas de proteção",
                RegistrationData = DateTime.Today
            };

            var product = _repository.Add(newProduct);

            //Act
            _repository.Delete(newProduct);

            //Assert
            var deletedFromDatabase = _repository.FindById(5).Result == null;
            Assert.True(deletedFromDatabase);
        }

        [Fact]
        public void NumberOfAddedEqualsTheAmountOfTheList()
        {
            //Arrange
            var numberOfAdded = 5;

            for(int i = 0; i < numberOfAdded; i ++) 
            {
                var newProduct = new Product()
                {
                    Name = $"Product Test {i}",
                    Description = $"Description test {1}",
                    RegistrationData = DateTime.Today
                };

                _repository.Add(newProduct);
            }

            //Act
            var listExpected = _repository.FindAll().Result;

            //Assert
            Assert.True(listExpected.Count >= numberOfAdded);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(10)]
        public void ReturnProductFindById(int id)
        {
            //Arrange
            var searchId = id;   
            
            //Assert & Act
            Assert.ThrowsAsync<ArgumentException>(async () => await _repository.FindById(id));
        }

        [Fact]
        public void ProductChangesUpdate()
        {
            //Arrange
            var newProduct = new Product()
            {
                Name = "Pipoca Doce",
                Description = "Marca - Bokus",
                RegistrationData = DateTime.Today
            };

            var product = _repository.Add(newProduct).Result;

            //Act
            product.Name = "Pipoca Salgada";
            _repository.Update(product);

            //Assert
            var expected = _repository.FindById(product.Id).Result;

            Assert.Equal(expected.Name, product.Name);
        }

    }
}
