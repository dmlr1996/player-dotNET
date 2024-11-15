using Newtonsoft.Json;

namespace PlayerDotNet.models
{
    public class Game
    {
        
        [JsonProperty("uid")]
        public UInt32 Uid { get; set; }
        
        [JsonProperty("tick")]
        public UInt32 Tick { get; set; }
        
        [JsonProperty("player_count")]
        public UInt32 PlayerCount { get; set; }
        
        [JsonProperty("remaining_players")]
        public UInt32 RemainingPlayers { get; set; }
        
        [JsonProperty("player")]
        public UInt32 Player { get; set; }
    }
}
