using Newtonsoft.Json;

namespace PlayerDotNet.models
{
    public class GameState
    {
        [JsonProperty("actions")]
        public List<BoardAction> Actions { get; set; }

        [JsonProperty("bases")]
        public List<Base> Bases { get; set; }

        [JsonProperty("config")] 
        public GameConfig Config { get; set; }

        [JsonProperty("game")] 
        public Game Game { get; set; }
    }
    
}
