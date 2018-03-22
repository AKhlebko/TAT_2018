using System;
using NUnit.Framework;
using DEV_6;

namespace TerminalTests
{
    [TestFixture]
    class SaleItemTests
    {
        [TestCase("***\\*Spoon", 100, (float)1.99)]
        [TestCase("*Lego robot!*", 10, (float)25.60)]
        [TestCase("", 10, (float)25.60)]
        public void AddItems_NotRightFormatName_FormatExceptionRaises(string itemName, int number, float price)
        {
            //Assert
            FormatException ex = Assert.Throws<FormatException>(() => new SaleItem(itemName, number, price));
            Assert.That(ex.Message == "Invalid string format.");
        }

        [TestCase("Spoon", 100, (float)-1.99)]
        [TestCase("Lego robot!", 0, (float)25.60)]
        public void AddItems_NotRightFormatNumbers_FormatExceptionRaises(string itemName, int number, float price)
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SaleItem(itemName, number, price));
        }

        [Test]
        public void PropertiesReader_ReturnsRightValues()
        {
            // Arrange
            SaleItem item = new SaleItem("Buravushka", 100, (float)3.99);

            // Assert
            Assert.IsTrue("Buravushka" == item.Name);
            Assert.IsTrue(100 == item.Count);
            Assert.IsTrue((float)3.99 == item.Price);
        }

        [Test]
        public void PropertiesAccessor_AssignesRightValue()
        {
            // Arrange
            SaleItem item = new SaleItem("Buravushka", 100, (float)3.99);
            int excpected = 777;

            // Act
            item.Count = 777;

            // Assert
            Assert.AreEqual(excpected, item.Count);
        }

        [TestCase(-10)]
        [TestCase(0)]
        public void PropertiesAccessor_NotRightFormat_ExceptionRaised(int pCount)
        {
            // Arrange
            SaleItem item = new SaleItem("Buravushka", 100, (float)3.99);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => item.Count = pCount);
        }
    }
}
