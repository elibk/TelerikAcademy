using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T05Businessmen
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberOfBusinessmen = long.Parse(Console.ReadLine());
            long handShakesCount = CountHandShakes(numberOfBusinessmen);
            Console.WriteLine(handShakesCount);
        }

        public static long CountHandShakes(long numberOfBusinessmen)
        
            {
                long[] result = new long[numberOfBusinessmen + 1];
                result[0] = 1;
                for (long row = 1; row <= numberOfBusinessmen; ++row)
                {
                    for (long col = 0; col <= row - 2; col += 2)
                    {
                        result[row] += result[col] * result[row - col - 2];
                    }
                }
                return result[numberOfBusinessmen];
            } 
        
    }
}
