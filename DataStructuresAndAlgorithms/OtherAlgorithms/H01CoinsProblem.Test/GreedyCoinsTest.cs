using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace H01CoinsProblem.Test
{
    [TestClass]
    public class GreedyCoinsTest
    {
        [TestMethod]
        public void GetNumberOfCoins_Sum33()
        {
           Bill bill = GreedyCoins.GetNumberOfCoins(33);

           StringBuilder actial = new StringBuilder();

           for (int i = 0; i < bill.coins.Count; i++)
           {
               actial.Append(bill.coins[i].Value);
               actial.Append(" ");
           }

           actial.Length--;
           string expected = "5 5 5 5 5 5 2 1";
           Assert.AreEqual(expected, actial.ToString());
        }
    }
}
