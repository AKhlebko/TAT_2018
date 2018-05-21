using NUnit.Framework;
using System;
using Task4;

namespace Task4Tests
{
    [TestFixture]
    class PersonTests
    {
        [TestCase("Anton", "Khlebko", 18)]
        [TestCase("Vanya", "Petrov", 19)]
        public void Constructor_ValidData_RightObjectsCreated(string name, string surName, int age)
        {
            string expected = $"{name} {surName} of {age} years old";

            string actual = (new Person(name, surName, age)).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Anton", "Khlebko??", 18)]
        [TestCase("Vanya", "Pet123rov", 19)]
        [TestCase("Anton123", "Khlebko", 18)]
        [TestCase("Vanya!!!", "Petrov", 19)]
        public void Constructor_InValidStringsFormat_ExceptionRaised(string name, string surName, int age)
        {
            Assert.Throws<FormatException>(() => new Person(name, surName, age));
        }
    }
}
