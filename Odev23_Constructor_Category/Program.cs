using System;
using Odev23_Constructor_Category.Models;

namespace Odev23_Constructor_Category
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Tek parametreli constructor kullanımı (Description boş kalacak)
            Category category1 = new Category("Elektronik")
            {
                CategoryId = 1
            };

            // 2. İki parametreli constructor kullanımı (Name ve Description dolu)
            Category category2 = new Category("Kitap", "Roman, Bilim ve Sanat Kitapları")
            {
                CategoryId = 2
            };

            Category[] categories = { category1, category2 };

            Console.WriteLine("=== KATEGORİ LİSTESİ ===\n");

            // Name ve Description değerlerini yazdırma
            foreach (Category cat in categories)
            {
                Console.WriteLine($"Kategori Adı : {cat.Name}");

                if (string.IsNullOrEmpty(cat.Description))
                {
                    Console.WriteLine("Açıklama     : (Açıklama Yok)");
                }
                else
                {
                    Console.WriteLine($"Açıklama     : {cat.Description}");
                }

                Console.WriteLine(new string('-', 35));
            }
        }
    }
}