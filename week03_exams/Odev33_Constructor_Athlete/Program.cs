using System;
using Odev33_Constructor_Athlete.Models;

namespace Odev33_Constructor_Athlete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Takımsız sporcu (Çift parametreli constructor - Takım varsayılan "Free Agent" olacak)
            Athlete athlete1 = new Athlete("Arda Güler", "Futbol");

            // 2. Takımlı sporcu (Dört parametreli constructor - Takım ve Forma No açıkça veriliyor)
            Athlete athlete2 = new Athlete("Hakan Çalhanoğlu", "Futbol", "Inter", 20);

            Athlete[] athletes = { athlete1, athlete2 };

            Console.WriteLine("=== SPORCU LİSTESİ VE TAKIM KARŞILAŞTIRMASI ===\n");

            // Sporcu detaylarını ve takım adlarını yazdırma
            foreach (Athlete athlete in athletes)
            {
                Console.WriteLine($"Sporcu Adı : {athlete.FullName}");
                Console.WriteLine($"Branş      : {athlete.SportBranch}");
                Console.WriteLine($"Takım      : {athlete.TeamName}");
                Console.WriteLine($"Forma No   : {athlete.JerseyNumber}");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}