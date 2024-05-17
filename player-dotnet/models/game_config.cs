using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace player_dotnet.models
{
    public class GameConfig
    {
        public List<BaseLevel> BaseLevels = new List<BaseLevel>();
        public PathConfig Paths = new PathConfig();
    }
}
