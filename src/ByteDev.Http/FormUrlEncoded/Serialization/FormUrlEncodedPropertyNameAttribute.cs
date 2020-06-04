using System;

namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FormUrlEncodedPropertyNameAttribute : Attribute
    {
        public string Name { get; }

        public FormUrlEncodedPropertyNameAttribute(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name was null or empty.", nameof(name));

            Name = name;
        }
    }
}