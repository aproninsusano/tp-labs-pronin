using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Core;
public static class Math
{
    public static long Factorial(int n)
    {
        if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));
        if (n > 20) throw new ArgumentOutOfRangeException(nameof(n), "переполнение long");
        long result = 1;
        for (int i = 2; i <= n; i++) result *= i;
        return result;
    }

    /// <summary>Числа Фибоначчи: 0, 1, 1, 2, 3, 5, ...</summary>
    public static IReadOnlyList<long> Fibonacci(int count)
    {
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
        var result = new List<long>();
        long a = 0, b = 1;
        for (int i = 0; i < count; i++)
        {
            result.Add(a);
            (a, b) = (b, a + b);
        }
        return result;
    }

    /// <summary>sin x рядом Тейлора с точностью eps.</summary>
    public static double SinTaylor(double x, double eps = 1e-6)
    {
        double term = x, sum = x;
        for (int n = 1; System.Math.Abs(term) > eps; n++)
        {
            term *= -x * x / ((2 * n) * (2 * n + 1));
            sum += term;
        }
        return sum;
    }
}
