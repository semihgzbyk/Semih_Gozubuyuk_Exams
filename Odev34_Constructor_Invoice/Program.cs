using System;
using Odev34_Constructor_Invoice.Models;

namespace Odev34_Constructor_Invoice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Üç parametreli constructor (KDV varsayılan 0.20 yani %20 olacak)
            Invoice inv1 = new Invoice("FTR2024001", "Ahmet Yılmaz", 1000.00m);

            // 2. Dört parametreli constructor (KDV oranı özel olarak 0.10 yani %10 veriliyor)
            Invoice inv2 = new Invoice("FTR2024002", "Mehmet Kaya", 2500.00m, 0.10m);

            Invoice[] invoices = { inv1, inv2 };

            Console.WriteLine("=== FATURA LİSTESİ ===\n");

            // Fatura detaylarını ve hesaplanan TotalAmount değerini yazdırma
            foreach (Invoice inv in invoices)
            {
                Console.WriteLine($"Fatura No   : {inv.InvoiceNo}");
                Console.WriteLine($"Müşteri Adı : {inv.CustomerName}");
                Console.WriteLine($"Tutar       : {inv.Amount} TL");
                Console.WriteLine($"KDV Oranı   : %{inv.TaxRate * 100}");
                Console.WriteLine($"Toplam Tutar: {inv.TotalAmount} TL");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}