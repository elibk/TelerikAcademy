////
namespace H05SubmatrixWithMaximalSum
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

   public class SubmatrixWithMaximalSum
    {
       private static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"...\...\input.txt", Encoding.GetEncoding("windows-1251"));
            int n = int.Parse(reader.ReadLine());

            int[,] matrix = GetMatrix(reader, n);

            int maxSum = GetSubMatrix2x2WithMaxSum(matrix, n);
            Console.WriteLine("With sum --------->  {0}", maxSum);
        }

        private static int[,] GetMatrix(StreamReader reader, int matrixLen)
        {
            using (reader)
            {
                int[,] matrix = new int[matrixLen, matrixLen];

                for (int row = 0; row < matrixLen; row++)
                {
                    string line = reader.ReadLine();

                    string[] lines = line.Split(' ');

                    for (int col = 0; col < lines.Length; col++)
                    {
                        matrix[row, col] = int.Parse(lines[col]);
                    }
                }

                return matrix;
            }
        }

        private static void PrintSubmatrix(int[,] matrix, int currentpositionY, int currentPositionX)
        {
            for (int row = currentpositionY, count = 0; count < 2; row++, count++)
            {               
                for (int col = currentPositionX, countCols = 0; countCols < 2; col++, countCols++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }

                Console.WriteLine();  
            }
        }

        private static int GetSubMatrix2x2WithMaxSum(int[,] matrix, int n)
        {
            int currentSum = 1,
                sum = 1;

            int currentPositionX = 0,
                currentpositionY = 0;

            for (int row = 0; row <= n - 2; row++)
            {
                for (int col = 0; col <= n - 2; col++)
                {
                    currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        currentPositionX = col;
                        currentpositionY = row;
                    }

                    currentSum = 1;
                }
            }
            //// Print
            PrintSubmatrix(matrix, currentpositionY, currentPositionX);
            return sum;
        }
    }
}
