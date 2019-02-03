using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmbeddedResourceService.Test
{
    [TestClass]
    public class TextResourceServiceTest
    {
        private readonly ITextResourceService _service;

        public TextResourceServiceTest()
        {
            _service = new TextResourceService(typeof(TextResourceServiceTest));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTextResourceServiceWithNullParameter_ThrowArgumentNullException()
        {
            // Arrange
            var service = new TextResourceService(null);
        }

        [TestMethod]
        public void ReadAllText()
        {
            // Arrange
            var expected = "This file contains simple text data.";

            // Act
            var actual = _service.ReadToEnd(@"EmbeddedResources.plaintext.txt");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadAllTextFromNonExistentResource_ReadEmptyString()
        {
            // Arrange
            var expected = string.Empty;

            // Act
            var actual = _service.ReadToEnd(@"nonExistentFile.txt");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadAllTextAsync()
        {
            // Arrange
            var expected = "This file contains simple text data.";

            // Act
            var actual = _service.ReadToEndAsync(@"EmbeddedResources.plaintext.txt").Result;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadAllTextAsyncFromNonExistentResource_ReadEmptyString()
        {
            // Arrange
            var expected = string.Empty;

            // Act
            var actual = _service.ReadToEndAsync(@"nonExistentFile.txt").Result;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
