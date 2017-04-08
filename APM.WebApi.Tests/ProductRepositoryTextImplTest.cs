using APM.WebApi.Models;
using APM.WebApi.Repository;
using APM.WebApi.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APM.WebApi.Tests
{
    [TestClass]
    public class ProductRepositoryTextImplTest
    {
        UnitTestPathProvider upp = new UnitTestPathProvider();

        [TestMethod]
        public void GetProductsTest()
        {
                      
            ProductRepositoryTextImpl repo = new ProductRepositoryTextImpl(upp);
            var result = repo.Retrieve();
            Assert.AreNotEqual(result, null);
        }

        [TestMethod]
        public void SaveProductTest()
        {
            //Arrange
            ProductRepositoryTextImpl repo = new ProductRepositoryTextImpl(upp);
            int originalCount = repo.Retrieve().Count;

            //Act
            Product newProduct = new Product();
            newProduct.Description = "Unit test";
            newProduct.Price = 10;
            newProduct.ProductCode = DateTime.Today.Ticks.ToString();
            newProduct.ReleaseDate = DateTime.Now;
            repo.Save(newProduct);

            //Assert
            int countAfterCreate = repo.Retrieve().Count;

            Assert.AreEqual(originalCount + 1, countAfterCreate);
        }
    }
}
