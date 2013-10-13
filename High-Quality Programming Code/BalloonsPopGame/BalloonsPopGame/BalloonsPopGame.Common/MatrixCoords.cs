using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPopGame.Common
{
    public class MatrixCoords
    {
        private int xCoord, yCoord;

        public MatrixCoords(int yCoord, int xCoord)
        {
            this.YCoord = yCoord;
            this.XCoord = xCoord;
        }

        public int XCoord
        {
            get
            {
                return this.xCoord;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value for 'XCoord' can not be negative number.");
                }
                this.xCoord = value;
            }
        }

        public int YCoord
        {
            get
            {
                return this.yCoord;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value for 'YCoord' can not be negative number.");
                }
                this.yCoord = value;
            }
        }
    }
}
