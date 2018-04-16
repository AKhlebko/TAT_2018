using System;

namespace DEV_8
{
    /// <summary>
    /// Class for interacting with user through the console 
    /// </summary>
    class Menu
    {
        public GetOldestPeopleCommand OldestPersonsGetter { get; set; }
        public AddAnotherPersonToDataBaseCommand PeopleToDataBaseAdder { get; set; }
        public GetAverageAgeCommand AverageAgeGetter { get; set; }
        public GetMostFrequentFemaleNameCommand MostRelevantFemaleNameGetter { get; set; }

        /// <summary>
        /// Method in which all the interactive part takes place
        /// </summary>
        public void Run()
        {
            Terminal commandTerminal = new Terminal();
            if (OldestPersonsGetter == null ||
                PeopleToDataBaseAdder == null ||
                AverageAgeGetter == null ||
                MostRelevantFemaleNameGetter == null)
            {
                Console.WriteLine("Something went wrong. Can't start the app. Shutting down...");
                return;
            }
            while (true)
            {
                switch(GetAction(1, 4))
                {
                    case 1:
                        commandTerminal.commandToExecute = PeopleToDataBaseAdder;
                        break;
                    case 2:
                        commandTerminal.commandToExecute = AverageAgeGetter;
                        break;
                    case 3:
                        commandTerminal.commandToExecute = OldestPersonsGetter;
                        break;
                    case 4:
                        commandTerminal.commandToExecute = MostRelevantFemaleNameGetter;
                        break;
                }
                commandTerminal.Execute();
            }
        }

        private int GetAction(int v1, int v2)
        {
            Console.Write("Choose action:\n" +
                "1) Add person\n" +
                "2) See average age\n" +
                "3) See the oldest persons\n" +
                "4) See the most popular female name\n" +
                "Your choice: ");
            int response = 0;
            while (!int.TryParse(Console.ReadLine(), out response) || (response < v1 || response > v2))
            {
                Console.Write("No such options in the list. Try again: ");
            }
            return response;
        }
    }
}
