using Newtonsoft.Json;

namespace PlayerDotNet.models
{
    public class PlayerAction
    {
        [JsonProperty("src")]
        public UInt32 Src { get; set; }

        [JsonProperty("dest")] public UInt32 Dest { get; set; }

        [JsonProperty("amount")]
        public UInt32 Amount { get; set; }
    }
}
