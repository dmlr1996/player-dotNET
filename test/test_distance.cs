using Xunit;
using PlayerDotNet.logic;
using PlayerDotNet.models;

namespace PlayerDotNet.tests
{
    public class StrategyTestsDistance
    {
        [Fact]
        public void CalculateDistanceOfBase_ValidBases_ReturnsCorrectDistance()
        {
            // Arrange
            var sourceBase = new Base
            {
                Position = new Position
                {
                    X = 3,
                    Y = 4,
                    Z = 5
                },
                Name = "abc"
            };

            var targetBase = new Base
            {
                Position = new Position
                {
                    X = 7,
                    Y = 1,
                    Z = 9
                },
                Name = "def"
            };

            // Act
            int result = Strategy.CalculateDistanceOfBase(sourceBase, targetBase);

            // Assert
            Assert.Equal(6, result); // Expected distance is 6.557 rounded to 6
        }

        [Fact]
        public void CalculateDistanceOfBase_SamePosition_ReturnsZero()
        {
            // Arrange
            var sourceBase = new Base
            {
                Position = new Position
                {
                    X = 3,
                    Y = 4,
                    Z = 5
                },
                Name = "abc"
            };

            var targetBase = new Base
            {
                Position = new Position
                {
                    X = 3,
                    Y = 4,
                    Z = 5
                },
                Name = "def"
            };

            // Act
            int result = Strategy.CalculateDistanceOfBase(sourceBase, targetBase);

            // Assert
            Assert.Equal(0, result); // Expected distance is 0
        }

        [Fact]
        public void CalculateDistanceOfBase_NegativeCoordinates_ReturnsCorrectDistance()
        {
            // Arrange
            var sourceBase = new Base
            {
                Position = new Position
                {
                    X = -3,
                    Y = -4,
                    Z = -5
                },
                Name = "abc"
            };

            var targetBase = new Base
            {
                Position = new Position
                {
                    X = -7,
                    Y = -1,
                    Z = -9
                },
                Name = "def"
            };

            // Act
            int result = Strategy.CalculateDistanceOfBase(sourceBase, targetBase);

            // Assert
            Assert.Equal(6, result); // Expected distance is the same as in the positive case
        }
    }
}
