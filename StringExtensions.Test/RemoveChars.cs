using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensions.Test
{
    [TestClass]
    public class RemoveChars
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InputStringIsNull_ThrowNullReferenceException()
        {
            // Arrange
            string input = null;

            // Act
            input.RemoveChars(new List<char> { 'a' });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InputParametersIsNull_ThrowArgumentNullException()
        {
            // Arrange
            var input = "Test string with some characters.";

            // Act
            input.RemoveChars(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InputStringAndInputParametersAreNull_ThrowNullReferenceException()
        {
            // Arrange
            string input = null;

            // Act
            input.RemoveChars(null);
        }

        [TestMethod]
        public void InputString_RemoveOneCharacter()
        {
            // Arrange
            var input = "Test string with some characters.";
            var expected = "Test string with some chrcters.";

            // Act
            var actual = input.RemoveChars(new List<char> {'a'});

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InputString_RemoveTwoCharacters()
        {
            // Arrange
            var input = "Test string with some characters.";
            var expected = "Test strng wth some chrcters.";

            // Act
            var actual = input.RemoveChars(new List<char> {'a', 'i'});

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InputString_RemoveLineBreaksAndTabs()
        {
            // Arrange
            var input = "\tTest string with some characters. \n" +
                "This is \t multiline text. \r\n";
            var expected = "Test string with some characters. This is  multiline text. ";

            // Act
            var actual = input.RemoveChars(new List<char> {'\n', '\t', '\r'});

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
