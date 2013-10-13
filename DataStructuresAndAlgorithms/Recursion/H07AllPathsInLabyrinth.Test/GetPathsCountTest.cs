using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H07AllPathsInLabyrinth.Test
{
    [TestClass]
    public class GetPathsCountTest
    {
        [TestMethod]
        public void EmptyMatrix5X5()
        {
            char[,] matrix = new char[5, 5];

            matrix[0, 3] = 's';

            matrix[3, 1] = 'e';

            int actual = Labyrinth.PerformWalk(matrix);

            Assert.AreEqual(4914, actual);
        }
    }
}
