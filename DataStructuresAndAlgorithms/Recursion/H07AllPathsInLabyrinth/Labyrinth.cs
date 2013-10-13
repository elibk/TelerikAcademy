using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H07AllPathsInLabyrinth
{
   public class Labyrinth
    {
        private const char StartSymbol = 's';
        private const char UnreachebleCellSymbol = 'u';
        private const char End = 'e';
        private static int pathsCount = 0;

        public static int PerformWalk(char[,] inputField)
        {
            if (inputField.GetLength(0) != inputField.GetLength(1))
            {
                throw new ArgumentException("Rows count of 'inputField' should be equal to it's Cols count.");
            }

            Coords currentPosition = FindStartCoord(inputField);

            MoveToAllPossibleDirections(ref inputField, ref currentPosition);

            return pathsCount;
        }

        private static void MoveToAllPossibleDirections(ref char[,] inputField, ref Coords currentPosition)
        {
            ////up
            Coords nextPosition = new Coords(currentPosition.Y - 1, currentPosition.X);
            bool continuePath = MoveToPosition(ref inputField, nextPosition);
            if (continuePath)
            {
                MoveToAllPossibleDirections(ref inputField, ref nextPosition);
                GoBack(ref inputField, nextPosition);
            }

            //// right
            nextPosition = new Coords(currentPosition.Y, currentPosition.X + 1);
            continuePath = MoveToPosition(ref inputField, nextPosition);

            if (continuePath)
            {
                MoveToAllPossibleDirections(ref inputField, ref nextPosition);
                GoBack(ref inputField, nextPosition);
            }

            ////down
            nextPosition = new Coords(currentPosition.Y + 1, currentPosition.X);
            continuePath = MoveToPosition(ref inputField, nextPosition);

            if (continuePath)
            {
                MoveToAllPossibleDirections(ref inputField, ref nextPosition);
                GoBack(ref inputField, nextPosition);
            }

            ////left
            nextPosition = new Coords(currentPosition.Y, currentPosition.X - 1);
            continuePath = MoveToPosition(ref inputField, nextPosition);

            if (continuePath)
            {
                MoveToAllPossibleDirections(ref inputField, ref nextPosition);
                GoBack(ref inputField, nextPosition);
            }
        }

        private static bool MoveToPosition(ref char[,] inputField, Coords nextPosition)
        {
            if (IsInRange(inputField, nextPosition))
            {
                if (inputField[nextPosition.Y, nextPosition.X] == default(char))
                {
                    inputField[nextPosition.Y, nextPosition.X] = UnreachebleCellSymbol;
                    return true;
                }
                else if (inputField[nextPosition.Y, nextPosition.X] == End)
                {
                    pathsCount++;
                }
                
            }
            
            return false;
        }

        private static void GoBack(ref char[,] inputField, Coords nextPosition)
        {

            inputField[nextPosition.Y, nextPosition.X] = default(char);
            
        }

        private static bool IsInRange(char[,] inputField, Coords currentPosition)
        {
            bool isInRange = true;
            if (currentPosition.Y >= inputField.GetLength(0) || currentPosition.Y < 0)
            {
                isInRange = false;
            }
            else if (currentPosition.X >= inputField.GetLength(1) || currentPosition.X < 0)
            {
                isInRange = false;
            }

            return isInRange;
        }

        public static Coords FindStartCoord(char[,] inputField)
        {
            for (int row = 0; row < inputField.GetLength(0); row++)
            {
                for (int col = 0; col < inputField.GetLength(1); col++)
                {
                    if (inputField[row, col] == StartSymbol)
                    {
                        return new Coords(row, col);
                    }
                }
            }

            throw new InvalidOperationException("There is no start field in the matrix.");
        }

    }
}
