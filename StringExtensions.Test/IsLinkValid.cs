using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensions.Test
{
    [TestClass]
    public class IsLinkValid
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LinkIsNull_ThrowArgumentNullException()
        {
            // Arrange
            string link = null;

            // Act
            link.IsLinkValid();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        public void LinkIsEmptyOrWhitespace_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("https://www.1.us")]
        [DataRow("https://www.1st.us")]
        [DataRow("https://www.s.us")]
        [DataRow("https://www.st.us")]
        [DataRow("https://www.site.us")]
        [DataRow("https://www.sample-site.us")]
        [DataRow("https://www.sample_site.us")]
        [DataRow("https://www.site.org.ru")]
        [DataRow("https://www.site.org.net")]
        public void HttpsWwwLink_LinkIsValid_ReturnTrue(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("http://www.1.us")]
        [DataRow("http://www.1st.us")]
        [DataRow("http://www.s.us")]
        [DataRow("http://www.st.us")]
        [DataRow("http://www.site.us")]
        [DataRow("http://www.sample-site.us")]
        [DataRow("http://www.sample_site.us")]
        [DataRow("http://www.site.org.ru")]
        [DataRow("http://www.site.org.net")]
        public void HttpWwwLink_LinkIsValid_ReturnTrue(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("https://1.us")]
        [DataRow("https://1st.us")]
        [DataRow("https://s.us")]
        [DataRow("https://st.us")]
        [DataRow("https://site.us")]
        [DataRow("https://sample-site.us")]
        [DataRow("https://sample_site.us")]
        [DataRow("https://site.org.ru")]
        [DataRow("https://site.org.net")]
        public void HttpsLink_LinkIsValid_ReturnTrue(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("http://1.us")]
        [DataRow("http://1st.us")]
        [DataRow("http://s.us")]
        [DataRow("http://st.us")]
        [DataRow("http://site.us")]
        [DataRow("http://sample-site.us")]
        [DataRow("http://sample_site.us")]
        [DataRow("http://site.org.ru")]
        [DataRow("http://site.org.net")]
        public void HttpLink_LinkIsValid_ReturnTrue(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("www.1.us")]
        [DataRow("www.1st.us")]
        [DataRow("www.s.us")]
        [DataRow("www.st.us")]
        [DataRow("www.site.us")]
        [DataRow("www.sample-site.us")]
        [DataRow("www.sample_site.us")]
        [DataRow("www.site.org.ru")]
        [DataRow("www.site.org.net")]
        public void WwwLink_LinkIsValid_ReturnTrue(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("https://www.1.us/index.html")]
        [DataRow("https://www.1st.us/index.html/")]
        [DataRow("https://www.s.us/index.html")]
        [DataRow("https://www.st.us/index.html")]
        [DataRow("https://www.site.us/index.html")]
        [DataRow("https://www.sample-site.us/index.html")]
        [DataRow("https://www.sample_site.us/id.html")]
        [DataRow("https://www.site.org.ru/main-page.html")]
        [DataRow("https://www.site.org.net/main_page.html")]
        public void HttpsWwwLink_ToHtml_LinkIsValid_ReturnTrue(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("http://www.1.us/awesome-image.jpg")]
        [DataRow("http://www.1st.us/awesome-image.bmp")]
        [DataRow("http://www.s.us/awesome-image.jpg")]
        [DataRow("http://www.st.us/awesome-image.jpeg")]
        [DataRow("http://www.site.us/awesome-image.gif")]
        [DataRow("http://www.sample-site.us/awesome-image.tiff")]
        [DataRow("http://www.sample_site.us/awesome-image.jpg")]
        [DataRow("http://www.site.org.ru/awesome-image.png")]
        [DataRow("http://www.site.org.net/awesome-image.jpg/")]
        public void HttpWwwLink_ToImage_LinkIsValid_ReturnTrue(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("https://1.us/1939-00-48_image.png")]
        [DataRow("https://1st.us/1939-00-48_image.png")]
        [DataRow("https://s.us/1939-00-48_image.png")]
        [DataRow("https://st.us/1939-00-48_image.png")]
        [DataRow("https://site.us/1939-00-48_image.png")]
        [DataRow("https://sample-site.us/1939-00-48_image.png")]
        [DataRow("https://sample_site.us/1939-00-48_image.png")]
        [DataRow("https://site.org.ru/1939-00-48_image.png")]
        [DataRow("https://site.org.net/1939-00-48_image.png")]
        public void HttpsLink_ToImage_LinkIsValid_ReturnTrue(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("http://1.us/top")]
        [DataRow("http://1st.us/top/")]
        [DataRow("http://s.us/top/")]
        [DataRow("http://st.us/st")]
        [DataRow("http://site.us/top-samples")]
        [DataRow("http://sample-site.us/top_samples")]
        [DataRow("http://sample_site.us/top-samples/")]
        [DataRow("http://site.org.ru/top_samples/")]
        [DataRow("http://site.org.net/s")]
        public void HttpLink_ToFolder_LinkIsValid_ReturnTrue(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("www.1.us/index.html#top")]
        [DataRow("www.1st.us/index.html#bottom/")]
        [DataRow("www.s.us/?search=qppoao")]
        [DataRow("www.st.us/?id=2")]
        [DataRow("www.site.us/?id=32/")]
        [DataRow("www.sample-site.us/id=3")]
        [DataRow("www.sample_site.us/id=42/")]
        [DataRow("www.site.org.ru/id/42")]
        [DataRow("www.site.org.net/id/64/")]
        public void WwwLink_ToAnchorAndId_LinkIsValid_ReturnTrue(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("htts://www.1.us")]
        [DataRow("htps://www.1st.us")]
        [DataRow("ttps://www.s.us")]
        [DataRow("https:///www.st.us")]
        [DataRow("https:/www.site.us")]
        [DataRow("https:www.sample-site.us")]
        [DataRow("https//www.sample_site.us")]
        [DataRow("httpwww.site.org.ru")]
        [DataRow("http://.site.org.net")]
        public void HttpsWwwLink_Mistakes_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("htt://www.1.us")]
        [DataRow("htp://www.1st.us")]
        [DataRow("ttp://www.s.us")]
        [DataRow("http:///www.st.us")]
        [DataRow("http:/www.site.us")]
        [DataRow("http:www.sample-site.us")]
        [DataRow("http//www.sample_site.us")]
        [DataRow("httpwww.site.org.ru")]
        [DataRow("http://.site.org.net")]
        public void HttpWwwLink_Mistakes_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("htts://1.us")]
        [DataRow("htps://1st.us")]
        [DataRow("ttps://s.us")]
        [DataRow("https:///st.us")]
        [DataRow("https:/site.us")]
        [DataRow("https:sample-site.us")]
        [DataRow("https//sample_site.us")]
        [DataRow("httpssite.org.ru")]
        [DataRow("https.site.org.net")]
        public void HttpsLink_Mistakes_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("htt://1.us")]
        [DataRow("htp://1st.us")]
        [DataRow("ttp://s.us")]
        [DataRow("http:///st.us")]
        [DataRow("http:/site.us")]
        [DataRow("http:sample-site.us")]
        [DataRow("http//sample_site.us")]
        [DataRow("httpsite.org.ru")]
        [DataRow("http.site.org.net")]
        public void HttpLink_Mistakes_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("www1.us")]
        [DataRow("ww.1st.us")]
        [DataRow("w.s.us")]
        [DataRow(".st.us")]
        [DataRow("www..site.us")]
        [DataRow("www/sample-site.us")]
        [DataRow("www://sample_site.us")]
        [DataRow("www:site.org.ru")]
        [DataRow("/www.site.org.net")]
        public void WwwLink_Mistakes_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("htts://www.1.us/index.html")]
        [DataRow("htps://www.1st.us/index.html/")]
        [DataRow("ttps://www.s.us/index.html")]
        [DataRow("https:///www.st.us/index.html")]
        [DataRow("https:/www.site.us/index.html")]
        [DataRow("https:www.sample-site.us/index.html")]
        [DataRow("https//www.sample_site.us/id.html")]
        [DataRow("httpswww.site.org.ru/main-page.html")]
        [DataRow("https.www.site.org.net/main_page.html")]
        public void HttpsWwwLink_ToHtml_Mistakes_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("htt://www.1.us/awesome-image.jpg")]
        [DataRow("htp://www.1st.us/awesome-image.bmp")]
        [DataRow("ttp://www.s.us/awesome-image.jpg")]
        [DataRow("http:///www.st.us/awesome-image.jpeg")]
        [DataRow("http:/www.site.us/awesome-image.gif")]
        [DataRow("http:www.sample-site.us/awesome-image.tiff")]
        [DataRow("http//www.sample_site.us/awesome-image.jpg")]
        [DataRow("httpwww.site.org.ru/awesome-image.png")]
        [DataRow("http.www.site.org.net/awesome-image.jpg/")]
        public void HttpWwwLink_ToImage_Mistakes_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("htts://1.us/1939-00-48_image.png")]
        [DataRow("htps://1st.us/1939-00-48_image.png")]
        [DataRow("ttps://s.us/1939-00-48_image.png")]
        [DataRow("https:///st.us/1939-00-48_image.png")]
        [DataRow("https:site.us/1939-00-48_image.png")]
        [DataRow("https//sample-site.us/1939-00-48_image.png")]
        [DataRow("https:sample_site.us/1939-00-48_image.png")]
        [DataRow("httpssite.org.ru/1939-00-48_image.png")]
        [DataRow("https.site.org.net/1939-00-48_image.png")]
        public void HttpsLink_ToImage_Mistakes_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("htt://1.us/top")]
        [DataRow("htp://1st.us/top/")]
        [DataRow("ttp://s.us/top/")]
        [DataRow("http:///st.us/st")]
        [DataRow("http:/site.us/top-samples")]
        [DataRow("http:sample-site.us/top_samples")]
        [DataRow("http//sample_site.us/top-samples/")]
        [DataRow("httpsite.org.ru/top_samples/")]
        [DataRow("http.site.org.net/s")]
        public void HttpLink_ToFolder_Mistakes_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("ww.1.us/index.html#top")]
        [DataRow("w.1st.us/index.html#bottom/")]
        [DataRow("wwww.s.us/?search=qppoao")]
        [DataRow("wwwst.us/?id=2")]
        [DataRow("site.us/?id=32/")]
        [DataRow(".sample-site.us/id=3")]
        [DataRow("/sample_site.us/id=42/")]
        [DataRow("www:site.org.ru/id/42")]
        [DataRow("site.org.net/id/64/")]
        public void WwwLink_ToAnchorAndId_Mistakes_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("1.us")]
        [DataRow("1st.us")]
        [DataRow("s.us")]
        [DataRow("st.us")]
        [DataRow("site.us")]
        [DataRow("sample-site.us")]
        [DataRow("sample_site.us")]
        [DataRow("site.org.ru")]
        [DataRow("site.org.net")]
        public void LinkIsNotFull_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("1.us/index.html")]
        [DataRow("1st.us/index.html/")]
        [DataRow("s.us/index.html")]
        [DataRow("st.us/index.html")]
        [DataRow("site.us/index.html")]
        [DataRow("sample-site.us/index.html")]
        [DataRow("sample_site.us/id.html")]
        [DataRow("site.org.ru/main-page.html")]
        [DataRow("site.org.net/main_page.html")]
        public void LinkIsNotFull_ToHtml_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }


        [TestMethod]
        [DataRow("1.us/awesome-image.jpg")]
        [DataRow("1st.us/awesome-image.bmp")]
        [DataRow("s.us/awesome-image.jpg")]
        [DataRow("st.us/awesome-image.jpeg")]
        [DataRow("site.us/awesome-image.gif")]
        [DataRow("sample-site.us/awesome-image.tiff")]
        [DataRow("sample_site.us/awesome-image.jpg")]
        [DataRow("site.org.ru/awesome-image.png")]
        [DataRow("site.org.net/awesome-image.jpg/")]
        public void LinkIsNotFull_ToImage_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("1.us/1939-00-48_image.png")]
        [DataRow("1st.us/1939-00-48_image.png")]
        [DataRow("s.us/1939-00-48_image.png")]
        [DataRow("st.us/1939-00-48_image.png")]
        [DataRow("site.us/1939-00-48_image.png")]
        [DataRow("sample-site.us/1939-00-48_image.png")]
        [DataRow("sample_site.us/1939-00-48_image.png")]
        [DataRow("site.org.ru/1939-00-48_image.png")]
        [DataRow("site.org.net/1939-00-48_image.png")]
        public void LinkIsNotFull_ToNumImage_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("1.us/top")]
        [DataRow("1st.us/top/")]
        [DataRow("s.us/top/")]
        [DataRow("st.us/st")]
        [DataRow("site.us/top-samples")]
        [DataRow("sample-site.us/top_samples")]
        [DataRow("sample_site.us/top-samples/")]
        [DataRow("site.org.ru/top_samples/")]
        [DataRow("site.org.net/s")]
        public void LinkIsNotFull_ToFolder_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("1.us/index.html#top")]
        [DataRow("1st.us/index.html#bottom/")]
        [DataRow("s.us/?search=qppoao")]
        [DataRow("st.us/?id=2")]
        [DataRow("site.us/?id=32/")]
        [DataRow("sample-site.us/id=3")]
        [DataRow("sample_site.us/id=42/")]
        [DataRow("site.org.ru/id/42")]
        [DataRow("site.org.net/id/64/")]
        public void LinkIsNotFull_ToAnchorAndId_LinkIsNotValid_ReturnFalse(string link)
        {
            // Act
            var actual = link.IsLinkValid();

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
