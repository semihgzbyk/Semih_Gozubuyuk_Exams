using System;
using Odev14_Event.Models;

namespace Odev14_Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Etkinlik
            Event event1 = new Event
            {
                Title = "Yapay Zeka Semineri",
                Location = "A Salonu",
                EventDate = new DateTime(2026, 9, 15, 14, 0, 0),
                Capacity = 150
            };

            // 2. Etkinlik
            Event event2 = new Event
            {
                Title = "Yazılım Kampı Workshop",
                Location = "B Laboratuvarı",
                EventDate = new DateTime(2026, 10, 1, 10, 0, 0),
                Capacity = 40
            };

            // Karşılaştırmalı Karşılaştırma Ekrana Yazdırma
            Console.WriteLine("=== ETKİNLİK KARŞILAŞTIRMA TABLOSU ===\n");
            
            Console.WriteLine($"{"Etkinlik Adı",-25} | {"Tarih",-18} | {"Kapasite",-10}");
            Console.WriteLine(new string('-', 60));
            
            Console.WriteLine($"{event1.Title,-25} | {event1.EventDate:dd.MM.yyyy HH:mm} | {event1.Capacity} Kişi");
            Console.WriteLine($"{event2.Title,-25} | {event2.EventDate:dd.MM.yyyy HH:mm} | {event2.Capacity} Kişi");

            Console.WriteLine("\n--- ÖZET KARŞILAŞTIRMA ---");
            
            // Tarih Karşılaştırması
            if (event1.EventDate < event2.EventDate)
            {
                Console.WriteLine($"* Daha Erken Etkinlik: {event1.Title} ({event1.EventDate:dd.MM.yyyy})");
            }
            else
            {
                Console.WriteLine($"* Daha Erken Etkinlik: {event2.Title} ({event2.EventDate:dd.MM.yyyy})");
            }

            // Kapasite Karşılaştırması
            if (event1.Capacity > event2.Capacity)
            {
                Console.WriteLine($"* Daha Yüksek Kapasiteli: {event1.Title} ({event1.Capacity} Kişi)");
            }
            else
            {
                Console.WriteLine($"* Daha Yüksek Kapasiteli: {event2.Title} ({event2.Capacity} Kişi)");
            }
        }
    }
}