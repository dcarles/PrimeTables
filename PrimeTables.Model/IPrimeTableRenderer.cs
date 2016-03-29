using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTables.Model
{
    public interface IPrimeTableRenderer
    {
        void DisplayMultiplicationTable(int[,] table);
    }
}
