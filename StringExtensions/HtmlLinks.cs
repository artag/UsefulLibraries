using System;
using System.Text.RegularExpressions;

namespace StringExtensions
{
    /// <summary>
    /// Static class with string extension methods to work with html links.
    /// </summary>
    public static class HtmlLinks
    {
        /// <summary>
        /// Returns the value indicating whether this link points to the anchor.
        /// </summary>
        /// <param name="link">Input link.</param>
        /// <returns>True if the input link points to the anchor; otherwise, false.</returns>
        public static bool IsLinkToAnchor(this string link)
        {
            if (link == null) throw new ArgumentNullException();

            return link.Contains('#');
        }

        /// <summary>
        /// Returns the value indicating whether this link is valid or not.
        /// </summary>
        /// <param name="link">Input link.</param>
        /// <returns>True if the input link is valid; otherwise, false.</returns>
        public static bool IsLinkValid(this string link)
        {
            var validLinkPattern = @"^(https:\/\/|http:\/\/|www\.)[A-Za-z0-9_-]+\.\S+";

            return Regex.IsMatch(link, validLinkPattern);
        }
    }
}
