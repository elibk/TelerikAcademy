using System;
namespace BalloonsPopGame.Common
{
    interface IScoreboard
    {
        void AddPlayer(IPlayer newPlayer);

        System.Collections.Generic.IEnumerable<IPlayer> GetPlayers();
    }
}
