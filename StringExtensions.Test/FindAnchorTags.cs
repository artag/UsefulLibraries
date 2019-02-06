using System.Collections.Generic;
using System.Linq;
using EmbeddedResourceService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensions.Test
{
    [TestClass]
    public class FindAnchorTags
    {
        private readonly ITextResourceService _textResourceService;

        public FindAnchorTags()
        {
            _textResourceService = new TextResourceService(typeof(FindAnchorTags));
        }

        [TestMethod]
        public void LinkToAnchorOnSamePage()
        {
            // Arrange
            var input = "< a href=\"#example\">Example headline</a >" +
                        "<h5><a id=\"example\"></a>Example headline</h5>";

            var expected = new List<string>
            {
                "< a href=\"#example\">Example headline</a >",
                "<a id=\"example\"></a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinkToAnchorOnAnotherPage()
        {
            // Arrange
            var input = "<a href=\"../html-link.html#generator\">HTML link code generator</a> \n" +
                        "<h2><a id=\"generator\"></a>HTML link code generator</h2>";

            var expected = new List<string>
            {
                "<a href=\"../html-link.html#generator\">HTML link code generator</a>",
                "<a id=\"generator\"></a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithAccesskeyAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorAccesskey.html");

            var expected = new List<string>
            {
                "<a href=\"images/super-image.jpg\" accesskey=\"x\"> Look at my photo! </a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithCoordsAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorCoords.html");

            var expected = new List<string> { "<a href=\"URL\" coords=\"coordinates\">...</a>" };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithDownloadAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorDownload.html");
            var expected = new List<string>
            {
                "<a href=\"images/file.jpg\">Open file in browser</a>",
                "<a href=\"images/secret.jpg\" download>Download file</a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithHrefAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorHref.html");
            var expected = new List<string>
            {
                "<a href=\"images/awesome.jpg\">Look at my photo!</a>",
                "<a href=\"tip.html\">How to do the same photo?</a>",
                "<a href=\"../../example/knob.html\"> Relative link </a>",
                "<a href=\"http://htmlbook.ru/example/knob.html\">Absolute link</a>",
                "<a href=\"text.html#bottom\">Go to bottom text part...</a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithHreflangAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorHreflang.html");
            var expected = new List<string>
            {
                "<a href=\"http://baidu.cn\" hreflang=\"zh\">Chinese searching service Baidu</a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithNameAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorName.html");
            var expected = new List<string>
            {
                "<a name=\"top\"></a>",
                "<a href=\"#top\">To the top</a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithRelAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorRel.html");
            var expected = new List<string>
            {
                "<a href=\"http://google.com\" rel=\"nofollow\"> Google </a>",
                "<a href=\"http://htmlbook.ru\" rel=\"sidebar\">Add to favourites</a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithRevAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorRev.html");
            var expected = new List<string>
            {
                "<a href=\"index.html\" rel=\"Main page\" rev=\"Child page\"> " +
                "Go to the main page</a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithShapeAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorShape.html");
            var expected = new List<string>
            {
                "<a href=\"URL\"shape=\"circle | default | poly | rect\">...</a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithTabIndexAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorTabIndex.html");
            var expected = new List<string>
            {
                "<a href=\"1.html\" tabindex=\"1\">Link 1</a>",
                "<a href=\"3.html\" tabindex=\"3\">Link 3</a>",
                "<a href=\"2.html\" tabindex=\"2\">Link 2</a>",
                "<a href=\"4.html\" tabindex=\"4\">Link 4</a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithTargetAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorTarget.html");
            var expected = new List<string>
            {
                "<a href=\"new.html\" target=\"_blank\"> Open in new tab </a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithTitleAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorTitle.html");
            var expected = new List<string>
            {
                "<a href=\"zoo.html\" title=\"Images of various animals...\"> Images</a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnchorWithTypeAttribute()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TagAnchorType.html");
            var expected = new List<string>
            {
                "<a href=\"1.html\">Link to the page</a>",
                "<a href=\"video/snowman.mp4\" type=\"video/mp4\">Link to the video</a>"
            };

            // Act
            var actual = input.ReplaceConsecutiveCharsWithSingle(' ')
                              .RemoveChars('\r', '\n', '\t')
                              .FindAnchorTags()
                              .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FindingAnchors_EmbeddedResource_TestPage()
        {
            // Arrange
            var input = _textResourceService.ReadToEnd("Resources.TestPage.html");
            var expected = new List<string>
            {
                @"<a href='/e'>english</a>",
                @"<a href=/test/><IMG SRC='/test2016site.jpg' width=225 height=309 " +
                    "alt=\"Unknown author, 2016\" border=0></a>",
                @"<a href='/journal/'>journal</a>",
                @"<a href=putevodi.htm>First chapter.</a>",
                @"<A HREF=test/>Link1</A>",
                @"<a href=autor.htm>Link2</a>",
                @"<a href=/reklama>Link3</a>",
                @"<a href=work.htm>Link4</a>",
                @"<A HREF=test/publ/index.htm>Books</A>",
                @"<a HREF=interview/index.shtml>Online-Interview</a>",
                @"<A HREF=foto/index.htm>Foto</A>",
                @"<A HREF=arhive>Books</A>",
                @"<A HREF='/Music/index.htm'>Music mp3</A>",
                @"<A HREF=index_prikol.htm>Prikols.</A>",
                @"<A HREF=index_project.htm>Old projects.</A>",
            };

            // Act
            var actual =  input.ReplaceConsecutiveCharsWithSingle(' ')
                               .RemoveChars('\r', '\n', '\t')
                               .FindAnchorTags()
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
                "<a href=\"/\">https://stallman.org</a>",
                "<a href=\"/archives/polnotes.html\">daily political notes</a>",
                "<a href=\"/biographies.html#serious\">RMS' Bio</a>",
                "<a href=\"http://gnu.org\">The GNU Project</a>",
                "<a href=\"https://www.fsf.org/resources/hw/systems\"> endorsed by the FSF</a>",
                "<a href=\"http://www.gnu.org/distros\">ethical distros</a>",
                "<a href=\"http://gnome.org/\">GNOME</a>",
                "<a href=\"http://www.netpurgatory.com/downloads.html#thumbnail\">" +
                    "this perl script</a>",
                "<a href=\"/site-search/StallmanOrgSearch.tar.gz\">this code</a>",

                "<a href=\"http://contemporary-home-computing.org/RUE/\"> " +
                    "explanation of the concept of designing</a>",
                "<a href=\"http://gnu.org/philosophy/javascript-trap.html\">" +
                    "nonfree Javascript code</a>",
                "<a href=\"https://gnu.org/software/librejs/\"> " +
                    "to prevent nonfree Javascript code from running.</a>",
                "<a href=\"/rms-lifestyle.html#cards\"> credit cards</a>",
                "<a href=\"/ebooks.pdf\">an e-book</a>",
                "<a href=\"/internet-music.html\">music recording</a>",
                "<a name=\"social-networking\">I do not use any social networking sites</a>",
                "<a href=\"http://gnu.org/philosophy/free-software-even-more-important.html\"> " +
                    "free vs proprietary</a>",
                "<a name=\"twitter\">I have a Twitter account</a>",

                "<a href=\"http://gnu.org/software/social\">GNU Social</a>",
                "<a name=\"facebook\">never had a Facebook account</a>",
                "<a href=\"/facebook.html\">Facebook is bad for many other reasons as well.</a>",
                "<a href=\"https://www.gnu.org/philosophy/javascript-trap.html\"> " +
                    "running nonfree Javascript code</a>",
                "<a name=\"lisp\">The most powerful programming language is Lisp.</a>",
                "<a href=\"http://gnu.org/philosophy/free-doc.html\">free as in freedom</a>",
                "<a href=\"http://shop.fsf.org/category/books\">order printed copies</a>",
                "<a href=\"/amazon.html\">don't buy books (or anything) from Amazon!</a>",
                "<a name=\"learnprogramming\"></a>",

                "<a href=\"#lisp\">including Lisp</a>",
                "<a href=\"https://gnu.org/philosophy/who-does-that-server-really-serve.html\"> " +
                    "service as a software substitute</a>",
                "<a name=\"streaming\">Streaming</a>",
                "<a href=\"http://DefectiveByDesign.org/\">DRM</a>",
                "<a href=\"http://DefectiveByDesign.org\">Digital Restrictions Management</a>",
                "<a href=\"/ebooks.pdf\"> Amazon Swindle</a>",
                "<a href=\"/index.html\">Richard Stallman's home page</a>"
            };

            // Act
            var actual =  input.ReplaceConsecutiveCharsWithSingle(' ')
                               .RemoveChars('\r', '\n', '\t')
                               .FindAnchorTags()
                               .ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
