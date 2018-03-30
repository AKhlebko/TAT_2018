using System;
using taskDEV3;
using NUnit.Framework;

namespace DEV3Tests
{
    [TestFixture]
    public class ConsoleDataFormatCheckerTests
    {   
        [TestCase("123", "16")]
        [TestCase("12342135423465", "12", "asdfasdbsdb")]
        public void CheckInputDataFormat_TwoAndMoreArgsRightFormat_TrueReturned(params string[] args)
        {
            ConsoleDataFormatChecker FormatChecker = new ConsoleDataFormatChecker(args);
            Assert.True(FormatChecker.CheckInputDataFormat());
        }

        [TestCase()]
        [TestCase("123")]
        [TestCase("123,1123")]
        public void CheckInputDataFormat_WrongArgsNumber_ArgumentExceptionAppeared(params string[] args)
        {
            ConsoleDataFormatChecker FormatChecker = new ConsoleDataFormatChecker(args);
            IndexOutOfRangeException ex = Assert.Throws<IndexOutOfRangeException>(() => FormatChecker.CheckInputDataFormat());
            Assert.That(ex.Message, Is.EqualTo("Wrong number of arguments."));
        }

        [TestCase("123.123", "14")]
        [TestCase("123", "12.12")]
        [TestCase("asd", "asd")]   
        public void CheckInputDataFormat_WrongDataFormat_FormatErrorAppeared(params string[] args)
        {
            ConsoleDataFormatChecker FormatChecker = new ConsoleDataFormatChecker(args);
            FormatException ex = Assert.Throws<FormatException>(() => FormatChecker.CheckInputDataFormat());
            Assert.That(ex.Source == "System.Numerics" || ex.Source == "mscorlib");
        }

        [TestCase("-123", "15")]
        [TestCase("123", "1")]
        [TestCase("123", "21")]
        [TestCase("-123", "21")]
        public void CheckInputDataFormat_InvalidNumbersRange_ArgumentOutOfRangeExceptionAppeared(params string[] args)
        {
            ConsoleDataFormatChecker FormatChecker = new ConsoleDataFormatChecker(args);
            Assert.Throws<ArgumentOutOfRangeException>(() => FormatChecker.CheckInputDataFormat())
        }
    }
}
