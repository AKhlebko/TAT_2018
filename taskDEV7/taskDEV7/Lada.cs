using System.Collections.Generic;
using Newtonsoft.Json;

namespace DEV_7
{
    /// <summary>
    /// Class Lada 
    /// </summary>
    [JsonObject]
    public class Lada : Car
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

        public Lada()
        {
            Brand = "Lada";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }


        /// <summary>
        /// Adds object's attributes to menu lists if needed
        /// </summary>
        /// <param name="lada">
        /// Object, which attrs will be added
        /// </param>
        public static void AddAttrs(Lada lada)
        {
            if (!bodyTypes.Contains(lada.BodyType))
            {
                bodyTypes.Add(lada.BodyType);
            }
            if (!engineTypes.Contains(lada.EngineType))
            {
                engineTypes.Add(lada.EngineType);
            }
            if (!transmissionTypes.Contains(lada.TransmissionType))
            {
                transmissionTypes.Add(lada.TransmissionType);
            }
            if (!salonTypes.Contains(lada.SalonType))
            {
                salonTypes.Add(lada.SalonType);
            }
            if (!climateControls.Contains(lada.ClimateControl))
            {
                climateControls.Add(lada.ClimateControl);
            }
            if (!models.Contains(lada.Model))
            {
                models.Add(lada.Model);
            }
        }
    }
}
