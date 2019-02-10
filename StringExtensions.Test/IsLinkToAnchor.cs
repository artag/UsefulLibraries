using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensions.Test
{
    [TestClass]
    public class IsLinkToAnchor
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LinkIsNull_ThrowArgumentNullException()
        {
            // Arrange
            string link = null;

            // Act
            link.IsLinkToAnchor();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        public void LinkIsEmptyOrWhitespace_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkToAnchor();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("#example")]
        [DataRow("../html-link.html#generator")]
        [DataRow("text.html#bottom")]
        [DataRow("#top")]
        [DataRow("/biographies.html#serious")]
        [DataRow("/rms-lifestyle.html#cards")]
        [DataRow("#lisp")]
        public void LinkToAnchor_ReturnTrue(string link)
        {
            // Act
            var actual = link.IsLinkToAnchor();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("link.html")]
        [DataRow("index.html")]
        [DataRow("images/super-image.jpg")]
        [DataRow("URL")]
        [DataRow("../../example/knob.html")]
        [DataRow("http://baidu.cn")]
        [DataRow("http://google.com")]
        [DataRow("https://www.fsf.org/resources/hw/systems")]
        [DataRow("/")]
        [DataRow("/e")]
        [DataRow("/ebooks.pdf")]
        public void LinkToHtmlPage_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkToAnchor();

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
