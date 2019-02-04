using System.Text;

namespace StringExtensions
{
    /// <summary>
    /// Static class with string extension methods to work with consecutive symbols.
    /// </summary>
    public static class ConsecutiveCharacters
    {
        /// <summary>
        /// Replace consecutive characters with single in the input string.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <param name="symbol">Consecutive symbol to replace.</param>
        /// <returns>String.</returns>
        public static string ReplaceConsecutiveCharsWithSingle(this string str, char symbol)
        {
            var initialLength = str.Length;
            var stringBuilder = new StringBuilder(initialLength);

            var skipNextSymbol = false;
            foreach (var currentChar in str)
            {
                if (currentChar == symbol)
                {
                    if (skipNextSymbol) continue;

                    stringBuilder.Append(currentChar);
                    skipNextSymbol = true;
                    continue;
                }

                stringBuilder.Append(currentChar);
                skipNextSymbol = false;
            }

            return stringBuilder.ToString();
        }
    }
}
