using System;

namespace DEV_8
{
    /// <summary>
    /// Class for storing info about each person
    /// </summary>
    [Serializable]
    public class Person
    {
        public enum PossibleSex
        {
            MALE,
            FEMALE
        }
        public PossibleSex Sex { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }

        public Person(string FName, string LName, PossibleSex Sex, int Age)
        {
            this.FName = FName;
            this.LName = LName;
            this.Sex = Sex;
            this.Age = Age;
        }

        public Person()
        {
            FName = "NULL";
            LName = "NULL";
            Sex = PossibleSex.MALE;
            Age = 0;
        }

        public override string ToString()
        {
            string sex = string.Empty;
            sex = (Sex == PossibleSex.MALE) ? "Male" : "Female";
            return $"Full name: {FName} {LName}, Sex: {sex}, Age: {Age}";
        }
    }   
}