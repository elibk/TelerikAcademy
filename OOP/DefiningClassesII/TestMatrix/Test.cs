using JustMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMatrix
{
    class Test
    {
        static int ind = 1;

        static void Main(string[] args)
        {
            Matrix<int> matrix = new Matrix<int>(3,3);

            if (matrix)
            {
                Console.WriteLine("The matrix contain all zero elements");
            }

            Matrix<int> matrixOther = new Matrix<int>(3, 3);

            FillMatrix(matrix);

            PrintMatrix(matrix);
            Console.WriteLine();

            FillMatrix(matrixOther);
            PrintMatrix(matrixOther);
            Console.WriteLine();

            Matrix<int> newMatrix = matrix + matrixOther;
            PrintMatrix(newMatrix);
            Console.WriteLine();

            PrintMatrix(matrix - matrixOther);
            Console.WriteLine();

            newMatrix = matrix * matrixOther;
            PrintMatrix(newMatrix);
            Console.WriteLine();

            newMatrix = matrix * 2;
            PrintMatrix(newMatrix);

        }

        private static void PrintMatrix(Matrix<int> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(Matrix<int> matrix)
        { 
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    matrix[row, col] = ind;
                    ind++;
                }
            }
        }
    }
}
