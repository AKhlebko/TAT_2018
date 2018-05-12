using System;
using System.Collections.Generic;

namespace DEV_7
{
    /// <summary>
    /// Exstension class for Car 
    /// Provides new method for filling info about the car with user
    /// </summary>
    public static class CarExstension
    {
        /// <summary>
        /// Method for filling info about the car with user
        /// </summary>
        /// <param name="car">
        /// Car parameter
        /// </param>
        public static void FillParametersByUser(this Car car)
        {
            if (car.GetType() == typeof(Mercedes))
            {
                car.Model = GetModel((car as Mercedes).Models);
                car.BodyType = GetCarcase((car as Mercedes).BodyTypes);
                car.TransmissionType = GetTransmission((car as Mercedes).TransmissionTypes);
                car.EngineType = GetEngine((car as Mercedes).EngineTypes);
                car.Volume = GetVolume();
                car.Power = GetPower();
                car.ClimateControl = GetAirCondition((car as Mercedes).ClimateControls);
                car.SalonType = GetSalonMaterial((car as Mercedes).SalonTypes);
            }
            else if (car.GetType() == typeof(Lada))
            {
                car.Model = GetModel((car as Lada).Models);
                car.BodyType = GetCarcase((car as Lada).BodyTypes);
                car.TransmissionType = GetTransmission((car as Lada).TransmissionTypes);
                car.EngineType = GetEngine((car as Lada).EngineTypes);
                car.Volume = GetVolume();
                car.Power = GetPower();
                car.ClimateControl = GetAirCondition((car as Lada).ClimateControls);
                car.SalonType = GetSalonMaterial((car as Lada).SalonTypes);
            }
            else if (car.GetType() == typeof(Volvo))
            {
                car.Model = GetModel((car as Volvo).Models);
                car.BodyType = GetCarcase((car as Volvo).BodyTypes);
                car.TransmissionType = GetTransmission((car as Volvo).TransmissionTypes);
                car.EngineType = GetEngine((car as Volvo).EngineTypes);
                car.Volume = GetVolume();
                car.Power = GetPower();
                car.ClimateControl = GetAirCondition((car as Volvo).ClimateControls);
                car.SalonType = GetSalonMaterial((car as Volvo).SalonTypes);
            }
        }

        private static string GetEngine(List<string> engines)
        {
            PrintVariants(engines);
            int choice = ConsoleMenu.GetActionBetween(1, engines.Count);
            if (choice == -1)
            {
                return string.Empty;
            }
            else
            {
                return engines[choice - 1];
            }
        }

        private static string GetSalonMaterial(List<string> salonTypes)
        {
            PrintVariants(salonTypes);
            int choice = ConsoleMenu.GetActionBetween(1, salonTypes.Count);
            if (choice == -1)
            {
                return string.Empty;
            }
            else
            {
                return salonTypes[choice - 1];
            }
        }

        private static string GetAirCondition(List<string> conditionTypes)
        {
            PrintVariants(conditionTypes);
            int choice = ConsoleMenu.GetActionBetween(1, conditionTypes.Count);
            if (choice == -1)
            {
                return string.Empty;
            }
            else
            {
                return conditionTypes[choice - 1];
            }
        }

        private static int GetPower()
        {
            int response;
            Console.Write("Input car's power: ");
            string inputData = Console.ReadLine();
            while (true)
            {
                if (inputData == "") return -1;
                else if (!int.TryParse(inputData, out response) || response < 0)
                {
                    Console.Write("Input right power: ");
                }
                else
                {
                    return response;
                }
            }
        }

        private static int GetVolume()
        {
            int response;
            Console.Write("Input car's volume: ");
            string inputData = Console.ReadLine();
            while (true)
            {
                if (inputData == "") return -1;
                else if (!int.TryParse(inputData, out response) || response < 0)
                {
                    Console.Write("Input right power: ");
                }
                else
                {
                    return response;
                }
            }
        }

        private static string GetTransmission(List<string> transmissionTypes)
        {
            PrintVariants(transmissionTypes);
            int choice = ConsoleMenu.GetActionBetween(1, transmissionTypes.Count);
            if (choice == -1)
            {
                return string.Empty;
            }
            else
            {
                return transmissionTypes[choice - 1];
            }
        }

        private static string GetCarcase(List<string> carcaseTypes)
        {
            PrintVariants(carcaseTypes);
            int choice = ConsoleMenu.GetActionBetween(1, carcaseTypes.Count);
            if (choice == -1)
            {
                return string.Empty;
            }
            else
            {
                return carcaseTypes[choice - 1];
            }
        }

        private static string GetModel(List<string> models)
        {
            PrintVariants(models);
            int choice = ConsoleMenu.GetActionBetween(1, models.Count);
            if (choice == -1)
            {
                return string.Empty;
            }
            else
            {
                return models[choice - 1];
            }
        }

        private static void PrintVariants(List<string> variants)
        {
            Console.WriteLine("Choose one (Or press enter to skip):");
            for (int i = 0; i < variants.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {variants[i]}");
            }
            Console.Write("Your choice: ");
        }
    }
}
