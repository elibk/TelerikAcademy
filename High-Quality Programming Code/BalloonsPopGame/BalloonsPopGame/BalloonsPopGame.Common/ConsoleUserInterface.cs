using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BalloonsPopGame.Common
{
   public class ConsoleUserInterface
    {
       
        public void DisplayGreeting()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons.");
            Console.WriteLine();
        }

        public void DisplayGameField(int[,] gameField)
        {
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            Console.WriteLine();
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("    --------------------");

            for (int row = 0; row < rows; row++)
            {
                Console.Write(row.ToString() + " | ");

                for (int col = 0; col < cols; col++)
                {
                    if (gameField[row, col] == 0)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(gameField[row, col] + " ");
                    }

                }

                Console.WriteLine("| ");
            }

            Console.WriteLine("    --------------------");
        }

        public void AskForCommand()
        {
            Console.WriteLine("Insert row and column or other command");
        }


        public string ReadCommand()
        {
            Console.Clear();
            string command = Console.ReadLine();
            return command;
        }

        public void InformAboutInvalidCommand(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void DisplayLeaderboard(IEnumerable<IPlayer> players)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            if (players == null)
            {
                throw new ArgumentNullException("Value for 'players' can not be null.");
            }

            Console.WriteLine("S C O R E S");

            if (players.Count() == 0)
            {
                Console.WriteLine("There are no scores to be displayed!");
            }
            else
            {
                foreach (var player in players)
                {
                    Console.WriteLine(player);
                }
            }

            Console.ResetColor();
        }

        public string GetNickName()
        {
            
            string nickname;
            do
            {
                Console.Write("Enter your Nickname: ");
                nickname = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(nickname));

            return nickname;
        }

        public void DisplayGoodbay()
        {
            Console.WriteLine("Thanks for playing!!");
        }
    }
}
