using System;

namespace Odev10_BankAccount.Models
{
    public class BankAccount
    {
        // Private field'lar
        private string ownerName = "";
        private decimal balance;

        // Property'ler
        public string OwnerName
        {
            get
            {
                return ownerName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hata: Hesap sahibi adı boş olamaz!");
                }
                ownerName = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hata: Bakiye negatif olamaz!");
                }
                balance = value;
            }
        }

        // Yapıcı Metot
        public BankAccount(string ownerName, decimal initialBalance = 0)
        {
            OwnerName = ownerName;
            Balance = initialBalance;
        }

        // Metot 1: Para Yatırma
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Hata: Yatırılacak tutar 0'dan büyük olmalıdır!");
            }

            Balance += amount;
        }

        // Metot 2: Para Çekme
        public bool WithDraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Hata: Çekilecek tutar 0'dan büyük olmalıdır!");
            }

            if (amount > Balance)
            {
                return false;
            }

            Balance -= amount;
            return true;
        }
    }
}