using TaskDEV11;
using NUnit.Framework;
using System;

namespace TaskDEV11Tests
{
    [TestFixture]
    class DateTests
    {
        [Test]
        public void Date_Constructor_RightInstanceCreated()
        {
            string date = "01/11/1";

            int dayExpected = 1;
            int monthExpected = 11;
            int yearExpected = 1;

            Date dateInstance = new Date(date);
            Assert.AreEqual(dayExpected, dateInstance.Day);
            Assert.AreEqual(monthExpected, dateInstance.Month);
            Assert.AreEqual(yearExpected, dateInstance.Year);
        }

        [TestCase("13/05", "Date was input in a wrong way")]
        [TestCase("/05/2018", "Date format is invalid.")]
        [TestCase("13//2018", "Date format is invalid.")]
        [TestCase("13/05/asdsa", "Date format is invalid.")]
        [TestCase("13/asdf/2018", "Date format is invalid.")]
        [TestCase("sdaf/05/2018", "Date format is invalid.")]
        public void Date_Constructor_WrongDataFormat_FormatException(string dateInStringFormat, string ExpectedExceptionMessage)
        {
            FormatException ex = Assert.Throws<FormatException>(() =>
                new Date(dateInStringFormat)
                );
            Assert.AreEqual(ExpectedExceptionMessage, ex.Message);
        }

        [TestCase(32)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Day_DaySetter_NotRightArguments_ExceptionRaised(int day)
        {
            Date date = new Date("1/1/1");
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                date.Day = day
                );
            Assert.AreEqual(ex.ParamName, "The number of days for this month is incorrect");
        }

        [TestCase(13)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Day_MonthSetter_NotRightArguments_ExceptionRaised(int month)
        {
            Date date = new Date("1/1/1");
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                date.Month = month
                );
            Assert.AreEqual(ex.ParamName, "Month can only be between 1 and 12.");
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void Day_YearSetter_NotRightArguments_ExceptionRaised(int year)
        {
            Date date = new Date("1/1/1");
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                date.Year = year
                );
            Assert.AreEqual(ex.ParamName, "Year can't be smaller than 1.");
        }
    }
}
