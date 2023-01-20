using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace CommonExtensions
{
    /// <summary>
    ///     The Objects class contains extension methods for all kinds of objects.
    /// </summary>
    public static class Objects
    {
        /// <summary>
        ///     Method to check if an object is null.
        /// </summary>
        /// <param name="value">Value which will be null checked.</param>
        /// <typeparam name="T">Type which will be null checked.</typeparam>
        /// <returns>
        ///     Returns true if an object is null.
        ///     Returns false if an object is not null.
        /// </returns>
        public static bool IsNull<T>([NotNullWhen(false)] this T value)
        {
            return value == null;
        }

        /// <summary>
        ///     Method to check if an object is null.
        /// </summary>
        /// <param name="value">Value which will be null checked.</param>
        /// <typeparam name="T">Type which will be null checked.</typeparam>
        /// <returns>
        ///     Returns true if an object is not null.
        ///     Returns false if an object is null.
        /// </returns>
        public static bool IsNotNull<T>([NotNullWhen(true)] this T value)
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
        /// <exception cref="JsonException">
        ///     If the specified object can not be deserialized.
        /// </exception>
        public static T TrySystemJsonDeserialization<T>(this object obj)
        {
            if (obj.GetType() == typeof(T)) return (T)obj;

            if (obj is string s) return JsonSerializer.Deserialize<T>(s);

            if (!(obj is JsonElement jsonElement))
                throw new ArgumentException($"Object was not of type {typeof(T)} or {nameof(JsonElement)}");

            var item = jsonElement.Deserialize<T>();
            return item;
        }
    }
}