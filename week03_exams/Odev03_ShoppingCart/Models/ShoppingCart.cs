using System;

namespace Odev03_ShoppingCart.Models
{
    public class ShoppingCart
    {
        // Private field'lar
        private int itemCount;
        private decimal totalPrice;

        // Property
        public int ItemCount
        {
            get
            {
                return itemCount;
            }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Hata: Sepetteki ürün sayısı negatif olamaz!");
                    itemCount = 0;
                }
                else
                {
                    itemCount = value;
                }
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Hata: Sepet toplam tutarı negatif olamaz!");
                    totalPrice = 0;
                }
                else
                {
                    totalPrice = value;
                }
            }
        }

        // Yapıcı Metot (Constructor)
        public ShoppingCart()
        {
            ItemCount = 0;
            TotalPrice = 0;
        }

        // Metot 1: Sepete Ürün Ekleme
        public void AddItem(decimal price)
        {
            // 0 veya negatif fiyat girilirse direkt hata fırlat ve çalışmayı kes
            if (price <= 0)
            {
                throw new ArgumentException("Hata: Eklenecek ürünün fiyatı 0 veya negatif olamaz!");
            }

            ItemCount += 1;
            TotalPrice += price;

            Console.WriteLine($"[EKLENDİ] {price} TL tutarında ürün sepete eklendi.");
        }

        // Metot 2: Sepeti Sıfırlama/Temizleme
        public void ClearCart()
        {
            ItemCount = 0;
            TotalPrice = 0;
            Console.WriteLine("[SEPET TEMİZLENDİ] Sepetteki tüm ürünler çıkarıldı.");
        }
    }
}