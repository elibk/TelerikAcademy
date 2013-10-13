using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06Horse
{
    public struct Coords
    {
        public int Y { get; set; }
        public int X { get; set; }

        public Coords(int y, int x)
            : this()
        {
            this.Y = y;
            this.X = x;
        }


    }
}
