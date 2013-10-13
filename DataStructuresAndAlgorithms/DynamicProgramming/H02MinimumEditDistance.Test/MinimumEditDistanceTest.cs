using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H02MinimumEditDistance.Test
{
    [TestClass]
    public class MinimumEditDistanceTest
    {
        [TestMethod]
        public void Solve_Example()
        {
           double actual = MinimumEditDistance.Solve("developer", "enveloped");
            
           Assert.AreEqual(2.7, actual);
        }
    }
}
