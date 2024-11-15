using Newtonsoft.Json;

namespace PlayerDotNet.models
{
    public class PathConfig
    {
        
        [JsonProperty("grace_period")]
        public UInt32 GracePeriod { get; set; }
        
        [JsonProperty("death_rate")]
        public UInt32 DeathRate { get; set; }
    }
}
