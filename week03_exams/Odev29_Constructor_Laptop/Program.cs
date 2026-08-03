using System;
using Odev29_Constructor_Laptop.Models;

namespace Odev29_Constructor_Laptop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Çift parametreli constructor (Marka ve Model)
            Laptop laptop1 = new Laptop("Asus", "ZenBook");
            laptop1.RamGb = 8;         
            laptop1.StorageGb = 256;   
            laptop1.Price = 32000;
            
            // 2. Dört parametreli constructor (Marka, Model, RAM, Depolama)
            Laptop laptop2 = new Laptop("Apple", "MacBook Pro", 16, 512);
            laptop2.Price = 64000;

            Laptop[] laptops = { laptop1, laptop2 };

            Console.WriteLine("=== LAPTOP LİSTESİ ===\n");

            foreach (Laptop laptop in laptops)
            {
                Console.WriteLine($"Marka    : {laptop.Brand}");
                Console.WriteLine($"Model    : {laptop.Model}");
                Console.WriteLine($"RAM      : {laptop.RamGb} GB");
                Console.WriteLine($"Depolama : {laptop.StorageGb} GB");
                Console.WriteLine($"Fiyat    : {laptop.Price} TL");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}