using System;
using System.Linq;
using System.Reflection;

namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    internal static class PropertyInfoExtensions
    {
        public static string GetAttributeOrPropertyName(this PropertyInfo source)
        {
            var attribute = source.GetCustomAttributes(typeof(FormUrlEncodedPropertyNameAttribute), false).SingleOrDefault();

            if (attribute != null)
            {
                var furpnAttribute = (FormUrlEncodedPropertyNameAttribute)attribute;

                if (!string.IsNullOrEmpty(furpnAttribute.Name))
                {
                    return furpnAttribute.Name;
                }
            }
                
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