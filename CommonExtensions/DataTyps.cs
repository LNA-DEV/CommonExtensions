namespace CommonExtensions
{
    public static class DataTyps
    {
        public static bool IsDefault<T>(this T value)
        {
            if (value == null)
                return default(T) == null;


            return value.Equals(default(T));
        }
    }
}