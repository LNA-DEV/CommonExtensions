using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Nodes;

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

            switch (obj)
            {
                case string s:
                {
                    return JsonSerializer.Deserialize<T>(s);

                    break;
                }
                case JsonElement e when typeof(T) == typeof(string):
                {
                    var value = e.ValueKind switch
                    {
                        JsonValueKind.Object => JsonObject.Create(e)?.ToJsonString(),
                        JsonValueKind.Array => JsonArray.Create(e)?.ToJsonString(),
                        JsonValueKind.String => e.GetString(),
                        _ => throw new ArgumentException("JsonElement Type unknown")
                    };

                    if (value.IsNotNullOrEmpty()) return (T)Convert.ChangeType(value, typeof(T));

                    break;
                }
            }

            if (!(obj is JsonElement jsonElement))
                throw new ArgumentException($"Object was not of type {typeof(T)} or {nameof(JsonElement)}");

            var item = jsonElement.Deserialize<T>();
            return item;
        }

        /// <summary>
        ///     Compares two objects based on their properties. This method does not only check for reference equality!
        /// </summary>
        /// <param name="obj">The first object which will be compared.</param>
        /// <param name="obj2">The second object which will be compared.</param>
        /// <typeparam name="T">The type of the objects which will be compared.</typeparam>
        /// <returns>
        ///     If two objects are the same this method returns true otherwise false.
        /// </returns>
        public static bool IsSameAs<T>(this T obj, T obj2)
        {
            if (ReferenceEquals(obj, obj2)) return true;
            if (obj.IsNull() || obj2.IsNull()) return false;

            // Compare all properties of the objects
            var result = true;
            foreach (var property in obj.GetType().GetProperties())
            {
                var objValue = property.GetValue(obj);
                var anotherValue = property.GetValue(obj2);
                if (!objValue.Equals(anotherValue)) result = false;
            }

            return result;
        }

        /// <summary>
        ///     Compares two objects based on their properties. This method does not only check for reference equality!
        /// </summary>
        /// <param name="obj">The first object which will be compared.</param>
        /// <param name="obj2">The second object which will be compared.</param>
        /// <typeparam name="T">The type of the objects which will be compared.</typeparam>
        /// <returns>If two objects are the same this method returns false otherwise true.</returns>
        public static bool IsNotSameAs<T>(this T obj, T obj2)
        {
            return !obj.IsSameAs(obj2);
        }
    }
}