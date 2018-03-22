using System;
using System.Text.RegularExpressions;

namespace DEV_6
{
    /// <summary>
    /// Class provides user with an interface for interacting 
    /// with the storage through the text menu.
    /// </summary>
    class ConsoleMenu
    {
        private const string menuString = "Choose action:\n" +
            "1) Add items\n" +
            "2) count types\n" +
            "3) count all\n" +
            "4) average price (all types)\n" +
            "5) average price (choosen type)\n" +
            "6) Exit\n" +
            "Input action number: ";
        private IStorageCommands terminal;

        public void SetCommandTerminal(IStorageCommands terminal)
        {
            this.terminal = terminal;
        }

        /// <summary>
        /// Endless cycle for rendering text menu.
        /// </summary>
        public void Work()
        {
            while (true)
            {
                Console.Write(menuString);
                int actNum = GetActionNumer();
                switch (actNum)
                {
                    case 1:
                        string typeName = GetAddItemsType();
                        SaleItem items = GetItemsToAdd();
                        if (ConfirmAdding(typeName, items))
                        {
                            terminal.AddItems(typeName, items);
                            Console.WriteLine($"You've added {items} of {typeName}.");
                        }
                        else
                        {
                            Console.WriteLine($"Adding've been aborted.");
                        }
                        break;
                    case 2:
                        int typesNum = terminal.CountTypes();
                        Console.WriteLine($"Right now there are {typesNum} types of products in the storage.");
                        break;
                    case 3:
                        long itemsNum = terminal.CountAll();
                        Console.WriteLine($"Right now there are {itemsNum} in the storage.");
                        break;
                    case 4:
                        double averagePrice = terminal.AveragePrice();
                        Console.WriteLine($"Average items' price in the storage is {averagePrice}.");
                        break;
                    case 5:
                        Console.Write("Input type's name to calculate average price: ");
                        typeName = Console.ReadLine();
                        averagePrice = terminal.AveragePrice(typeName);
                        if (averagePrice != -1)
                        {
                            Console.WriteLine($"Average {typeName}'s price in the storage is {averagePrice}.");
                        }
                        else
                        {
                            Console.WriteLine($"There is no type {typeName} in the storage.");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Exiting terminal...");
                        return;
                }
            }
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
            int number = GetNumberToOfItemsToAdd();
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
                inputString = Console.ReadLine();
            }
            return response;
        }

        private int GetNumberToOfItemsToAdd()
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

        private int GetActionNumer()
        {
            int response = 0;
            string inputString = string.Empty;
            while (true)
            {
                if (int.TryParse((inputString = Console.ReadLine()), out response))
                {
                    if (response > 0 && response < 7)
                    {
                        return response;
                    }
                }
                Console.Write("Input right number of Action: ");
            }
        }

        private bool ConfirmAdding(string typeName, SaleItem products)
        {
            Console.Write($"Do you want to add {products} into {typeName} type [Yes/No]: ");
            string confirmation = Console.ReadLine().ToLower().Trim();
            if (confirmation == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
