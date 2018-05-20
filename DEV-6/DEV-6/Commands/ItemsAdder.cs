using System;
using System.Text.RegularExpressions;

namespace DEV_6
{
    /// <summary>
    /// Class implements command interface and
    /// adds new items to the storage using execute method
    /// </summary>
    class ItemsAdder : ICommand
    {
        private Storage storage;

        public ItemsAdder(Storage storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// Method for command execution
        /// interacts with user and adds new items to the storage
        /// </summary>
        public void Execute()
        {
            string typeName = GetAddItemsType();
            SaleItem items = GetItemsToAdd();
            string confirmation = GetConfirmation(typeName, items);
            if (confirmation == "yes")
            {
                storage.AddItems(typeName, items);
                Console.WriteLine($"You've added {items} of {typeName}.");
            }
            else
            {
                Console.WriteLine($"Adding've been aborted.");
            }
        }

        private string GetConfirmation(string typeName, SaleItem products)
        {
            Console.Write($"Do you want to add {products} into {typeName} type [Yes/No]: ");
            return Console.ReadLine().ToLower().Trim();
        }

        private string GetAddItemsType()
        {
            Console.Write($"Input type name, please: ");
            string inputString = string.Empty;
            while (Regex.IsMatch((inputString = Console.ReadLine()), @"[\\/:*?<>|]+"))
            {
                Console.Write($"Input right format type name, please: ");
            }
            return inputString;
        }

        private SaleItem GetItemsToAdd()
        {
            string name = GetItemName();
            int number = GetNumberOfItemsToAdd();
            float price = GetAddItemPrice();
            return new SaleItem(name, number, price);
        }

        private string GetItemName()
        {
            Console.Write($"Input product name, please: ");
            string inputString = string.Empty;
            while (Regex.IsMatch((inputString = Console.ReadLine()), @"[\\/:*?<>|]+"))
            {
                Console.Write($"Input right format product name, please: ");
            }
            return inputString;
        }

        private float GetAddItemPrice()
        {
            float response = 0;
            string inputString = string.Empty;
            Console.Write("Input item's price: ");
            while (!float.TryParse((inputString = Console.ReadLine()), out response) || (response <= 0))
            {
                Console.Write("Input right format price: ");
            }
            return response;
        }

        private int GetNumberOfItemsToAdd()
        {
            int response = 0;
            Console.Write("Input number of items: ");
            string inputString = Console.ReadLine();
            while (!int.TryParse((inputString), out response) || (response <= 0))
            {
                Console.Write("Input right number of items: ");
                inputString = Console.ReadLine();
            }
            return response;
        }
    }
}
