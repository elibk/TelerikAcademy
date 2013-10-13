using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T05TheGameOfLife
{
    class Program
    {
        private const int moveXRight = 1;
        private const int moveXLeft = -1;
        private const int stayStill = 0;
        private const int moveYDown = 1;
        private const int moveYUp = -1;

        private static readonly int[] directionsX = { moveXRight, moveXRight, moveXRight, stayStill, moveXLeft, moveXLeft, moveXLeft, stayStill };
        private static readonly int[] directionsY = { moveYDown, stayStill, moveYUp, moveYUp, moveYUp, stayStill, moveYDown, moveYDown };

        static bool[,] currentState;
        static bool[,] newState;
        static bool[,] temp;
        static int state;
        static int n;
        static int m;
        private static int minRow = 0;
        private static int minCol = 0;
        private static int maxRow = n;
        private static int maxCol = m;
        private static int aliveCellsCount = 0;

        static void Main(string[] args)
        {
            state = int.Parse(Console.ReadLine());

            string[] data = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            n = int.Parse(data[0]);
            m = int.Parse(data[1]);
            maxRow = n - 1;
            maxCol = m;
            currentState =  new bool[n,m];

            newState = new bool[n, m];

            //temp = new bool[n, m];


            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int j = 0, col = 0; j < line.Length; j += 2, col ++)
			    {
			        if (line[j] == '1')
	                {
                        currentState[row, col] = true;
                        aliveCellsCount++;
	                }
			    }
            }

            Console.WriteLine( Solve() ); 
        }

        private static int Solve()
        {
            int currentStateLevel = 0;
            
            while (currentStateLevel < state)
            {
                if (currentStateLevel % 2 == 0)
                {
                    if (!NextGenerationOdd())
                    {

                        return aliveCellsCount;   
	                }

                  
                }
                else
                {
                    if (!NextGeneration())
                    {

                        return aliveCellsCount;   
                    }

                   
                }
                currentStateLevel++;
            }

           
                return aliveCellsCount;
        }

        private static bool NextGeneration()
        {
            bool hasChange = false;
            bool isFirst = true;
            int currentRowBreak = maxRow;
            int currentRowStart = minRow;
            bool isThereAliveCells = false;
            for (int row = currentRowStart; row <= currentRowBreak; row++)
            {
                for (int col = minCol; col < maxCol; col++)
                {
                    bool isAlive = newState[row, col];
                    int aliveNeigboors = GetAliveNeighboursCount(row, col);

                    if (isAlive)
                    {
                        if (aliveNeigboors < 2)
                        {
                            currentState[row, col] = false;
                            hasChange = true;
                            aliveCellsCount--;
                        }
                        else if (aliveNeigboors > 3)
                        {
                            currentState[row, col] = false;
                             hasChange = true;
                             aliveCellsCount--;
                        }
                        else
                        {
                            currentState[row, col] = true;
                            isThereAliveCells = true;
                        }
                    }
                    else
                    {
                        if (aliveNeigboors == 3)
                        {
                            currentState[row, col] = true;
                            isThereAliveCells = true;
                            hasChange = true;
                            aliveCellsCount++;
                        }
                        else
                        {
                            currentState[row, col] = false;
                        }
                    }
                }

               
            }

            return hasChange;
        }

        private static bool NextGenerationOdd()
        {
            bool hasChange = false;
            bool isFirst = true;
            int currentRowBreak = maxRow;
            int currentRowStart = minRow;
            bool isThereAliveCells = false;
            for (int row = currentRowStart; row <= currentRowBreak; row++)
            {
                for (int col = minCol; col < maxCol; col++)
                {
                    bool isAlive = currentState[row, col];
                    int aliveNeigboors = GetAliveNeighboursCountOdd(row, col);

                    if (isAlive)
                    {
                        if (aliveNeigboors < 2)
                        {
                            newState[row, col] = false;
                            hasChange = true;
                            aliveCellsCount--;
                        }
                        else if (aliveNeigboors > 3)
                        {
                            newState[row, col] = false;
                            hasChange = true;
                            aliveCellsCount--;
                        }
                        else
                        {
                            newState[row, col] = true;
                            isThereAliveCells = true;
                        }
                    }
                    else
                    {
                        if (aliveNeigboors == 3)
                        {
                            newState[row, col] = true;
                            isThereAliveCells = true;
                            hasChange = true;
                            aliveCellsCount++;
                        }
                        else
                        {
                            newState[row, col] = false;
                        }
                    }
                }

            }

            return hasChange;
        }
        private static int GetAliveNeighboursCount(int currentRow, int currentCol)
        {
            int neighboorsCount = 0;


            for (int i = 0; i < directionsX.Length; i++)
            {
                if (IsAlive(currentRow + directionsX[i], currentCol + directionsY[i]))
                {
                    neighboorsCount++;
                }
            }

            
            return neighboorsCount;
        }

        private static int GetAliveNeighboursCountOdd(int currentRow, int currentCol)
        {
            int neighboorsCount = 0;


            for (int i = 0; i < directionsX.Length; i++)
            {
                if (IsAliveOdd(currentRow + directionsX[i], currentCol + directionsY[i]))
                {
                    neighboorsCount++;
                }
            }


            return neighboorsCount;
        }

        private static bool IsAliveOdd(int currentRow, int currentCol)
        {
            if (IsInRange(currentRow, currentCol) && currentState[currentRow, currentCol])
            {
                return true;
            }
            return false;
        }

        private static bool IsAlive(int currentRow, int currentCol)
        {
            if (IsInRange(currentRow, currentCol) && newState[currentRow, currentCol])
            {
                return true;
            }
            return false;
        }

        private static bool IsInRange(int currentRow, int currentCol)
        {
            bool check = true;

            if (currentRow < 0 || currentRow >= n)
            {
                check = false;
            }
            else if (currentCol < 0 || currentCol >=m)
            {
                check = false;
            }

            return check;
        }


    }
}
