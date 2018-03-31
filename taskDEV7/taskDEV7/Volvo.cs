using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace DEV_7
{
    /// <summary>
    /// Class volvo
    /// </summary>
    [JsonObject]
    public class Volvo : Car
    {
        private static List<string> models = new List<string>();
        private static List<string> engineTypes = new List<string>();
        private static List<string> transmissionTypes = new List<string>();
        private static List<string> bodyTypes = new List<string>();
        private static List<string> climateControls = new List<string>();
        private static List<string> salonTypes = new List<string>();

        public List<string> Models { get => models; set => models = value; }
        public List<string> EngineTypes { get => engineTypes; set => engineTypes = value; }
        public List<string> TransmissionTypes { get => transmissionTypes; set => transmissionTypes = value; }
        public List<string> BodyTypes { get => bodyTypes; set => bodyTypes = value; }
        public List<string> ClimateControls { get => climateControls; set => climateControls = value; }
        public List<string> SalonTypes { get => salonTypes; set => salonTypes = value; }

        public Volvo()
        {
            base.Brand = "Volvo";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Adds object's attributes to menu lists if needed
        /// </summary>
        /// <param name="volvo">
        /// Object, which attrs will be added
        /// </param>
        public static void AddAttrs(Volvo volvo)
        {
            if (!bodyTypes.Contains(volvo.BodyType))
            {
                bodyTypes.Add(volvo.BodyType);
            }
            if (!engineTypes.Contains(volvo.EngineType))
            {
                engineTypes.Add(volvo.EngineType);
            }
            if (!transmissionTypes.Contains(volvo.TransmissionType))
            {
                transmissionTypes.Add(volvo.TransmissionType);
            }
            if (!salonTypes.Contains(volvo.SalonType))
            {
                salonTypes.Add(volvo.SalonType);
            }
            if (!climateControls.Contains(volvo.ClimateControl))
            {
                climateControls.Add(volvo.ClimateControl);
            }
            if (!models.Contains(volvo.Model))
            {
                models.Add(volvo.Model);
            }
        }
    }
}
