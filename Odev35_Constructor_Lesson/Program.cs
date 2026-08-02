using System;
using Odev35_Constructor_Lesson.Models;

namespace Odev35_Constructor_Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Üç parametreli constructor (Kredi varsayılan 3 olacak)
            Lesson lesson1 = new Lesson("MAT101", "Matematik I", "Prof. Dr. Ahmet Yılmaz");
            lesson1.IsMandatory = true;

            // 2. Beş parametreli constructor (Kredi 4 ve Zorunlu mu bilgisi false olarak veriliyor)
            Lesson lesson2 = new Lesson("FIZ102", "Fizik II", "Doç. Dr. Ayşe Kaya", 4, false);

            Lesson[] lessons = { lesson1, lesson2 };

            int totalCredit = 0;

            Console.WriteLine("=== DERS LİSTESİ ===\n");

            // Ders bilgilerini yazdırma ve toplam krediyi hesaplama
            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine($"Ders Kodu   : {lesson.LessonCode}");
                Console.WriteLine($"Ders Adı    : {lesson.LessonName}");
                Console.WriteLine($"Öğretmen    : {lesson.Instructor}");
                Console.WriteLine($"Kredi       : {lesson.Credit}");
                Console.WriteLine($"Zorunlu mu? : {lesson.IsMandatory}");
                Console.WriteLine(new string('-', 35));

                totalCredit += lesson.Credit;
            }

            Console.WriteLine($"\nToplam Kredi: {totalCredit}");
        }
    }
}