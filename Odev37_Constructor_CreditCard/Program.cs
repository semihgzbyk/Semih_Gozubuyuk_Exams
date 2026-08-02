using System;
using Odev37_Constructor_CreditCard.Models;

namespace Odev37_Constructor_CreditCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Üç parametreli constructor (Limit varsayılan 10.000 TL olacak)
            CreditCard card1 = new CreditCard("Ali Yılmaz", "1234-5678-9012-3456", new DateTime(2028, 12, 31));

            // 2. Dört parametreli constructor (Limit özel olarak 25.000 TL tanımlanıyor)
            CreditCard card2 = new CreditCard("Ayşe Kaya", "9876-5432-1098-7654", new DateTime(2029, 6, 30), 25000m);

            CreditCard[] cards = { card1, card2 };

            Console.WriteLine("=== KREDİ KARTI LİSTESİ VE LİMİT KARŞILAŞTIRMASI ===\n");

            // Kart detaylarını yazdırma
            foreach (CreditCard card in cards)
            {
                Console.WriteLine($"Kart Sahibi : {card.CardHolder}");
                Console.WriteLine($"Kart No     : {card.CardNumber}");
                Console.WriteLine($"SKT         : {card.ExpiryDate.ToShortDateString()}");
                Console.WriteLine($"Limit       : {card.Limit:N2} TL");
                Console.WriteLine(new string('-', 40));
            }

            // Limitleri karşılaştırma
            Console.WriteLine("\n--- Limit Karşılaştırması ---");
            if (card1.Limit > card2.Limit)
            {
                Console.WriteLine($"{card1.CardHolder} adlı kullanıcının kart limiti daha yüksek.");
            }
            else if (card2.Limit > card1.Limit)
            {
                Console.WriteLine($"{card2.CardHolder} adlı kullanıcının kart limiti daha yüksek.");
            }
            else
            {
                Console.WriteLine("İki kartın da limiti eşit.");
            }
        }
    }
}