using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
       

        // Регулярний вираз
        string pattern = @"^(\d{1,9})[+-](\d{1,9})=(\d+)$";
        Regex regex = new Regex(pattern);

        // Введення строки користувачем
        Console.WriteLine("Введiть рядок для перевiрки:");
        string input = Console.ReadLine();

        // Перевірка строки на відповідність регулярному виразу
        Match match = regex.Match(input);
        if (match.Success)
        {
            // Витягнення чисел та оператора
            int number1 = int.Parse(match.Groups[1].Value);
            int number2 = int.Parse(match.Groups[2].Value);
            int expectedResult = int.Parse(match.Groups[3].Value);
            char operation = input[number1.ToString().Length + 1]; // Операція знаходиться після першого числа

            // Обчислення результату
            int result = operation == '+' ? number1 + number2 : number1 - number2;

            // Перевірка результату на відповідність очікуваному
            if (result == expectedResult)
            {
                Console.WriteLine("Вираз вiрний.");
            }
            else
            {
                Console.WriteLine("Вираз невiрний.");
            }
        }
        else
        {
            Console.WriteLine("Рядок не вiдповiдає формату.");
        }

        Console.ReadKey(); // Очікування натискання клавіші перед виходом з програми
    }
}
