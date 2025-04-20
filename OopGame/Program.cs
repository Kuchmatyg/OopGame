using OopGame;

public class Program
{
    public static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            GameUI.DisplayWelcomeMessage();
            var difficulty = GameUI.GetDifficultyLevel();
            var max = GameUI.GetNumberEndRange();

            var game = new GameBuilder()
                .EndRange(max)
                .WithDifficulty(difficulty)
                .Build();

            Console.WriteLine($"\nУ вас есть {game.GetMaxAttempts()} попыток, чтобы угадать число.");

            int lastGuess = int.MinValue;
            bool gameOver = false;

            while (!gameOver)
            {
                int guess;
                try
                {
                    guess = GameUI.GetUserGuess(game.GetAttemptsUsed() + 1);

                    if (guess == lastGuess)
                    {
                        Console.WriteLine("Вы уже вводили это число! Попробуйте другое.");
                        continue;
                    }

                    if (guess < 0)
                    {
                        Console.WriteLine("Число должно быть не отрицательным! Попробуйте другое.");
                        continue;
                    }

                    lastGuess = guess;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                    continue;
                }

                var result = game.MakeGuess(guess);
                GameUI.DisplayGameResult(result);
                gameOver = result.IsCorrect || result.AttemptsLeft == 0;
            }
        }
        while (GameUI.AskToPlayAgain());

        Console.WriteLine("\nСпасибо за игру! До свидания!");
    }
}
