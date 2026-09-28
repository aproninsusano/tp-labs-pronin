using System;
using System.Numerics;  
class Program
{
    static void Main()
    {
        Task1_Factorial();
        Task2_Fibonacci();
        Task3_Formula();
    }
    static void Task1_Factorial()
    {
        Console.Write("Введите n (целое неотрицательное число): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
        {
            Console.WriteLine("Ошибка: введите целое неотрицательное число");
            return;
        }

        BigInteger result = Factorial(n);
        Console.WriteLine($"{n}! = {result}");
    }
    static BigInteger Factorial(int n)
    {
        BigInteger result = BigInteger.One;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
    static void Task2_Fibonacci()
    {
        Console.Write("Введите количество чисел Фибоначчи: ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count < 0)
        {
            Console.WriteLine("Ошибка: введите целое неотрицательное число");
            return;
        }

        string result = GetFibonacciString(count);
        Console.WriteLine(result);
    }
    static string GetFibonacciString(int count)
    {
        if (count == 0) return "0";
        if (count == 1) return "1";
        int previous = 0;  
        int current = 1;    
        string result = $"{previous}, {current}";
        for (int i = 2; i <= count; i++)
        {
            int next = previous + current;
            previous = current;
            current = next;
            result += $", {next}";
        }

        return $"{result}\n" +
               $"Итог последовательности Фибоначчи: {count + 1} чисел (шагов: {count})";
    }
    static void Task3_Formula()
    {
        Console.WriteLine("Формула");
        Console.WriteLine("A = √(tg(x/5) + 3) · ln(|sin x| + 1.5)");
        Console.Write("Введите x: ");
        if (!double.TryParse(Console.ReadLine(), out double x))
        {
            Console.WriteLine("Ошибка: введите число");
            return;
        }

        double? result = CalculateFormula(x);
        if (result == null)
        {
            Console.WriteLine("Ошибка: корень не существует");
            return;
        }

        Console.WriteLine($"A = {result:F4}");
    }
    static double? CalculateFormula(double x)
    {
        double tgPart = Math.Tan(x / 5.0) + 3;
        if (tgPart < 0)
        {
            return null;
        }
        double lnPart = Math.Log(Math.Abs(Math.Sin(x)) + 1.5);

        return Math.Sqrt(tgPart) * lnPart;
    }
}