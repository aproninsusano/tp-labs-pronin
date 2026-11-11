using Laborator3;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Сравнение двух текстовых файлов");
            logicclass comparer = new logicclass();
            while (true)
            {
                Console.WriteLine("\n1. Сравнить файлы");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string? choice = Console.ReadLine();
                if (choice == "0") break;

                if (choice == "1")
                {
                    Console.Write("Введите путь к первому файлу: ");
                    string? path1 = Console.ReadLine();

                    Console.Write("Введите путь ко второму файлу: ");
                    string? path2 = Console.ReadLine();
                    // Проверка на пустой ввод
                    if (string.IsNullOrWhiteSpace(path1) || string.IsNullOrWhiteSpace(path2))
                    {
                        Console.WriteLine("Ошибка: пути к файлам не могут быть пустыми.");
                        continue;
                    }
                    try
                    {
                        List<string> diff = comparer.classforsravnenia(path1, path2);

                        if (diff.Count == 0)
                        {
                            Console.WriteLine("Файлы идентичны.");
                        }
                        else
                        {
                            Console.WriteLine($"\nНайдены различия ({diff.Count / 3} строк):");
                            foreach (string line in diff)
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Ошибка: нет прав на чтение файла.");
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный выбор.");
                }
            }
        }
    }
}