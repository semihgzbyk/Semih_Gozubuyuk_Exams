using System;
using Odev21_Constructor_BankAccount.Models;

namespace Odev21_Constructor_BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Constructor kullanarak 2 farklı hesap oluşturma
            BankAccount account1 = new BankAccount("Ahmet Yılmaz");
            BankAccount account2 = new BankAccount("Ayşe Kaya");

            BankAccount[] accounts = { account1, account2 };

            Console.WriteLine("=== BANKA HESAP BİLGİLERİ ===\n");

            // Sahip adı ve bakiye bilgilerini yazdırma
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine($"Hesap Sahibi : {account.OwnerName}");
                Console.WriteLine($"Bakiye       : {account.Balance} TL");
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}