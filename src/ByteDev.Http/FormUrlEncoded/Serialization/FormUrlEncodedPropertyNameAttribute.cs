using System;

namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    /// <summary>
    /// Specifies the property name that is present in the Form URL encoded data
    /// when serializing and deserializing.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FormUrlEncodedPropertyNameAttribute : Attribute
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Http.FormUrlEncoded.Serialization.FormUrlEncodedPropertyNameAttribute" /> class
        /// with the specified property name.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        public FormUrlEncodedPropertyNameAttribute(string name)
        {
            Name = name;
        }
    }
}