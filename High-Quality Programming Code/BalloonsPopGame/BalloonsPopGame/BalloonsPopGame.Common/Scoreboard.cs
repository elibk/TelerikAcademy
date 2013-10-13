using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPopGame.Common
{
    public class Scoreboard
    {
        private IList<IPlayer> players;

        public Scoreboard(IList<IPlayer> players)
        {
            this.Players = players;
        }

        protected IList<IPlayer> Players
        {
            get
            {
                return this.players;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value for 'Scores' can not be 'null'.");
                }

                this.players = value;
            }
        }

        public void AddPlayer(string playerName, int playerScore)
        {
            IPlayer newPlayer = new Player(playerName, playerScore);

            this.Players.Add(newPlayer);

            this.Players = this.Players.OrderBy(x => x.Score).ToList();

            if (this.Players.Count > 5)
            {
                this.Players.RemoveAt(this.Players.Count - 1);
            }
        }

        public IEnumerable<IPlayer> GetTopFivePlayers()
        {
            return this.Players;
        }
    }
}
