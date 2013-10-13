using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixWalk.Test
{
    [TestClass]
    public class HasPossibleDirection
    {
        [TestMethod]
        public void HasPossibleDirection_HasNot()
        {
            int[,] matrix = new int[5, 5]{
                                  {0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0},
                                  {0, 0, 1, 1, 1},
                                  {0, 0, 1, 0, 1},
                                  {0, 0, 1, 1, 1},
                              };

            var result = MatrixWalk.HasPossibleDirection(matrix, 3, 3);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasPossibleDirection_HasDownLeft()
        {
            int[,] matrix = new int[5, 5]{
                                  {0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0},
                                  {0, 0, 1, 1, 1},
                                  {0, 0, 1, 0, 1},
                                  {0, 0, 0, 1, 1},
                              };

            var result = MatrixWalk.HasPossibleDirection(matrix, 3, 3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasPossibleDirection_HasNotCorner()
        {
            int[,] matrix = new int[5, 5]{
                                  {0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0},
                                  {0, 0, 0, 1, 1},
                                  {0, 0, 0, 1, 0},
                              };

            var result = MatrixWalk.HasPossibleDirection(matrix, 4, 4);
            Assert.IsTrue(result);
        }
    }
}
