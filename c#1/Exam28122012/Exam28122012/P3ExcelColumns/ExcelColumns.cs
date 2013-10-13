using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P3ExcelColumns
{
    class ExcelColumns
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] nums = new int[N];

            BigInteger colNumber = 0;
            

            for (int i = N-1; i >= 0; i--)
            {
                nums[i] = (char.Parse(Console.ReadLine())) - 64;
                colNumber += (BigInteger)(Math.Pow(26,(double)i)) * nums[i];
            }

            Console.WriteLine(colNumber);
        }
    }
}
