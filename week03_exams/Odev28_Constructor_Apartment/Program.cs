using System;
using Odev28_Constructor_Apartment.Models;

namespace Odev28_Constructor_Apartment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Çift parametreli constructor (Oda sayısı varsayılan 2 olacak)
            Apartment apt1 = new Apartment(4, 2)
            {
                RentPrice = 15000.00m
            };

            // 2. Üç parametreli constructor (Oda sayısı açıkça belirtiliyor)
            Apartment apt2 = new Apartment(12, 5, 3)
            {
                RentPrice = 22500.00m
            };

            Apartment[] apartments = { apt1, apt2 };

            Console.WriteLine("=== DAİRE LİSTESİ ===\n");

            // Daire bilgilerini ve oda sayılarını yazdırma
            foreach (Apartment apt in apartments)
            {
                Console.WriteLine($"Daire No   : {apt.ApartmentNo}");
                Console.WriteLine($"Kat        : {apt.Floor}");
                Console.WriteLine($"Oda Sayısı : {apt.RoomCount}");
                Console.WriteLine($"Kira Tutarı: {apt.RentPrice} TL");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}