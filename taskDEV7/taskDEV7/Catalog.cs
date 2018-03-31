using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DEV_7
{
    /// <summary>
    /// Class catalog for storing cars list and interacting with it
    /// </summary>
    public class Catalog
    {
        private CarBuilder builder = null;
        private string catalogPath = string.Empty;
        private List<Car> carsInCatalog;
        private List<string> brands = new List<string>(new string[] { "Mercedes", "Lada", "Volvo" });

        public Catalog(string pCatalogPath)
        {
            catalogPath = pCatalogPath;
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            Car[] newList = JsonConvert.DeserializeObject<Car[]>(File.ReadAllText(catalogPath), settings);
            carsInCatalog = new List<Car>();
            foreach (Car car in newList)
            {
                switch (car.Brand)
                {
                    case "Mercedes":
                        builder = new MercedesBuilder();
                        Car mercedes = builder.Create();
                        FillFieldsWithCarAttrs(mercedes, car);
                        carsInCatalog.Add(mercedes);
                        Mercedes.AddAttrs((Mercedes)mercedes);
                        break;
                    case "Lada":
                        builder = new LadaBuilder();
                        Car lada = builder.Create();
                        FillFieldsWithCarAttrs(lada, car);
                        carsInCatalog.Add(lada);
                        Lada.AddAttrs((Lada)lada);
                        break;
                    case "Volvo":
                        builder = new VolvoBuilder();
                        Car volvo = builder.Create();
                        FillFieldsWithCarAttrs(volvo, car);
                        carsInCatalog.Add(volvo);
                        Volvo.AddAttrs((Volvo)volvo);
                        break;
                }
            }
        }

        /// <summary>
        /// Method makes list with cars similar to input one 
        /// </summary>
        /// <param name="userChoice">
        /// Car to check similarity with
        /// </param>
        /// <returns>
        /// List of similar cars
        /// </returns>
        public List<Car> GetSimilarToBuy(Car userChoice)
        {
            List<Car> responseList = carsInCatalog;
            responseList = responseList.Where(t => (t.Brand.Equals(userChoice.Brand))).ToList();
            if (userChoice.BodyType != string.Empty)
            {
                responseList = responseList.Where(t => (t.BodyType.Equals(userChoice.BodyType))).ToList();
            }
            if (userChoice.ClimateControl != string.Empty)
            {
                responseList = responseList.Where(t => (t.ClimateControl.Equals(userChoice.ClimateControl))).ToList();
            }
            if (userChoice.EngineType != string.Empty)
            {
                responseList = responseList.Where(t => (t.EngineType.Equals(userChoice.EngineType))).ToList();
            }
            if (userChoice.Model != string.Empty)
            {
                responseList = responseList.Where(t => (t.Model.Equals(userChoice.Model))).ToList();
            }
            if (userChoice.Power != -1)
            {
                responseList = responseList.Where(t => (t.Power.Equals(userChoice.Power))).ToList();
            }
            if (userChoice.SalonType != string.Empty)
            {
                responseList = responseList.Where(t => (t.SalonType.Equals(userChoice.SalonType))).ToList();
            }
            if (userChoice.TransmissionType != string.Empty)
            {
                responseList = responseList.Where(t => (t.TransmissionType.Equals(userChoice.TransmissionType))).ToList();
            }
            if (userChoice.Volume != -1)
            {
                responseList = responseList.Where(t => (t.Volume.Equals(userChoice.Volume))).ToList();
            }
            return responseList;
        }

        /// <summary>
        /// Methods returns brands from this catalog
        /// </summary>
        /// <returns></returns>
        public List<string> GetSellingBrands()
        {
            return brands;
        }

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
