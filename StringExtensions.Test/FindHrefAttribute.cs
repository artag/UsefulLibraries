using System;
using System.Collections.Generic;
using System.Linq;
using EmbeddedResourceService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensions.Test
{
    [TestClass]
    public class FindHrefAttribute
    {
        private readonly TextResourceService _textResourceService;

        public FindHrefAttribute()
        {
            _textResourceService = new TextResourceService(typeof(FindAnchorTags));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AnchorIsNull_ThrowArgumentNullException()
        {
            // Arrange
            string anchor = null;

            // Act
            anchor.FindHrefAttribute();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        public void AnchorIsEmptyOrWhitespace_ReturnEmptyString(string anchor)
        {
            // Arrange
            var expected = string.Empty;

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("< a href=\"#example\">Example headline</a >")]
        [DataRow("< a href = \"#example\">Example headline</a >")]
        [DataRow("< a href=\"#example\"></a >")]
        [DataRow("<a href=\"#example\"></a>")]
        [DataRow("<a  href=\"#example\" ></a>")]
        public void LinkToAnchorOnSamePage(string anchor)
        {
            // Arrange
            var expected = "#example";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("<a href=\"../html-link.html#generator\">HTML link code generator</a>")]
        [DataRow("<a href = \"../html-link.html#generator\">HTML link code generator</a>")]
        [DataRow("< a  href=\"../html-link.html#generator\" >HTML link code generator</a>")]
        [DataRow("<a href=\"../html-link.html#generator\"></a>")]
        [DataRow("<a href='../html-link.html#generator'></a>")]
        public void LinkToAnchorOnAnotherPage(string anchor)
        {
            // Arrange
            var expected = "../html-link.html#generator";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("<a href=\"link.html\">Some link</a>")]
        [DataRow("<a href='link.html'>Some link</a>")]
        public void SameLinksWithVariousQuotationMarks(string anchor)
        {
            // Arrange
            var expected = "link.html";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("<a href=\"index.html\">Link to main page</a>")]
        [DataRow("<a href='index.html'>Link to main page</a>")]
        [DataRow("<a Href=\"index.html\">Link to main page</a>")]
        [DataRow("<a Href='index.html'>Link to main page</a>")]
        [DataRow("<a HREF=\"index.html\">Link to main page</a>")]
        [DataRow("<a HREF='index.html'>Link to main page</a>")]
        public void SameLinksWithUppercaseAndLowerCase(string anchor)
        {
            // Arrange
            var expected = "index.html";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("<a href=\"images/super-image.jpg\" accesskey=\"x\"> Look at my photo! </a>")]
        [DataRow("<a  href=\"images/super-image.jpg\"  accesskey=\"x\" > Look at my photo! </a>")]
        [DataRow("<a  href = 'images/super-image.jpg' accesskey = \"x\"> Look at my photo! </a>")]
        [DataRow("<a accesskey=\"x\" href=\"images/super-image.jpg\"> Look at my photo! </a>")]
        [DataRow("<a  accesskey=\"x\"  href=\"images/super-image.jpg\" > Look at my photo! </a>")]
        public void AnchorWithAccesskeyAttribute(string anchor)
        {
            // Arrange
            var expected = "images/super-image.jpg";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("<a href=\"URL\" coords=\"coordinates\">...</a>")]
        [DataRow("<a href = \"URL\" coords=\"coordinates\">...</a>")]
        [DataRow("<a  coords=\"coordinates\" href=\"URL\">...</a>")]
        [DataRow("<a coords=\"coordinates\"  href = \"URL\" >...</a>")]
        public void AnchorWithCoordsAttribute(string anchor)
        {
            // Arrange
            var expected = "URL";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithDownloadAttribute()
        {
            // Arrange
            var anchors = new List<string>
            {
                "<a href='images/file.jpg'>Open file in browser</a>",
                "<a href=\"images/secret.jpg\" download>Download file</a>",
                "< a href = \"images/file.jpg\" > Open file in browser < /a >",
                "< a href = \"images/secret.jpg\" download >Download file < /a >",
            };

            var expected = new List<string>
            {
                "images/file.jpg",
                "images/secret.jpg",
                "images/file.jpg",
                "images/secret.jpg"
            };

            // Act
            var actual = anchors.Select(anchor => anchor.FindHrefAttribute())
                                .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithHrefAttribute()
        {
            // Arrange
            // Arrange
            var anchors = new List<string>
            {
                "<a href=\"images/awesome.jpg\">Look at my photo!</a>",
                "<a href='images/awesome.jpg'>Look at my photo!</a>",
                "<a href = 'images/awesome.jpg'>Look at my photo!</a>",
                "<a href=\"tip.html\">How to do the same photo?</a>",
                "<a href=\"../../example/knob.html\"> Relative link </a>",
                "<a href=\"http://htmlbook.ru/example/knob.html\">Absolute link</a>",
                "<a href=\"text.html#bottom\">Go to bottom text part...</a>"
            };

            var expected = new List<string>
            {
                "images/awesome.jpg",
                "images/awesome.jpg",
                "images/awesome.jpg",
                "tip.html",
                "../../example/knob.html",
                "http://htmlbook.ru/example/knob.html",
                "text.html#bottom"
            };

            // Act
            var actual = anchors.Select(anchor => anchor.FindHrefAttribute())
                                .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("<a href=\"http://baidu.cn\" hreflang=\"zh\"Searching service Baidu</a>")]
        [DataRow("<a href = \"http://baidu.cn\" hreflang=\"zh\">Searching service Baidu</a>")]
        [DataRow("<a hreflang=\"zh\" href=\"http://baidu.cn\" >Searching service Baidu</a>")]
        [DataRow("<a hreflang = \"zh\" href = \"http://baidu.cn\">Searching service Baidu</a>")]
        public void AnchorWithHreflangAttribute(string anchor)
        {
            // Arrange
            var expected = "http://baidu.cn";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("<a href=\"#top\" name=\"top\">To the top</a>")]
        [DataRow("< a href = \"#top\" name = \"top\" > To the top < /a >")]
        [DataRow("<a name=\"top\" href=\"#top\"> To the top </a>")]
        [DataRow("<a  name = \"top\" href = \"#top\" >To the top</a>")]
        public void AnchorWithNameAttribute(string anchor)
        {
            // Arrange
            var expected = "#top";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithRelAttribute()
        {
            // Arrange
            var anchors = new List<string>
            {
                "<a href=\"http://google.com\" rel=\"nofollow\"> Google </a>",
                "<a href=\"http://htmlbook.ru\" rel=\"sidebar\">Add to favourites</a>",
                "<a rel = \"nofollow\" href = \"http://google.com\" > Google </a>",
                "<a rel=\"sidebar\" href=\"http://htmlbook.ru\">Add to favourites</a>",
                "<a rel=\"sidebar\" href='http://htmlbook.ru'>Add to favourites</a>"
            };

            var expected = new List<string>
            {
                "http://google.com",
                "http://htmlbook.ru",
                "http://google.com",
                "http://htmlbook.ru",
                "http://htmlbook.ru"
            };

            // Act
            var actual = anchors.Select(anchor => anchor.FindHrefAttribute())
                                .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("<a href=\"index.html\" rel=\"Main page\" rev=\"Child page\">Main page</a>")]
        [DataRow("<a rel=\"Main page\" href=\"index.html\" rev=\"Child page\">Main page</a>")]
        [DataRow("<a rel=\"Main page\" rev=\"Child page\" href=\"index.html\">Main page</a>")]
        public void AnchorWithRevAttribute(string anchor)
        {
            // Arrange
            var expected = "index.html";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("<a href=\"URL\"shape=\"circle | default | poly | rect\">...</a>")]
        [DataRow("<a circle | default | poly | rect\" href=\"URL\"shape=\">...</a>")]
        public void AnchorWithShapeAttribute(string anchor)
        {
            // Arrange
            var expected = "URL";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithTabIndexAttribute()
        {
            // Arrange
            var anchors = new List<string>
            {
                "<a href=\"1.html\" tabindex=\"1\">Link 1</a>",
                "<a href=\"3.html\" tabindex=\"3\">Link 3</a>",
                "<a href=\"2.html\" tabindex=\"2\">Link 2</a>",
                "<a href=\"4.html\" tabindex=\"4\">Link 4</a>",
                "<a href='5.html'tabindex=\"5\">Link 5</a>",
                "<a tabindex=\"1\" href = \"1.html\" >Link 1</a>",
                "<a tabindex=\"3\" href = \"3.html\" >Link 3</a>",
                "<a tabindex=\"3\" href = \"2.html\" tabindex=\"2\">Link 2</a>",
                "<a tabindex=\"4\" href = \"4.html\" >Link 4</a>"
            };

            var expected = new List<string>
            {
                "1.html",
                "3.html",
                "2.html",
                "4.html",
                "5.html",
                "1.html",
                "3.html",
                "2.html",
                "4.html"
            };

            // Act
            var actual = anchors.Select(anchor => anchor.FindHrefAttribute())
                                .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("<a href=\"/new.html\" target=\"_blank\"> Open in new tab </a>")]
        [DataRow("<a href='/new.html' target='_blank'> Open in new tab </a>")]
        [DataRow("<a target=\"_blank\" href=\"/new.html\"></a>")]
        [DataRow("<a target=\"_blank\" href = \"/new.html\"></a>")]
        public void AnchorWithTargetAttribute(string anchor)
        {
            // Arrange
            var expected = "/new.html";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("<a href=\"zoo.html\" title=\"Images of various animals...\"> Images</a>")]
        [DataRow("<a href='zoo.html' title=\"Images of various animals...\"> Images</a>")]
        [DataRow("<a title=\"Images of various animals...\" href=\"zoo.html\"> Images</a>")]
        public void AnchorWithTitleAttribute(string anchor)
        {
            // Arrange
            var expected = "zoo.html";

            // Act
            var actual = anchor.FindHrefAttribute();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithTypeAttribute()
        {
            // Arrange
            var anchors = new List<string>
            {
                "<a href=\"1.html\">Link to the page</a>",
                "<a href=\"video/snowman.mp4\" type=\"video/mp4\">Link to the video</a>",
                "<a href = \"1.html\">Link to the page</a>",
                "<a type=\"video/mp4\" href=\"video/snowman.mp4\">Link to the video</a>"
            };

            var expected = new List<string>
            {
                "1.html",
                "video/snowman.mp4",
                "1.html",
                "video/snowman.mp4"
            };

            // Act
            var actual = anchors.Select(anchor => anchor.FindHrefAttribute())
                                .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FindingHref_EmbeddedResource_TestPage()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TestPage.html");
            var expected = new List<string>
            {
                "/e",
                "/journal/",
                "/Music/index.htm"
            };

            // Act
            var anchors = input.ReplaceConsecutiveCharsWithSingle(' ')
                               .RemoveChars('\r', '\n', '\t')
                               .FindAnchorTags();

            var actual = anchors.Select(anchor => anchor.FindHrefAttribute())
                                .Where(anchor => anchor.IsNotNullOrEmpty())
                                .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindingAnchors_EmbeddedResource_StallmanComputingCropPage()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.stallman-computing.html");
            var expected = new List<string>
            {
                "/",
                "/archives/polnotes.html",
                "/biographies.html#serious",
                "http://gnu.org",
                "https://www.fsf.org/resources/hw/systems",
                "http://www.gnu.org/distros",
                "http://gnome.org/",
                "http://www.netpurgatory.com/downloads.html#thumbnail",
                "/site-search/StallmanOrgSearch.tar.gz",

                "http://contemporary-home-computing.org/RUE/",
                "http://gnu.org/philosophy/javascript-trap.html",
                "https://gnu.org/software/librejs/",
                "/rms-lifestyle.html#cards",
                "/ebooks.pdf",
                "/internet-music.html",
                "http://gnu.org/philosophy/free-software-even-more-important.html",

                "http://gnu.org/software/social",
                "/facebook.html",
                "https://www.gnu.org/philosophy/javascript-trap.html",
                "http://gnu.org/philosophy/free-doc.html",
                "http://shop.fsf.org/category/books",
                "/amazon.html",

                "#lisp",
                "https://gnu.org/philosophy/who-does-that-server-really-serve.html",
                "http://DefectiveByDesign.org/",
                "http://DefectiveByDesign.org",
                "/ebooks.pdf",
                "/index.html"
            };

            // Act
            var anchors = input.ReplaceConsecutiveCharsWithSingle(' ')
                               .RemoveChars('\r', '\n', '\t')
                               .FindAnchorTags();

            var actual = anchors.Select(anchor => anchor.FindHrefAttribute())
                                .Where(anchor => anchor.IsNotNullOrEmpty())
                                .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
