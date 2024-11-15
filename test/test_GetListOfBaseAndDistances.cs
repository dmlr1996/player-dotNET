using System;
using System.Collections.Generic;
using Xunit;
using PlayerDotNet.models;
using PlayerDotNet.logic;

namespace PlayerDotNet.Tests
{
    public class StrategyTestsLists
    {
        [Fact]
        public void GetListOfBaseAndDistances_ExcludesMyBases_ReturnsCorrectDistances()
        {
            // Arrange
            var myBases = new List<Base>
            {
                new Base
                {
                    Uid = 1,
                    Position = new Position
                    {
                        X = 0,
                        Y = 0,
                        Z = 0
                    },
                    Population = 100,
                    Name = "abc"
                },
                new Base
                {
                    Uid = 2,
                    Position = new Position
                    {
                        X = 10,
                        Y = 10,
                        Z = 10
                    },
                    Population = 150,
                    Name = "def"
                }
            };

            var referenceBase = new Base
            {
                Uid = 99,
                Position = new Position
                {
                    X = 10,
                    Y = 11,
                    Z = 12
                },
                Population = 100,
                Name = "def"
            };

            var gameState = new GameState
            {
                Bases = new List<Base>
                {
                    new Base
                    {
                        Uid = 1,
                        Position = new Position
                        {
                            X = 0,
                            Y = 0,
                            Z = 0
                        },
                        Population = 100,
                        Name = "def"
                    },
                    new Base
                    {
                        Uid = 2,
                        Position = new Position
                        {
                            X = 10,
                            Y = 10,
                            Z = 10
                        },
                        Population = 150,
                        Name = "def"
                    },
                    new Base
                    {
                        Uid = 3,
                        Position = new Position
                        {
                            X = 20,
                            Y = 20,
                            Z = 20
                        },
                        Population = 50,
                        Name = "def"
                    },
                    new Base
                    {
                        Uid = 4,
                        Position = new Position
                        {
                            X = 30,
                            Y = 30,
                            Z = 30
                        },
                        Population = 200,
                        Name = "def"
                    }
                },
                Actions = null,
                Config = null,
                Game = null
            };

            // Act
            var distances = Strategy.GetListOfBaseAndDistances(gameState, referenceBase, myBases);

            // Assert
            // Ensure the reference base (with highest population) is base 4
            Assert.Contains(distances, d => d.Key == 3); // Base with Uid 3 (foreign base) should be included
            Assert.DoesNotContain(distances, d => d.Key == 1); // Base with Uid 1 (myBase) should be excluded
            Assert.DoesNotContain(distances, d => d.Key == 2); // Base with Uid 2 (myBase) should be excluded
            Assert.Contains(distances, d => d.Key == 4); // Base with Uid 4 (foreign base) should be included
        }
    }
}
