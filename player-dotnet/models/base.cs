using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using player_dotnet.models;

namespace player_dotnet.models
{
    public class Base
    {
        public Position Position = new Position();
        public UInt32 Uid = 0;
        public UInt32 Player = 0;
        public UInt32 Population = 0;
        public UInt32 Level = 0;
        public UInt32 UnitsUntilUpgrade = 0;
    }
}
