using System;
using EmployeeRecords.Helpers;
using EmployeeRecords.Interfaces;
using EmployeeRecords.Logging;
using EmployeeRecords.Models;

namespace EmployeeRecords
{
    static class Program
    {
        private static ILogger _logger;
        private static IEmployeeManager _employeeManager;
        private static ICompanyRepository _companyRepository;
        private static IUserInterface _userInterface;

        static void Main()
        {
            _logger = new FileLogger();
            _companyRepository = new CompanyRepository(_logger);
            _employeeManager = new EmployeeManager(_companyRepository);
            _userInterface = new ConsoleInterface();

            var exitProgram = false;

            while (!exitProgram)
            {
                _userInterface.DisplayMenu();
                var choice = _userInterface.GetUserChoice();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        RemoveEmployee();
                        break;
                    case "3":
                        DisplayEmployees();
                        break;
                    case "4":
                        GetEmployeeById();
                        break;
                    case "5":
                        exitProgram = true;
                        break;
                    default:
                        _userInterface.ShowMessage("Некорректный выбор. Попробуйте еще раз.");
                        break;
                }

                _userInterface.ShowEmptyLine();
            }
        }

        private static void AddEmployee()
        {
            _userInterface.ShowMessage("Введите данные сотрудника:");
            var fullName = _userInterface.ReadString("Имя: ");
            var age = _userInterface.ReadValidAge("Возраст: ");
            var salary = _userInterface.ReadDecimal("Зарплата: ");

            var selectedPosition = _userInterface.ReadValidPosition("Выберите должность (введите номер):");

            var recruitDate = DateTime.Now;

            var newEmployee = new Employee
            {
                Id = Guid.NewGuid(),
                FullName = fullName,
                Age = age,
                Salary = salary,
                Position = selectedPosition,
                RecruteDate = recruitDate
            };

            _employeeManager.RecruitEmployee(newEmployee);
            _userInterface.ShowMessage("Сотрудник добавлен успешно.");
        }

        private static void RemoveEmployee()
        {
            var employeeId = _userInterface.ReadGuid("Введите идентификатор сотрудника: ");
            _employeeManager.TerminateEmployee(employeeId);
            _userInterface.ShowMessage("Сотрудник удален успешно.");
        }

        private static void DisplayEmployees()
        {
            var employees = _employeeManager.GetAllEmployees();
            if (employees == null)
            {
                _userInterface.ShowMessage("Список сотрудников пуст.");
            }
            else
            {
                _userInterface.ShowMessage("Список сотрудников:");
                foreach (var employee in employees)
                {
                    _userInterface.ShowMessage(
                        $"Имя: {employee.FullName}, " +
                        $"Должность: {employee.Position}, " +
                        $"Возраст: {employee.Age}, " +
                        $"Зарплата: {employee.Salary}, " +
                        $"Дата найма: {employee.RecruteDate.ToShortDateString()}");
                }
            }
        }

        private static void GetEmployeeById()
        {
            var employeeId = _userInterface.ReadGuid("Введите ID сотрудника: ");

            var employee = _employeeManager.GetEmployeeById(employeeId);

            if (employee != null)
            {
                _userInterface.ShowMessage("Информация о сотруднике:");
                _userInterface.ShowMessage($"ID: {employee.Id}");
                _userInterface.ShowMessage($"Имя: {employee.FullName}");
                _userInterface.ShowMessage($"Возраст: {employee.Age}");
                _userInterface.ShowMessage($"Зарплата: {employee.Salary}");
                _userInterface.ShowMessage($"Должность: {employee.Position}");
                _userInterface.ShowMessage($"Дата приема на работу: {employee.RecruteDate}");
            }
            else
            {
                _userInterface.ShowMessage("Сотрудник с указанным ID не найден.");
            }
        }
    }
}