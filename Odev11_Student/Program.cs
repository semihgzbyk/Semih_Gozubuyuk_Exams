using System;
using Odev11_Student.Models;

namespace Odev11_Student
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Öğrenci
            Student student1 = new Student();
            student1.FirstName = "Ahmet";
            student1.LastName = "Yılmaz";
            student1.StudentNumber = "2024001";
            student1.Department = "Yazılım Mühendisliği";

            // 2. Öğrenci
            Student student2 = new Student();
            student2.FirstName = "Ayşe";
            student2.LastName = "Kaya";
            student2.StudentNumber = "2024002";
            student2.Department = "Bilgisayar Programcılığı";

            // Ekrana yazdırma
            Console.WriteLine("=== ÖĞRENCİ LİSTESİ ===\n");

            Console.WriteLine($"Numara  : {student1.StudentNumber}");
            Console.WriteLine($"Ad Soyad: {student1.FirstName} {student1.LastName}");
            Console.WriteLine($"Bölüm   : {student1.Department}");
            Console.WriteLine("----------------------------------");

            Console.WriteLine($"Numara  : {student2.StudentNumber}");
            Console.WriteLine($"Ad Soyad: {student2.FirstName} {student2.LastName}");
            Console.WriteLine($"Bölüm   : {student2.Department}");
        }
    }
}