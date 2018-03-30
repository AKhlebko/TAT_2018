﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DEV_7
{
    /// <summary>
    /// Class Lada 
    /// </summary>
    [JsonObject]
    class Lada : Car
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

        public static void AddAttrs(Car mercedes)
        {
            if (!bodyTypes.Contains(mercedes.BodyType))
            {
                bodyTypes.Add(mercedes.BodyType);
            }
            if (!engineTypes.Contains(mercedes.EngineType))
            {
                engineTypes.Add(mercedes.EngineType);
            }
            if (!transmissionTypes.Contains(mercedes.TransmissionType))
            {
                transmissionTypes.Add(mercedes.TransmissionType);
            }
            if (!salonTypes.Contains(mercedes.SalonType))
            {
                salonTypes.Add(mercedes.SalonType);
            }
            if (!climateControls.Contains(mercedes.ClimateControl))
            {
                climateControls.Add(mercedes.ClimateControl);
            }
            if (!models.Contains(mercedes.Model))
            {
                models.Add(mercedes.Model);
            }
        }
    }
}
