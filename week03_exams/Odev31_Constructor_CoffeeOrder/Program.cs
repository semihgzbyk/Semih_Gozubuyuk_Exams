using System;
using Odev31_Constructor_CoffeeOrder.Models;

namespace Odev31_Constructor_CoffeeOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Sipariş: Çift parametreli constructor (Boy varsayılan "Medium" olacak)
            CoffeeOrder order1 = new CoffeeOrder("Ahmet", "Latte");
            order1.SugarCount = 1;

            // 2. Sipariş: Çift parametreli constructor (Boy varsayılan "Medium" olacak)
            CoffeeOrder order2 = new CoffeeOrder("Ayşe", "Americano");
            order2.SugarCount = 0;

            // 3. Sipariş: Üç parametreli constructor (Boy açıkça "Large" olarak veriliyor)
            CoffeeOrder order3 = new CoffeeOrder("Mehmet", "Cappuccino", "Large");
            order3.SugarCount = 2;

            CoffeeOrder[] orders = { order1, order2, order3 };

            Console.WriteLine("=== KAHVE SİPARİŞ LİSTESİ ===\n");

            // Sipariş detaylarını yazdırma
            foreach (CoffeeOrder order in orders)
            {
                Console.WriteLine($"Müşteri Adı : {order.CustomerName}");
                Console.WriteLine($"Kahve Türü  : {order.CoffeeType}");
                Console.WriteLine($"Boy         : {order.Size}");
                Console.WriteLine($"Şeker Sayısı: {order.SugarCount}");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}