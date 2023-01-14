namespace CommonExtensions
{
    public static class DataTypes
    {
        /// <summary>
        ///     Returns the default value of a type
        /// </summary>
        public static bool IsDefault<T>(this T value)
        {
            if (value == null)
                return default(T) == null;

            return value.Equals(default(T));
        }
    }
}