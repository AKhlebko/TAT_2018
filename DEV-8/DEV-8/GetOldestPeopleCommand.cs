using System;
using System.Collections.Generic;

namespace DEV_8
{
    /// <summary>
    /// Command for getting the list of the oldest people in the database
    /// </summary>
    class GetOldestPeopleCommand: ICommand 
    {
        public PeopleDataBase DataBase { get; set; }
        public List<Person> OldestPeople { get; set; }

        public void Execute()
        {
            try
            {
                Console.WriteLine("The oldest persons in the database are: ");
                int i = 0;
                foreach (Person person in DataBase.GetOldestPersons())
                {
                    Console.WriteLine($"{++i}) {person}");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
