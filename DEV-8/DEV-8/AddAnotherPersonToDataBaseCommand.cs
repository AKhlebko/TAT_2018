using System;

namespace DEV_8
{
    /// <summary>
    /// Command for adding people to the database
    /// </summary>
    class AddAnotherPersonToDataBaseCommand : ICommand
    {
        public PeopleDataBase DataBase { get; set; }

        public void Execute()
        {
            try
            {
                string firstName = GetFirstName();
                string lastName = GetLastName();
                Person.PossibleSex sex = GetSex();
                int age = GetAge();
                DataBase.AddPerson(new Person(firstName, lastName, sex, age));
            }
            catch
            {
                throw;
            }
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
            Console.Write($"1) FEMALE\n2) MALE\nChoose one: ");
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
