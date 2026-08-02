using System;

namespace Odev37_Constructor_CreditCard.Models
{
    public class CreditCard
    {
        // Auto-property'ler
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Limit { get; set; }

        // 1. Constructor: Kart Sahibi, Kart Numarası ve SKT zorunlu. Limit varsayılan 10000 TL
        public CreditCard(string cardHolder, string cardNumber, DateTime expiryDate)
        {
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
            Limit = 10000m; // Varsayılan limit
        }

        // 2. Constructor Overloading: Tüm parametreler (Limit dahil) birlikte alınır
        public CreditCard(string cardHolder, string cardNumber, DateTime expiryDate, decimal limit)
        {
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
            Limit = limit;
        }
    }
}