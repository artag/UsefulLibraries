using System.Text.RegularExpressions;

namespace StringExtensions
{
    /// <summary>
    /// Static class with string extension methods to work with html attributes.
    /// </summary>
    public static class HtmlAttributes
    {
        /// <summary>
        /// Searching for href attribute in input anchor tag (<a>...</a>).
        /// </summary>
        /// <param name="anchor">Anchor tag (<a>...</a>).</param>
        /// <returns>Href attribute. If attribute not found returns empty string ("").</returns>
        /// <remarks>For searching anchors on html page use extension FindAnchorTags().</remarks>
        public static string FindHrefAttribute(this string anchor)
        {
            var hrefPattern = @"href\s*=\s*" + "[\"'](.*?)[\"']";

            var regexOptions = RegexOptions.Singleline | RegexOptions.IgnoreCase;
            var result = Regex.Match(anchor, hrefPattern, regexOptions);

            return result.Success
                ? result.Groups[1].Value
                : string.Empty;
        }
    }
}
