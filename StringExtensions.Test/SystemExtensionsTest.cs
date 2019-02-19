using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensions.Test
{
    [TestClass]
    public class SystemExtensionsTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckNullOrWhiteSpace_InputIsNull_ThrowArgumentNullException()
        {
            // Arrange
            string input = null;

            // Act
            input.CheckNullOrWhiteSpace();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckNullOrWhiteSpace_InputIsEmpty_ThrowArgumentException()
        {
            // Arrange
            var input = string.Empty;

            // Act
            input.CheckNullOrWhiteSpace();
        }

        [TestMethod]
        [DataRow(" ")]
        [DataRow("   ")]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckNullOrWhiteSpace_InputIsWhiteSpace_ThrowArgumentException(string input)
        {
            // Act
            input.CheckNullOrWhiteSpace();
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void TestIsNullOrEmpty_StringIsNullOrEmpty_ReturnTrue(string input)
        {
            // Act
            var actual = input.IsNullOrEmpty();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow(" ")]
        [DataRow("  ")]
        [DataRow("This is string.")]
        public void TestIsNullOrEmpty_StringIsNotNullOrEmpty_ReturnFalse(string input)
        {
            // Act
            var actual = input.IsNullOrEmpty();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void TestIsNotNullOrEmpty_StringIsNullOrEmpty_ReturnFalse(string input)
        {
            // Act
            var actual = input.IsNotNullOrEmpty();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow(" ")]
        [DataRow("  ")]
        [DataRow("This is string.")]
        public void TestIsNotNullOrEmpty_StringIsNotNullOrEmpty_ReturnTrue(string input)
        {
            // Act
            var actual = input.IsNotNullOrEmpty();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestIsNullOrWhiteSpace_StringIsNull_ReturnTrue()
        {
            // Arrange
            string input = null;

            // Act
            var actual = input.IsNullOrWhiteSpace();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("  ")]
        public void TestIsNullOrWhiteSpace_StringIsEmptyOrWhiteSpace_ReturnTrue(string input)
        {
            // Act
            var actual = input.IsNullOrWhiteSpace();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("/")]
        [DataRow("42")]
        [DataRow("This is string.")]
        public void TestIsNullOrWhiteSpace_StringWithSymbols_ReturnFalse(string input)
        {
            // Act
            var actual = input.IsNullOrWhiteSpace();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("   ")]
        public void TestIsNotNullOrWhiteSpace_StringIsNullOrEmptyOrWhiteSpace_ReturnFalse(
            string input)
        {
            // Act
            var actual = input.IsNotNullOrWhiteSpace();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("/")]
        [DataRow("42")]
        [DataRow("This is string.")]
        public void TestIsNotNullOrWhiteSpace_StringWithSymbols_ReturnTrue(string input)
        {
            // Act
            var actual = input.IsNotNullOrWhiteSpace();

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
