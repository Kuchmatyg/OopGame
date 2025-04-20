using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OopGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopGame.Tests
{
    [TestClass()]
    public class GameBuilderTests
    {
        [TestMethod()]
        [DataRow(2, 2)]
        [DataRow(12, 12)]
        public void EndRangeTest(int value, int expectedValue)
        {

            var build = new GameBuilder();

            var game = build.Build();
            build.EndRange(value);

            Assert.AreEqual(expectedValue, game.Settings.MaxNumber);
            Assert.AreEqual(build, build.EndRange(value));
        }

        [TestMethod()]
        [DataRow(DifficultyLevel.Hard, DifficultyLevel.Hard)]
        [DataRow(DifficultyLevel.Medium, DifficultyLevel.Medium)]
        [DataRow(DifficultyLevel.Easy, DifficultyLevel.Easy)]
        public void WithDifficultyTest(DifficultyLevel value, DifficultyLevel expectedValue)
        {
            var builder = new GameBuilder()
                .WithDifficulty(value);

            var game = builder.Build();

            Assert.AreEqual(expectedValue, game.Settings.Difficulty);
        }
    }
}