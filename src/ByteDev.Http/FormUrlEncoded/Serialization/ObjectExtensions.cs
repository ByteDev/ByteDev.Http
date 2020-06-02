using System;
using System.Collections.Generic;
using System.Reflection;

namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    internal static class ObjectExtensions
    {
        public static void SetPublicProperty(this object source, string propertyName, object propertyValue)
        {
            var pi = source.GetPublicProperty(propertyName);

            if (pi != null && pi.CanWrite)
            {
                if (pi.PropertyType == typeof(bool))
                    pi.SetValue(source, Convert.ToBoolean(propertyValue), null);
                else if (pi.PropertyType == typeof(long))
                    pi.SetValue(source, Convert.ToInt64(propertyValue), null);
                else if (pi.PropertyType == typeof(int))
                    pi.SetValue(source, Convert.ToInt32(propertyValue), null);                
                else if (pi.PropertyType == typeof(short))
                    pi.SetValue(source, Convert.ToInt16(propertyValue), null);
                else if (pi.PropertyType == typeof(byte))
                    pi.SetValue(source, Convert.ToByte(propertyValue), null);
                else if (pi.PropertyType == typeof(char))
                    pi.SetValue(source, Convert.ToChar(propertyValue), null);
                else if (pi.PropertyType == typeof(float))
                    pi.SetValue(source, Convert.ToSingle(propertyValue), null);
                else if (pi.PropertyType == typeof(double))
                    pi.SetValue(source, Convert.ToDouble(propertyValue), null);
                else
                    pi.SetValue(source, propertyValue, null);
            }
        }

        public static PropertyInfo GetPublicProperty(this object source, string propertyName)
        {
            return source.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        }

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

                dict.Add(property.Name, value.ToString());
            }

            return dict;
        }
    }
}