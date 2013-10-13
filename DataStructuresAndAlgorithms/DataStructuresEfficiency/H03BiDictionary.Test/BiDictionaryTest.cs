namespace H03BiDictionary.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BiDictionaryTest
    {
        [TestMethod]
        public void FindByTwo_GetByTwoKeys()
        {
            BiDictionary<string, char, int> dict = new BiDictionary<string, char, int>();

            dict.Add("e", 'e', 5);

            var actial = dict.FindByBothKeys("e", 'e');
            Assert.AreEqual(1, actial.Count);
            int actualValue = 0;
            foreach (var item in actial)
            {
                actualValue = item;
            }
            
            Assert.AreEqual(5, actualValue);
        }
    }
}
