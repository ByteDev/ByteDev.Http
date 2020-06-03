namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    /// <summary>
    /// Represents options when serializing.
    /// </summary>
    public class SerializeOptions
    {
        /// <summary>
        /// Encode all public property names and values when
        /// serializing. True by default.
        /// </summary>
        public bool Encode { get; set; } = true;

        /// <summary>
        /// Encode spaces as a plus when serializing. True by default.
        /// Property Encode must be true for this property to have any affect.
        /// </summary>
        public bool EncodeSpaceAsPlus { get; set; } = true;
    }
}