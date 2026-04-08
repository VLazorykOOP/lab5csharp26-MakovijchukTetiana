using System;
using lab_5.task1;
using lab_5.task2;
using lab_5.task3;
using Lab_4; // Простір імен для 4 завдання (клас Date)

namespace lab_5
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("  ГОЛОВНЕ МЕНЮ ");
                Console.WriteLine("1 - Запустити Завдання 1 (Ієрархія класів)");
                Console.WriteLine("2 - Запустити Завдання 2 (Конструктори та Деструктори)");
                Console.WriteLine("3 - Запустити Завдання 3 (Абстрактний клас ПЗ)");
                Console.WriteLine("4 - Запустити Завдання 4 (Часткові класи Date з Лаб 4)");
                Console.WriteLine("0 - Вихід з програми");
                Console.Write("Оберіть пункт меню: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        task1Runner.Run();
                        break;
                    case "2":
                        task2Runner.Run();
                        break;
                    case "3":
                        task3Runner.Run();
                        break;
                    case "4":
                        RunTask4();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Програму завершено.");
                        break;
                    default:
                        Console.WriteLine("Невірний вибір! Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void RunTask4()
        {
            Console.WriteLine(" ВИКОНАННЯ ЗАВДАННЯ 4 ");
            try
            {
                Date myDate = new Date(5, 4, 2026);
                Console.Write("Створено дату: ");
                myDate.PrintTextFormat();
                Console.WriteLine($"Чи валідна ця дата? {myDate.IsValidDate()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}