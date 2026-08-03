using System;
using Odev39_Constructor_FlightTicket.Models;

namespace Odev39_Constructor_FlightTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Üç parametreli constructor (Kabin sınıfı varsayılan "Economy" olacak)
            FlightTicket ticket1 = new FlightTicket("Zeynep Demir", "TK1923", 2500.50m);

            // 2. Dört parametreli constructor (Kabin sınıfı "Business" olarak belirtiliyor)
            FlightTicket ticket2 = new FlightTicket("Caner Tekin", "TK2024", 8750.00m, "Business");

            FlightTicket[] tickets = { ticket1, ticket2 };

            Console.WriteLine("=== UÇUŞ BİLETİ LİSTESİ ===\n");

            // Bilet detaylarını ve Yolcu Adı + Sınıf bilgisini yazdırma
            foreach (FlightTicket ticket in tickets)
            {
                Console.WriteLine($"Yolcu Adı : {ticket.PassengerName}");
                Console.WriteLine($"Sınıf     : {ticket.SeatClass}");
                Console.WriteLine($"Uçuş Kodu : {ticket.FlightCode}");
                Console.WriteLine($"Fiyat     : {ticket.Price:N2} TL");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}