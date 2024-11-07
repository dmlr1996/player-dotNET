using Newtonsoft.Json;

namespace PlayerDotNet.models
{
    public class BaseLevel
    {
        
        [JsonProperty("max_population")]
        public UInt32 MaxPopulation { get; set; }
        
        [JsonProperty("upgrade_cost")]
        public UInt32 UpgradeCost { get; set; }
        
        [JsonProperty("spawn_rate")]
        public UInt32 SpawnRate { get; set; }
    }
}
