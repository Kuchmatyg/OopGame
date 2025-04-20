using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopGame
{
    public static class GameUI
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");
            Console.WriteLine("Выберите уровень сложности:");
            Console.WriteLine("1. Легкий");
            Console.WriteLine("2. Средний");
            Console.WriteLine("3. Сложный");
        }

        public static DifficultyLevel GetDifficultyLevel()
        {
            while (true)
            {
                Console.Write("Ваш выбор (1-3): ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
                {
                    return (DifficultyLevel)(choice - 1);
                }
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 3.");
            }
        }

        public static int GetNumberEndRange()
        {
            Console.WriteLine("Выберите диапазон чисел:");
            Console.WriteLine("1. Стандартный (0-10)");
            Console.WriteLine("2. Пользовательский");

            while (true)
            {
                Console.Write("Ваш выбор (1-2): ");
                if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
                {
                    if (choice == 1) return  10;

                    Console.Write("Введите максимальное число: ");
                    int max = GetValidNumber();

                    return  max;
                }
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите 1 или 2.");
            }
        }

        private static int GetValidNumber(int minValue = int.MinValue)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if (number > minValue) return number;
                    Console.WriteLine($"Число должно быть больше {minValue}. Попробуйте снова:");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число:");
                }
            }
        }

        public static int GetUserGuess(int attemptNumber)
        {
            Console.WriteLine($"\n=== Попытка #{attemptNumber} ===");
            Console.Write("Введите ваше предположение: ");
            return GetValidNumber();
        }

        public static void DisplayGameResult(GuessResult result)
        {
            Console.WriteLine(result.Message);
        }

        public static bool AskToPlayAgain()
        {
            Console.Write("\nХотите сыграть еще раз? (y/n): ");
            return Console.ReadLine()?.ToLower() == "y";
        }
    }
}
