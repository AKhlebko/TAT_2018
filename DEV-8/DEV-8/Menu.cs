using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_8
{
    class Menu
    {
        public GetOldestPersonsCommand OldestPersonsGetter { get; set; }
        public AddAnotherPersonToDataBaseCommand AddPersonToDataBase { get; set; }
        public GetAverageAgeCommand AverageAgeGetter { get; set; }
        public GetMostRelevantFemaleNameCommand MostRelevantFemaleNameGetter { get; set; }

        public void Run()
        {
            ICommand commandToExecute;
            if (OldestPersonsGetter == null ||
                AddPersonToDataBase == null ||
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
                        string firstName = GetFirstName();
                        string lastName = GetLastName();
                        Person.PossibleSex sex = GetSex();
                        int age = GetAge();
                        AddPersonToDataBase.PersonToAdd = new Person(firstName, lastName, sex, age);
                        commandToExecute = AddPersonToDataBase;
                        commandToExecute.Execute();
                        break;
                    case 2:
                        commandToExecute = AverageAgeGetter;
                        commandToExecute.Execute();
                        Console.WriteLine($"Average peoples' age in the database is {(commandToExecute as GetAverageAgeCommand).AverageAge}");
                        break;
                    case 3:
                        commandToExecute = OldestPersonsGetter;
                        commandToExecute.Execute();
                        Console.WriteLine("The oldest persons in the database are: ");
                        int i = 0;
                        foreach (Person person in (commandToExecute as GetOldestPersonsCommand).OldestPeople)
                        {
                            Console.WriteLine($"{++i}) {person}");
                        }
                        break;
                    case 4:
                        commandToExecute = MostRelevantFemaleNameGetter;
                        commandToExecute.Execute();
                        Console.WriteLine($"Most relevant female name is {(commandToExecute as GetMostRelevantFemaleNameCommand).MostRelevanceName}");
                        break;
                }
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

        private string GetFirstName()
        {
            Console.Write("Input first name please: ");
            string response = string.Empty;
            while ((response = Console.ReadLine()) == string.Empty)
            {
                Console.Write("First name can't be empty: ");
            }
            return response;
        }

        private string GetLastName()
        {
            Console.Write("Input last name please: ");
            string response = string.Empty;
            while ((response = Console.ReadLine()) == string.Empty)
            {
                Console.Write("Last name can't be empty: ");
            }
            return response;
        }

        private Person.PossibleSex GetSex()
        {
            Console.WriteLine("Input sex please.");
            Console.Write($"1) FEMALE\n2) MALE\nChoose one:");
            int response = 0;
            while (!int.TryParse(Console.ReadLine(), out response) && (response < 1 || response > 2))
            {
                Console.Write("No such option in the list. Try again: ");
            }
            return (response == 1) ? Person.PossibleSex.FEMALE : Person.PossibleSex.MALE;
        }

        private int GetAge()
        {
            Console.Write("Input age please: ");
            int response = 0;
            while (!int.TryParse(Console.ReadLine(), out response) || (response < 1))
            {
                Console.Write("Age can't be negative. Try again: ");
            }
            return response;
        }
    }
}
