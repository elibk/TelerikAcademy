using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H08FindPathInLabyrinth.Test
{
    [TestClass]
    public class LabyrinthTest
    {
        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public void IsPathExists_EmptyMatrix100X100()
        {
            char[,] matrix = new char[84, 84];

            matrix[0, 3] = 's';

            matrix[3, 1] = 'e';

            Assert.IsTrue(Labyrinth.IsPathExists(matrix));
        }

        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public void IsPathExists_EmptyMatrix100X100NoPath()
        {
            char[,] matrix = new char[84, 84];

            matrix[0, 3] = 's';

            //matrix[3, 1] = 'e';

            Assert.IsFalse(Labyrinth.IsPathExists(matrix));
        }
    }
}
