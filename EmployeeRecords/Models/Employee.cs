using System;
using EmployeeRecords.Enums;

namespace EmployeeRecords.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public Position Position { get; set; }
        public DateTime RecruteDate { get; set; }
    }
}