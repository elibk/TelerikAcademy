using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06Horse
{
    class Program
    {
        private const string StartSymbol = "s";
        private const string exitSymbol = "e";
        private const string unreachableCellSymbol = "x";
        private const string EmptyCellSymbol = "-";
        private static bool isExitReached = false;
        private static int steps = 1;

        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[,] maze = new string[fieldSize, fieldSize];


            Coords startCoords = new Coords();

            for (int row = 0; row < fieldSize; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0, symbolOfline = 0; col < fieldSize; col++, symbolOfline += 2)
                {
                    if (line[symbolOfline].ToString() == StartSymbol)
                    {
                        startCoords = new Coords(row, col);
                    }

                    maze[row, col] = line[symbolOfline].ToString();
                }
            }

            PerformWalkBfs(maze, startCoords);
            if (isExitReached)
            {
                Console.WriteLine(steps);
            }
            else
            {
                Console.WriteLine("-1");
            }
        }

        public static string[,] PerformWalkBfs(string[,] inputField, Coords startPosition)
        {
            if (inputField.GetLength(0) != inputField.GetLength(1))
            {
                throw new ArgumentException("Rows count of 'inputField' should be equal to it's Cols count.");
            }

            MoveToAllPossibleDirectionsBfs(ref inputField, startPosition);

            return inputField;
        }

        private static void MoveToAllPossibleDirectionsBfs(ref string[,] inputField, Coords currentPosition)
        {

            Queue<Coords> nextPositions = new Queue<Coords>();
            MoveAround(ref inputField, currentPosition, ref nextPositions);

            while (nextPositions.Count > 0)
            {
                if (isExitReached)
                {
                    return;
                }
                MoveAround(ref inputField, nextPositions.Dequeue(), ref nextPositions);

            }
        }

        private static void MoveAround(ref string[,] inputField, Coords currentPosition, ref Queue<Coords> nextPositions)
        {

            //steps++;
            ////up- left
            Coords nextPositionUPLeft = new Coords(currentPosition.Y - 2, currentPosition.X -1);
            bool continuePathUPLeft = MoveToPosition(ref inputField, currentPosition, nextPositionUPLeft);
            if (continuePathUPLeft)
            {
                nextPositions.Enqueue(nextPositionUPLeft);
            }

            //up- left
            Coords nextPositionUPRight = new Coords(currentPosition.Y - 2, currentPosition.X + 1);
            bool continuePathUPRight = MoveToPosition(ref inputField, currentPosition, nextPositionUPRight);
            if (continuePathUPRight)
            {
                nextPositions.Enqueue(nextPositionUPRight);
            }

            //// right-up
            Coords nextPositionRightUp = new Coords(currentPosition.Y -1, currentPosition.X + 2);
            bool continuePathRightUp = MoveToPosition(ref inputField, currentPosition, nextPositionRightUp);
            if (continuePathRightUp)
            {
                nextPositions.Enqueue(nextPositionRightUp);
            }

            // right-down
            Coords nextPositionRightDown = new Coords(currentPosition.Y + 1, currentPosition.X + 2);
            bool continuePathRightDown = MoveToPosition(ref inputField, currentPosition, nextPositionRightDown);
            if (continuePathRightDown)
            {
                nextPositions.Enqueue(nextPositionRightDown);
            }


            //down -left
            Coords nextPositionDownLeft = new Coords(currentPosition.Y + 2, currentPosition.X -1);
            bool continuePathDownLeft = MoveToPosition(ref inputField, currentPosition, nextPositionDownLeft);
            if (continuePathDownLeft)
            {
                nextPositions.Enqueue(nextPositionDownLeft);
            }
            //down -right
            Coords nextPositionDownRigth = new Coords(currentPosition.Y + 2, currentPosition.X + 1);
            bool continuePathDownRight = MoveToPosition(ref inputField, currentPosition, nextPositionDownRigth);
            if (continuePathDownRight)
            {
                nextPositions.Enqueue(nextPositionDownRigth);
            }


            ////left - up
            Coords nextPositionLeftUp = new Coords(currentPosition.Y -1, currentPosition.X - 2);
            bool continuePathLeftUp = MoveToPosition(ref inputField, currentPosition, nextPositionLeftUp);
            if (continuePathLeftUp)
            {
                nextPositions.Enqueue(nextPositionLeftUp);
            }

            //left - down
            Coords nextPositionLeftDown = new Coords(currentPosition.Y + 1, currentPosition.X - 2);
            bool continuePathLeftDown = MoveToPosition(ref inputField, currentPosition, nextPositionLeftDown);
            if (continuePathLeftDown)
            {
                nextPositions.Enqueue(nextPositionLeftDown);
            }
        }

        private static bool MoveToPosition(ref string[,] inputField, Coords currentPosition, Coords nextPosition)
        {
            if (IsInRange(inputField, nextPosition))
            {

                if (inputField[nextPosition.Y, nextPosition.X] == exitSymbol)
                {
                    isExitReached = true;
                    int nextStepValue = 1;
                    if (inputField[currentPosition.Y, currentPosition.X] != StartSymbol)
                    {
                        nextStepValue = int.Parse(inputField[currentPosition.Y, currentPosition.X]) + 1;

                    }

                    steps = nextStepValue;
                }
                else
                {
                    if (IsEmpty(inputField, nextPosition))
                    {

                        int nextStepValue = 1;
                        if (inputField[currentPosition.Y, currentPosition.X] != StartSymbol)
                        {
                            nextStepValue = int.Parse(inputField[currentPosition.Y, currentPosition.X]) + 1;

                        }

                        steps = nextStepValue;
                        inputField[nextPosition.Y, nextPosition.X] = nextStepValue.ToString();

                        return true;
                    }
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

        public struct Coords
        {
            public int Y { get; set; }
            public int X { get; set; }

            public Coords(int y, int x)
                : this()
            {
                this.Y = y;
                this.X = x;
            }


        }
    }
}
