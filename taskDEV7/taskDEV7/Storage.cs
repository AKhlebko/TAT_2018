using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DEV_7
{
    /// <summary>
    /// Class storage for storing cars
    /// </summary>
    class Storage
    {
        private CarBuilder builder = null;
        private List<Car> carsInStorage;
        private List<string> brands = new List<string>(new string[] { "Mercedes", "Lada", "Volvo" });
        public Storage()
        {
            LoadCars();

        }

        /// <summary>
        /// Reloads cars[] from storage file
        /// </summary>
        public void ReloadCars()
        {
            LoadCars();
        }

        private void LoadCars()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            Car[] newList = JsonConvert.DeserializeObject<Car[]>(File.ReadAllText(@"storage.json"), settings);
            carsInStorage = new List<Car>();
            foreach (Car car in newList)
            {
                switch (car.Brand)
                {
                    case "Mercedes":
                        builder = new MercedesBuilder();
                        Car mercedes = builder.Create();
                        FillFieldsWithCarAttrs(mercedes, car);
                        carsInStorage.Add(mercedes);
                        break;
                    case "Lada":
                        builder = new LadaBuilder();
                        Car lada = builder.Create();
                        FillFieldsWithCarAttrs(lada, car);
                        carsInStorage.Add(lada);
                        break;
                    case "Volvo":
                        builder = new VolvoBuilder();
                        Car volvo = builder.Create();
                        FillFieldsWithCarAttrs(volvo, car);
                        carsInStorage.Add(volvo);
                        break;
                }
            }
        }

        /// <summary>
        /// Saves list of cars to the file 
        /// </summary>
        public void SaveToJSON()
        {
            Car[] arrayToSerialize = carsInStorage.ToArray();
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string serialized = JsonConvert.SerializeObject(arrayToSerialize);
            File.WriteAllText(@"storage.json", serialized);
        }

        /// <summary>
        /// Adds new car to the storage for futher selling
        /// </summary>
        /// Which car to buy
        /// <param name="carToProduce"></param>
        public void ProduceCar(Car carToProduce)
        {
            carsInStorage.Add(carToProduce);
        }

        /// <summary>
        /// Check whether car is in the storage or not
        /// </summary>
        /// <param name="carToFind">
        /// Car to find in the list
        /// </param>
        /// <returns></returns>
        public bool IsInStorage(Car carToFind)
        {
            return carsInStorage.Contains(carToFind) ? true : false;
        }

        /// <summary>
        /// Deletes chosen car rom the storage
        /// </summary>
        /// <param name="boughtOne">
        /// Car to delete
        /// </param>
        /// <returns></returns>
        public bool DeleteBoughtCar(Car boughtOne)
        {
            carsInStorage.Remove(boughtOne);
            return true;
        }

        /// <summary>
        /// Copies attributes from one car to another
        /// </summary>
        /// <param name="response">
        /// Car to copy attr in
        /// </param>
        /// <param name="carFromJson">
        /// Car to copy attrs from
        /// </param>
        private void FillFieldsWithCarAttrs(Car response, Car carFromJson)
        {
            response.BodyType = carFromJson.BodyType;
            response.Brand = carFromJson.Brand;
            response.ClimateControl = carFromJson.ClimateControl;
            response.EngineType = carFromJson.EngineType;
            response.Model = carFromJson.Model;
            response.Power = carFromJson.Power;
            response.SalonType = carFromJson.SalonType;
            response.TransmissionType = carFromJson.TransmissionType;
            response.Volume = carFromJson.Volume;
        }
    }
}
