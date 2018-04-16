using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_8
{
    /// <summary>
    /// Class for stroring information about people
    /// </summary>
    public class PeopleDataBase
    {
        public List<Person> People { get; set; }
        public delegate void NamesakeInputHandler(object sender, NamesakeEventArg e);
        public event NamesakeInputHandler NamesakeDispatching;

        public PeopleDataBase(Person[] people)
        {
            this.People = new List<Person>(people);
        }

        public PeopleDataBase()
        {
            this.People = new List<Person>();
        }

        /// <summary>
        /// Method returns average age in the database
        /// </summary>
        /// <returns>
        /// Average age in the database
        /// </returns>
        public int GetAverageAge()
        {
            return (int)People.Average(t => t.Age);
        }
        
        /// <summary>
        /// Adds another person to the database
        /// </summary>
        /// <param name="person">
        /// Person to add
        /// </param>
        public void AddPerson(Person person)
        {
            if (person != null)
            {
                if (People.Select(t => t.LName).ToList().Contains(person.LName))
                {
                    NamesakeEventArg eventArg = new NamesakeEventArg();
                    eventArg.Namesakes = GetNamesakes(person);
                    NamesakeDispatching(this, eventArg);
                }
                People.Add(person);
            }
            else throw new NullReferenceException(message: "PeopleDataBase.AddPerson: person can't be null;");
        }

        /// <summary>
        /// Returns list of oldest people in the database
        /// </summary>
        /// <returns>
        /// List of oldest people in the database
        /// </returns>
        public List<Person> GetOldestPersons()
        {
            return People.Where(t => t.Age == (int)People.Max(v => v.Age)).ToList();
        }

        /// <summary>
        /// Returns list of namesakes for this person
        /// </summary>
        /// <param name="person">
        /// Person to find namesakes
        /// </param>
        /// <returns>
        /// List of namesakes for input person
        /// </returns>
        public List<Person> GetNamesakes(Person person)
        {
            try
            {
                return People.Where(x => x.LName == person.LName).ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Method returns the most frequent female name
        /// </summary>
        /// <returns>
        /// Returns the most frequent female name
        /// </returns>
        public string GetMostFrequentFemaleName()
        {
            List<Person> allFemales = People.Where(t => t.Sex == Person.PossibleSex.FEMALE).ToList();
            string mostFrequent = string.Empty;
            int relevance = 0;
            for (int i = 0; i < allFemales.Count; i++)
            {
                int bufferFrequency = 0;
                for (int j = 0; j < allFemales.Count; j++)
                {
                    if (allFemales[i].FName == allFemales[j].FName)
                    {
                        bufferFrequency++;
                    }
                }
                if (bufferFrequency > relevance)
                {
                    mostFrequent = allFemales[i].FName;
                    relevance = bufferFrequency;
                }
            }
            return mostFrequent;
        }
    }
}
