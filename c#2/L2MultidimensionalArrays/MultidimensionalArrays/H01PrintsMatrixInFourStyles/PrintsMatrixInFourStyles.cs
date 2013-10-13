////
namespace H01PrintsMatrixInFourStyles
{
    using System;
    using System.Linq;

   public class PrintsMatrixInFourStyles
    {
       private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            int index = 1;
            Console.WriteLine("a)");
            ////a
            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = index;
                    index++;
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0,-5}", matrix[row, col]);
                }

                Console.WriteLine();
            }

            ////b
            index = 1;
            Console.WriteLine("b)");
            for (int col = 0; col < n; col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix[row, col] = index;
                        index++;
                    }
                }
                else
                {
                    for (int row = n - 1; row >= 0; row--)
                    {
                        matrix[row, col] = index;
                        index++;
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0,-5}", matrix[row, col]);
                }

                Console.WriteLine();
            }

            ////c           
            index = 1;
            Console.WriteLine("c)");

            for (int row = n - 1, col = 0; row >= 0; row--, col++)
            {                
                for (int y = row, x = 0; x <= col; y++, x++)
                {
                    matrix[y, x] = index;
                    index++;
                }
            }

            for (int col = 1; col <= n - 1; col++)
            {
                for (int y = 0, x = col; x <= n - 1; y++, x++)
                {
                    matrix[y, x] = index;
                    index++;
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0,-5}", matrix[row, col]);
                }

                Console.WriteLine();
            }

            ////d
            
            ////for (int rRight = 0, cRight = 0, condRight = N,
            ////    rDown = 0, cDown = 0, condDown = N,
            ////    rLeft = N - 1, cLeft = N - 2, condLeft = 0,
            ////    rUp = N - 2, cUp = 0, condUp = 1;
            ////   cUp <= N / 2;
            ////    rRight++, cRight++, condRight--,
            ////    rDown++, cDown--, condDown--,
            ////    rLeft--, cLeft--, condLeft++,
            ////    rUp--, cUp++, condUp++)
            ////{
            ////    for (int row = rDown, col = cDown; row < condDown; row++, index++)
            ////    {
            ////        //DOWN

            ////        matrix[row, col] = index;
            ////    }
            ////    //    for (int row = rRight, col = cRight; col < condRight; col++, index++)
            ////    //    {
            ////    //        //RIGHT

            ////    //        matrix[row, col] = index;
            ////    //    }
            ////    //    for (int row = rUp, col = cUp; row >= condUp; row--, index++)
            ////    //    {
            ////    //        //UP

            ////    //        matrix[row, col] = index;
            ////    //    }
            ////    //    for (int row = rLeft, col = cLeft; col >= condLeft; col--, index++)
            ////    //    {
            ////    //        //LEFT

            ////    //        matrix[row, col] = index;
            ////    //    }

            ////    //}

            ////    //for (int row = 0; row < N; row++)
            ////    //{

            ////    //    for (int col = 0; col < N; col++)
            ////    //    {
            ////    //        Console.Write("{0,-5}", matrix[row, col]);
            ////    //    }
            ////    //    Console.WriteLine();
            ////    //}
            ////}
        }
    }
}
