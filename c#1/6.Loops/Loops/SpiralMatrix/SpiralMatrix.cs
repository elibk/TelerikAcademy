using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrix
{
    class SpiralMatrix
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[,] matrix = new int[N,N];
            int index = 1;

            for (int rRight = 0, cRight = 0, condRight = N, 
                rDown = 1, cDown = N-1, condDown = N,
                rLeft = N-1, cLeft = N-2, condLeft = 0, 
                rUp = N-2, cUp = 0, condUp = 1; 
               cUp<= N/2;
                rRight++, cRight++, condRight--,
                rDown++, cDown--, condDown--,
                rLeft--, cLeft--, condLeft++,
                rUp--, cUp++, condUp++)
            {
                for (int row = rRight, col = cRight; col < condRight; col++, index++)
                {
                    //RIGHT

                    matrix[row, col] = index;
                }
                for (int row = rDown, col = cDown; row < condDown; row++, index++)
                {
                    //DOWN

                    matrix[row, col] = index;
                }
                for (int row = rLeft, col = cLeft; col >= condLeft; col--, index++)
                {
                    //LEFT

                    matrix[row, col] = index;
                }
                for (int row = rUp, col = cUp; row >= condUp; row--, index++)
                {
                    //UP
                    
                    matrix[row, col] = index;
                }
            }


            for (int row = 0; row < N; row++)
            {
                
                for (int col = 0; col < N; col++)
                {
                    Console.Write("{0,-5}",matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
