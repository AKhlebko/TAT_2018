using NUnit.Framework;
using TaskDEV11;

namespace TaskDEV11Tests
{
    [TestFixture]
    class DaysFromBCTests
    {
        [Test]
        public void CountDaysFromBC_RightResult()
        {
            DaysFromBC daysFromBC = new DaysFromBC();
            int expected = 737192;
            string dateInStringFormat = "13/05/2018";

            int actual = daysFromBC.CountDaysFromBC(dateInStringFormat);
            Assert.AreEqual(expected, actual);
        }
    }
}
