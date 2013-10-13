using System;
namespace BalloonsPopGame.Common
{
  public interface IPlayer
    {
        string Name { get; }

        int Score { get; }
    }
}
