using System;
using System.Linq;
using System.Reflection;

namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    internal static class PropertyInfoExtensions
    {
        public static string GetPropertyName(this PropertyInfo source)
        {
            var attribute = source.GetCustomAttributes(typeof(FormUrlEncodedPropertyNameAttribute), false).SingleOrDefault();

            if (attribute != null)
                return ((FormUrlEncodedPropertyNameAttribute) attribute).Name;

            return source.Name;
        }

        public static string GetAttributeName(this PropertyInfo source)
        {
            var attribute = source.GetCustomAttributes(typeof(FormUrlEncodedPropertyNameAttribute), false).SingleOrDefault();

            if (attribute == null)
                throw new InvalidOperationException($"Property: {source.Name} does not have a {nameof(FormUrlEncodedPropertyNameAttribute)} attribute applied.");

            return ((FormUrlEncodedPropertyNameAttribute) attribute).Name;
        }
    }
}