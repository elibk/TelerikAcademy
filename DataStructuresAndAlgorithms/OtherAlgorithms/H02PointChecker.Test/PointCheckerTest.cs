using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H02PointChecker.Test
{
    [TestClass]
    public class PointCheckerTest
    {
        [TestMethod]
        public void IsPointWithinTriangle_SimpleWithin()
        {
            //0, 0, 20, 0, 10, 30, 10, 15

            Point a = new Point(0, 0);
            Point b = new Point(20, 0);
            Point c = new Point(10, 30);
            Point point = new Point(10, 15);

            PointChecker checker = new PointChecker();

            Assert.IsTrue(checker.IsPointWithinTriangle(a, b, c, point));
        }

        [TestMethod]
        public void IsPointWithinTriangle_SimpleOutOf()
        {
            //0, 0, 20, 0, 10, 30, 25, 15

            Point a = new Point(0, 0);
            Point b = new Point(20, 0);
            Point c = new Point(10, 30);
            Point point = new Point(25, 15);

            PointChecker checker = new PointChecker();

            Assert.IsFalse(checker.IsPointWithinTriangle(a, b, c, point));
        }
    }
}
