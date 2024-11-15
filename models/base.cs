using Newtonsoft.Json;

namespace PlayerDotNet.models
{
    public class Base
    {
        [JsonProperty("position")]
        public required Position Position { get; set; }

        [JsonProperty("uid")]
        public UInt32 Uid { get; set; }

        [JsonProperty("player")]
        public UInt32 Player { get; set; }

        [JsonProperty("population")]
        public UInt32 Population { get; set; }

        [JsonProperty("level")]
        public UInt32 Level { get; set; }

        [JsonProperty("units_until_upgrade")]
        public UInt32 UnitsUntilUpgrade { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }
    }
}
