using System;
using Odev26_Constructor_StudentNumber.Models;

namespace Odev26_Constructor_StudentNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Constructor kullanımı (Okul numarası sonradan veya yok)
            Student student1 = new Student("Mehmet", "Demir")
            {
                Gpa = 3.25
            };

            // 2. Constructor kullanımı (Okul numarası baştan tanımlı)
            Student student2 = new Student(1054, "Elif", "Çelik")
            {
                Gpa = 3.80
            };

            Student[] students = { student1, student2 };

            Console.WriteLine("=== ÖĞRENCİ BİLGİ LİSTESİ ===\n");

            // Öğrenci bilgilerini karşılaştırmalı yazdırma
            foreach (Student student in students)
            {
                if (student.StudentNumber == 0)
                {
                    Console.WriteLine("Numara   : Atanmadı");
                }
                else
                {
                    Console.WriteLine($"Numara   : {student.StudentNumber}");
                }

                Console.WriteLine($"Ad Soyad : {student.FirstName} {student.LastName}");
                Console.WriteLine($"GNO (GPA): {student.Gpa}");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}