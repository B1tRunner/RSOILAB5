using System;
using EmployeeRecords.Enums;
using EmployeeRecords.Interfaces;

namespace EmployeeRecords.Helpers
{
    public class ConsoleInterface : IUserInterface
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Добавить сотрудника");
            Console.WriteLine("2. Удалить сотрудника");
            Console.WriteLine("3. Отобразить список сотрудников");
            Console.WriteLine("4. Получить информацию о сотруднике по ID");
            Console.WriteLine("5. Выйти из программы");
        }

        public string GetUserChoice()
        {
            return Console.ReadLine();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowEmptyLine()
        {
            Console.WriteLine();
        }

        public string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public int ReadValidAge(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out var age) && age >= 18)
                {
                    return age;
                }

                Console.WriteLine("Некорректный возраст. Возраст должен быть целым числом " +
                    "и не меньше 18 лет.");
            }
        }

        public Position ReadValidPosition(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                foreach (Position position in Enum.GetValues(typeof(Position)))
                {
                    Console.WriteLine($"{(int)position + 1}. {position}");
                }

                if (int.TryParse(Console.ReadLine(), out var selectedPositionIndex) &&
                    selectedPositionIndex >= 1 && selectedPositionIndex <= Enum.GetValues(typeof(Position)).Length)
                {
                    var position = (Position)(selectedPositionIndex - 1);
                    return position;
                }

                Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
            }
        }

        public decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out var value) && value >= 0)
                {
                    return value;
                }

                Console.WriteLine("Некорректное значение. Введите неотрицательное число.");
            }
        }

        public Guid ReadGuid(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (Guid.TryParse(Console.ReadLine(), out var guid))
                {
                    return guid;
                }

                Console.WriteLine("Некорректный ID. Попробуйте еще раз.");
            }
        }
    }
}