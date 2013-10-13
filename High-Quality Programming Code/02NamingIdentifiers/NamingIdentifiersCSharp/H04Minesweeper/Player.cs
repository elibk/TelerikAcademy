////
namespace H04Minesweeper
{
    using System;
    using System.Linq;

    public class Player
    {
        private string name;
        private int score;

        public Player() 
        { 
        }

        public Player(string name, int points)
        {
            this.Name = name;
            this.Score = points;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }
    }
}
