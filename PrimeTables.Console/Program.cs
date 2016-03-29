using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeTables.Model;

namespace PrimeTables.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = GetPrimeNumbersQuantityInput();

            if (n < 15)
            {
                var consoleRenderer = new PrimeTableConsoleRenderer();
                DisplayTable(n, consoleRenderer);
            }
            else
            {
                var fileRenderer = new PrimeTableCsvFileRenderer();
                DisplayTable(n, fileRenderer);
                Console.WriteLine("");
                Console.WriteLine($"A CSV file with the Prime multiplication table was generated in {AppDomain.CurrentDomain.BaseDirectory}\\primeTable.csv");
            }

            Console.ReadLine();
        }

        private static int GetPrimeNumbersQuantityInput()
        {
            Console.WriteLine("How many prime numbers do you want to generate?");
            Console.Write("Please input a number greater than 1: ");
            var input = Console.ReadLine();
            int n;
            while (!int.TryParse(input, out n) || n < 1)
            {
                Console.Write("Invalid number. Please input a number greater than 1: ");
                input = Console.ReadLine();
            }
            return n;
        }

        private static void DisplayTable(int n, IPrimeTableRenderer consoleRenderer)
        {
            var generator = new PrimeGenerator();
            var table = generator.GenerateMultiplicationTable(n);
            consoleRenderer.DisplayMultiplicationTable(table);
        }
    }
}
