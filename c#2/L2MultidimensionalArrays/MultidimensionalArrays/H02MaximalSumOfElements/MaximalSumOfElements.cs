////Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
namespace H02MaximalSumOfElements
{
    using System;
    using System.Linq;

   public class MaximalSumOfElements
    {
       private static void Main(string[] args)
        {
            int[,] matrix = 
                            {
                              { 9, 1, 1, 9, 1, 1 },
                              { 1, 9, 1, 1, 1, 1 },
                              { 1, 1, 9, 1, 1, 1 },
                              { 1, 1, 1, 1, 9, 1 },
                              { 1, 1, 9, 1, 1, 9 },
                              { 1, 1, 1, 9, 9, 9 }
                            };

            int rows = 6,
                cols = 6;

            int currentSum = 1,
                sum = 1;

            int currentPositionX = 0,
                currentpositionY = 0;

            for (int row = 0; row <= rows - 3; row++)
            {
                for (int col = 0; col <= cols - 3; col++)
                {
                    currentSum = matrix[row, col] + matrix[row, col + 1] + 
                                 matrix[row, col + 2] + matrix[row + 1, col] + 
                                 matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + 
                                 matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        currentPositionX = col;
                        currentpositionY = row;
                    }

                    currentSum = 1;
                }
            }

            for (int row = currentpositionY, count = 0; count < 3; row++, count++)
            {               
                for (int col = currentPositionX, countCols = 0; countCols < 3; col++, countCols++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
