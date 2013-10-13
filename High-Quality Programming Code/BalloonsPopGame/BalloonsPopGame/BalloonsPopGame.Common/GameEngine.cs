using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPopGame.Common
{
    public class GameEngine
    {
        
        public event EventHandler GameOver;

        private int[,] gameField;
        private readonly int gameFieldColsCount = 10;
        private readonly int gameFieldRowsCount = 6;
        private const int MinFieldValue = 1;
        private const int MaxFieldValue = 5; // not inclusive
        private int currentPlayerScore;

        public GameEngine()
        {
            this.GameField = new int[this.gameFieldRowsCount, this.gameFieldColsCount];
            this.CurrentPlayerScore = 0;
        }

        public int[,] GameField
        {
            get
            {
                return this.gameField;
            }
            private set
            {
                this.gameField = value;
            }
        }

        public int CurrentPlayerScore
        {
            get
            {
                return this.currentPlayerScore;
            }
            protected set
            {
                this.currentPlayerScore = value;
            }
        }


        public int[,] InitializeGameField()
        {
            Random randomGenerator = new Random();

            for (int row = 0; row < gameFieldRowsCount; row++)
            {
                for (int col = 0; col < gameFieldColsCount; col++)
                {
                    gameField[row, col] = randomGenerator.Next(MinFieldValue, MaxFieldValue);
                }
            }

            return gameField;
        }

        public void ExitTheGame()
        {
            Environment.Exit(0);
        }

        public int[,] PerformMovement(MatrixCoords coords)
        {

            
            if (gameField[coords.YCoord - 1, coords.XCoord - 1] == 0)
            {
                Console.WriteLine();
                return gameField;
            }
            else
            {
                this.CurrentPlayerScore++;
                int state = gameField[coords.YCoord - 1, coords.XCoord - 1];
                int top = coords.YCoord - 1;
                int bottom = coords.YCoord - 1;
                int left = coords.XCoord - 1;
                int right = coords.XCoord - 1;



                while (top > 0 && (gameField[top - 1, coords.XCoord - 1] == state))
                {
                    top--;
                }

                while (bottom < 5 && gameField[bottom + 1, coords.XCoord - 1] == state)
                {
                    bottom++;
                }
                while (left > 0 && gameField[coords.YCoord - 1, left - 1] == state)
                {
                    left--;
                }
                while (right < 9 && gameField[coords.YCoord - 1, right + 1] == state)
                {
                    right++;
                }

                for (int i = left; i <= right; i++)
                {
                    //first remove the elements on the same coords.YCoord and float the elemnts above down
                    if (coords.YCoord == 1)
                    {
                        gameField[coords.YCoord - 1, i] = 0;
                    }
                    else
                    {
                        for (int j = coords.YCoord - 1; j > 0; j--)
                        {
                            gameField[j, i] = gameField[j - 1, i];
                            gameField[j - 1, i] = 0;
                        }
                    }
                }

                if (top == bottom)
                {
                    return gameField;

                    // return kraj();
                }
                else
                {
                    for (int i = top; i > 0; --i)
                    {
                        //float the elements above down and replace them
                        gameField[i + bottom - top, coords.XCoord - 1] = gameField[i, coords.XCoord - 1];
                        gameField[i, coords.XCoord - 1] = 0;
                    }

                    if (bottom - top > top - 1)
                    {
                        //if there are more baloons to pop in the coords.XCoordumn than elements above them, pop them as well
                        for (int i = top; i <= bottom; i++)
                        {
                            if (gameField[i, coords.XCoord - 1] == state)
                            {
                                gameField[i, coords.XCoord - 1] = 0;
                            }
                        }
                    }
                }

                return gameField;
            }
        }

        private void CheckForGameOver() 
        {
            foreach (var cell in this.GameField)
            {
                if (cell != 0)
                {
                    return;
                }
            }

            if (this.GameOver != null)
            {
                this.GameOver(this, EventArgs.Empty);
            }
        }
    }
}
