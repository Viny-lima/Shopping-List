using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Data.Connection;
using ShoppingList.Infrastructure.Tests.Service;
using System;
using Xunit;

namespace ShoppingList.Infrastructure.Tests
{
    [Collection("StartUpDB")]
    public class ShoppingListContextTest
    {
        //Adicionando banco de dados que ser� usado nos testes
        private readonly StartDB _starDB;
        private readonly ShoppingListContext _context;

        public ShoppingListContextTest()
        {
            _context = new ShoppingListContext();
            _starDB = new StartDB();
        }

        [Fact]
        public void ConnectionContextWithSQLite()
        {
            //Arrange 
            bool connected;
            var db = _context;            

            //Act
            try
            {
                connected = db.Database.CanConnect();
            }
            catch
            {
                throw new Exception("N�o foi poss�vel conectar ao banco de dados.");
            }

            Assert.True(connected);
        }
    }
}
