using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
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
        public double CalculateParallel(double a, double b, int n)
        {
            double h = (b - a) / n;
            // PLINQ
            double totalSum = Enumerable.Range(1, n - 1)
                                        .AsParallel()
                                        .Sum(i => Function(a + i * h));

            totalSum += 0.5 * (Function(a) + Function(b));
            return totalSum * h;
        }
        public long MeasureParallel(double a, double b, int n)
        {
            Stopwatch sw = Stopwatch.StartNew();
            CalculateParallel(a, b, n);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}