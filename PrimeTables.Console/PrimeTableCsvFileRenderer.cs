using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeTables.Model;

namespace PrimeTables.UI
{
    public class PrimeTableCsvFileRenderer : IPrimeTableRenderer
    {
        public void DisplayMultiplicationTable(int[,] table)
        {
            var csv = new StringBuilder();

            for (var i = 0; i < table.GetLength(0); i++)
            {
                for (var j = 0; j < table.GetLength(1); j++)
                {
                    if (i != 0 || j != 0)
                        csv.Append(table[i, j].ToString().PadLeft(2, '0'));

                    csv.Append(",");
                }
                csv.Remove(csv.Length - 1, 1);
                csv.Append(Environment.NewLine);
            }

            File.WriteAllText("primeTable.csv", csv.ToString());
        }
    }
}
