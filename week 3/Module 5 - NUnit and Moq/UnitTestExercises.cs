using System;
using NUnit.Framework;

namespace Training.Week3.Testing
{
    // class to be unit tested
    public class SimpleCalculator
    {
        public int Add(int x, int y) => x + y;
        
        public double Divide(int numerator, int denominator)
        {
            if (denominator == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return (double)numerator / denominator;
        }
    }

    // NUnit test fixture containing test cases
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calc;

        [SetUp]
        public void Init()
        {
            // run before every test method
            _calc = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            // run after every test completes
            _calc = null;
        }

        [Test]
        public void Add_GivenTwoNumbers_ReturnsCorrectSum()
        {
            int result = _calc.Add(5, 10);
            Assert.AreEqual(15, result, "The Add method failed to sum correctly.");
        }

        // parameterized testing
        [TestCase(10, 2, 5.0)]
        [TestCase(9, 3, 3.0)]
        [TestCase(5, 2, 2.5)]
        public void Divide_ParametrizedInputs_ReturnsExpectedQuotient(int num, int den, double expected)
        {
            double result = _calc.Divide(num, den);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Divide_DividingByZero_ThrowsException()
        {
            // verify method throws correct exception
            Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
        }
    }
}