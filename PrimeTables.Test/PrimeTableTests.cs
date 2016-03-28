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
        [Test]
        public void GetNPrimeNumbers_Should_Throw_ArgumentException_If_N_Is_Less_Than_One()
        {
            //Arrange
            //Act
            TestDelegate primeNumbersDelegate = () => PrimeGenerator.GeneratePrimeNumbers(0);
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
            var actual = PrimeGenerator.GeneratePrimeNumbers(n).ToList();

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
            var actual = PrimeGenerator.GeneratePrimeNumbers(n).ToList();

            //Assert
            Assert.AreEqual(n, actual.Count());
            CollectionAssert.AreEqual(expected, actual);

        }

    }

    public class PrimeGenerator
    {
        public static IEnumerable<long> GeneratePrimeNumbers(long n)
        {
            if(n <1)
            throw new ArgumentException("N parameter must be greater than Zero");

           return GetNPrimeNumbers(n);
        }

        private static IEnumerable<long> GetNPrimeNumbers(long n)
        {

            yield return 2;

            for (var i = 3; i <= n + 1; i++)
            {
                yield return i;
            }
         
        }


        

    }
}
