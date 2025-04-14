

using System.Reflection.Metadata.Ecma335;

public class Program
{ 
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        int randomNum = rnd.Next(0, 10);
        Console.WriteLine("Я, GameRandomNumber. И Тебе надо отгадать число, которое загодал.\nТы имеешь сделть 2 ошибки. Удачи!");

        int attempt = 1;
        while (attempt <= 3)
        {
            Console.WriteLine($"========== ПОПЫТКА №{attempt} ==========");
            Console.Write("Ваш ответ: ");
            string inputAnswer = Console.ReadLine();
            bool resultNumber = int.TryParse(inputAnswer, out int number);

            if (!resultNumber)
                throw new ArgumentException("Параметр должен быть числом", nameof(inputAnswer));

            if (number == randomNum)
            {
                Console.WriteLine($"И вы угадали {number} c {attempt} попытки");
                return;
            }
            attempt++;
            if (attempt > 3)
            {
                Console.WriteLine("Эх, не угадали(\n " +
                    $"\n Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Эх, не угадали(\n " +
                    $"Ну ничего у Тебя есть {attempt} попытка" +
                    $"\n Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        Console.WriteLine("К сожалению вы проиграли.\n" +
            $"Было число {randomNum}");
    }
}
