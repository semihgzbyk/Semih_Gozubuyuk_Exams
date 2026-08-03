using System;
using Odev13_Product.Models;

namespace Odev13_Product
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Ürün
            Product product1 = new Product();
            product1.ProductCode = "PRD-001";
            product1.Name = "Kablosuz Kulaklık";
            product1.Category = "Elektronik";
            product1.UnitPrice = 1250.00m;

            // 2. Ürün
            Product product2 = new Product();
            product2.ProductCode = "PRD-002";
            product2.Name = "Çalışma Masası";
            product2.Category = "Mobilya";
            product2.UnitPrice = 3400.00m;

            // 3. Ürün
            Product product3 = new Product();
            product3.ProductCode = "PRD-003";
            product3.Name = "Mekanik Klavye";
            product3.Category = "Elektronik";
            product3.UnitPrice = 2100.00m;

            // 4. Ürün
            Product product4 = new Product();
            product4.ProductCode = "PRD-004";
            product4.Name = "Pamuklu Tişört";
            product4.Category = "Giyim";
            product4.UnitPrice = 450.00m;

            Console.WriteLine("=== ELEKTRONİK KATEGORİSİNDEKİ ÜRÜNLER ===\n");

            // Sadece Category == "Elektronik" olanların yazdırılması
            if (product1.Category == "Elektronik")
            {
                Console.WriteLine($"[Kod: {product1.ProductCode}] {product1.Name} - Fiyat: {product1.UnitPrice} TL");
            }

            if (product2.Category == "Elektronik")
            {
                Console.WriteLine($"[Kod: {product2.ProductCode}] {product2.Name} - Fiyat: {product2.UnitPrice} TL");
            }

            if (product3.Category == "Elektronik")
            {
                Console.WriteLine($"[Kod: {product3.ProductCode}] {product3.Name} - Fiyat: {product3.UnitPrice} TL");
            }

            if (product4.Category == "Elektronik")
            {
                Console.WriteLine($"[Kod: {product4.ProductCode}] {product4.Name} - Fiyat: {product4.UnitPrice} TL");
            }
        }
    }
}