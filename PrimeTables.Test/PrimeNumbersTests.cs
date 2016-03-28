using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PrimeTables.Model;

namespace PrimeTables.Test
{
    [TestFixture]
    public class PrimeNumbersTests
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
            TestDelegate primeNumbersDelegate = () => _primeNumberGenerator.GeneratePrimeNumbers(0);
            //Assert
            Assert.That(primeNumbersDelegate, Throws.ArgumentException);

        }

        [Test]
        public void GetNPrimeNumbers_Should_Return_List_With_Two_If_N_Is_One()
        {
            //Arrange
            var expected = new List<long> { 2 };
            var n = 1;

            //Act
            var actual = _primeNumberGenerator.GeneratePrimeNumbers(n).ToList();

            //Assert
            Assert.AreEqual(n, actual.Count());
            CollectionAssert.AreEqual(expected, actual);

        }

        [Test]
        public void GetNPrimeNumbers_Should_Return_List_With_Two_And_Three_If_N_Is_Two()
        {
            //Arrange
            var expected = new List<long> { 2, 3 };
            var n = 2;

            //Act
            var actual = _primeNumberGenerator.GeneratePrimeNumbers(n).ToList();

            //Assert
            Assert.AreEqual(n, actual.Count());
            CollectionAssert.AreEqual(expected, actual);

        }

        [Test]
        public void GetNPrimeNumbers_Should_Return_List_With_Two_And_Three_And_Five_If_N_Is_Three()
        {
            //Arrange
            var expected = new List<long> { 2, 3, 5 };
            var n = 3;

            //Act
            var actual = _primeNumberGenerator.GeneratePrimeNumbers(n).ToList();

            //Assert
            Assert.AreEqual(n, actual.Count());
            CollectionAssert.AreEqual(expected, actual);

        }


        [Test]
        public void GetNPrimeNumbers_Should_Return_Correct_Prime_Numbers_List_With_10_Elements_If_N_Is_Ten()
        {
            //Arrange
            var expected = new List<long> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            var n = 10;

            //Act
            var actual = _primeNumberGenerator.GeneratePrimeNumbers(n).ToList();

            //Assert
            Assert.AreEqual(n, actual.Count());
            CollectionAssert.AreEqual(expected, actual);

        }

    }

 
}
