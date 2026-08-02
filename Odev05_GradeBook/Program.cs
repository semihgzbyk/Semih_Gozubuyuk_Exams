using System;
using Odev05_GradeBook.Models;

namespace Odev05_GradeBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ÖĞRENCİ NOT DEFTERİ SİSTEMİ ===\n");

            // 1. Öğrenci Not Defteri Nesnesi Oluşturma
            GradeBook gradeBook = new GradeBook("Ahmet Yılmaz");
            Console.WriteLine($"Öğrenci: {gradeBook.StudentName}\n");

            // 2. En az 4 not ekleme
            Console.WriteLine("--- Notlar Ekleniyor ---");
            gradeBook.AddExamScore(85);
            gradeBook.AddExamScore(90);
            gradeBook.AddExamScore(75);
            gradeBook.AddExamScore(100);
            Console.WriteLine();

            // 3. Ortalamayı yazdırma
            Console.WriteLine("--- Dönem Sonu Ortalaması ---");
            double ortalama = gradeBook.GetAverage();
            Console.WriteLine($"{gradeBook.StudentName} isimli öğrencinin ortalaması: {ortalama}\n");

            // 4. Geçersiz not denemesi (try-catch ile yakalama)
            Console.WriteLine("--- Geçersiz Not Denemesi ---");
            try
            {
                Console.WriteLine("105 notu eklenmeye çalışılıyor...");
                gradeBook.AddExamScore(105);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"[YAKALANAN HATA] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GENEL HATA] {ex.Message}");
            }

            Console.WriteLine("\nİşlem tamamlandı.");
        }
    }
}