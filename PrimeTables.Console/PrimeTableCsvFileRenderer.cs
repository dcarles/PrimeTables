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
            const string fileName = "primeTable.csv";

            if (File.Exists(fileName))
                File.Delete(fileName);

            using (var outfile = new StreamWriter(fileName))
            {
                for (var i = 0; i < table.GetLength(0); i++)
                {
                    for (var j = 0; j < table.GetLength(1); j++)
                    {
                        if (i != 0 || j != 0)
                            outfile.Write(table[i, j].ToString().PadLeft(2, '0'));

                        outfile.Write(",");
                    }
                    outfile.Write(Environment.NewLine);
                }
            }
        }
    }
}
