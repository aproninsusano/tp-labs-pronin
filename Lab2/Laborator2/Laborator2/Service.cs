using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator2
{
    //реализуем логику работы сервиса
    public class Service
    {
        private readonly List<RepairJob> _queue = new();
        public void AddJob(RepairJob job)
        {
            if (job == null) throw new ArgumentNullException(nameof(job));
            _queue.Add(job);
        }
        // подсчёт общей стоимости
        public double TotalCost() => _queue.Sum(j => j.CalculateCost());
        // тут в словаре будем хранить наследников + для фильтрации по типу
        public List<RepairJob> GetByType(string jobType) =>
            _queue.Where(j => j.JobType == jobType).ToList();
        public double AverageCost() =>
            _queue.Count == 0 ? 0 : _queue.Average(j => j.CalculateCost());
        public List<RepairJob> GetSortedByCost() =>
            _queue.OrderBy(j => j.CalculateCost()).ToList();
       // Группируем работы по строковому ключу и возвращает словарь, где ключ — тип, а значение — количество.
        public Dictionary<string, int> CountByType() =>
            _queue.GroupBy(j => j.JobType)
                  .ToDictionary(g => g.Key, g => g.Count());
        public void PrintQueue()
        {
            Console.WriteLine("Очередь работ:");
            foreach (var job in _queue)
                Console.WriteLine(job);
        }
    }
}