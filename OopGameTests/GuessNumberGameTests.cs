using Microsoft.VisualStudio.TestTools.UnitTesting;
using OopGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopGame.Tests
{
    [TestClass()]
    public class GuessNumberGameTests
    {

        [TestMethod()]
        [DataRow(16, DifficultyLevel.Easy, 5)]
        [DataRow(16, DifficultyLevel.Medium, 4)]
        [DataRow(16, DifficultyLevel.Hard, 3)]
        [DataRow(15, DifficultyLevel.Easy, 4)]
        public void CalculateMaxAttemptsTest(int max, DifficultyLevel difficulty, int expected)
        {
            var settings = new GameSettings
            {
                MaxNumber = max,
                Difficulty = difficulty
            };
            var game = new GuessNumberGame(settings);

            int attempts = game.GetMaxAttempts();

            Assert.AreEqual(expected, attempts);
        }
    }
}