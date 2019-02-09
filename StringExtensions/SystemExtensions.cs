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
    }
}
