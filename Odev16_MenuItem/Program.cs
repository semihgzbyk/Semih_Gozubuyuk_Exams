using System;
using Odev16_MenuItem.Models;

namespace Odev16_MenuItem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 5 Yemek Tanımlama
            MenuItem item1 = new MenuItem
            {
                Name = "Mercimek Çorbası",
                Description = "Süzme mercimek, tereyağı ve baharatlar ile",
                Price = 90.00m,
                IsVegetarian = true
            };

            MenuItem item2 = new MenuItem
            {
                Name = "Adana Kebap",
                Description = "Zırh kıyması, közlenmiş biber ve domates ile",
                Price = 320.00m,
                IsVegetarian = false
            };

            MenuItem item3 = new MenuItem
            {
                Name = "Mantar Sote",
                Description = "Taze kültür mantarı, zeytinyağı ve sarımsak ile",
                Price = 180.00m,
                IsVegetarian = true
            };

            MenuItem item4 = new MenuItem
            {
                Name = "Izgara Köfte",
                Description = "Dana kıymadan ev yapımı köfte, pirinç pilavı ile",
                Price = 280.00m,
                IsVegetarian = false
            };

            MenuItem item5 = new MenuItem
            {
                Name = "Mevsim Salatası",
                Description = "Akdeniz yeşillikleri, zeytinyağı ve limon sosu ile",
                Price = 120.00m,
                IsVegetarian = true
            };

            MenuItem[] menu = { item1, item2, item3, item4, item5 };

            // 1. Vejetaryen Yemekler
            Console.WriteLine("=== VEJETARYEN MENÜ ===\n");
            foreach (MenuItem item in menu)
            {
                if (item.IsVegetarian)
                {
                    Console.WriteLine($"• {item.Name} ({item.Price} TL)");
                    Console.WriteLine($"  Açıklama: {item.Description}\n");
                }
            }

            // 2. Diğer Yemekler (Opsiyonel Düzen)
            Console.WriteLine("=== DİĞER YEMEKLER ===\n");
            foreach (MenuItem item in menu)
            {
                if (!item.IsVegetarian)
                {
                    Console.WriteLine($"• {item.Name} ({item.Price} TL)");
                    Console.WriteLine($"  Açıklama: {item.Description}\n");
                }
            }
        }
    }
}