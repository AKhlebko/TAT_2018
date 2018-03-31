using DEV_7;
using NUnit.Framework;

namespace taskDEV7Tests
{
    [TestFixture]
    class LadaTests
    {
        [Test]
        public void Equal_equalObject_TrueExcpected()
        {
            // Arrange
            string brand = "Mercedes";
            string model = "A";
            string bodyType = "Wagon";
            string transmissionType = "Manual";
            string engineType = "Petrol";
            int volume = 4;
            int power = 300;
            string climateControl = "None";
            string salonType = "Leather";
            Lada first = new Lada()
            {
                Brand = brand,
                Model = model,
                BodyType = bodyType,
                TransmissionType = transmissionType,
                EngineType = engineType,
                Volume = volume,
                Power = power,
                ClimateControl = climateControl,
                SalonType = salonType
            };

            Lada second = new Lada()
            {
                Brand = brand,
                Model = model,
                BodyType = bodyType,
                TransmissionType = transmissionType,
                EngineType = engineType,
                Volume = volume,
                Power = power,
                ClimateControl = climateControl,
                SalonType = salonType
            };

            // Assert
            Assert.AreEqual(first, second);
        }

        [Test]
        public void Equal_differentObject_FalseExcpected()
        {
            // Arrange
            string brand = "Mercedes";
            string model = "A";
            string bodyType = "Wagon";
            string transmissionType = "Manual";
            string engineType = "Petrol";
            int volume = 4;
            int power = 300;
            string climateControl = "None";
            string salonType = "Leather";
            Lada first = new Lada()
            {
                Brand = brand,
                Model = model,
                BodyType = bodyType,
                TransmissionType = transmissionType,
                EngineType = engineType,
                Volume = volume,
                Power = power,
                ClimateControl = climateControl,
                SalonType = salonType
            };

            Lada second = new Lada()
            {
                Brand = brand,
                Model = model,
                BodyType = string.Empty,
                TransmissionType = transmissionType,
                EngineType = engineType,
                Volume = volume,
                Power = power,
                ClimateControl = "Opened window",
                SalonType = salonType
            };

            // Assert
            Assert.AreNotEqual(first, second);
        }
    }
}
