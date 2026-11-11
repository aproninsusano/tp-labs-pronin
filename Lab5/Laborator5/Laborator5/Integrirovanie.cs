using System;
using System.Diagnostics;
namespace Laborator5
{
    public class Integrator
    {
        // Функция f(x) = x^2
        private double Function(double x) => x * x;
        public double CalculateSequential(double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = 0.5 * (Function(a) + Function(b));
            for (int i = 1; i < n; i++)
            {
                sum += Function(a + i * h);
            }
            return sum * h;
        }
        //Проверка по скорости
        public long MeasureSequential(double a, double b, int n)
        {
            Stopwatch sw = Stopwatch.StartNew();
            CalculateSequential(a, b, n);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}