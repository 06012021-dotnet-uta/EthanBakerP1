using System;
using Xunit;
using BusinessLayer;
using ModelsLibrary;
using RepositoryLayer;

namespace Project1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CorrectProductIndexFound()
        {
            //Arrange
            Project1Db context = new Project1Db();
            Methods methods = new Methods(context);
            ShoppingCart.shoppingCartProductList.Add(new Products { ProductID = 1000, ProductName = "thing1", ProductPrice = 1, ProductDescription = "A object" });
            ShoppingCart.shoppingCartProductList.Add(new Products { ProductID = 1001, ProductName = "thing2", ProductPrice = 2, ProductDescription = "Another object" });
            int i = 1;

            //Act
            int indexTest = methods.FindProductIndex(1001);
            ShoppingCart.shoppingCartProductList.Clear();

            //Assert
            Assert.Equal(i, indexTest);
        }
    }
}
