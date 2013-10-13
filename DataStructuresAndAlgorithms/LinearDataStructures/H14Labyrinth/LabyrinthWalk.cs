////
namespace H14Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class LabyrinthWalk
    {
        private const string StartSymbol = "*";
        private const string VisitedCellSymbol = @"[1-9]{1}\d*";
        private const string UnreachebleCellSymbol = "u";
        private const string EmptyCellSymbol = "0";
       
        public static string[,] PerformWalk(string[,] inputField)
        {
            if (inputField.GetLength(0) != inputField.GetLength(1))
            {
                throw new ArgumentException("Rows count of 'inputField' should be equal to it's Cols count.");
            }

            Coords currentPosition = FindStartCoord(inputField);

            MoveToAllPossibleDirections(ref inputField, ref currentPosition);

            ReplaceUreachebleCells(inputField);

            return inputField;
        }

        private static void ReplaceUreachebleCells(string[,] inputField)
        {
            for (int row = 0; row < inputField.GetLength(0); row++)
            {
                for (int col = 0; col < inputField.GetLength(1); col++)
                {
                    if (inputField[row, col] == EmptyCellSymbol)
                    {
                        inputField[row, col] = UnreachebleCellSymbol;
                    }
                }
            }
        }

        private static void MoveToAllPossibleDirections(ref string[,] inputField, ref Coords currentPosition)
        {
            ////up
            Coords nextPosition = new Coords(currentPosition.Y - 1, currentPosition.X);
            bool continuePath = MoveToPosition(ref inputField, currentPosition, nextPosition);
            if (continuePath)
            {
                MoveToAllPossibleDirections(ref inputField, ref nextPosition);
            }

            //// right
            nextPosition = new Coords(currentPosition.Y, currentPosition.X + 1);
            continuePath = MoveToPosition(ref inputField, currentPosition, nextPosition);

            if (continuePath)
            {
                MoveToAllPossibleDirections(ref inputField, ref nextPosition);
            }

            ////down
            nextPosition = new Coords(currentPosition.Y + 1, currentPosition.X);
            continuePath = MoveToPosition(ref inputField, currentPosition, nextPosition);

            if (continuePath)
            {
                MoveToAllPossibleDirections(ref inputField, ref nextPosition);
            }

            ////left
            nextPosition = new Coords(currentPosition.Y, currentPosition.X - 1);
            continuePath = MoveToPosition(ref inputField, currentPosition, nextPosition);

            if (continuePath)
            {
                MoveToAllPossibleDirections(ref inputField, ref nextPosition);
            }
        }

        public static string[,] PerformWalkBfs(string[,] inputField)
        {
            if (inputField.GetLength(0) != inputField.GetLength(1))
            {
                throw new ArgumentException("Rows count of 'inputField' should be equal to it's Cols count.");
            }

            Coords currentPosition = FindStartCoord(inputField);
   
            MoveToAllPossibleDirectionsBfs(ref inputField, currentPosition);

            ReplaceUreachebleCells(inputField);

            return inputField;
        }

        private static void MoveToAllPossibleDirectionsBfs(ref string[,] inputField, Coords currentPosition)
        {
           Queue<Coords> nextPositions = new Queue<Coords>();
           MoveAround(ref inputField, currentPosition, ref nextPositions);

           while (nextPositions.Count > 0)
           {
               MoveAround(ref inputField, nextPositions.Dequeue(), ref nextPositions);
           }
        }

        private static void MoveAround(ref string[,] inputField, Coords currentPosition, ref Queue<Coords> nextPositions)
        {
            ////up
            Coords nextPositionUP = new Coords(currentPosition.Y - 1, currentPosition.X);
            bool continuePathUP = MoveToPosition(ref inputField, currentPosition, nextPositionUP);
            if (continuePathUP)
            {
                nextPositions.Enqueue(nextPositionUP);
            }

            //// right
            Coords nextPositionRight = new Coords(currentPosition.Y, currentPosition.X + 1);
            bool continuePathRight = MoveToPosition(ref inputField, currentPosition, nextPositionRight);
            if (continuePathRight)
            {
                nextPositions.Enqueue(nextPositionRight);
            }

            ////down
            Coords nextPositionDown = new Coords(currentPosition.Y + 1, currentPosition.X);
            bool continuePathDown = MoveToPosition(ref inputField, currentPosition, nextPositionDown);
            if (continuePathDown)
            {
                nextPositions.Enqueue(nextPositionDown);
            }

            ////left
            Coords nextPositionLeft = new Coords(currentPosition.Y, currentPosition.X - 1);
            bool continuePathLeft = MoveToPosition(ref inputField, currentPosition, nextPositionLeft);
            if (continuePathLeft)
            {
                nextPositions.Enqueue(nextPositionLeft);
            }
        }
   
        private static bool MoveToPosition(ref string[,] inputField, Coords currentPosition, Coords nextPosition)
        {
            if (IsInRange(inputField, nextPosition) && !IsVisited(inputField, nextPosition))
            {
                if (IsEmpty(inputField, nextPosition))
                {
                    int nextStepValue = 1;
                    if (inputField[currentPosition.Y, currentPosition.X] != StartSymbol)
                    {
                        nextStepValue = int.Parse(inputField[currentPosition.Y, currentPosition.X]) + 1;
                    }
                   
                   inputField[nextPosition.Y, nextPosition.X] = nextStepValue.ToString();

                   return true;
                }
            }

            return false;
        }

        private static bool IsEmpty(string[,] inputField, Coords currentPosition)
        {
            if (inputField[currentPosition.Y, currentPosition.X] == EmptyCellSymbol)
            {
                return true;
            }

            return false;
        }

        public static bool IsVisited(string[,] inputField, Coords currentPosition)
        {
            if (Regex.IsMatch(inputField[currentPosition.Y, currentPosition.X], VisitedCellSymbol))
            {
                return true;
            }

            return false;
        }

        private static bool IsInRange(string[,] inputField, Coords currentPosition)
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

        public static Coords FindStartCoord(string[,] inputField)
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
