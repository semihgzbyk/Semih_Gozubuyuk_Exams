using System;
using Odev17_Patient.Models;

namespace Odev17_Patient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Hasta Kaydı
            Patient patient1 = new Patient
            {
                PatientId = "10023456789",
                FullName = "Ahmet Yılmaz",
                BirthDate = new DateTime(1992, 5, 14),
                BloodType = "A Rh+"
            };

            // 2. Hasta Kaydı
            Patient patient2 = new Patient
            {
                PatientId = "98765432100",
                FullName = "Ayşe Kaya",
                BirthDate = new DateTime(1988, 11, 23),
                BloodType = "0 Rh-"
            };

            Patient[] patients = { patient1, patient2 };

            Console.WriteLine("=== HASTA BİLGİLERİ (AD & KAN GRUBU) ===\n");

            // Kan grubu ve ad bilgilerini yazdırma
            foreach (Patient patient in patients)
            {
                Console.WriteLine($"Hasta Adı: {patient.FullName} | Kan Grubu: {patient.BloodType}");
            }
        }
    }
}