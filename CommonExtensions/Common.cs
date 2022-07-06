using System.Collections.Generic;

namespace CommonExtensions
{
    public static class Common
    {
        public static string ToCamelCase(this string s)
        {
            var result = char.ToLower(s[0]) + s.Substring(1);

            return result;
        }

        public static string SplitToString(this string[] strings, string seperator)
        {
            string result = "";

            if (!strings.IsNullOrEmpty())
            {
                foreach (var item in strings)
                {
                    result += item + seperator;
                }

                result = result.Remove(result.Length - seperator.Length);
            }

            return result;
        }

        public static string SplitToString(this List<string> strings, string separator)
        {
            string result = "";

            if (strings != null)
            {
                foreach (var item in strings)
                {
                    result += item + separator;
                }
            }

            return result;
        }
    }
}
