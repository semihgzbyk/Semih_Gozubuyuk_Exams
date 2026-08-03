using System;
using Odev27_Constructor_Employee.Models;

namespace Odev27_Constructor_Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Tek parametreli constructor (Position varsayılan "Junior" olacak)
            Employee emp1 = new Employee("Caner Öztürk")
            {
                EmployeeId = 1,
                Salary = 35000.00m
            };

            // 2. Çift parametreli constructor (Position açıkça belirtiliyor)
            Employee emp2 = new Employee("Selin Yılmaz", "Senior Developer")
            {
                EmployeeId = 2,
                Salary = 75000.00m
            };

            Employee[] employees = { emp1, emp2 };

            Console.WriteLine("=== PERSONEL LİSTESİ ===\n");

            // Personel bilgilerini yazdırma
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"ID       : {emp.EmployeeId}");
                Console.WriteLine($"Ad Soyad : {emp.FullName}");
                Console.WriteLine($"Pozisyon : {emp.Position}");
                Console.WriteLine($"Maaş     : {emp.Salary} TL");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}