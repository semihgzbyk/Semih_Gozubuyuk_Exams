using System;
using Odev22_Constructor_Product.Models;

namespace Odev22_Constructor_Product
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Ürün (Constructor ile isim zorunlu, diğer değerler sonradan atanıyor)
            Product product1 = new Product("Laptop")
            {
                Id = 101,
                Price = 25000.50m
            };

            // 2. Ürün
            Product product2 = new Product("Kablosuz Fare")
            {
                Id = 102
            };
            product2.Price = 450.00m; // Property ile sonradan atama

            // 3. Ürün
            Product product3 = new Product("Mekanik Klavye");
            product3.Id = 103;
            product3.Price = 1250.75m;

            Product[] products = { product1, product2, product3 };

            Console.WriteLine("=== ÜRÜN LİSTESİ ===\n");

            // Ürün bilgilerini ve isimlerini yazdırma
            foreach (Product p in products)
            {
                Console.WriteLine($"ID: {p.Id} | Ürün Adı: {p.Name} | Fiyat: {p.Price} TL");
            }
        }
    }
}