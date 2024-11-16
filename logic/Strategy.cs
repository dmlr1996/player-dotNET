using System.Diagnostics;
using PlayerDotNet.models;

namespace PlayerDotNet.logic
{
    public abstract class Strategy
    {
        public static List<PlayerAction> Decide(GameState? gameState)
        {
            var playerActions = new List<PlayerAction>();
            var myPlayerId = gameState.Game.Player;

            var listOfMyBases = GetListOfMyBases(gameState, myPlayerId);

            var startAttackBase = GetBaseWithMostPopulation(gameState);

            var targetBases =   GetListOfBaseAndDistances(gameState, startAttackBase, listOfMyBases);

            var baseScores = CalculateScoreOfBases(targetBases, gameState);

            //UpgradeMyBases(listOfMyBases, playerActions);

            listOfMyBases.ForEach(i =>
                playerActions.Add(new PlayerAction
                    {
                        Src = i.Uid,
                        Dest = i.Uid,
                        Amount = i.Population
                    }
                    ));

            CreateLog(myPlayerId, gameState, listOfMyBases, startAttackBase);

            return playerActions;
        }

        private static void CreateLog(UInt32 myPlayerId, GameState gameState, List<Base> listOfMyBases, Base myStartBase)
        {
            Console.WriteLine("My ID: {0}", myPlayerId);
            Console.WriteLine("Incoming gameState:");
            gameState.Bases.ForEach(i => Console.WriteLine("Player: " + i.Player.ToString() + " Base UID: " + i.Uid.ToString()));
            Console.WriteLine();
            Console.WriteLine("My Bases: ");
            listOfMyBases.ForEach(i => Console.WriteLine("Base UID: " + i.Uid.ToString() + " Player of Base: " + i.Player.ToString() + " Population: " + i.Population.ToString()));
            Console.WriteLine();
            Console.WriteLine("My Start Base: " + myStartBase.Uid.ToString());
            Console.WriteLine();
        }

        //private static void UpgradeMyBases(List<Base> listOfMyBases, List<PlayerAction> playerActions)
        //{
        //    var listOfPopulations = new List<KeyValuePair<uint, uint>>();

        //    foreach (var myBase in listOfMyBases)
        //    {
        //        if (myBase.Population < 100)
        //        {
        //            playerActions.Add(new PlayerAction
        //            {
        //                Action = "upgrade",
        //                Base = myBase.Uid
        //            });
        //        }
        //        listOfPopulations.Add(new KeyValuePair<uint, uint>(myBase.Uid, myBase.Population));
        //    }

            
        //}

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

        private static Base? GetBaseWithMostPopulation(GameState? gameState)
        {
            if (gameState == null || gameState.Bases.Count == 0)
                return null;

            return gameState.Bases.OrderByDescending(b => b.Population).First();
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
