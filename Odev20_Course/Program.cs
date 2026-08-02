using System;
using Odev20_Course.Models;

namespace Odev20_Course
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4 Ders Tanımlama
            Course course1 = new Course
            {
                CourseCode = "CS101",
                CourseName = "Nesne Yönelimli Programlama",
                Instructor = "Dr. Ahmet Yılmaz",
                Credit = 4,
                IsOnline = true
            };

            Course course2 = new Course
            {
                CourseCode = "MATH201",
                CourseName = "Lineer Cebir",
                Instructor = "Prof. Ayşe Kaya",
                Credit = 3,
                IsOnline = false
            };

            Course course3 = new Course
            {
                CourseCode = "CS203",
                CourseName = "Veri Yapıları ve Algoritmalar",
                Instructor = "Doç. Mehmet Demir",
                Credit = 4,
                IsOnline = true
            };

            Course course4 = new Course
            {
                CourseCode = "ENG102",
                CourseName = "Akademik İngilizce",
                Instructor = "Öğr. Gör. Sarah Brown",
                Credit = 2,
                IsOnline = false
            };

            Course[] courses = { course1, course2, course3, course4 };

            // 1. Online Dersler
            Console.WriteLine("=== ONLINE DERSLER ===\n");
            foreach (Course course in courses)
            {
                if (course.IsOnline)
                {
                    Console.WriteLine($"[{course.CourseCode}] {course.CourseName}");
                    Console.WriteLine($"  Eğitmen: {course.Instructor} | Kredi: {course.Credit}\n");
                }
            }

            // 2. Yüz Yüze Dersler
            Console.WriteLine("=== YÜZ YÜZE DERSLER ===\n");
            foreach (Course course in courses)
            {
                if (!course.IsOnline)
                {
                    Console.WriteLine($"[{course.CourseCode}] {course.CourseName}");
                    Console.WriteLine($"  Eğitmen: {course.Instructor} | Kredi: {course.Credit}\n");
                }
            }
        }
    }
}