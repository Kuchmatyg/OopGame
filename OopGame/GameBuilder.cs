using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopGame
{
    public class GameBuilder
    {
        public GameSettings Settings { get; set; } = new GameSettings();

        public GameBuilder EndRange(int max)
        {
            Settings.MaxNumber = max;
            return this;
        }

        public GameBuilder WithDifficulty(DifficultyLevel difficulty)
        {
            Settings.Difficulty = difficulty;
            return this;
        }

        public GuessNumberGame Build()
        {
            return new GuessNumberGame(Settings);
        }
    }
}
