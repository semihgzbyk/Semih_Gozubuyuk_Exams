using System;
using Odev04_ParkingTicket.Models;

namespace Odev04_ParkingTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== OTOPARK BİLET SİSTEMİ ===\n");

            // 1. Plaka ve giriş saati vererek bilet oluşturma
            DateTime girişZamanı = DateTime.Now;
            ParkingTicket ticket = new ParkingTicket("34 ABC 123", girişZamanı);

            Console.WriteLine($"Bilet Oluşturuldu -> Plaka: {ticket.PlateNumber} | Giriş Saati: {ticket.EntryTime}");
            Console.WriteLine($"Ödeme Durumu: {(ticket.IsPaid ? "Ödendi" : "Ödenmedi")}\n");

            // 2. 3 saatlik ücret hesaplama (Örn: Saatlik ücret 50 TL)
            Console.WriteLine("--- Ücret Hesaplama ---");
            decimal toplamTutar = ticket.CalculateFee(3, 50.00m);
            Console.WriteLine();

            // 3. Önce yetersiz ödeme denemesi (Örn: 100 TL veriliyor)
            Console.WriteLine("--- 1. Ödeme Denemesi (Yetersiz) ---");
            ticket.Pay(100.00m);
            Console.WriteLine($"Ödeme Durumu: {(ticket.IsPaid ? "Ödendi" : "Ödenmedi")}\n");

            // 4. Sonra yeterli ödeme denemesi (Örn: 150 TL veriliyor)
            Console.WriteLine("--- 2. Ödeme Denemesi (Yeterli) ---");
            ticket.Pay(150.00m);
            Console.WriteLine($"Ödeme Durumu: {(ticket.IsPaid ? "Ödendi" : "Ödenmedi")}");
        }
    }
}