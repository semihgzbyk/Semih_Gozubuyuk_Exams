using System;
using Odev24_Constructor_Book.Models;

namespace Odev24_Constructor_Book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Parametresiz constructor
            Book book1 = new Book
            {
                Id = 1,
                Name = "Anonim Eser",
                AuthorName = "Bilinmiyor"
            };

            // 2. Sadece isim alan constructor (Sayfa varsayılan 100)
            Book book2 = new Book("Nutuk");

            // 3. İsim ve Yazar alan constructor (Sayfa varsayılan 100)
            Book book3 = new Book("Simyacı", "Paulo Coelho");

            // 4. İsim, Yazar ve Kategori alan constructor (Sayfa varsayılan 100)
            Book book4 = new Book("Suç ve Ceza", "Dostoyevski", "Klasik");

            // 5. Tüm bilgileri (Sayfa sayısı dahil) alan constructor
            Book book5 = new Book("Sefiller", "Victor Hugo", "Klasik", 1462);

            Book[] books = { book1, book2, book3, book4, book5 };

            Console.WriteLine("=== KİTAP LİSTESİ ===\n");

            // Her kitabın ad, yazar ve sayfa bilgisini yazdırma
            foreach (Book book in books)
            {
                Console.WriteLine($"Kitap Adı   : {book.Name}");

                if (string.IsNullOrEmpty(book.AuthorName))
                {
                    Console.WriteLine("Yazar       : Belirtilmedi");
                }
                else
                {
                    Console.WriteLine($"Yazar       : {book.AuthorName}");
                }

                Console.WriteLine($"Sayfa Sayısı: {book.PageCount}");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}