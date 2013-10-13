using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalanNumbers
{
    class CatalanNumbers
    {
        static void Main()
        {
            Console.Write("Find number of Catalan's numbers.\nEnter position of the number you want to find:");
            decimal n = decimal.Parse(Console.ReadLine());
            decimal doubleN = n*2;
            decimal nPlusOne = n + 1;

            for (decimal i = doubleN - 1; i > n; i--)
            {
                doubleN = doubleN * i;
            }

            for (decimal i = n - 1; i >= 1; i--)
            {
                n = n * i;
            }
            nPlusOne = n * nPlusOne;
            doubleN = doubleN * n;

            Console.WriteLine("{0}/{1}*{2} = {3}",doubleN,nPlusOne,n,doubleN/(nPlusOne*n));
        }
    }
}
