using System;
using Odev25_Constructor_Student.Models;

namespace Odev25_Constructor_Student
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Öğrenci (Constructor ile Ad/Soyad zorunlu, diğer bilgiler sonradan atanıyor)
            Student student1 = new Student("Ali", "Yılmaz")
            {
                StudentNumber = "202401"
            };
            student1.Department = "Bilgisayar Mühendisliği"; // Property ile sonradan atama

            // 2. Öğrenci
            Student student2 = new Student("Zeynep", "Kaya");
            student2.StudentNumber = "202402";
            student2.Department = "Yazılım Mühendisliği"; // Property ile sonradan atama

            Student[] students = { student1, student2 };

            Console.WriteLine("=== ÖĞRENCİ LİSTESİ ===\n");

            // Öğrenci bilgilerini yazdırma
            foreach (Student student in students)
            {
                Console.WriteLine($"Öğrenci No : {student.StudentNumber}");
                Console.WriteLine($"Ad Soyad   : {student.FirstName} {student.LastName}");
                Console.WriteLine($"Bölüm      : {student.Department}");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}