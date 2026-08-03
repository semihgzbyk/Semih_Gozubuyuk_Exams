namespace Odev21_Constructor_BankAccount.Models
{
    public class BankAccount
    {
        // Auto-property'ler
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }

        // Zorunlu parametre alan Constructor
        public BankAccount(string ownerName)
        {
            OwnerName = ownerName;
            Balance = 0; // İlk açılışta bakiye sıfırdır
        }
    }
}