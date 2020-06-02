namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    public class DeserializeOptions
    {
        public bool Decode { get; set; } = true;

        public bool DecodePlusAsSpace { get; set; } = true;
    }
}