using Newtonsoft.Json;

namespace PlayerDotNet.models
{
    public class Progress
    {
        
        [JsonProperty("distance")]
        public UInt32 Distance { get; set; }
        
        [JsonProperty("traveled")]
        public UInt32 Traveled { get; set; }
    }
}
