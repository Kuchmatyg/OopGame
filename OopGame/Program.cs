using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();

        // Менюшка
        int option = 0;
        while (option != 1 && option != 2)
        {
            Console.WriteLine("Я, GameRandomNumber.\nИгра, где нужно отгадать число.\nЯ могу предолжить тебе два сценария по которому можно пойти");
            Console.Write("1) По умолчанию (число от 0 до 10)\n" +
                "2) Ты сам границу выбираешь (число от 0 до n)\n" +
                "Твой выбор: ");
            string inputOptin = Console.ReadLine();
            option = SelectGameOption(inputOptin);
        }

        //Заполняем randomNum в зависимости от выбора пользователя
        int randomNum;
        int n = 10; //Граница выборки
        if (option == 1) randomNum = rnd.Next(0, n);
        else
        {
            Console.Write("Ооо классный сценарий)\n" +
                "Какое число будет заканчивать выборку?\n" +
                "n=");
            string inputN = Console.ReadLine();

            bool resultOption = int.TryParse(inputN, out n);
            if (!resultOption)
                throw new ArgumentException("Строка должна состоять из цифры", nameof(inputN));
            randomNum = rnd.Next(0, n);
        }


        //Рассчитываем количество попыток пользователя
        int countOfAttempt = CalculateTheNumberOfAttempts(n);

        int attempt = 1; //Первая попытка
        int prevNumber = -1;  //Специально выставляем такое значение
        Console.WriteLine($"Изначально у тебя вот столкьое попыток --> {countOfAttempt}");
        while (attempt <= countOfAttempt)
        {
            Console.WriteLine($"========== ПОПЫТКА №{attempt} ==========");
            Console.Write("Ваш ответ: ");
            string inputAnswer = Console.ReadLine();
            bool resultNextNumber = int.TryParse(inputAnswer, out int nextNumber);

            if (!resultNextNumber)
                throw new ArgumentException("Параметр должен быть числом", nameof(inputAnswer));

            if (nextNumber == prevNumber)
            {
                Console.WriteLine($"Серьёзно {nextNumber}? В прошлый раз ты уже вводил {prevNumber}. Ну и лошара\n" +
                    $"Ладно, так уж и быть попытку №{attempt} не сгорает)\n" +
                    $"У тебя осталось столько же попыток, т.е. \'{countOfAttempt - attempt + 1}\'\n" +
                    $"\nНажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
                continue;
            }

            if (nextNumber == randomNum)
            {
                Console.WriteLine($"И вы угадали {nextNumber} c {attempt} попытки");
                return;
            }

            attempt++;
            if (attempt > countOfAttempt)
            {
                Console.WriteLine("Эх, не угадали(\n" +
                    "Ваши попытки закончились.\n" +
                    $"\nНажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Эх, не угадали(\n" +
                    $"Ну ничего у Тебя есть {attempt} попытка\n" +
                    $"У тебя осталось попыток --> {countOfAttempt - attempt + 1}\n" +
                    $"\nНажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
                prevNumber = nextNumber;
            }
        }
        Console.WriteLine("К сожалению вы проиграли.\n" +
            $"Было число {randomNum}");
    }

    public static int SelectGameOption(string option)
    {
        bool resultOption = int.TryParse(option, out int num);

        if (!resultOption)
            throw new ArgumentException("Строка должна состоять из цифры", nameof(option));

        switch (num)
        {
            case 1:
                break;
            case 2:
                break;

            default:
                Console.WriteLine("Такого варианта ответа нет! Выберить 1 или 2.\n" +
                    "\nНажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();

                break;
        }
        return num;
    }

    public static int CalculateTheNumberOfAttempts(int n)
    {
        int countAttempts = 0;
        double pow;
        for (int i = 0; i < n; i++)
        {
            pow = Math.Pow(2, i);
            if (pow > n)
            {
                countAttempts = i - 1;
                break;
            }
        }

        return countAttempts;
    }
}
