using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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

    public class PrimeGenerator
    {
        public List<long> GeneratePrimeNumbers(long n)
        {
            if (n < 1)
                throw new ArgumentException("N parameter must be greater than Zero");

            return GetNPrimeNumbers(n);
        }

        private static List<long> GetNPrimeNumbers(long n)
        {
            //Create list with first prime in it
            var primes = new List<long> {2};
           
            var candidate = 3;
            while (primes.Count < n)
            {

                if (IsPrime(candidate))
                {
                    primes.Add(candidate);
                }

                candidate += 2;
            }

            return primes;
        }


        private static bool IsPrime(int number)
        {
            //We get the limiting int by square rooting number 
            var max = Convert.ToInt32(Math.Sqrt(number));

            if (number == 1 || number % 2 == 0)
                return false;

            if (number == 2)
                return true;

            for (int i = 2; i <= max; i++)
            {
                if ((number % i) == 0)
                    return false;
            }

            return true;
        }




    }
}
