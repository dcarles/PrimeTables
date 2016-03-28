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
        public void GetNPrimeNumbers_Should_Return_List_With_2_If_N_Is_One()
        {
            //Arrange
            var expected = new List<int> { 2 };
            var n = 1;

            //Act
            var actual = PrimeGenerator.GetNPrimeNumbers(n).ToList();

            //Assert
            Assert.AreEqual(n,actual.Count());
            CollectionAssert.AreEqual(expected, actual);

        }

    }

    public class PrimeGenerator
    {
        public static IEnumerable<int> GetNPrimeNumbers(int i)
        {
            yield return 2;
        }
    }
}
