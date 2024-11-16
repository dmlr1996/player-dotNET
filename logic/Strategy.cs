using System.Diagnostics;
using PlayerDotNet.models;

namespace PlayerDotNet.logic
{
    public abstract class Strategy
    {
        public static List<PlayerAction> Decide(GameState? gameState)
        {
            var myPlayerActions = new List<PlayerAction>();
            var myPlayerId = gameState.Game.Player;

            var listOfMyBases = GetListOfMyBases(gameState, myPlayerId);

            var startAttackBase = GetBaseWithLeastPopulation(gameState);

            var targetBases =   GetListOfBaseAndDistances(gameState, startAttackBase, listOfMyBases);

            var baseScores = CalculateScoreOfBases(targetBases, gameState);

            UpgradeMyBases(listOfMyBases, myPlayerActions);

            CreateLog(myPlayerId, gameState, listOfMyBases, myPlayerActions, startAttackBase);

            return myPlayerActions;
        }

        private static void CreateLog(UInt32 myPlayerId, GameState gameState, List<Base> listOfMyBases, List<PlayerAction> listOfMyPlayerActions, Base attackBase)
        {
            Console.WriteLine("My ID: {0}", myPlayerId);
            Console.WriteLine("Game ID: " + gameState.Game.Uid.ToString());
            Console.WriteLine();
            Console.WriteLine("gameState Actions");
            gameState.Actions.ForEach(i => Console.WriteLine("Src: " + i.Src.ToString() + " Dest: " + i.Dest.ToString() + " Amount: " + i.Amount.ToString() + " uuid: " + i.Uuid.ToString() + " Player: " + i.Player.ToString() + " Distance: " + i.Progress.Distance.ToString() + " Travelled: " + i.Progress.Traveled.ToString()));
            Console.WriteLine();
            Console.WriteLine("gameState Bases:");
            gameState.Bases.ForEach(i => Console.WriteLine("Base UID: " + i.Uid.ToString() + " Player: " + i.Player.ToString() + " Population: " + i.Population.ToString() + " Level: " + i.Level.ToString()));
            Console.WriteLine();
            Console.WriteLine("Attack Base: ");
            Console.WriteLine("Base UID: " + attackBase.Uid.ToString() + " Player: " + attackBase.Player.ToString() + " Population: " + attackBase.Population.ToString() + " Level: " + attackBase.Level.ToString());
            Console.WriteLine();
            Console.WriteLine("My Bases: ");
            listOfMyBases.ForEach(i => Console.WriteLine("Base UID: " + i.Uid.ToString() + " Player: " + i.Player.ToString() + " Population: " + i.Population.ToString() + " Level: " + i.Level.ToString()));
            Console.WriteLine();
            Console.WriteLine("My Actions: ");
            listOfMyPlayerActions.ForEach(i => Console.WriteLine("Src: " + i.Src.ToString() + " Dest: " + i.Dest.ToString() + " Amount: " + i.Amount.ToString()));
            Console.WriteLine("*************************************************************************************");
            Console.WriteLine();
        }

        private static void UpgradeMyBases(List<Base> listOfMyBases, List<PlayerAction> playerActions)
        {
            foreach (var bBase in listOfMyBases)
            {
                if (bBase.Level >= 14) return;
                if (DecideIfUpgrade(bBase))
                {
                    playerActions.Add(new PlayerAction
                    {
                        Src = bBase.Uid,
                        Dest = bBase.Uid,
                        Amount = bBase.Population
                    });
                }
            }
        }

        private static bool DecideIfUpgrade(Base bBase)
        {
            var baseLevel = bBase.Level;
            var basePopulation = bBase.Population;

            switch (baseLevel)
            {
                case 0 when basePopulation >= 15:
                case 1 when basePopulation >= 30:
                case 2 when basePopulation >= 50:
                case 3 when basePopulation >= 70:
                case 4 when basePopulation >= 200:
                case 5 when basePopulation >= 200:
                case 6 when basePopulation >= 300:
                case 7 when basePopulation >= 450:
                case 8 when basePopulation >= 600:
                case 9 when basePopulation >= 800:
                case 10 when basePopulation >= 1000:
                case 11 when basePopulation >= 1500:
                case 12 when basePopulation >= 2000:
                case 13 when basePopulation >= 3000:
                    return true;
                default:
                    return false;
            }
        }

        public static Base CalculateScoreOfBases(List<KeyValuePair<uint, int>> targetBases, GameState gameState)
        {
            var listOfScores = new List<KeyValuePair<uint, long>>();
            foreach (var keyValuePair in targetBases)
            {
                var score = keyValuePair.Value * gameState.Bases.Find(b => b.Uid == keyValuePair.Key).Population;
                listOfScores.Add(new KeyValuePair<uint, long>(keyValuePair.Key, score));
            }

            return gameState.Bases.Find(b => b.Uid == listOfScores.Find(b => b.Value == listOfScores.Min(b => b.Value)).Key);
        }

        private static List<Base> GetListOfMyBases(GameState? gameState, UInt32 myPlayerId)
        {
            var myBases = new List<Base>();

            if (gameState?.Bases != null)
            {
                foreach (Base bBase in gameState.Bases)
                {
                    if (bBase.Player == myPlayerId)
                    {
                        myBases.Add(bBase);
                    }
                }
            }

            return myBases;
        }

        private static Base? GetBaseWithLeastPopulation(GameState? gameState)
        {
            if (gameState == null || gameState.Bases.Count == 0)
                return null;

            return gameState.Bases.OrderByDescending(b => b.Population).Last();
        }


        public static List<KeyValuePair<uint, int>> GetListOfBaseAndDistances(GameState? gameState, Base referenceBase, List<Base> myBases)
        {
            if (gameState == null || referenceBase == null || gameState.Bases.Count == 0)
                return new List<KeyValuePair<uint, int>>();

            var baseDistances = new List<KeyValuePair<uint, int>>();

            // Iterate over all bases in the gameState, excluding bases in myBases
            foreach (var targetBase in gameState.Bases)
            {
                // Exclude bases that are in myBases (-> list foreign bases only)
                if (targetBase.Uid != referenceBase.Uid && !myBases.Any(b => b.Uid == targetBase.Uid))
                {
                    int distance = Strategy.CalculateDistanceOfBase(referenceBase, targetBase);
                    baseDistances.Add(new KeyValuePair<uint, int>(targetBase.Uid, distance));
                }
            }

            return baseDistances;
        }


        public static int CalculateDistanceOfBase(Base sourceBase, Base targetBase)
        {
            int deltaX = sourceBase.Position.X - targetBase.Position.X;
            int deltaY = sourceBase.Position.Y - targetBase.Position.Y;
            int deltaZ = sourceBase.Position.Z - targetBase.Position.Z;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
            return (int)Math.Round(distance);
        }
    }
}
