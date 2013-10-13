using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BalloonsPopGame.Common
{
    public class GameManager
    {
        ConsoleUserInterface ui = new ConsoleUserInterface();
        private GameEngine engine;
        private int[,] gameField;
        private Scoreboard scoreboard;

        public GameManager(ConsoleUserInterface ui, GameEngine gameEngine, Scoreboard scoreboard)
        {
            this.Ui = ui;
            this.Engine = gameEngine;
            this.Scoreboard = scoreboard;
        }

        public Scoreboard Scoreboard
        {
            get
            {
                return this.scoreboard;
            }
           private set
            {
                this.scoreboard = value;
            }
        }

        public GameEngine Engine
        {
            get
            {
                return this.engine;
            }
           private set
            {
                this.engine = value;
            }
        }

        public ConsoleUserInterface Ui
        {
            get
            {
                return this.ui;
            }
            private set
            {
                this.ui = value;
            }
        }

        public void Initialize()
        {
            engine.GameOver += (sender, evArgs) =>
            {
               string playerNick = ui.GetNickName();
               int playerScore = engine.CurrentPlayerScore;

               scoreboard.AddPlayer(playerNick, playerScore);

               gameField = engine.InitializeGameField();
               ui.DisplayGameField(gameField);
            };

            gameField = engine.InitializeGameField();
            ui.DisplayGreeting();
            ui.DisplayGameField(gameField);
        }

        public void Play()
        {
            ui.AskForCommand();
            string command = this.ParseCommand();
            switch (command)
            {
                case "exit":
                    ui.DisplayGoodbay();
                    engine.ExitTheGame();
                    break;
                case "restart":
                    Initialize();
                    break;
                case "top":
                    IEnumerable<IPlayer> scores = scoreboard.GetTopFivePlayers();
                    ui.DisplayLeaderboard(scores);
                    break;
                default:
                    if (Regex.IsMatch(command, @"\d+\s\d+"))
                    {
                        try
                        {
                            MatrixCoords coords = ParseToCoordinates(command);
                            int[,] gameField = engine.PerformMovement(coords);
                            ui.DisplayGameField(gameField);
                        }
                        catch (CoordinatesOutOfRangeException ex)
                        {
                            ui.InformAboutInvalidCommand(ex.Message);
                        }
                        catch (InvalidMoveException)
                        {
                            ui.InformAboutInvalidCommand("Invalid Move! Can not pop a baloon at that place!!");
                        }
                    }
                    else
                    {
                        ui.InformAboutInvalidCommand("Unknown command!");
                    }

                    break;
            }
        }

        private MatrixCoords ParseToCoordinates(string command)
        {
            int rowCoord, colCoord;
            string[] fieldCoods = command.Split(' ');

            bool yCoord = Int32.TryParse(fieldCoods[0], out rowCoord);
            bool xCoord = Int32.TryParse(fieldCoods[1], out colCoord);
            if (yCoord && xCoord)
            {
                if (rowCoord <= 0 || rowCoord >= gameField.g)
                {
                    Console.WriteLine("coords.YCoord out of range");
                    //return;
                }

                if (coords.XCoord <= 0 || coords.XCoord >= gameFieldRowsCount)
                {
                    Console.WriteLine("coords.XCoord out of range");
                    //return;
                }
            }

            
            return new MatrixCoords(rowCoord, colCoord);

        }

        private string ParseCommand()
        {
            string command = ui.ReadCommand();
            
            Regex regex = new Regex(@"[ ]{2,}", RegexOptions.None);
            command = command.Trim();
            command = regex.Replace(command, @" ");

            return command;
        }
    }
}
