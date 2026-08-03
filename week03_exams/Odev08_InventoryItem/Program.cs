using System;
using Odev08_InventoryItem.Models;

namespace Odev08_InventoryItem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Başlangıç stoğu 50 olan ürün oluşturma
            InventoryItem item = new InventoryItem("Laptop", 50);
            Console.WriteLine($"Ürün: {item.ProductName} | Başlangıç Stoğu: {item.Quantity}");

            // 2. Stoğu 20 artır
            item.IncreaseStock(20);
            Console.WriteLine($"20 Artırıldı | Güncel Stok: {item.Quantity}");

            // 3. Stoğu 30 azalt
            bool isDecreased1 = item.DecreaseStock(30);
            Console.WriteLine($"30 Azaltıldı mı: {isDecreased1} | Güncel Stok: {item.Quantity}");

            // 4. Stoğu 60 azaltmayı dene (Stokta 40 var, başarısız olmalı)
            bool isDecreased2 = item.DecreaseStock(60);
            Console.WriteLine($"60 Azaltıldı mı: {isDecreased2} | Güncel Stok: {item.Quantity}");
        }
    }
}