using System.Collections.Generic;
using System.Reflection;

namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    internal static class ObjectExtensions
    {
        public static IDictionary<string, string> GetPropertiesAsDictionary(this object source)
        {
            var dict = new Dictionary<string, string>();

            if (source == null)
                return dict;

            var properties = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in properties)
            {
                var value = property.GetValue(source);

                if (value == null)
                    continue;

                dict.Add(property.GetAttributeOrPropertyName(), value.ToString());
            }

            return dict;
        }
    }
}