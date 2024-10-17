using PlayerDotNet.models;

namespace PlayerDotNet.logic
{
    public abstract class Strategy
    {
        public static PlayerAction Decide(GameState? gameState)
        {
            //TODO: Add your logic here!
            return new PlayerAction();
        }
    }
}
