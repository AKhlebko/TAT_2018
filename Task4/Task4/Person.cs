using System;
using System.Text.RegularExpressions;

namespace Task4
{
    /// <summary>
    /// Class stores info about person
    /// </summary>
    public class Person
    {
        public string Name { get; private set; }
        public string SurName { get; private set; }
        public int Age { get; private set; }

        public Person(string name, string surName, int age)
        {
            string invalidStringPattern = @"[!?@#$%^&*()_123456789]+";
            if (Regex.IsMatch(name, invalidStringPattern) || Regex.IsMatch(surName, invalidStringPattern))
            {
                throw new FormatException("Invalid name or surname format");
            }
            this.Name = name;
            this.SurName = surName;
            if (age <= 0)
            {
                throw new ArgumentOutOfRangeException("Age can't be zero or negative.");
            }
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{Name} {SurName} of {Age} years old";
        }
    }
}