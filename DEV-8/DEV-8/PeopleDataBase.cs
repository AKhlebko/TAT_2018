using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_8
{
    public class PeopleDataBase
    {
        List<Person> people;
        public delegate void NamesakeInputHandler(object sender, NamesakeEventArg e);
        public event NamesakeInputHandler NamesakeDispatching;

        public PeopleDataBase(Person[] people)
        {
            this.people = new List<Person>(people);
        }

        public int GetAverageAge()
        {
            return (int)people.Average(t => t.Age);
        }

        public void AddPerson(Person person)
        {
            if (person != null)
            {
                if (people.Select(t => t.LName).ToList().Contains(person.LName))
                {
                    NamesakeEventArg eventArg = new NamesakeEventArg();
                    eventArg.Namesakes = GetNameSakes(person);
                    NamesakeDispatching(this, eventArg);
                }
                people.Add(person);
            }
            else throw new NullReferenceException(message: "PeopleDataBase.AddPerson: person can't be null;");
        }

        public List<Person> GetOldestPersons()
        {
            return people.Where(t => t.Age == (int)people.Max(v => v.Age)).ToList();
        }

        public List<Person> GetNameSakes(Person person)
        {
            try
            {
                return people.Where(x => x.LName == person.LName).ToList();
            }
            catch
            {
                throw;
            }
        }

        public string GetMostRelevantFemaleName()
        {
            List<Person> allFemales = people.Where(t => t.Sex == Person.PossibleSex.FEMALE).ToList();
            string mostRelevant = string.Empty;
            int relevance = 0;
            for (int i = 0; i < allFemales.Count; i++)
            {
                int bufferRelevance = 0;
                for (int j = 0; j < allFemales.Count; j++)
                {
                    if (allFemales[i].FName == allFemales[j].FName)
                    {
                        bufferRelevance++;
                    }
                }
                if (bufferRelevance > relevance)
                {
                    mostRelevant = allFemales[i].FName;
                    relevance = bufferRelevance;
                }
            }
            return mostRelevant;
        }
    }
}
