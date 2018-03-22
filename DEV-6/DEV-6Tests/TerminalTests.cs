using NUnit.Framework;
using System;
using DEV_6;

namespace TerminalTests
{
    [TestFixture]
    public class TerminalTests
    {
        [TestCase("Spoon", "Golden", 100, (float)1.99)]
        [TestCase("Fork", "Silver", 10, (float)25.60)]
        public void AddItems_RightFormatName_ReturnedTrue(string typeName, string itemName, int number, float price)
        {
            // Arrange
            SaleItem item = new SaleItem(pName: itemName, pNumber: number, pPrice: price);
            Storage storage = new Storage();
            Terminal terminal = new Terminal(storage);

            //Assert
            Assert.IsTrue(terminal.AddItems(typeName, item));
        }

        [TestCase("sadf\\/asd:asd*?asdf<asdf>|", "Spoon", 100, (float)1.99)]
        [TestCase("", "Spoon", 100, (float)1.99)]
        [TestCase("", "Spoon", 100, (float)1.99)]
        public void AddItems_NotRightFormatName_FormatExceptionRaises(string typeName, string itemName, int number, float price)
        {
            // Arrange
            SaleItem item = new SaleItem(pName: itemName, pNumber: number, pPrice: price);
            Storage storage = new Storage();
            Terminal terminal = new Terminal(storage);

            //Assert
            FormatException ex = Assert.Throws<FormatException>(() => terminal.AddItems(typeName, item));
        }

        [Test]
        public void CountAll_ZeroItemsStored_ReturnsZero()
        {
            // Arrange
            Storage storage = new Storage();
            Terminal terminal = new Terminal(storage);

            //Assert
            int actual = terminal.CountAll();
            Assert.Zero(actual);
        }

        [Test]
        public void CountTypes_ZeroTypesStored_ReturnsZero()
        {
            // Arrange
            Storage storage = new Storage();
            Terminal terminal = new Terminal(storage);

            //Assert
            int actual = terminal.CountTypes();
            Assert.Zero(actual);
        }

        [Test]
        public void AveragePrice_AddSomeItems_Returns3()
        {
            // Arrange
            Storage storage = new Storage();
            Terminal terminal = new Terminal(storage);
            string typeName = "Spoon";
            terminal.AddItems(typeName, new SaleItem(pName: "Golden", pNumber: 100, pPrice: (float)4.99));
            typeName = "Fork";
            terminal.AddItems(typeName, new SaleItem(pName: "Silver", pNumber: 100, pPrice: (float)1.01));
            float excpected = (float)3.0;

            //Assert
            float actual = terminal.AveragePrice();
            Assert.AreEqual(excpected, actual);
        }

        [Test]
        public void AveragePriceDefinedType_AddSomeItems_Returns3()
        {
            // Arrange
            Storage storage = new Storage();
            Terminal terminal = new Terminal(storage);

            string typeName = "Spoon";
            terminal.AddItems(typeName, new SaleItem(pName: "Golden", pNumber: 100, pPrice: (float)4.99));
            terminal.AddItems(typeName, new SaleItem(pName: "Silver", pNumber: 100, pPrice: (float)1.01));
            float excpected = (float)3.0;

            //Assert
            float actual = terminal.AveragePrice(typeName);
            Assert.AreEqual(excpected, actual);
        }        
    }
}
