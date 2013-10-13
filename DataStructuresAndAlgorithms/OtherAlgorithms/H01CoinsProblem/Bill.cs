using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H01CoinsProblem
{
    public class Bill
    {
        public List<Coin> coins { get; set; }
        public Bill()
        {
            this.coins = new List<Coin>();
        }
    }
}
