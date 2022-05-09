using ShoppingList.Domain.Entities;
using System;
using Xunit;

namespace ShoppingList.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CreatingValidProduct()
        {
            //Arrange
            var id = 1;
            var name = "Banana";
            var description = "Um palma de banana madura";
            var data = DateTime.Today;

            //Act
            var product = new Product()
            {
                Id = id,
                Name = name,
                Description = description,
                RegistrationData = data
            };

            //Assert
            Assert.Equal(id, product.Id);
            Assert.Equal(name, product.Name);
            Assert.Equal(description, product.Description);
            Assert.Equal(data, product.RegistrationData);

        }
    }
}
