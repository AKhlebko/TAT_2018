using NUnit.Framework;
using System.Collections.Generic;

namespace DEV_8
{
    [TestFixture]
    class PeopleDataBaseTests
    {
        PeopleDataBase testedBase = new PeopleDataBase();

        [OneTimeSetUp]
        public void PeopleDataBase_SetUp()
        {
            testedBase.People = new List<Person>(
                new Person[4]{
                    new Person("Anton", "Khlebko", Person.PossibleSex.MALE, 18),
                    new Person("Katya", "Pushkarova", Person.PossibleSex.FEMALE, 24),
                    new Person("Katya", "Andropova", Person.PossibleSex.FEMALE, 16),
                    new Person("Anna", "Pushkarova", Person.PossibleSex.FEMALE, 20),
            });
        }

        [Test]
        public void AddPerson_Test()
        {
            // Assign
            Person personToAdd = new Person("Andrei", "Valerievich", Person.PossibleSex.MALE, 45);
            List<Person> expected = new List<Person>();
            expected.AddRange(testedBase.People);
            expected.Add(personToAdd);

            // Act
            testedBase.AddPerson(personToAdd);

            // Assert
            Assert.AreEqual(expected, testedBase.People);
        }

        [Test]
        public void GetOldestPersons_Test()
        {
            // Assign
            List<Person> expected = new List<Person>();
            expected.Add(new Person("Andrei", "Valerievich", Person.PossibleSex.MALE, 45));

            // Act
            List<Person> actual = testedBase.GetOldestPersons();

            // Assert
            for (int i = 0; (i < expected.Count) && (i < actual.Count); i++)
            {
                Assert.AreEqual(expected[i].ToString(), actual[i].ToString());
            }
        }

        [Test]
        public void GetMostFrequentFemaleName_Test()
        {
            // Assign 
            string expected = "Katya";

            // Act
            string actual = testedBase.GetMostFrequentFemaleName();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(24, true)]
        [TestCase(90, false)]
        public void GetAverageAge_Test(int expected, bool assertResult)
        {
            // Act
            int actual = testedBase.GetAverageAge();

            // Assert
            if (assertResult)
            {
                Assert.AreEqual(expected, actual);
            }
            else
            {
               Assert.AreNotEqual(expected, actual);
            }
        }
    }
}
