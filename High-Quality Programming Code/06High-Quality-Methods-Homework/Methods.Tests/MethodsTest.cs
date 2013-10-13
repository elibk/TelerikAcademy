////
namespace Methods.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MethodsTest
    {
        [TestMethod]
        public void ConvertDigitToEnglishWord_DigitIs1()
        {
            string actual = Methods.ConvertDigitToEnglishWord(1);
            Assert.AreEqual("one", actual, "The output schoul be 2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertDigitToEnglishWord_DigitIsInvalid()
        {
            string actual = Methods.ConvertDigitToEnglishWord(345);
        }
    }
}
