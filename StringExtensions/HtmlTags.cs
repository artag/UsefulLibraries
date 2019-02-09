using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringExtensions
{
    /// <summary>
    /// Static class with string extension methods to work with html tags.
    /// </summary>
    public static class HtmlTags
    {
        /// <summary>
        /// Searching for anchor tags in input html page.
        /// </summary>
        /// <param name="htmlPage">Input </param>
        /// <returns>Anchor tags.</returns>
        /// <remarks>
        /// <para>1) Searching tags is case-insensitive.</para>
        /// <para>2) Searching results also includes comment parts of html page.</para>
        /// <para>3) This search works with tags located at one line.</para>
        /// </remarks>
        public static IEnumerable<string> FindAnchorTags(this string htmlPage)
        {
            var anchorPattern = @"<\s*a.*?>.*?<\s*\/a\s*>";

            var matches = Regex.Matches(htmlPage, anchorPattern, RegexOptions.IgnoreCase);

            return matches.Select(match => match.Groups[0].Value);
        }
    }
}
