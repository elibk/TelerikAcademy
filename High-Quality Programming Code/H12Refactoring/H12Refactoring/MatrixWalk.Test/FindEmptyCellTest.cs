using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixWalk.Test
{
    [TestClass]
    public class FindEmptyCellTest
    {
        [TestMethod]
        public void FindEmptyCell_ZeroMatrix()
        {

            int[,] input = new int[5, 5]
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
         
            };

            int x,
                y;

            MatrixWalk.FindEmptyCell(input, out x, out y);

            var result = x == 0 && y == 0;

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void FindEmptyCell_NoZerosInMatrix()
        {

            int[,] input = new int[5, 5]
            {
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1},
         
            };

            int x,
                y;

            MatrixWalk.FindEmptyCell(input, out x, out y);

            var result = x == default(int) && y == default(int);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void FindEmptyCell_OnlyCellAtPositionx1y1isEmpty()
        {

            int[,] input = new int[5, 5]
            {
                {1, 1, 1, 1, 1},
                {1, 0, 1, 1, 1},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1},
         
            };

            int x,
                y;

            MatrixWalk.FindEmptyCell(input, out x, out y);

            var result = x == 1 && y == 1;

            Assert.IsTrue(result);

        }
    }
}
