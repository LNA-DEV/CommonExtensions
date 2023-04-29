using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CommonExtensions
{
    /// <summary>
    ///     This class contains the extension methods for collections.
    /// </summary>
    public static class Collections
    {
        /// <summary>
        ///     Returns TRUE if an IEnumerable is NULL or empty
        /// </summary>
        public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? elements)
        {
            return elements.IsNull() || !elements.Any();
        }

        /// <summary>
        ///     Returns FALSE if an IEnumerable is NULL or empty
        /// </summary>
        public static bool IsNotNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? elements)
        {
            return !elements.IsNullOrEmpty();
        }
    }
}