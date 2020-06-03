namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    /// <summary>
    /// Represents options when deserializing.
    /// </summary>
    public class DeserializeOptions
    {
        /// <summary>
        /// Decode all pair names and values when deserializing.
        /// True by default.
        /// </summary>
        public bool Decode { get; set; } = true;

        /// <summary>
        /// Decode the plus as a space when deserializing. True by default.
        /// Property Decode must be true for this property to have any affect.
        /// </summary>
        public bool DecodePlusAsSpace { get; set; } = true;
    }
}