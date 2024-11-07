using Newtonsoft.Json;

namespace PlayerDotNet.models
{
    public class GameConfig
    {
        
        [JsonProperty("base_levels")]
        public List<BaseLevel> BaseLevels { get; set; }
        
        [JsonProperty("paths")]
        public PathConfig Paths { get; set; }
    }
}
