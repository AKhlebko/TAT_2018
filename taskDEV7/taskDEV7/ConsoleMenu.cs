using System;
using System.Collections.Generic;

namespace DEV_7
{
    class ConsoleMenu
    {
        private CarBuilder builder;
        private string menuString = "Input car's parameters and we'll try to find smth for you.";
        ICatalogCommand<List<Car>> getSimilarCarsCommand;
        IStorageCommand<bool> checkIsCarInStorageCommand;
        IStorageCommand<bool>  deleteCarInStorageCommand;
        IStorageCommand<bool> storageCarProduceCommand;
        IStorageCommand<bool> storageSaveCommand;
        IStorageCommand<bool> storageReloader;

        public ICatalogCommand<List<Car>> GetSimilarCarsCommand { get => getSimilarCarsCommand; set => getSimilarCarsCommand = value; }
        public IStorageCommand<bool> CheckIsCarInStorageCommand { get => checkIsCarInStorageCommand; set => checkIsCarInStorageCommand = value; }
        public IStorageCommand<bool> DeleteCarInStorageCommand { get => deleteCarInStorageCommand; set => deleteCarInStorageCommand = value; }
        public IStorageCommand<bool> StorageCarProduceCommand { get => storageCarProduceCommand; set => storageCarProduceCommand = value; }
        public IStorageCommand<bool> StorageSaveCommand { get => storageSaveCommand; set => storageSaveCommand = value; }
        public IStorageCommand<bool> StorageReloader { get => storageReloader; set => storageReloader = value; }

        public void Work()
        {
            while (true)
            {
                Console.Write(menuString);
                string brandName = GetUserBrandName();
                builder = GetBuilder(brandName);
                Car userChoiceCar = builder.Create();
                userChoiceCar.FillParametersByUser();
                (getSimilarCarsCommand as SimilarCarsToBuyGetter).setUserChoice(userChoiceCar);
                List<Car> suitableCars = getSimilarCarsCommand.execute();
                PrintAvailableCars(suitableCars);
                int ChosenCarNumber = GetActionBetween(1, suitableCars.Count);
                if (ChosenCarNumber != -1)
                {
                    (CheckIsCarInStorageCommand as CarInStorageChecker).SetCarToFind(suitableCars[ChosenCarNumber - 1]);
                    if (CheckIsCarInStorageCommand.Execute())
                    {
                        (deleteCarInStorageCommand as CarFromStorageDeleter).SetCarToDelete(suitableCars[ChosenCarNumber - 1]);
                        deleteCarInStorageCommand.Execute();
                        storageSaveCommand.Execute();
                        Console.WriteLine("Deal, your car will be right here in 15 minutes.");
                    }
                    else
                    {
                        (storageCarProduceCommand as StorageCarProducer).SetCarToProduce(suitableCars[ChosenCarNumber - 1]);
                        storageCarProduceCommand.Execute();
                        Console.WriteLine("Your car will be produced.");
                        storageSaveCommand.Execute();
                        storageReloader.Execute();
                    }
                }
                else
                {
                    Console.WriteLine("Okay, thx for coming!");
                    break;
                }
            }
        }

        private CarBuilder GetBuilder(string brandName)
        {
            if (brandName == "Mercedes")
            {
                return new MercedesBuilder();
            }
            else if (brandName == "Volvo")
            {
                return new VolvoBuilder();
            }
            else
            {
                return new LadaBuilder();
            }
        }

        /// <summary>
        /// Gets number in input range
        /// </summary>
        /// <param name="first">
        /// minimum number
        /// </param>
        /// <param name="last">
        /// maximum number
        /// </param>
        /// <returns>
        /// number or -1 if you pressed enter
        /// </returns>
        public static int GetActionBetween(int first, int last)
        {
            int response = 0;
            string userChoice = string.Empty;
            while (true)
            {
                userChoice = Console.ReadLine();
                if (userChoice == string.Empty)
                {
                    return -1;
                }
                else if (!int.TryParse(userChoice, out response) || (response < first || response > last))
                {
                    Console.WriteLine("Input right number! ");
                }
                else
                {
                    return response;
                }
            }
        }

        private void PrintAvailableCars(List<Car> variants)
        {
            if (variants.Count == 0)
            {
                Console.Write("There is no such cars in catalog.");
            }
            Console.WriteLine("We've got something for you: ");
            for (int i = 0; i < variants.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {variants[i]}");
            }
            Console.Write("Your choice: ");
        }

        private string GetUserBrandName()
        {
            List<string> brandsList = new List<string>(new string[] { "Mercedes", "Lada", "Volvo" });
            Console.Write("Input brand name's number:\n");
            int bufferVar = 1;
            foreach (string name in brandsList)
            {
                Console.WriteLine($"{bufferVar}) {name}");
                bufferVar++;
            }
            Console.Write("Your choice: ");
            bufferVar = GetActionBetween(1, brandsList.Count);
            while (bufferVar == -1)
            {
                Console.Write("You must choose type :");
                bufferVar = GetActionBetween(1, brandsList.Count);
            }
            return brandsList[bufferVar - 1];
        }
    }
}
