namespace H01TreeNodes.Test
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TreeControlerTest
    {
        [TestMethod]
        public void GetPathsTreversingFromTheRoots_SumSix()
        {
            string[] lines = 
            {
                "7",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1"
            };

            var nodes = TreeControler.ParseToTree(lines);
            var paths = TreeControler.GetPathsTreversingFromTheRoots(nodes, 6);

            var expected = "| 2 4 || 5 1 || 6 |";
            var actual = new StringBuilder();

            foreach (var path in paths)
            {
                actual.Append('|');
                foreach (var node in path)
                {
                    actual.Append(" " + node.Value);
                }

                actual.Append(" |");
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void GetPathsTreversingFromTheRoots_SumNine()
        {
            string[] lines = 
            {
                "7",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1"
            };

            var nodes = TreeControler.ParseToTree(lines);
            var paths = TreeControler.GetPathsTreversingFromTheRoots(nodes, 9);

            var expected = "| 3 5 1 || 3 2 4 |";
            var actual = new StringBuilder();

            foreach (var path in paths)
            {
                actual.Append('|');
                foreach (var node in path)
                {
                    actual.Append(" " + node.Value);
                }

                actual.Append(" |");
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void GetPathsTreversingFromTheRoots_Sum8()
        {
            string[] lines = 
            {
                "7",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1"
            };

            var nodes = TreeControler.ParseToTree(lines);
            var paths = TreeControler.GetPathsTreversingFromTheRoots(nodes, 8);

            var expected = "| 3 5 || 3 5 0 |";
            var actual = new StringBuilder();

            foreach (var path in paths)
            {
                actual.Append('|');
                foreach (var node in path)
                {
                    actual.Append(" " + node.Value);
                }

                actual.Append(" |");
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void GetPathsTreversingFromTheRoots_Sum5()
        {
            string[] lines = 
            {
                "7",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1"
            };

            var nodes = TreeControler.ParseToTree(lines);
            var paths = TreeControler.GetPathsTreversingFromTheRoots(nodes, 5);

            var expected = "| 3 2 || 5 || 5 0 |";
            var actual = new StringBuilder();

            foreach (var path in paths)
            {
                actual.Append('|');
                foreach (var node in path)
                {
                    actual.Append(" " + node.Value);
                }

                actual.Append(" |");
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void GetPathsTreversingFromTheRoots_Sum7()
        {
            string[] lines = 
            {
                "8",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1",
                "0 7",
            };

            var nodes = TreeControler.ParseToTree(lines);
            var paths = TreeControler.GetPathsTreversingFromTheRoots(nodes, 7);

            var expected = "| 0 7 || 7 |";
            var actual = new StringBuilder();

            foreach (var path in paths)
            {
                actual.Append('|');
                foreach (var node in path)
                {
                    actual.Append(" " + node.Value);
                }

                actual.Append(" |");
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void GetPathsTreversingFromTheRoots_SumSixTreeEightNodes()
        {
            string[] lines = 
            {
                "8",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1",
                "0 7",
            };

            var nodes = TreeControler.ParseToTree(lines);
            var paths = TreeControler.GetPathsTreversingFromTheRoots(nodes, 6);

            var expected = "| 2 4 || 5 1 || 6 |";
            var actual = new StringBuilder();

            foreach (var path in paths)
            {
                actual.Append('|');
                foreach (var node in path)
                {
                    actual.Append(" " + node.Value);
                }

                actual.Append(" |");
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void GetPathsTreversingFromTheRoots_SumNineTreeEightNodes()
        {
            string[] lines = 
            {
                "8",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1",
                "0 7",
            };

            var nodes = TreeControler.ParseToTree(lines);
            var paths = TreeControler.GetPathsTreversingFromTheRoots(nodes, 9);

            var expected = "| 3 5 1 || 3 2 4 |";
            var actual = new StringBuilder();

            foreach (var path in paths)
            {
                actual.Append('|');
                foreach (var node in path)
                {
                    actual.Append(" " + node.Value);
                }

                actual.Append(" |");
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void GetPathsTreversingFromTheRoots_Sum8TreeEightNodes()
        {
            string[] lines = 
            {
                "8",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1",
                "0 7",
            };

            var nodes = TreeControler.ParseToTree(lines);
            var paths = TreeControler.GetPathsTreversingFromTheRoots(nodes, 8);

            var expected = "| 3 5 || 3 5 0 |";
            var actual = new StringBuilder();

            foreach (var path in paths)
            {
                actual.Append('|');
                foreach (var node in path)
                {
                    actual.Append(" " + node.Value);
                }

                actual.Append(" |");
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void GetPathsTreversingFromTheRoots_Sum5TreeEightNodes()
        {
            string[] lines = 
            {
                "8",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1",
                "0 7",
            };

            var nodes = TreeControler.ParseToTree(lines);
            var paths = TreeControler.GetPathsTreversingFromTheRoots(nodes, 5);

            var expected = "| 3 2 || 5 || 5 0 |";
            var actual = new StringBuilder();

            foreach (var path in paths)
            {
                actual.Append('|');
                foreach (var node in path)
                {
                    actual.Append(" " + node.Value);
                }

                actual.Append(" |");
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void GetSubtreesWithSum_Sum6TreeSevenNodes()
        {
            string[] lines = 
            {
                "7",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1",
            };

            var nodes = TreeControler.ParseToTree(lines);
            var roots = TreeControler.GetSubtreesWithSum(nodes, 6);

            var expected = "| 2 || 6 |";
            var actual = new StringBuilder();

            foreach (var node in roots)
            {
                actual.Append('|');
                
                actual.Append(" " + node.Value);

                actual.Append(" |");
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void GetSubtreesWithSum_Sum12TreeSevenNodes()
        {
            string[] lines = 
            {
                "7",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1",
            };

            var nodes = TreeControler.ParseToTree(lines);
            var roots = TreeControler.GetSubtreesWithSum(nodes, 12);

            var expected = "| 5 |";
            var actual = new StringBuilder();

            foreach (var node in roots)
            {
                actual.Append('|');

                actual.Append(" " + node.Value);

                actual.Append(" |");
            }

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
