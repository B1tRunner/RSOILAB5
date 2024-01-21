using System;
using System.Collections.Generic;
using EmployeeRecords.Models;

namespace EmployeeRecords.Interfaces
{
    public interface IEmployeeManager
    {
        void RecruitEmployee(Employee employee);
        void TerminateEmployee(Guid employeeId);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(Guid employeeId);
    }
}