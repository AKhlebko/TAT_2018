using NUnit.Framework;
using System.Collections.Generic;
using Task4;

namespace Task4Tests
{
    [TestFixture]
    class SimplePeopleDataBaseTests
    {
        SimplePeopleDataBase dateBase = new SimplePeopleDataBase();

        [SetUp]
        public void SetUpDataBase()
        {
            List<Person> list = new List<Person>()
            {
                new Person("Anton", "Khlebko", 13),
                new Person("Vanya", "Petrov", 3),
                new Person("Sasha", "Molodec", 3),
            };

            dateBase = new SimplePeopleDataBase(list);
        }

        [Test]
        public void GetGeneralInfo_RightANswer()
        {
            string expected = $"Min Age = 3, Max Age = 13, Average Age = 6.333";

            string actual = dateBase.GetGeneralInfo();

            Assert.AreEqual(expected, actual);
        }
    }
}
