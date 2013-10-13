////
namespace H04MaxSequenceOfEqualElements.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MaxSequenceOfEqualElementsTest
    {
        [TestMethod]
        public void GetMaxSequenceOfEqualElements_EqualInTheBegining()
        {
            List<int> sequence = new List<int> { 2, 2, 2, 1, 2, 1, 1, 23 };

            var actual = MaxSequenceOfEqualElements.GetMaxSequenceOfEqualElements(sequence);

            Assert.IsTrue(actual.Count == 3);
            Assert.IsTrue(actual[0] == 2);
        }

        [TestMethod]
        public void GetMaxSequenceOfEqualElements_EqualInTheMiddle()
        {
            List<int> sequence = new List<int> { 2, 2, 2, 1, 1, 1, 1, 23 };

            var actual = MaxSequenceOfEqualElements.GetMaxSequenceOfEqualElements(sequence);

            Assert.IsTrue(actual.Count == 4);
            Assert.IsTrue(actual[0] == 1);
        }

        [TestMethod]
        public void GetMaxSequenceOfEqualElements_EqualInTheEnd()
        {
            List<int> sequence = new List<int> { 2, 2, 2, 1, 1, 1, 1 };

            var actual = MaxSequenceOfEqualElements.GetMaxSequenceOfEqualElements(sequence);

            Assert.IsTrue(actual.Count == 4);
            Assert.IsTrue(actual[0] == 1);
        }

        [TestMethod]
        public void GetMaxSequenceOfEqualElements_TwoSequanceWithSameLength()
        {
            List<int> sequence = new List<int> { 2, 2, 2, 1, 1, 1 };

            var actual = MaxSequenceOfEqualElements.GetMaxSequenceOfEqualElements(sequence);

            Assert.IsTrue(actual.Count == 3);
            Assert.IsTrue(actual[0] == 2);
        }

        [TestMethod]
        public void GetMaxSequenceOfEqualElements_NoEqualElemnts()
        {
            List<int> sequence = new List<int> { 2, 3, 5, 6 };

            var actual = MaxSequenceOfEqualElements.GetMaxSequenceOfEqualElements(sequence);

            Assert.IsTrue(actual.Count == 1);
            Assert.IsTrue(actual[0] == 2);
        }
    }
}
