using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H07AllPathsInLabyrinth
{
    public struct Coords
    {
        public Coords(int y, int x)
            : this()
        {
            this.Y = y;
            this.X = x;
            
        }

        public int Y { get; set; }

        public int X { get; set; }

    }
}
