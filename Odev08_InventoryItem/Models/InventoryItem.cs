using System;

namespace Odev08_InventoryItem.Models
{
    public class InventoryItem
    {
        // Private field'lar
        private string productName = "";
        private int quantity;

        // Property'ler
        public string ProductName
        {
            get
            {
                return productName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hata: Ürün adı boş olamaz!");
                }
                productName = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hata: Stok adedi negatif olamaz!");
                }
                quantity = value;
            }
        }

        // Yapıcı Metot
        public InventoryItem(string productName, int initialQuantity)
        {
            ProductName = productName;
            Quantity = initialQuantity;
        }

        // Metot 1: Stok Artırma
        public void IncreaseStock(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Hata: Eklenen stok miktarı 0'dan büyük olmalıdır!");
            }

            Quantity += amount;
        }

        // Metot 2: Stok Azaltma
        public bool DecreaseStock(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Hata: Azaltılacak stok miktarı 0'dan büyük olmalıdır!");
            }

            if (amount > Quantity)
            {
                return false;
            }

            Quantity -= amount;
            return true;
        }
    }
}