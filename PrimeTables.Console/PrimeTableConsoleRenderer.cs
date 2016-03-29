using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeTables.Model;

namespace PrimeTables.UI
{
    public class PrimeTableConsoleRenderer : IPrimeTableRenderer
    {
        public void DisplayMultiplicationTable(int[,] table)
        {
            Console.WriteLine("");
            Console.WriteLine($"======= The Prime Multiplication table for {table.GetLength(0)} prime numbers is ========");
            Console.WriteLine("");

            for (var i = 0; i < table.GetLength(0); i++)
            {
                Console.Write("|");
                for (var j = 0; j < table.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                        Console.Write("    ");
                    else
                        Console.Write(table[i, j].ToString().PadLeft(2, '0').PadLeft(4, ' '));

                    Console.Write("|");
                }
                Console.WriteLine();
            }
        }
    }
}
