using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringExtensions
{
    public static class HtmlTagsFinder
    {
        private static string s_anchorPattern = @"<\s*a.*?>.*?<\s*\/a\s*>";

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
            var matches = Regex.Matches(htmlPage, s_anchorPattern, RegexOptions.IgnoreCase);

            return matches.Select(match => match.Groups[0].Value);
        }
    }
}
