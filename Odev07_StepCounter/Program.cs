using System;
using Odev07_StepCounter.Models;

namespace Odev07_StepCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Hedefi 8000 yapın
            StepCounter counter = new StepCounter(8000);

            // 2. 5000 adım ekleyin
            counter.AddSteps(5000);
            Console.WriteLine($"Atılan Adım: {counter.Steps} | Hedefe Ulaşıldı mı: {counter.IsGoalReached()}");

            // 3. 4000 adım daha ekleyin (Toplam 9000)
            counter.AddSteps(4000);
            Console.WriteLine($"Atılan Adım: {counter.Steps} | Hedefe Ulaşıldı mı: {counter.IsGoalReached()}");
        }
    }
}