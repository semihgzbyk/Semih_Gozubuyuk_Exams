using System;
using Odev12_Employee.Models;

namespace Odev12_Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Çalışan
            Employee emp1 = new Employee();
            emp1.FullName = "Ali Öztürk";
            emp1.Title = "Kıdemli Yazılım Uzmanı";
            emp1.Department = "Bilgi Teknolojileri";
            emp1.HireDate = new DateTime(2021, 3, 15);

            // 2. Çalışan
            Employee emp2 = new Employee();
            emp2.FullName = "Elif Demir";
            emp2.Title = "İnsan Kaynakları Uzmanı";
            emp2.Department = "İnsan Kaynakları";
            emp2.HireDate = new DateTime(2022, 6, 1);

            // 3. Çalışan
            Employee emp3 = new Employee();
            emp3.FullName = "Mehmet Can";
            emp3.Title = "Mali İşler Sorumlusu";
            emp3.Department = "Finans";
            emp3.HireDate = new DateTime(2023, 1, 10);

            // Çalışanların Unvan ve Departman Bilgilerini Yazdırma
            Console.WriteLine("=== ÇALIŞAN UNVAN VE DEPARTMAN BİLGİLERİ ===\n");

            Console.WriteLine($"Çalışan : {emp1.FullName}");
            Console.WriteLine($"Unvan   : {emp1.Title}");
            Console.WriteLine($"Departman: {emp1.Department}");
            Console.WriteLine("----------------------------------");

            Console.WriteLine($"Çalışan : {emp2.FullName}");
            Console.WriteLine($"Unvan   : {emp2.Title}");
            Console.WriteLine($"Departman: {emp2.Department}");
            Console.WriteLine("----------------------------------");

            Console.WriteLine($"Çalışan : {emp3.FullName}");
            Console.WriteLine($"Unvan   : {emp3.Title}");
            Console.WriteLine($"Departman: {emp3.Department}");
        }
    }
}