using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeTables.Model
{
    public class PrimeGenerator
    {
        public List<long> GenerateNPrimeNumbers(long n)
        {
            if (n < 1)
                throw new ArgumentException("N parameter must be greater than Zero");

            return GetNPrimeNumbers(n);
        }

        private static List<long> GetNPrimeNumbers(long n)
        {
            //Create list with first prime in it
            var primes = new List<long> { 2 };

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

        public long[,] GenerateMultiplicationTable(long n)
        {
           var firstNPrimeNumberMatrix = new long[n + 1, n +1];
            // Generate N prime numbers
            var primes = GenerateNPrimeNumbers(n).ToList();

            // Make an index set, including the element 1 so we can multiply through
            var indexSet = (new List<long> { 1 }.Union(primes)).ToList();


            // We don't want 1 to feature by double multiplication, so we bypass this here
            for (var i = 0; i <= n; i++)
            {
                for (var j = 0; j <= n; j++)
                {

                    firstNPrimeNumberMatrix[i, j] = indexSet[i] * indexSet[j];
                }
            }

            firstNPrimeNumberMatrix[0, 0] = 0;

            return firstNPrimeNumberMatrix;
        }

    }
}