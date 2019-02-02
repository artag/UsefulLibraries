using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensions.Test
{
    [TestClass]
    public class ReplaceConsecutiveCharsWithSingle
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InputStringIsNull_ThrowNullReferenceException()
        {
            // Arrange
            string input = null;

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle('a');
        }

        [TestMethod]
        public void InputStringIsEmpty_ReturnsEmptyString()
        {
            // Arrange
            var input = string.Empty;
            var expected = string.Empty;

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle('a');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(@"abcd")]
        [DataRow(@"abbcd")]
        [DataRow(@"abbbbbcd")]
        [DataRow(@"abbbbbbbbbbcd")]
        public void OneWord_MultipleB_Return_StringWithOneB(string input)
        {
            // Arrange
            var expected = @"abcd";

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle('b');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(@"Simpliest Number 666-666-6666")]
        [DataRow(@"Simpliest Number 66-6666-666")]
        [DataRow(@"Simpliest Number 6666-66-6")]
        public void ThreeWords_Multiple6_Return_StringWithOne6(string input)
        {
            // Arrange
            var expected = @"Simpliest Number 6-6-6";

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle('6');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(@"Language C# 7.3")]
        [DataRow(@"Language C### 7.3")]
        [DataRow(@"Language C##### 7.3")]
        public void TwoWords_MultipleSymbolSharp_Return_StringWithOneSymbolSharp(string input)
        {
            // Arrange
            var expected = @"Language C# 7.3";

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle('#');

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
