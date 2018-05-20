using System;

namespace DEV_6
{
    /// <summary>
    /// Class provides user with an UI for interacting 
    /// with the storage through the text menu.
    /// </summary>
    class ConsoleMenu
    {
        private int numberOfAvailabeCommands = 6;
        private const string menuString = "Choose action:\n" +
            "1) Add items\n" +
            "2) count types\n" +
            "3) count all\n" +
            "4) average price (all types)\n" +
            "5) average price (choosen type)\n" +
            "6) Exit\n" +
            "Input action number: ";
        private Terminal terminal;
        private AveragePriceCounter averagePriceCounter;
        private AveragePriceInTypeCounter averageTypePriceCounter;
        private TypeCounter typesCounter;
        private ItemsCounter itemsCounter;
        private ItemsAdder itemsAdder;

        public ConsoleMenu(Storage storage)
        {
            terminal = new Terminal();
            averageTypePriceCounter = new AveragePriceInTypeCounter(storage);
            averagePriceCounter = new AveragePriceCounter(storage);
            typesCounter = new TypeCounter(storage);
            itemsCounter = new ItemsCounter(storage);
            itemsAdder = new ItemsAdder(storage);
        }

        /// <summary>
        /// Endless cycle for rendering text menu
        /// switching between commanders and executing commands
        /// </summary>
        public void Execute()
        {
            while (true)
            {
                Console.Write(menuString);
                int actNum = GetActionNumer();
                switch (actNum)
                {
                    case 1:
                        terminal.setCommand(itemsAdder);
                        break;
                    case 2:
                        terminal.setCommand(typesCounter);
                        break;
                    case 3:
                        terminal.setCommand(itemsCounter);
                        break;
                    case 4:
                        terminal.setCommand(averagePriceCounter);
                        break;
                    case 5:
                        terminal.setCommand(averageTypePriceCounter);
                        break;
                    case 6:
                        Console.WriteLine("Exiting terminal...");
                        return;
                }
                terminal.DoCommand();
            }
        }

        private int GetActionNumer()
        {
            int response = 0;
            string inputString = string.Empty;
            while (true)
            {
                if (int.TryParse((inputString = Console.ReadLine()), out response))
                {
                    if (response > 0 && response <= numberOfAvailabeCommands)
                    {
                        return response;
                    }
                }
                Console.Write("Input right number of Action: ");
            }
        }
    }
}
