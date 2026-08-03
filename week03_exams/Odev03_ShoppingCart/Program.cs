using System;
using Odev03_ShoppingCart.Models;

namespace Odev03_ShoppingCart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ONLINE MARKET ALIŞVERİŞ SEPETİ ===\n");

            // 1. Yeni bir sepet oluşturuluyor
            ShoppingCart cart = new ShoppingCart();

            // 2. 3 farklı fiyatla AddItem çağrılıyor
            Console.WriteLine("--- Ürünler Sepete Ekleniyor ---");
            cart.AddItem(150.50m);
            cart.AddItem(49.99m);
            cart.AddItem(200.00m);
            // cart.AddItem(0);


            Console.WriteLine();

            // 3. Sepet özeti yazdırılıyor
            Console.WriteLine("--- Sepet Özeti ---");
            Console.WriteLine($"Sepetteki Ürün Sayısı : {cart.ItemCount}");
            Console.WriteLine($"Toplam Tutar          : {cart.TotalPrice} TL");

            Console.WriteLine();

            // 4. Sepet temizleniyor
            Console.WriteLine("--- Sepet Temizleniyor ---");
            cart.ClearCart();

            Console.WriteLine();

            // 5. ClearCart() sonrası tekrar özet yazdırılıyor
            Console.WriteLine("--- Temizleme Sonrası Sepet Özeti ---");
            Console.WriteLine($"Sepetteki Ürün Sayısı : {cart.ItemCount}");
            Console.WriteLine($"Toplam Tutar          : {cart.TotalPrice} TL");

        }
    }
}