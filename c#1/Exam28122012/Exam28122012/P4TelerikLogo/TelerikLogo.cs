using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4TelerikLogo
{
    class TelerikLogo
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()),
                len = 3 * N - 2;

            for (int rowCount = 1, 
                Z = N / 2 + 1, 
                Z2 = len - N / 2, 
                Y = N / 2 + 1, 
                Y2 = len - N / 2, 
                X = N / 2 + 1, 
                X2 = len - N / 2; 
                
                rowCount <= len; 
                
                rowCount++, Z--, Z2++, Y++, Y2--)
            {
                if (rowCount >= 2*N )
                {
                    X++;
                    X2--;
                }
                
                for (int colCount = 1; colCount <= len; colCount++)
                {
                    if (Z == colCount || Z2 == colCount 
                        || (Y == colCount && Y <= len - N / 2) 
                        || (Y2 == colCount && Y2 >=  N / 2 + 1)
                        || ((rowCount >= 2 * N ) && X == colCount)
                        || ((rowCount >= 2 * N ) && X2 == colCount))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                    
                }
                Console.WriteLine();
            }
            
        }
    }
}
