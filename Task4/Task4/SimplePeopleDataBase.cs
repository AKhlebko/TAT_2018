using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    /// <summary>
    /// Class storing people and interacting with them
    /// </summary>
    public class SimplePeopleDataBase
    {
        public List<Person> peopleList { get; private set; }

        public SimplePeopleDataBase()
        {
            peopleList = new List<Person>();
        }

        public SimplePeopleDataBase(List<Person> list)
        {
            peopleList = list;
        }

        /// <summary>
        /// Lets user input people until he inputs "end"
        /// </summary>
        public void InputPeople()
        {
            try
            {
                Console.WriteLine("Input people in Name SurName Age format, to stop input,{as} input \"end\"");
                string request = string.Empty;
                while ("end" != (request = Console.ReadLine()))
                {
                    string[] args = request.Split(' ');
                    peopleList.Add(new Person(
                        name: args[0],
                        surName: args[1],
                        age: int.Parse(args[2]))
                        );
                }
            }
            catch (Exception ex)
            {   
                throw;
            }
        }

        /// <summary>
        /// Print all people to console
        /// </summary>
        public void PrintPeople()
        {
            foreach (Person man in peopleList)
            {
                Console.WriteLine(man);
            }
        }

        /// <summary>
        /// Returns info about age in dataBase
        /// </summary>
        /// <returns>
        /// Returns info about age in dataBase
        /// </returns>
        public string GetGeneralInfo()
        {
            int minAge = peopleList.Min(t => t.Age);
            int maxAge = peopleList.Max(t => t.Age);
            double averageAge = peopleList.Average(t => t.Age);
            return $"Min Age = {minAge}, Max Age = {maxAge}, Average Age = {averageAge:#.###}";
        }
    }
}