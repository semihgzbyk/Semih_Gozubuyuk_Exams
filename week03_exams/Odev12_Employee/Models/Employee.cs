using System;

namespace Odev12_Employee.Models
{
    public class Employee
    {
        // Auto-property'ler
        public string FullName { get; set; } = "";
        public string Title { get; set; } = "";
        public string Department { get; set; } = "";
        public DateTime HireDate { get; set; }
    }
}