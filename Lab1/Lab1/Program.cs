using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите n от 0 до 20:");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 0 || n > 20)
        {
            Console.WriteLine("Ошибка: введите целое число от 0 до 20");
            return;
        }
        Console.WriteLine($"{n}! = {Factorial(n)}");

        // === ЗАДАЧА 2: ФИБОНАЧЧИ ===
        Console.WriteLine("\nВведите количество чисел Фибоначчи:");
        if (!int.TryParse(Console.ReadLine(), out int numbers) || numbers < 0)
        {
            Console.WriteLine("Ошибка: введите целое неотрицательное число");
            return;
        }

        int result1 = 0;
        int result2 = 1;

        if (numbers == 0)
        {
            Console.WriteLine("0");
        }
        else if (numbers == 1)
        {
            Console.WriteLine("1");
        }
        else
        {
            Console.Write($"{result1}, {result2}");
            for (int i = 2; i <= numbers; i++)
            {
                int result3 = result1 + result2;
                result1 = result2;
                result2 = result3;
                Console.Write($", {result3}");
            }
            Console.WriteLine();
            Console.WriteLine($"Итог последовательности Фибоначчи приведён выше с количеством шагов, равным: {numbers}");
        }
        Console.WriteLine("\nВведите x для формулы A = √(tg(x/5) + 3) · ln(|sin x| + 1.5):");
        if (!double.TryParse(Console.ReadLine(), out double x))
        {
            Console.WriteLine("Ошибка: введите число");
            return;
        }
        double tgPart = Math.Tan(x / 5.0) + 3;

        if (tgPart < 0)
        {
            Console.WriteLine("Ошибка: подкоренное выражение отрицательно, корень не существует");
            return;
        }

        double A = Math.Sqrt(tgPart) * Math.Log(Math.Abs(Math.Sin(x)) + 1.5);
        Console.WriteLine($"A = {A:F4}");
    }

    static long Factorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;   
    }
}