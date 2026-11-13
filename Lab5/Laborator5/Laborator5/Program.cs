using System;
namespace Laborator5
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Вариант 11: Численное интегрирование");
            Console.WriteLine("Функция: f(x) = x^2 на отрезке [0, 1]\n");
            const int N = 100_000_000; 
            const double A = 0.0;
            const double B = 1.0;
            Console.WriteLine($"Количество разбиений: {N:N0}");
            Console.WriteLine($"Ядер доступно: {Environment.ProcessorCount}\n");
            Integrator integrator = new Integrator();
            // Последовательно
            long timeSeq = integrator.MeasureSequential(A, B, N);
            double resSeq = integrator.CalculateSequential(A, B, N);
            Console.WriteLine($"Последовательно: {timeSeq} мс (Результат: {resSeq:F5})");
            // Параллельно
            long timePar = integrator.MeasureParallel(A, B, N);
            double resPar = integrator.CalculateParallel(A, B, N);
            Console.WriteLine($"Параллельно:      {timePar} мс (Результат: {resPar:F5})");
            // Ускорение
            if (timePar > 0)
            {
                double speedup = (double)timeSeq / timePar;
                Console.WriteLine($"\nУскорение: {speedup:F2}x");
            }
        }
    }
}