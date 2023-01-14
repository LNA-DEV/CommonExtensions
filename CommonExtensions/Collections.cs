using System.Collections.Generic;
using System.Linq;

namespace CommonExtensions
{
    public static class Collections
    {
        /// <summary>
        ///     Returns TRUE if an IEnumerable is NULL or empty
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> elements)
        {
            if (elements == null || !elements.Any()) return true;

            return false;
        }

        /// <summary>
        ///     Returns FALSE if an IEnumerable is NULL or empty
        /// </summary>
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> elements)
        {
            return !elements.IsNullOrEmpty();
        }
    }
}