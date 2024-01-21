using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmployeeRecords.Interfaces;
using EmployeeRecords.Models;
using Newtonsoft.Json;

namespace EmployeeRecords
{
    public class CompanyRepository : ICompanyRepository
    {
        private List<Employee> _employees;
        private readonly ILogger _logger;
        private readonly string _employeesListPath;
        private readonly string _logsFilePath;

        public CompanyRepository(ILogger logger)
        {
            _logsFilePath = @"EmployeeLogs.txt";
            _employeesListPath = @"Employees.txt";
            _logger = logger;
            LoadEmployeesFromFile();
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
            SaveEmployeesToFile();
            _logger.LogInfo(_logsFilePath, $"Added employee: {employee.FullName}");
        }

        public void DeleteEmployee(Employee employee)
        {
            _employees.Remove(employee);
            SaveEmployeesToFile();
            _logger.LogInfo(_logsFilePath, $"Deleted employee: {employee.FullName}");
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            return _employees.FirstOrDefault(e => e.Id == employeeId);
        }

        private void SortEmployeesBySalary()
        {
            _employees = _employees.OrderBy(e => e.Salary)
                .Reverse()
                .ToList();
        }

        private void LoadEmployeesFromFile()
        {
            if (File.Exists(_employeesListPath))
            {
                var json = File.ReadAllText(_employeesListPath);
                _employees = JsonConvert.DeserializeObject<List<Employee>>(json) ?? new List<Employee>();
            }
            else
            {
                Console.WriteLine("Файл сотрудников не найден.");
            }
        }

        private void SaveEmployeesToFile()
        {
            SortEmployeesBySalary();
            _logger.LogEmployeesListToFile(_employeesListPath, _employees);
        }
    }
}