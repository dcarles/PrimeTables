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
        public void GenerateMultiplicationTable_Should_Return_Matrix_NPlusOne_Dimension_And_Correct_Multiplication()
        {
            //Arrange
            var n = 1;

            //Act
            var actual = _primeNumberGenerator.GenerateMultiplicationTable(n);

            //Assert
            Assert.AreEqual(n + 1, actual.GetLength(1));
            Assert.AreEqual(n + 1, actual.GetLength(0));
            Assert.AreEqual(actual[0,1], 2);
            Assert.AreEqual(actual[1, 0], 2);
            Assert.AreEqual(actual[1, 1], 4);

        }

        [Test]
        public void GenerateMultiplicationTable_Should_Return_Matrix_NPlusOne_Dimension_And_Correct_Multiplication2()
        {
            //Arrange
            var n = 2;

            //Act
            var actual = _primeNumberGenerator.GenerateMultiplicationTable(n);

            //Assert
            Assert.AreEqual(n + 1, actual.GetLength(1));
            Assert.AreEqual(n + 1, actual.GetLength(0));
            Assert.AreEqual(actual[0, 1], 2);
            Assert.AreEqual(actual[1, 0], 2);
            Assert.AreEqual(actual[1, 1], 4);
            Assert.AreEqual(actual[1, 2], 6);

            Assert.AreEqual(actual[0, 2], 3);
            Assert.AreEqual(actual[2, 0], 3);
            Assert.AreEqual(actual[2, 1], 6);
            Assert.AreEqual(actual[2, 2], 9);

        }
    }
}
