using System;
using Odev15_Car.Models;

namespace Odev15_Car
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Araç
            Car car1 = new Car
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2022,
                PlateNumber = "34 ABC 123",
                Color = "Beyaz"
            };

            // 2. Araç
            Car car2 = new Car
            {
                Brand = "BMW",
                Model = "320i",
                Year = 2024,
                PlateNumber = "06 XYZ 789",
                Color = "Siyah"
            };

            // 3. Araç
            Car car3 = new Car
            {
                Brand = "Ford",
                Model = "Focus",
                Year = 2020,
                PlateNumber = "35 KLM 456",
                Color = "Gri"
            };

            // Araç listesi
            Car[] cars = { car1, car2, car3 };

            Console.WriteLine("=== ARAÇ LİSTESİ ===\n");

            // "Marka Model (Plaka)" formatında yazdırma
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Brand} {car.Model} ({car.PlateNumber})");
            }
        }
    }
}