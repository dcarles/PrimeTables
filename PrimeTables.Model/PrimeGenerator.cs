using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PrimeTables.Model
{
    public class PrimeGenerator
    {
        public IEnumerable<int> GenerateNPrimeNumbers(int n)
        {
            if (n < 1)
                throw new ArgumentException("N parameter must be greater than Zero");

            return GetNPrimeNumbers(n);
        }

        private static IEnumerable<int> GetNPrimeNumbers(int n)
        {
            //To make a list of the first n primes, we first need to approximate value of the *n*th prime
            var limit = ApproximateNthPrime(n);
            
            //We use a simple Sieve to find the prime numbers much faster
            var bits = SieveOfEratosthenes(limit);

            var primes = new List<int>();
            for (int i = 0, found = 0; i < limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add(i);
                    found++;
                }
            }
            return primes;
        }
        
        private static int ApproximateNthPrime(int nn)
        {
            var n = (double)nn;
            double p;
            if (nn >= 7022)
            {
                p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            }
            else if (nn >= 6)
            {
                p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            }
            else if (nn > 0)
            {
                p = new int[] { 2, 3, 5, 7, 11, 13 }[nn];
            }
            else
            {
                p = 0;
            }
            return (int)p;
        }

        // Find all primes up to and including the limit
        private static BitArray SieveOfEratosthenes(int limit)
        {
            var bits = new BitArray(limit + 1, true)
            {
                [0] = false,
                [1] = false
            };

            for (var i = 0; i * i <= limit; i++)
            {
                if (bits[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }
            return bits;
        }
      

        public int[,] GenerateMultiplicationTable(int n)
        {
           var firstNPrimeNumberMatrix = new int[n + 1, n +1];
            // Generate N prime numbers
            var primes = GenerateNPrimeNumbers(n);

            // Make a list including the element 1 so we can multiply easily
            var multiplicationNumbers = (new List<int> { 1 }.Union(primes)).ToList();
            
            for (var i = 0; i <= n; i++)
            {
                for (var j = 0; j <= n; j++)
                {
                    firstNPrimeNumberMatrix[i, j] = multiplicationNumbers[i] * multiplicationNumbers[j];
                }
            }

            return firstNPrimeNumberMatrix;
        }

    }
}