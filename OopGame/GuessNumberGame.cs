using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopGame
{
    public class GuessNumberGame
    {
        public GameSettings Settings { get; set; }
        private readonly int _secretNumber;
        private readonly int _maxAttempts;
        private int _attemptsUsed;

        public GuessNumberGame(GameSettings settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            var rnd = new Random();
            _secretNumber = rnd.Next(Settings.MinNumber, Settings.MaxNumber + 1);
            _maxAttempts = CalculateMaxAttempts();
            _attemptsUsed = 0;
        }

        public int CalculateMaxAttempts()
        {
            int range = Settings.MaxNumber - Settings.MinNumber;
            int baseAttempts = (int)Math.Ceiling(Math.Log(range + 1, 2));

            return Settings.Difficulty switch
            {
                DifficultyLevel.Easy => baseAttempts,
                DifficultyLevel.Medium => Math.Max(1, baseAttempts - 1),
                DifficultyLevel.Hard => Math.Max(1, baseAttempts - 2),
                _ => baseAttempts
            };
        }

        public GuessResult MakeGuess(int number)
        {
            _attemptsUsed++;

            if (number == _secretNumber)
            {
                return new GuessResult
                {
                    IsCorrect = true,
                    Message = $"Поздравляем! Вы угадали число {_secretNumber} с {_attemptsUsed} попытки.",
                    AttemptsLeft = _maxAttempts - _attemptsUsed
                };
            }

            if (_attemptsUsed >= _maxAttempts)
            {
                return new GuessResult
                {
                    IsCorrect = false,
                    Message = $"К сожалению, вы проиграли. Было загадано число {_secretNumber}.",
                    AttemptsLeft = 0
                };
            }

            return new GuessResult
            {
                IsCorrect = false,
                Message = $"Не угадали. У вас осталось {_maxAttempts - _attemptsUsed} попыток.",
                AttemptsLeft = _maxAttempts - _attemptsUsed
            };
        }

        public int GetMaxAttempts() => _maxAttempts;

        public int GetAttemptsUsed() => _attemptsUsed;
    }
}
