using System;
using System.Runtime.CompilerServices;

namespace StringExtensions
{
    /// <summary>
    /// Static class with string extension methods for standart System namespace.
    /// </summary>
    public static class SystemExtensions
    {
        /// <summary>
        /// Indicates whether the specified string is null or an empty string ("").
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns>
        /// True if the value parameter is null or an empty string (""); otherwise, false.
        /// </returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Indicates whether the specified string is NOT null or an empty string ("").
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns>
        /// True if the value parameter is NOT null or an empty string (""); otherwise, false.
        /// </returns>
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Indicates whether a specified string is null, empty,
        /// or consists only of white-space characters.
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns>
        /// True if the value parameter is null or Empty,
        /// or if value consists exclusively of white-space characters.
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Indicates whether a specified string is NOT null, empty,
        /// or consists only of white-space characters.
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns>
        /// True if the value parameter is NOT null or NOT Empty,
        /// or if value NOT consists exclusively of white-space characters.
        /// </returns>
        public static bool IsNotNullOrWhiteSpace(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Check whether a specified string is null, empty,
        /// or consists only of white-space characters.
        /// If string is null throws <see cref="ArgumentNullException"/>.
        /// If string is empty or whitespace throws <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CheckNullOrWhiteSpace(this string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            if (str.IsNullOrWhiteSpace())
                throw new ArgumentException($"Argument {nameof(str)} can't be empty or whitespace");
        }
    }
}
