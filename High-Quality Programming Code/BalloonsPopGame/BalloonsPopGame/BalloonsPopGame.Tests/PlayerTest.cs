using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalloonsPopGame.Common;

namespace BalloonsPopGame.Tests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void ToString_PlayerWithZeroForScore()
        {
            IPlayer player = new Player("Stamat", 0);

            string expected = "Stamat --> 0 moves";
            string actual = player.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_PlayerWithOneForScore()
        {
            IPlayer player = new Player("Stamat", 1);

            string expected = "Stamat --> 1 move";
            string actual = player.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
