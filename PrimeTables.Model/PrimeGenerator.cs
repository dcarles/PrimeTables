using System;
using System.Collections.Generic;

namespace PrimeTables.Model
{
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

    }
}