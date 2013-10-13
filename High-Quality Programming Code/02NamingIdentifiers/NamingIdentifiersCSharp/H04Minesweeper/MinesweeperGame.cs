////
namespace H04Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MinesweeperGame
    {
       private static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] playingSuraface = InitializePlayingSurface();
            char[,] playingArea = InitializePlayingArea();
            int pointsCounter = 0;
            bool isExplosion = false;
            List<Player> players = new List<Player>(6);
            int selectedRow = 0;
            int selectedCol = 0;
            bool isNewGame = true;
            const int TopResult = 35;
            bool isTopResultReached = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                                      " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrowPlayingSurface(playingSuraface);
                    isNewGame = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out selectedRow) &&
                        int.TryParse(command[2].ToString(), out selectedCol) &&
                        selectedRow <= playingSuraface.GetLength(0) && selectedCol <= playingSuraface.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowScores(players);
                        break;
                    case "restart":
                        playingSuraface = InitializePlayingSurface();
                        playingArea = InitializePlayingArea();
                        DrowPlayingSurface(playingSuraface);
                        isExplosion = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (playingArea[selectedRow, selectedCol] != '*')
                        {
                            if (playingArea[selectedRow, selectedCol] == '-')
                            {
                                ExecuteTurn(playingSuraface, playingArea, selectedRow, selectedCol);
                                pointsCounter++;
                            }

                            if (TopResult == pointsCounter)
                            {
                                isTopResultReached = true;
                            }
                            else
                            {
                                DrowPlayingSurface(playingSuraface);
                            }
                        }
                        else
                        {
                            isExplosion = true;
                        }

                        break;
                    default:
                        Console.WriteLine("{0}Greshka! nevalidna Komanda{0}", Environment.NewLine);
                        break;
                }

                if (isExplosion)
                {
                    DrowPlayingSurface(playingArea);
                    Console.Write(
                        "{1}Hrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", pointsCounter, Environment.NewLine);
                    string playerName = Console.ReadLine();
                    Player deadPlayer = new Player(playerName, pointsCounter);
                    if (players.Count < 5)
                    {
                        players.Add(deadPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Score < deadPlayer.Score)
                            {
                                players.Insert(i, deadPlayer);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((Player onePlayer, Player anotherPlayer) => anotherPlayer.Name.CompareTo(onePlayer.Name));
                    players.Sort((Player onePlayer, Player anotherPlayer) => anotherPlayer.Score.CompareTo(onePlayer.Score));
                    ShowScores(players);

                    playingSuraface = InitializePlayingSurface();
                    playingArea = InitializePlayingArea();
                    pointsCounter = 0;
                    isExplosion = false;
                    isNewGame = true;
                }

                if (isTopResultReached)
                {
                    Console.WriteLine("{0}BRAVOOOS! Otvori 35 kletki bez kapka kryv.", Environment.NewLine);
                    DrowPlayingSurface(playingArea);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string playerName = Console.ReadLine();
                    Player topScoredPlayer = new Player(playerName, pointsCounter);
                    players.Add(topScoredPlayer);
                    ShowScores(players);
                    playingSuraface = InitializePlayingSurface();
                    playingArea = InitializePlayingArea();
                    pointsCounter = 0;
                    isTopResultReached = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void ShowScores(List<Player> players)
        {
            Console.WriteLine("{0}To4KI:", Environment.NewLine);
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} kutii", i + 1, players[i].Name, players[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!{0}", Environment.NewLine);
            }
        }

        private static void ExecuteTurn(
            char[,] playingSurface, char[,] playingArea, int selectedRow, int selectedCol)
        {
            char fieldValie = GetFieldValue(playingArea, selectedRow, selectedCol);
            playingArea[selectedRow, selectedCol] = fieldValie;
            playingSurface[selectedRow, selectedCol] = fieldValie;
        }

        private static void DrowPlayingSurface(char[,] playboard)
        {
            int rows = playboard.GetLength(0);
            int cols = playboard.GetLength(1);
            Console.WriteLine("{0}    0 1 2 3 4 5 6 7 8 9", Environment.NewLine);
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", playboard[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------" + Environment.NewLine);
        }

        private static char[,] InitializePlayingSurface()
        {
            int rows = 5;
            int cols = 10;
            char[,] playingSurface = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    playingSurface[row, col] = '?';
                }
            }

            return playingSurface;
        }

        private static char[,] InitializePlayingArea()
        {
            int rows = 5;
            int cols = 10;
            char[,] playingArea = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    playingArea[row, col] = '-';
                }
            }

            InitializeMines(cols, playingArea);
        
            return playingArea;
        }

        /// <summary>
        /// Using Algoritum for random selection of fields to put a mine fills playng area with mines 
        /// </summary>
        /// <param name="colsInArea"></param>
        /// <param name="playingArea"></param>
        private static void InitializeMines(int colsInArea, char[,] playingArea)
        {            
            List<int> uniqueChances = new List<int>();
            while (uniqueChances.Count < 15)
            {
                Random randomGenerator = new Random();
                int chance = randomGenerator.Next(50);
                if (!uniqueChances.Contains(chance))
                {
                    uniqueChances.Add(chance);
                }
            }

            foreach (int chance in uniqueChances)
            {
                int row = chance / colsInArea;
                int col = chance % colsInArea;
                if (col == 0 && chance != 0)
                {
                    row--;
                    col = colsInArea;
                }
                else
                {
                    col++;
                }

                playingArea[row, col - 1] = '*';
            }
        }
        
        private static void FillAllNumberFields(char[,] playingArea)
        {
            int areaRows = playingArea.GetLength(0);
            int areaCols = playingArea.GetLength(1);
            
            for (int row = 0; row < areaRows; row++)
            {
                for (int col = 0; col < areaCols; col++)
                {
                    if (playingArea[row, col] != '*')
                    {
                        char fieldValue = GetFieldValue(playingArea, row, col);
                        playingArea[row, col] = fieldValue;
                    }
                }
            }
        }
        
        private static char GetFieldValue(char[,] playingArea, int row, int col)
        {
            //// the value depends of the number of the mines that surouding its field
            int minesAroundCounter = 0;
            int areaRows = playingArea.GetLength(0);
            int areaCols = playingArea.GetLength(1);
            
            if (row - 1 >= 0)
            {
                if (playingArea[row - 1, col] == '*')
                { 
                    minesAroundCounter++; 
                }
            }

            if (row + 1 < areaRows)
            {
                if (playingArea[row + 1, col] == '*')
                { 
                    minesAroundCounter++; 
                }
            }

            if (col - 1 >= 0)
            {
                if (playingArea[row, col - 1] == '*')
                { 
                    minesAroundCounter++;
                }
            }

            if (col + 1 < areaCols)
            {
                if (playingArea[row, col + 1] == '*')
                { 
                    minesAroundCounter++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (playingArea[row - 1, col - 1] == '*')
                { 
                    minesAroundCounter++; 
                }
            }

            if ((row - 1 >= 0) && (col + 1 < areaCols))
            {
                if (playingArea[row - 1, col + 1] == '*')
                { 
                    minesAroundCounter++; 
                }
            }

            if ((row + 1 < areaRows) && (col - 1 >= 0))
            {
                if (playingArea[row + 1, col - 1] == '*')
                { 
                    minesAroundCounter++; 
                }
            }

            if ((row + 1 < areaRows) && (col + 1 < areaCols))
            {
                if (playingArea[row + 1, col + 1] == '*')
                { 
                    minesAroundCounter++; 
                }
            }

            return char.Parse(minesAroundCounter.ToString());
        }
    }
}
