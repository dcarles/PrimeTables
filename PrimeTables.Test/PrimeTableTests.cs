using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PrimeTables.Model;

namespace PrimeTables.Test
{
    [TestFixture]
    public class PrimeTableTests
    {
        private PrimeGenerator _primeNumberGenerator;

        [OneTimeSetUp]
        public void TestInitialise()
        {
            _primeNumberGenerator = new PrimeGenerator();
        }

        [Test]
        public void GetNPrimeNumbers_Should_Throw_ArgumentException_If_N_Is_Less_Than_One()
        {
            //Arrange
            //Act
            TestDelegate primeNumbersDelegate = () => _primeNumberGenerator.GenerateMultiplicationTable(0);
            //Assert
            Assert.That(primeNumbersDelegate, Throws.ArgumentException);

        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(10)]
        public void GenerateMultiplicationTable_Should_Return_Matrix_NPlusOne_Dimension_And_Correct_Multiplication(long n)
        {
           
            //Act
            var actual = _primeNumberGenerator.GenerateMultiplicationTable(n);
            var primes = _primeNumberGenerator.GenerateNPrimeNumbers(n).ToList();

            //Assert that Length of row and column should be n + 1
            Assert.AreEqual(n + 1, actual.GetLength(1));
            Assert.AreEqual(n + 1, actual.GetLength(0));


            //Assert that cells that are not in first row and first column should be multiplication product
            for (var i = 1; i < actual.GetLength(0); i++)
            {
                for (var j = 1; j < actual.GetLength(1); j++)
                {
                    Assert.AreEqual(actual[i, j], actual[0, j] * actual[0, i]);
                }
            }

            //Assert that cells in first column and first row should be the prime numbers in order until N prime number
            for (var i = 1; i < actual.GetLength(0); i++)
            {
                Assert.AreEqual(actual[0, i], primes[i - 1]);
                Assert.AreEqual(actual[i, 0], primes[i - 1]);
            }

        }
    }
}
