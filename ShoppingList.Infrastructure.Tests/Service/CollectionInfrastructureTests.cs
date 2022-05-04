using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingList.Infrastructure.Tests.Service
{
    [CollectionDefinition("StartUpDB")]
    public class CollectionInfrastructureTests : ICollectionFixture<StartDB>
    {
    }
}
