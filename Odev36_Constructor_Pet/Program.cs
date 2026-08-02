using System;
using Odev36_Constructor_Pet.Models;

namespace Odev36_Constructor_Pet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Çift parametreli constructor (Tür varsayılan "Unknown" olacak, yaş sonradan atanabilir)
            Pet pet1 = new Pet("Pamuk", "Mehmet Demir");

            // 2. Dört parametreli constructor (Tür ve yaş bilgisi açıkça veriliyor)
            Pet pet2 = new Pet("Duman", "Elif Şahin", "Kedi", 3);

            Pet[] pets = { pet1, pet2 };

            Console.WriteLine("=== EVCİL HAYVAN LİSTESİ ===\n");

            // Tür ve yaş bilgilerini yazdırma
            foreach (Pet pet in pets)
            {
                Console.WriteLine($"Hayvan Adı : {pet.Name}");
                Console.WriteLine($"Sahibi     : {pet.OwnerName}");
                Console.WriteLine($"Tür        : {pet.Type}");
                Console.WriteLine($"Yaş        : {pet.Age}");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}