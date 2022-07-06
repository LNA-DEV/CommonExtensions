using System.Collections.Generic;
using System.Linq;

namespace CommonExtensions
{
    public static class Assertions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> elements)
        {
            if (elements == null || elements.Count() == 0)
            {
                return true;
            }

            return false;
        }
    }
}
