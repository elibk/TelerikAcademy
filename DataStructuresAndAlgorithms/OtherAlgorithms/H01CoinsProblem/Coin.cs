using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H01CoinsProblem
{
    public class Coin
    {
        private long value;

        public Coin(long value)
        {
            this.Value = value;
        }

        public long Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}
