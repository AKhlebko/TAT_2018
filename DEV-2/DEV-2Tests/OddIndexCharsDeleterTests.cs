using System;
using Xunit;
using TaskDEV2;

namespace TaskDEV2Tests
{
    public class OddIndexCharsDeleterTests
    {
        [Fact]
        public void MakeEvenIndexStringBulder_input_qwqwqw_returned_qqq()
        {
            // arrange
            string inputString = "112233445!6!7!";
            string excpected = "1234567";
            OddIndexCharsDeleter evener = new OddIndexCharsDeleter(inputString);

            // act
            string actual = evener.MakeEvenIndexStringBulder().ToString();

            // assert
            Assert.Equal(excpected, actual);
        }

        [Fact]
        public void MakeEvenIndexStringBulder_EmptyStringInput_EmptyStringOutput()
        {
            // arrange
            string inputString = string.Empty;
            string excpected = string.Empty;
            OddIndexCharsDeleter evener = new OddIndexCharsDeleter(inputString);

            // act
            string actual = evener.MakeEvenIndexStringBulder().ToString();

            // assert
            Assert.Equal(excpected, actual);
        }
    }
}
