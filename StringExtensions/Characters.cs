using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringExtensions
{
    /// <summary>
    /// Static class with string extension methods to work with characters.
    /// </summary>
    public static class Characters
    {
        /// <summary>
        /// Remove characters from the input string.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <param name="charsToRemove">Characters to remove.</param>
        /// <returns>String without selected characters.</returns>
        public static string RemoveChars(this string str, IEnumerable<char> charsToRemove)
        {
            return RemoveCharsFromString(str, charsToRemove);
        }

        /// <summary>
        /// Remove characters from the input string.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <param name="charsToRemove">Characters to remove.</param>
        /// <returns>String without selected characters.</returns>
        public static string RemoveChars(this string str, params char[] charsToRemove)
        {
            return RemoveCharsFromString(str, charsToRemove);
        }

        private static string RemoveCharsFromString(string str, IEnumerable<char> charsToRemove)
        {
            var initialLength = str.Length;
            var stringBuilder = new StringBuilder(initialLength);

            foreach (var currentChar in str)
            {
                var needsToRemove = charsToRemove.Contains(currentChar);
                if (needsToRemove)
                    continue;

                stringBuilder.Append(currentChar);
            }

            return stringBuilder.ToString();
        }
    }
}
