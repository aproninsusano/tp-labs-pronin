using Todo.Core;
using ConsoleTables;
Console.OutputEncoding = System.Text.Encoding.UTF8;
var manager = new TaskManager();

while (true)
{
    Console.WriteLine("\nМенеджер задач Todo");
    Console.WriteLine("1 - Добавить задачу");
    Console.WriteLine("2 - Выполнить задачу");
    Console.WriteLine("3 - Удалить задачу");
    Console.WriteLine("4 - Показать все задачи");
    Console.WriteLine("0 - Выход");
    Console.Write("Выбор: ");

    string? choice = Console.ReadLine();
    if (choice == "0") break;

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Введите название задачи: ");
                string? title = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(title))
                {
                    manager.Add(title);
                    Console.WriteLine("Задача добавлена.");
                }
                break;
            case "2":
                Console.Write("Введите ID задачи: ");
                if (int.TryParse(Console.ReadLine(), out int doneId))
                {
                    if (manager.MarkDone(doneId)) Console.WriteLine("Задача выполнена!");
                    else Console.WriteLine("Задача не найдена.");
                }
                break;
            case "3":
                Console.Write("Введите ID задачи: ");
                if (int.TryParse(Console.ReadLine(), out int delId))
                {
                    if (manager.Delete(delId)) Console.WriteLine("Задача удалена.");
                    else Console.WriteLine("Задача не найдена.");
                }
                break;
            case "4":
                Console.WriteLine($"\nВсего: {manager.Count()}, Выполнено: {manager.Count(true)}");

                // Использование NuGet-пакета ConsoleTables
                var table = new ConsoleTable("ID", "Название", "Статус", "Дата");
                foreach (var t in manager.Tasks)
                {
                    table.AddRow(t.Id, t.Title, t.IsDone ? "[V]" : "[ ]", t.CreatedAt.ToShortTimeString());
                }
                table.Write();
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}