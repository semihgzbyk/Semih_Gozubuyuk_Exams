using System;
using Odev19_Customer.Models;

namespace Odev19_Customer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Müşteri
            Customer customer1 = new Customer
            {
                Name = "Zeynep Arslan",
                Address = "Kadıköy / İstanbul",
                BirthDate = new DateTime(1995, 4, 12)
            };

            // 2. Müşteri
            Customer customer2 = new Customer
            {
                Name = "Murat Öztürk",
                Address = "Çankaya / Ankara",
                BirthDate = new DateTime(1987, 9, 28)
            };

            Customer[] customers = { customer1, customer2 };

            Console.WriteLine("=== MÜŞTERİ PROFİL BİLGİLERİ ===\n");

            // Ad, Adres ve Doğum Yılı bilgilerini yazdırma
            foreach (Customer c in customers)
            {
                Console.WriteLine($"Müşteri Adı : {c.Name}");
                Console.WriteLine($"Adres       : {c.Address}");
                Console.WriteLine($"Doğum Yılı  : {c.BirthDate.Year}");
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}