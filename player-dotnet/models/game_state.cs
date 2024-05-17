using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace player_dotnet.models
{
    public class GameState
    {
        public List<BoardAction> Actions = new List<BoardAction>();
        public List<Base> Bases = new List<Base>();
        public GameConfig Config = new GameConfig();
        public Game Game = new Game();
    }
}
