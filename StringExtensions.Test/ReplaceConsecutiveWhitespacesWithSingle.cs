using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensions.Test
{
    [TestClass]
    public class ReplaceConsecutiveWhitespacesWithSingle
    {
        [TestMethod]
        [DataRow(@"word")]
        public void OneWord_WithoutSpaces_Return_InputString(string input)
        {
            // Arrange
            var expected = input;

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(@" word")]
        [DataRow(@"word ")]
        [DataRow(@" word ")]
        public void OneWord_SingleSpaces_Return_InputString(string input)
        {
            // Arrange
            var expected = input;

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(@"word1 word2")]
        [DataRow(@" word1 word2")]
        [DataRow(@"word1 word2 ")]
        [DataRow(@" word1 word2 ")]
        public void TwoWords_SingleSpaces_Return_InputString(string input)
        {
            // Arrange
            var expected = input;

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(@"  word")]
        [DataRow(@"   word")]
        [DataRow(@"     word")]
        public void OneWord_MultipleSpacesAtBeginning_Return_StringWithOneSpace(string input)
        {
            // Arrange
            var expected = " word";

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(@"word  ")]
        [DataRow(@"word   ")]
        [DataRow(@"word      ")]
        public void OneWord_MultipleSpacesAtEnd_Return_StringWithOneSpace(string input)
        {
            // Arrange
            var expected = "word ";

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(@"  word1 word2")]
        [DataRow(@"    word1 word2")]
        [DataRow(@"       word1 word2")]
        public void TwoWords_MultipleSpacesAtBeginning_Return_StringWithSingleSpaces(string input)
        {
            // Arrange
            var expected = " word1 word2";

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(@"word1 word2  ")]
        [DataRow(@"word1 word2     ")]
        [DataRow(@"word1 word2        ")]
        public void TwoWords_MultipleSpacesAtEnd_Return_StringWithSingleSpaces(string input)
        {
            // Arrange
            var expected = "word1 word2 ";

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(@"word1  word2")]
        [DataRow(@"word1    word2")]
        [DataRow(@"word1      word2")]
        public void TwoWords_MultipleSpacesInBetween_Return_StringWithSingleSpaces(string input)
        {
            // Arrange
            var expected = "word1 word2";

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(@" word1  word2  ")]
        [DataRow(@"   word1    word2 ")]
        [DataRow(@"    word1      word2    ")]
        public void TwoWords_MultipleSpacesEverywhere_Return_StringWithSingleSpaces(string input)
        {
            // Arrange
            var expected = " word1 word2 ";

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ');

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
