using System.Collections.Generic;
using EmployeeRecords.Models;

namespace EmployeeRecords.Interfaces
{
    public interface ILogger
    {
        void LogInfo(string filePath, string message);
        void LogEmployeesListToFile(string filePath, List<Employee> employees);
    }
}