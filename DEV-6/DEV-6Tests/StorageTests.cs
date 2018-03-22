using NUnit.Framework;
using DEV_6;

namespace TerminalTests
{
    [TestFixture]
    class StorageTests
    {
        [Test]
        public void GetAveragePrice_AddSomeItems_Returns3()
        {
            // Arrange
            Storage storage = new Storage();
            string typeName = "Spoon";
            storage.AddItems(typeName, new SaleItem(pName: "Golden", pNumber: 100, pPrice: (float)4.99));
            typeName = "Fork";
            storage.AddItems(typeName, new SaleItem(pName: "Silver", pNumber: 100, pPrice: (float)1.01));
            float excpected = (float)3.0;

            //Assert
            float actual = storage.GetAveragePrice();
            Assert.AreEqual(excpected, actual);
        }

        [TestCase("Spoon", 3)]
        [TestCase("Fork", -1)]
        public void AveragePriceDefinedType_AddSomeItems_Returns3(string nameToCalc, float price)
        {
            // Arrange
            Storage storage = new Storage();
            string typeName = "Spoon";
            storage.AddItems(typeName, new SaleItem(pName: "Golden", pNumber: 100, pPrice: (float)4.99));
            storage.AddItems(typeName, new SaleItem(pName: "Silver", pNumber: 100, pPrice: (float)1.01));
            float excpected = price;

            //Assert
            float actual = storage.GetAverageTypePrice(nameToCalc);
            Assert.AreEqual(excpected, actual);
        }
    }
}
