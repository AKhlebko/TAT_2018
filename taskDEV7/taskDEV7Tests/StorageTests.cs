using DEV_7;
using NUnit.Framework;

namespace taskDEV7Tests
{
    [TestFixture]
    class StorageTests
    {
        [Test]
        public void AddingObject_IsInStorage_ReturnsTrue()
        {
            // Arrange
            Storage storage = new Storage(@"C:\Users\AKhlebko\workspace\TAT_2018\taskDEV7\taskDEV7Tests\bin\Debug\storage.json");
            storage.ReloadCars();
            Car newCarToStorage = new Car()
            {
                Brand = "Mercedes",
                Model = "A",
                BodyType = "Wagon",
                TransmissionType = "Manual",
                EngineType = "Petrol",
                Volume = 3,
                Power = 200,
                ClimateControl = "Opened window",
                SalonType = "Leather"
            };

            // Act
            storage.ProduceCar(newCarToStorage);

            // Assert
            Assert.IsTrue(storage.IsInStorage(newCarToStorage));
        }

        [Test]
        public void DeletingObject_IsInStorage_ReturnsFalse()
        {
            // Arrange 
            Storage storage = new Storage(@"C:\Users\AKhlebko\workspace\TAT_2018\taskDEV7\taskDEV7Tests\bin\Debug\storage.json");
            storage.ReloadCars();
            Car newCarToStorage = new Car()
            {
                Brand = "Mercedes",
                Model = "A",
                BodyType = "Wagon",
                TransmissionType = "Manual",
                EngineType = "Petrol",
                Volume = 3,
                Power = 200,
                ClimateControl = "Opened window",
                SalonType = "Leather"
            };

            // Act
            storage.ProduceCar(newCarToStorage);

            // Assert
            Assert.IsTrue(storage.IsInStorage(newCarToStorage));

            storage.DeleteBoughtCar(newCarToStorage);
            Assert.IsFalse(storage.IsInStorage(newCarToStorage));
        }
    }
}
