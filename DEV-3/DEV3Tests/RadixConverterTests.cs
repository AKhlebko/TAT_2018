using NUnit.Framework;
using System;
using System.Numerics;
using taskDEV3;

namespace DEV3Tests
{
    [TestFixture]
    class RadixConverterTests
    {
        [Test]
        public void GetNewRadixNumber_BigInteger_returnExcpected()
        {
            // arrange
            int newRadix = 16;
            BigInteger decimalNumber = new BigInteger(ulong.MaxValue);
            decimalNumber += 2; // 18446744073709551617 bigger than ulong
            string excpected = "10000000000000001";
            RadixConverter converter = new RadixConverter(decimalNumber, newRadix);

            // act
            string actual = converter.GetNewRadixNumber().ToString();

            // assert
            Assert.AreEqual(excpected, actual);
        }

        [TestCase(123, 2, "1111011")]
        [TestCase(123, 16, "7B")]
        public void GetNewRadixNumber_WithRadixFromDifferentEquivalentClasses(long num, int newRadix, string excpected)
        {
            // arrange
            BigInteger decimalInteger = new BigInteger(num);
            RadixConverter converter = new RadixConverter(decimalInteger, newRadix);

            // act
            string actual = converter.GetNewRadixNumber().ToString();

            // assert
            Assert.AreEqual(excpected, actual);
        }

        [TestCase(123, 21)]
        [TestCase(-123, 12)]
        [TestCase(-123, 1)]
        public void GetNewRadixNumber_InvalidNumbersRange_ArgumentOutOfRangeThrown(int num, int radix)
        {
            // arrange
            BigInteger decimalNumber = new BigInteger(num);
            RadixConverter converter = new RadixConverter(decimalNumber, radix);

            // assert 
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => converter.GetNewRadixNumber());
            Assert.That(ex.ParamName == "Invalid radix range" || ex.ParamName == "Invalid decimal range");
        }
    }
}
