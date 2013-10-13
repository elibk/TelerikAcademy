using System;
using System.Diagnostics;

namespace MatrixWalk
{
   public class MatrixWalk
    {
        private const int moveXRight = 1;
        private const int moveXLeft = -1;
        private const int stayStill = 0;
        private const int moveYDown = 1;
        private const int moveYUp = -1;

        private static int currentCol = 0;
        private static int currentRow = 0;

        private static int valueInTheCell = 1;

        private static readonly int directionsCount = 8;

        private static readonly int[] directionsX = { moveXRight, moveXRight, moveXRight, stayStill, moveXLeft, moveXLeft, moveXLeft, stayStill };
        private static readonly int[] directionsY = { moveYDown, stayStill, moveYUp, moveYUp, moveYUp, stayStill, moveYDown, moveYDown };

        public static void ChangeDirection(ref int dx, ref int dy)
        {
            int cd = 0;

            for (int count = 0; count < directionsCount; count++)
            {
                if (directionsX[count] == dx && directionsY[count] == dy) 
                { 
                    cd = count; 
                    break; 
                }
            }

            if (cd == 7) // last direction -> first
            { 
                dx = directionsX[0]; 
                dy = directionsY[0];
                return;
            }

            dx = directionsX[cd + 1]; // get next direction
            dy = directionsY[cd + 1];
        }

        public static bool HasPossibleDirection(int[,] matrix, int x, int y)
        {
            Debug.Assert(matrix.GetLength(0) == matrix.GetLength(1), "The matrix shoul be with equal num of rows and num of cols");
          
            int matrixSize = matrix.GetLength(0);

            int[] directionsX = { moveXRight, moveXRight, moveXRight, stayStill, moveXLeft, moveXLeft, moveXLeft, stayStill };
            int[] directionsY = { moveYDown, stayStill, moveYUp, moveYUp, moveYUp, stayStill, moveYDown, moveYDown };

            for (int i = 0; i < directionsCount; i++)
            {
                if (IsPathOver(x, directionsX[i], matrixSize))
                {

                    directionsX[i] = stayStill;
                }

                if (IsPathOver(y, directionsY[i], matrixSize))
                {
                    directionsY[i] = stayStill;
                }
            }

            for (int i = 0; i < directionsCount; i++)
            {
                if (matrix[x + directionsX[i], y + directionsY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsPathOver(int currentPosition, int directionToMove, int maxDestination) 
        {
            int minDestination = 0;

            if (currentPosition + directionToMove >= maxDestination || currentPosition + directionToMove < minDestination)
            {
                return true;
            }

            return false;
        }

        public static void FindEmptyCell(int[,] matrix, out int x, out int y)
        {
            int matrixSize = matrix.GetLength(0);
            x = 0;
            y = 0;
            for (int col = 0; col < matrixSize; col++)
            {
                for (int row = 0; row < matrixSize; row++)
                {
                    if (matrix[col, row] == 0) 
                    { 
                        x = col; 
                        y = row; 

                        return; 
                    }
                }
            }
        }

        public  static void Main(string[] args)
        {
            //Console.WriteLine( "Enter a positive number " );
            //string input = Console.ReadLine(  );
            //int n = 0;
            //while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            //{
            //    Console.WriteLine( "You haven't entered a correct positive number" );
            //    input = Console.ReadLine(  );
            //}
            
            int[,] matrix = GetMatrix(5);
            DisplayMatrix(matrix);
        }

        public static int[,] GetMatrix(int matrixSize)
        {

            int[,] matrix = new int[matrixSize, matrixSize];

            matrix = PerformWalk(matrix);

            FindEmptyCell(matrix, out currentCol, out currentRow);

            if (currentCol != 0 && currentRow != 0)
            {
                matrix = PerformWalk(matrix);
            }

            return matrix;
        }

        public static int[,] PerformWalk(int[,] matrix)
        {
            int
            matrixSize = matrix.GetLength(0),
            directionX = moveXRight,
            directionY = moveYDown;
           
            matrix[currentCol, currentRow] = valueInTheCell;

            while (HasPossibleDirection(matrix, currentCol, currentRow))
            {
                while ((IsPathOver(currentCol, directionX, matrixSize) || IsPathOver(currentRow, directionY, matrixSize) || matrix[currentCol + directionX, currentRow + directionY] != 0))
                {
                    ChangeDirection(ref directionX, ref directionY);
                }
                currentCol += directionX;
                currentRow += directionY;
                valueInTheCell++;

                matrix[currentCol, currentRow] = valueInTheCell;
            }

            return matrix;
        }

        public static void DisplayMatrix(int[,] matrica)
        {
            int matrixSize = matrica.GetLength(0);
            Debug.Assert(matrica.GetLength(0) == matrica.GetLength(1), "The matrix shoul be with equal num of rows and num of cols");

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write("{0,3}", matrica[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}