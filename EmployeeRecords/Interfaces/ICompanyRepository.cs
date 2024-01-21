using System;
using System.Collections.Generic;
using EmployeeRecords.Models;

namespace EmployeeRecords.Interfaces
{
    public interface ICompanyRepository
    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(Guid employeeId);
    }
}