using System;
using System.Text.Json;

namespace CommonExtensions
{
    public static class Objects
    {
        /// <summary>
        ///     <para>Returns true if an object is null</para>
        ///     <para>Returns false if an object is not null</para>
        /// </summary>
        public static bool IsNull<T>(this T value)
        {
            return value == null;
        }

        /// <summary>
        ///     <para>Returns true if an object is not null</para>
        ///     <para>Returns false if an object is null</para>
        /// </summary>
        public static bool IsNotNull<T>(this T value)
        {
            return !value.IsNull();
        }

        /// <summary>
        ///     This method trys to extract a type T from an object.
        /// </summary>
        /// <param name="obj">The to be converted object.</param>
        /// <typeparam name="T">The type which the object should be converted into.</typeparam>
        /// <returns>If the object is of type T the method returns the converted object.</returns>
        /// <returns>If the object is of type JsonElement the method trys to convert it into type T.</returns>
        /// <exception cref="ArgumentException">
        ///     If the specified object is not of type T or JsonElement this method throws an
        ///     ArgumentException.
        /// </exception>
        public static T TrySystemJsonDeserialization<T>(this object obj)
        {
            if (obj.GetType() == typeof(T)) return (T)obj;

            if (!(obj is JsonElement jsonElement))
                throw new ArgumentException($"Object was not of type {typeof(T)} or JsonElement");
            
            var item = jsonElement.Deserialize<T>();
            return item;

        }
    }
}