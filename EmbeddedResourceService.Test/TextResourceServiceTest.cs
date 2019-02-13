using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmbeddedResourceService.Test
{
    [TestClass]
    public class TextResourceServiceTest
    {
        private readonly ITextResource _service;

        public TextResourceServiceTest()
        {
            _service = new TextResource(typeof(TextResourceServiceTest));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTextResourceServiceWithNullParameter_ThrowArgumentNullException()
        {
            // Arrange
            var service = new TextResource(null);
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
        public async Task ReadAllTextAsync()
        {
            // Arrange
            var expected = "This file contains simple text data.";

            // Act
            var actual = await _service.ReadToEndAsync(@"EmbeddedResources.plaintext.txt");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task ReadAllTextAsyncFromNonExistentResource_ReadEmptyString()
        {
            // Arrange
            var expected = string.Empty;

            // Act
            var actual = await _service.ReadToEndAsync(@"nonExistentFile.txt");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
