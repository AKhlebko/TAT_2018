using System;
using NUnit.Framework;
using Task2;

namespace Task2Tests
{
    [TestFixture]
    public class AreaCalculatorTests
    {
        [TestCase(-1, 10)]
        [TestCase(10, -1)]
        [TestCase(0, 10)]
        [TestCase(10, 0)]
        public void Constructor_NegativeSides_Exception(double a, double b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new AreaCalculator(a, b));
        }
    }
}
