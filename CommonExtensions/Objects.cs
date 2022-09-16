namespace CommonExtensions
{
    public static class Objects
    {
        /// <summary>
        /// <para>Returns true if an object is null</para>
        /// <para>Returns false if an object is not null</para>
        /// </summary>
        public static bool IsNull<T>(this T value)
        {
            if (value == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// <para>Returns true if an object is not null</para>
        /// <para>Returns false if an object is null</para>
        /// </summary>
        public static bool IsNotNull<T>(this T value)
        {
            return !value.IsNull();
        }
    }
}