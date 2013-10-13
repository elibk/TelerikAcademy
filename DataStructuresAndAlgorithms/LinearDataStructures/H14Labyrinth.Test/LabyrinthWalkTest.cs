namespace H14Labyrinth.Test
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LabyrinthWalkTest
    {
        [TestMethod]
        public void PerformWalk_CommonCase()
        {
            string[,] inputField = new string[6, 6]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" },
            };

            string[,] expectedResult = 
            {
                { "3", "4", "5", "x", "u", "x" },
                { "2", "x", "6", "x", "u", "x" },
                { "1", "*", "x", "8", "x", "10" },
                { "2", "x", "6", "7", "8", "9" },
                { "3", "4", "5", "x", "x", "10" },
                { "8", "7", "6", "x", "u", "x" },
            };

            string[,] actualResult = LabyrinthWalk.PerformWalk(inputField);

            string expected = GetMatrixView(expectedResult);
            string actual = GetMatrixView(actualResult);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PerformWalk_CanNotMove()
        {
            string[,] inputField = new string[6, 6]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "x", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" },
            };

            string[,] expectedResult = 
            {
                { "u", "u", "u", "x", "u", "x" },
                { "u", "x", "u", "x", "u", "x" },
                { "x", "*", "x", "u", "x", "u" },
                { "u", "x", "u", "u", "u", "u" },
                { "u", "u", "u", "x", "x", "u" },
                { "u", "u", "u", "x", "u", "x" },
            };

            string[,] actualResult = LabyrinthWalk.PerformWalk(inputField);

            string expected = GetMatrixView(expectedResult);
            string actual = GetMatrixView(actualResult);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PerformWalkBfs_CommonCase()
        {
            string[,] inputField = new string[6, 6]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" },
            };

            string[,] expectedResult = 
            {
                { "3", "4", "5", "x", "u", "x" },
                { "2", "x", "6", "x", "u", "x" },
                { "1", "*", "x", "8", "x", "10" },
                { "2", "x", "6", "7", "8", "9" },
                { "3", "4", "5", "x", "x", "10" },
                { "4", "5", "6", "x", "u", "x" },
            };

            string[,] actualResult = LabyrinthWalk.PerformWalkBfs(inputField);

            string expected = GetMatrixView(expectedResult);
            string actual = GetMatrixView(actualResult);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PerformWalkBfs_CanNotMove()
        {
            string[,] inputField = new string[6, 6]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "x", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" },
            };

            string[,] expectedResult = 
            {
                { "u", "u", "u", "x", "u", "x" },
                { "u", "x", "u", "x", "u", "x" },
                { "x", "*", "x", "u", "x", "u" },
                { "u", "x", "u", "u", "u", "u" },
                { "u", "u", "u", "x", "x", "u" },
                { "u", "u", "u", "x", "u", "x" },
            };

            string[,] actualResult = LabyrinthWalk.PerformWalk(inputField);

            string expected = GetMatrixView(expectedResult);
            string actual = GetMatrixView(actualResult);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PerformWalkBfs_NoLimits()
        {
            string[,] inputField = new string[6, 6]
            {
                { "0", "0", "0", "0", "0", "0" },
                { "0", "0", "0", "0", "0", "0" },
                { "0", "0", "*", "0", "0", "0" },
                { "0", "0", "0", "0", "0", "0" },
                { "0", "0", "0", "0", "0", "0" },
                { "0", "0", "0", "0", "0", "0" },
            };

            string[,] expectedResult = 
            {
                { "4", "3", "2", "3", "4", "5" },
                { "3", "2", "1", "2", "3", "4" },
                { "2", "1", "*", "1", "2", "3" },
                { "3", "2", "1", "2", "3", "4" },
                { "4", "3", "2", "3", "4", "5" },
                { "5", "4", "3", "4", "5", "6" },
            };

            string[,] actualResult = LabyrinthWalk.PerformWalkBfs(inputField);

            string expected = GetMatrixView(expectedResult);
            string actual = GetMatrixView(actualResult);

            Assert.AreEqual(expected, actual);
        }

        private string GetMatrixView(string[,] matrix)
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    result.AppendFormat("{0} ", matrix[row, col]);
                }
                result.Append("|");
            }

            return result.ToString();
        }
    }
}
