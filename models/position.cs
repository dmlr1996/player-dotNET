using Newtonsoft.Json;

namespace PlayerDotNet.models
{
    public class Position
    {
        
        [JsonProperty("x")]
        public Int32 X { get; set; }
        
        [JsonProperty("y")]
        public Int32 Y { get; set; }
        
        [JsonProperty("z")]
        public Int32 Z { get; set; }
    }
}
