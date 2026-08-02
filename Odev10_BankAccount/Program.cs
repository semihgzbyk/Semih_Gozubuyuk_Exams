using System;
using Odev10_BankAccount.Models;

namespace Odev10_BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hesap oluşturma
            BankAccount account = new BankAccount("Ahmet Yılmaz");
            Console.WriteLine($"Hesap Sahibi: {account.OwnerName} | Başlangıç Bakiyesi: {account.Balance} TL\n");

            // 1. 2500 TL yatır
            account.Deposit(2500);
            Console.WriteLine($"2500 TL Yatırıldı | Güncel Bakiye: {account.Balance} TL");

            // 2. 7000 TL yatır
            account.Deposit(7000);
            Console.WriteLine($"7000 TL Yatırıldı | Güncel Bakiye: {account.Balance} TL\n");

            // 3. 3000 TL çek
            bool isSuccess1 = account.WithDraw(3000);
            Console.WriteLine($"3000 TL Çekildi mi: {isSuccess1} | Güncel Bakiye: {account.Balance} TL\n");

            // 4. 20000 TL çekmeyi dene ve sonucu mesajla göster
            bool isSuccess2 = account.WithDraw(20000);
            if (isSuccess2)
            {
                Console.WriteLine($"20000 TL başarıyla çekildi. Güncel Bakiye: {account.Balance} TL");
            }
            else
            {
                Console.WriteLine($"20000 TL çekilemedi: Yetersiz bakiye! Güncel Bakiye: {account.Balance} TL");
            }
        }
    }
}