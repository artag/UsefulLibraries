using System.Collections.Generic;
using System.Text;

namespace StringExtensions
{
    /// <summary>
    /// Static class with string extension methods to work with numbers.
    /// </summary>
    public static class Numbers
    {
        /// <summary>
        /// Get integer numbers from the input string.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <returns>Enumeration contains integer numbers.</returns>
        /// <remarks>
        /// Integer value will be ignored if it's less than <see cref="int.MinValue"/>
        /// and more than <see cref="int.MaxValue"/>.
        /// </remarks>
        public static IEnumerable<int> GetIntegers(this string str)
        {
            var results = new List<int>();
            var sb = new StringBuilder(str.Length);

            foreach (var ch in str)
            {
                if (char.IsNumber(ch))
                    sb.Append(ch);
                else
                {
                    TryGetIntegerAndAddToCollection(sb.ToString(), results);
                    sb.Clear();
                }
            }

            if (sb.Length > 0)
                TryGetIntegerAndAddToCollection(sb.ToString(), results);

            return results;
        }

        private static void TryGetIntegerAndAddToCollection(string str, ICollection<int> results)
        {
            var success = int.TryParse(str, out var intResult);
            if (success)
                results.Add(intResult);
        }
    }
}
