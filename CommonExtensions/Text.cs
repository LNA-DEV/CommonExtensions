using System.Collections.Generic;

namespace CommonExtensions
{
    public static class Text
    {
        public static string ToCamelCase(this string s)
        {
            var result = char.ToLower(s[0]) + s.Substring(1);

            return result;
        }

        public static string SplitToString(this IEnumerable<string> strings, string separator)
        {
            string result = "";

            if (strings != null)
            {
                foreach (var item in strings)
                {
                    result += item + separator;
                }

                result = result.Remove(result.Length - separator.Length);
            }

            return result;
        }
    }
}
