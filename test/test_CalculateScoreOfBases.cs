using PlayerDotNet.logic;
using PlayerDotNet.models;
using Xunit;

namespace PlayerDotNet.test
{
    public class TestCalculateScoreOfBases
    {
        [Fact]
        public void CalculateScoreOfBases_Returns_Base_With_Minimum_Score()
        {
            // Arrange
            var gameState = new GameState
            {
                Bases = new List<Base>
                {
                    new Base
                    {
                        Uid = 1,
                        Population = 100,
                        Name = "abc",
                        Position = null
                    },
                    new Base
                    {
                        Uid = 2,
                        Population = 200,
                        Name = "abc",
                        Position = null
                    },
                    new Base
                    {
                        Uid = 3,
                        Population = 50,
                        Name = "abc",
                        Position = null
                    }
                },
                Actions = null,
                Config = null,
                Game = null
            };

            var targetBases = new List<KeyValuePair<uint, int>>
            {
                new KeyValuePair<uint, int>(1, 2), // Score = 2 * 100 = 200
                new KeyValuePair<uint, int>(2, 3), // Score = 3 * 200 = 600
                new KeyValuePair<uint, int>(3, 1)  // Score = 1 * 50 = 50
            };

            // Expected base (Uid 3 has the minimum score of 50)
            var expectedBase = gameState.Bases.Find(b => b.Uid == 3);

            // Act
            var result = Strategy.CalculateScoreOfBases(targetBases, gameState);

            // Assert
            Assert.NotNull(result); // Ensure result is not null
            Assert.Equal(expectedBase.Uid, result.Uid);
            Assert.Equal(expectedBase.Population, result.Population);
        }
    }
}
