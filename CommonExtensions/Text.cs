using System.Collections.Generic;

namespace CommonExtensions
{
    /// <summary>
    ///     Extension Methods which topic operations based on Text.
    /// </summary>
    public static class Text
    {
        /// <summary>
        ///     An extension method which converts an string into an Camel-Case string.
        /// </summary>
        /// <param name="s">String which will be converted.</param>
        /// <returns>The method will return a Camel-Case string.</returns>
        public static string ToCamelCase(this string s)
        {
            var result = char.ToLower(s[0]) + s.Substring(1);

            return result;
        }

        /// <summary>
        ///     This method splits an IEnumerable of strings into an single string seperated with the separator string.
        /// </summary>
        /// <param name="strings">The strings which will be converted into a string.</param>
        /// <param name="separator">Separator string which will split the values.</param>
        /// <returns>A with the separator seperated string.</returns>
        public static string SplitToString(this IEnumerable<string> strings, string separator)
        {
            var result = "";

            if (strings.IsNotNullOrEmpty())
            {
                foreach (var item in strings) result += item + separator;

                result = result.Remove(result.Length - separator.Length);
            }

            return result;
        }
    }
}