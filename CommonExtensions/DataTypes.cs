namespace CommonExtensions
{
    public static class DataTypes
    {
        public static bool IsDefault<T>(this T value)
        {
            if (value == null)
                return default(T) == null;


            return value.Equals(default(T));
        }
    }
}