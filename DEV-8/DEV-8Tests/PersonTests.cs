using NUnit.Framework;
using DEV_8;

namespace DEV_8Tests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void ToStringTest()
        {
            // Assign
            Person testedPerson = new Person("Anton", "Khlebko", Person.PossibleSex.MALE, 18);
            string expected = "Full name: Anton Khlebko, Sex: Male, Age: 18";

            // Act
            string actual = testedPerson.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
