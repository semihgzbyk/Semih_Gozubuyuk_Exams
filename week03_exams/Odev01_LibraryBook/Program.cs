using System;
using Odev01_LibraryBook.Models;

namespace Odev01_LibraryBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== KÜTÜPHANE KİTAP YÖNETİM SİSTEMİ ===\n");

            // 1. Kitap oluşturuluyor
            LibraryBook book = new LibraryBook("Nutuk", "Mustafa Kemal Atatürk");

            Console.WriteLine($"Kitap: {book.Title} - Yazar: {book.Author}\n");

            // 2. İlk defa ödünç alma (Başarılı)
            Console.WriteLine("1. Adım: Kitap ödünç alınıyor...");
            book.Borrow();

            Console.WriteLine();

            // 3. Tekrar ödünç alma denemesi (Uyarı verir)
            Console.WriteLine("2. Adım: Aynı kitap tekrar ödünç alınmaya çalışılıyor...");
            book.Borrow();

            Console.WriteLine();

            // 4. Kitap iade ediliyor
            Console.WriteLine("3. Adım: Kitap iade ediliyor...");
            book.ReturnBook();

            Console.WriteLine();

            // 5. İade edildikten sonra tekrar ödünç alma (Başarılı)
            Console.WriteLine("4. Adım: Kitap tekrar ödünç alınıyor...");
            book.Borrow();
        }
    }
}