using System;
using System.Collections.Generic;

namespace Laborator2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Автосервис: демонстрация\n");
            //Экземпляр класса-менеджера, который будет хранить нашу очередь работ
            Service station = new Service();
            //Объекты на обработку в очередь
            station.AddJob(new MaintenanceJob("Смирнов", 2.0, 1500, 10000));
            station.AddJob(new BodyRepairJob("Игнатьев", 5.0, 2000, 3));
            station.AddJob(new DiagnosticJob("Рудько", 1.0, 1800, true));
            station.AddJob(new MaintenanceJob("данилов", 1.5, 1500, 15000));
            station.AddJob(new DiagnosticJob("Смирнов", 0.5, 1800, false));
            station.PrintQueue();
            Console.WriteLine($"\nОбщая стоимость: {station.TotalCost():F2} руб.");
            Console.WriteLine($"Средняя стоимость: {station.AverageCost():F2} руб.");
            //LINQ-фильтраци
            Console.WriteLine("\nТолько ТО");
            List<RepairJob> toJobs = station.GetByType("ТО");
            //Перебираем отфильтрованный список и выводим его
            foreach (RepairJob job in toJobs)
            {
                Console.WriteLine(job);
            }
            Console.WriteLine("\nСтатистика по типам");
            Dictionary<string, int> stats = station.CountByType();
            foreach (KeyValuePair<string, int> pair in stats)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} шт.");
            }
            List<RepairJob> listForSort = new List<RepairJob>
            {
                new MaintenanceJob("Смирнов", 2.0, 1500, 10000),
                new BodyRepairJob("Игнатьев", 5.0, 2000, 3),
                new DiagnosticJob("Рудько", 1.0, 1800, true),
                new MaintenanceJob("данилов", 1.5, 1500, 15000),
                new DiagnosticJob("Смирнов", 0.5, 1800, false)};
            listForSort.Sort();
            Console.WriteLine("\nОтсортировано");
            foreach (RepairJob job in listForSort)
            {
                Console.WriteLine(job);
            }
        }
    }
}