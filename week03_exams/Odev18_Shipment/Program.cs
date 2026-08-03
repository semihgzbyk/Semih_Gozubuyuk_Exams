using System;
using Odev18_Shipment.Models;

namespace Odev18_Shipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Gönderi
            Shipment shipment1 = new Shipment
            {
                TrackingNumber = "TR123456789",
                SenderName = "Ahmet Yılmaz",
                ReceiverName = "Mehmet Demir",
                ShipDate = new DateTime(2026, 8, 1),
                WeightKg = 3.5
            };

            // 2. Gönderi
            Shipment shipment2 = new Shipment
            {
                TrackingNumber = "TR987654321",
                SenderName = "ABC Teknoloji",
                ReceiverName = "Ayşe Kaya",
                ShipDate = new DateTime(2026, 8, 2),
                WeightKg = 12.8
            };

            // 3. Gönderi
            Shipment shipment3 = new Shipment
            {
                TrackingNumber = "TR456789123",
                SenderName = "Selin Çelik",
                ReceiverName = "Caner Şahin",
                ShipDate = new DateTime(2026, 8, 2),
                WeightKg = 7.2
            };

            Shipment[] shipments = { shipment1, shipment2, shipment3 };

            // En ağır gönderiyi bulma
            Shipment heaviestShipment = shipments[0];

            foreach (Shipment s in shipments)
            {
                if (s.WeightKg > heaviestShipment.WeightKg)
                {
                    heaviestShipment = s;
                }
            }

            // Ekrana yazdırma
            Console.WriteLine("=== EN AĞIR KARGO GÖNDERİSİ ===\n");
            Console.WriteLine($"Takip No      : {heaviestShipment.TrackingNumber}");
            Console.WriteLine($"Gönderici     : {heaviestShipment.SenderName}");
            Console.WriteLine($"Alıcı         : {heaviestShipment.ReceiverName}");
            Console.WriteLine($"Gönderim Tarihi: {heaviestShipment.ShipDate:dd.MM.yyyy}");
            Console.WriteLine($"Ağırlık       : {heaviestShipment.WeightKg} kg");
        }
    }
}