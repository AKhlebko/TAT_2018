using Newtonsoft.Json;

namespace DEV_7
{
    /// <summary>
    /// Class car with all it's attributes and methods
    /// </summary>
    [JsonObject]
    public class Car
    {
        private string brand;
        private string model;
        private string bodyType;
        private string transmissionType;              
        private string engineType;
        private int volume;
        private int power;
        private string climateControl;
        private string salonType;

        public Car() {}

        public Car(string brand, string model, string bodyType, string transmissionType, string engineType, int volume, int power, string climateControl, string salonType)
        {
            this.brand = brand;
            this.model = model;
            this.bodyType = bodyType;
            this.transmissionType = transmissionType;
            this.engineType = engineType;
            this.volume = volume;
            this.power = power;
            this.climateControl = climateControl;
            this.salonType = salonType;
        }
        
        [JsonProperty("Brand")]
        public string Brand { get => brand; set => brand = value; }
        [JsonProperty("Model")]
        public string Model { get => model; set => model = value; }
        [JsonProperty("BodyType")]
        public string BodyType { get => bodyType; set => bodyType = value; }
        [JsonProperty("TransmissionType")]
        public string TransmissionType { get => transmissionType; set => transmissionType = value; }
        [JsonProperty("EngineType")]
        public string EngineType { get => engineType; set => engineType = value; }
        [JsonProperty("Volume")]
        public int Volume { get => volume; set => volume = value; }
        [JsonProperty("Power")]
        public int Power { get => power; set => power = value; }
        [JsonProperty("ClimateControl")]
        public string ClimateControl { get => climateControl; set => climateControl = value; }
        [JsonProperty("SalonType")]
        public string SalonType { get => salonType; set => salonType = value; }

        public override string ToString()
        {
            return $"Car: {brand}, {model}, {bodyType}, {transmissionType}, {climateControl}, {salonType}; Volume: {volume}, Power: {power};";
        }

        public override bool Equals(object obj)
        {
            bool response = true;
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            Car car = (Car)obj;
            if (bodyType != car.bodyType)
            {
                response = false;
            }
            else if (model != car.model)
            {                               
                response = false;
            }
            else if (climateControl != car.climateControl)
            {
                response = false;
            }
            else if (this.engineType != car.engineType)
            {
                response = false;
            }
            else if (this.power != car.power)
            {
                response = false;
            }
            else if (this.salonType != car.salonType)
            {
                response = false;
            }
            else if (this.transmissionType != car.transmissionType)
            {
                response = false;
            }
            else if (this.volume != car.volume)
            {
                response = false;
            }
            return response;
        }
    }
}
