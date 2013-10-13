using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H01CoinsProblem
{
    public class GreedyCoins
    {
        private static long[] coinsValues = { 5, 2, 1 }; 

        public static Bill GetNumberOfCoins(long sum)
        {
            Bill bill = new Bill();

            int currentCoinIndex = 0;

            while (sum != 0)
            {
                sum -= coinsValues[currentCoinIndex];
                if (sum < 0)
                {
                    sum += coinsValues[currentCoinIndex];
                    currentCoinIndex++;
                }
                else
                {
                    bill.coins.Add(new Coin(coinsValues[currentCoinIndex]));
                }

                

                
            }

            return bill;
        }
    }
}
