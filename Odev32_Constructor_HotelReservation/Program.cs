using System;
using Odev32_Constructor_HotelReservation.Models;

namespace Odev32_Constructor_HotelReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Üç parametreli constructor (Gece sayısı varsayılan 1 olacak)
            HotelReservation reservation1 = new HotelReservation("Ali Yılmaz", 101, DateTime.Now);
            reservation1.TotalPrice = 2500;

            // 2. Dört parametreli constructor (Gece sayısı açıkça 4 olarak veriliyor)
            HotelReservation reservation2 = new HotelReservation("Zeynep Kaya", 205, DateTime.Now, 4);
            reservation2.TotalPrice = 10000;

            HotelReservation[] reservations = { reservation1, reservation2 };

            Console.WriteLine("=== OTEL REZERVASYON LİSTESİ ===\n");

            // Rezervasyon detaylarını, misafir adı ve gece sayılarını yazdırma
            foreach (HotelReservation res in reservations)
            {
                Console.WriteLine($"Misafir Adı : {res.GuestName}");
                Console.WriteLine($"Oda No      : {res.RoomNumber}");
                Console.WriteLine($"Giriş Tarihi: {res.CheckInDate.ToShortDateString()}");
                Console.WriteLine($"Gece Sayısı : {res.NightCount}");
                Console.WriteLine($"Toplam Tutar: {res.TotalPrice} TL");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}