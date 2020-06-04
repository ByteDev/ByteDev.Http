using System;
using System.Collections.Generic;
using System.Reflection;

namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    internal static class ObjectExtensions
    {
        public static void SetPublicProperty(this object source, string propertyName, object value)
        {
            var pi = source.GetPublicProperty(propertyName);

            if (pi != null && pi.CanWrite)
            {
                source.SetTypeValue(pi, value);
            }
        }

        public static void SetTypeValue(this object source, PropertyInfo pi, object value)
        {
            if (pi == null)
                throw new ArgumentNullException(nameof(pi));

            if (value == null)
                pi.SetValue(source, null, null);

            else if (pi.PropertyType == typeof(string))
                pi.SetValue(source, value, null);

            else if (pi.PropertyType == typeof(bool))
                pi.SetValue(source, Convert.ToBoolean(value), null);
            else if (pi.PropertyType == typeof(char))
                pi.SetValue(source, Convert.ToChar(value), null);

            else if (pi.PropertyType == typeof(long))
                pi.SetValue(source, Convert.ToInt64(value), null);
            else if (pi.PropertyType == typeof(int))
                pi.SetValue(source, Convert.ToInt32(value), null);                
            else if (pi.PropertyType == typeof(short))
                pi.SetValue(source, Convert.ToInt16(value), null);
            else if (pi.PropertyType == typeof(byte))
                pi.SetValue(source, Convert.ToByte(value), null);

            else if (pi.PropertyType == typeof(decimal))
                pi.SetValue(source, Convert.ToDecimal(value), null);
            else if (pi.PropertyType == typeof(double))
                pi.SetValue(source, Convert.ToDouble(value), null);
            else if (pi.PropertyType == typeof(float))
                pi.SetValue(source, Convert.ToSingle(value), null);
            
            else if (pi.PropertyType == typeof(ulong))
                pi.SetValue(source, Convert.ToUInt64(value), null);
            else if (pi.PropertyType == typeof(uint))
                pi.SetValue(source, Convert.ToUInt32(value), null);                
            else if (pi.PropertyType == typeof(ushort))
                pi.SetValue(source, Convert.ToUInt16(value), null);
            else if (pi.PropertyType == typeof(sbyte))
                pi.SetValue(source, Convert.ToSByte(value), null);

            else
                pi.SetValue(source, value.ToString(), null);
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

                dict.Add(property.GetPropertyName(), value.ToString());
            }

            return dict;
        }
    }
}