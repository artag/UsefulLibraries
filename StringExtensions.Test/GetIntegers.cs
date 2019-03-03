using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensions.Test
{
    [TestClass]
    public class GetIntegers
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StringIsNull_ThrowNullReferenceException()
        {
            // Arrange
            string input = null;

            // Act
            input.GetIntegers();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("   ")]
        public void StringIsEmptyOrWhitespace_ReturnEmptyEnumeration(string input)
        {
            // Arrange
            var expected = new List<int>();

            // Act
            var actual = input.GetIntegers().ToList();

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        [DataRow("Input string without numbers.")]
        public void StringWithoutNumbers_ReturnEmptyEnumeration(string input)
        {
            // Arrange
            var expected = new List<int>();

            // Act
            var actual = input.GetIntegers().ToList();

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        [DataRow("Input string with one number: 42")]
        [DataRow("42 is the sum of the first sixth positive even numbers.")]
        [DataRow("Alice's Adventures in Wonderland has 42 illustrations.")]
        [DataRow("BetweenPoints.42.integer")]
        [DataRow("Between symbols_#42&_")]
        public void StringWithOneNumber_ReturnEnumerationWithOneItem(string input)
        {
            // Arrange
            var expected = new List<int> { 42 };

            // Act
            var actual = input.GetIntegers().ToList();

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        [DataRow("Test extreme numbers -2147483649 and 2147483648.")]
        [DataRow("88888888888 so big number")]
        public void StringWithNumbers_MoreThanIntMax_ReturnEmptyEnumeration(string input)
        {
            // Arrange
            var expected = new List<int>();

            // Act
            var actual = input.GetIntegers().ToList();

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        [DataRow("Add numbers 5, 23 and 666.")]
        [DataRow("5 23 and 666 are testing numbers.")]
        [DataRow("Need to add: 5; 23; 666")]
        [DataRow("5;23;666;")]
        [DataRow("5,23,666")]
        [DataRow("5.23.666")]
        [DataRow("5 23 666")]
        [DataRow("|5|23|666|")]
        public void StringWithThreeNumbers_ReturnEnumerationWithThreeItems(string input)
        {
            // Arrange
            var expected = new List<int> { 5, 23, 666 };

            // Act
            var actual = input.GetIntegers().ToList();

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        [DataRow("The big number 2247483648 isn't added. Added numbers 256 and 1024.")]
        [DataRow("256 and 1024. The big number -7247483648 isn't added.")]
        public void StringWithThreeNumbers_OneMoreThanIntMax_ReturnEnumerationWithTwoItems(
            string input)
        {
            // Arrange
            var expected = new List<int> { 256, 1024 };

            // Act
            var actual = input.GetIntegers().ToList();

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
