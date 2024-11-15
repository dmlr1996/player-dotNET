using Newtonsoft.Json;

namespace PlayerDotNet.models
{
    public class BoardAction
    {
        [JsonProperty("src")]
        public UInt32 Src { get; set; }

        [JsonProperty("dest")]
        public UInt32 Dest { get; set; }

        [JsonProperty("amount")]
        public UInt32 Amount { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("player")]
        public UInt32 Player { get; set; }

        [JsonProperty("progress")]
        public required Progress Progress { get; set; }
    }
}
