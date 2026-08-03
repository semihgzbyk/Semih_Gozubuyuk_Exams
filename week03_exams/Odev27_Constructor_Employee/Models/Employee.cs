namespace Odev27_Constructor_Employee.Models
{
    public class Employee
    {
        // Auto-property'ler
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        // 1. Constructor: Pozisyon belirtilmezse varsayılan "Junior" kabul edilir
        public Employee(string fullName)
        {
            FullName = fullName;
            Position = "Junior";
        }

        // 2. Constructor Overloading: İsim ve pozisyon birlikte alınır
        public Employee(string fullName, string position)
        {
            FullName = fullName;
            Position = position;
        }
    }
}