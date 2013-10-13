////
namespace H14Labyrinth
{
    using System;
    using System.Linq;

    public struct Coords
    {
        public Coords(int y, int x) : this()
        {
            this.Y = y;
            this.X = x;
        }

        public int Y { get; set; }

        public int X { get; set; }
    }
}
