using DEV_7;
using NUnit.Framework;
using System.Collections.Generic;

namespace taskDEV7Tests
{
    [TestFixture]
    class CatalogTests
    {
        [Test]
        public void GetSellingBrands_ReturnsList()
        {
            // Arrange
            Catalog catalog = new Catalog(@"C:\Users\AKhlebko\workspace\TAT_2018\taskDEV7\taskDEV7Tests\bin\Debug\cars.json");

            // Act
            List<string> actual = catalog.GetSellingBrands();
            List<string> excpected = new List<string>(new string[] { "Mercedes", "Lada", "Volvo" });

            // Assert
            Assert.AreEqual(excpected, actual);
        }
    }
}
