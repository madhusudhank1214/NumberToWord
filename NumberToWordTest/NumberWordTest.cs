using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToText;

namespace NumberToWordTest
{
    [TestClass]
    public  class NumberWordTest
    {
        [TestMethod]
        public void NumberToWordsTestMethod()
        {
            //Arrange
            var numberToWord = new NumberToWord();
            var result = numberToWord.NumberToWords(3);
            Assert.AreEqual("three", result.ToLower());
        }
        [TestMethod]
        public void NumberToWordsTestFailMethod()
        {
            //Arrange
            var numberToWord = new NumberToWord();
            var result = numberToWord.NumberToWords(0);
            Assert.AreNotEqual("one", result.ToLower());
        }
        
    }
}
