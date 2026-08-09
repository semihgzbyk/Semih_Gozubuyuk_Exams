namespace MiniBankApp.Accounts;

// CheckingAccount'tan türetildi.
// Gerekçe: Günlük limit ve çekim kuralları Vadesiz (Checking) hesap ile birebir aynıdır.
// Sıfırdan kod yazmak yerine kalıtım alarak var olan limiti ve faizi özelleştirdik.
public class PremiumAccount : CheckingAccount
{
    public PremiumAccount(string accountId, string ownerName, decimal initialBalance = 0, decimal dailyLimit = 50000m)
        : base(accountId, ownerName, initialBalance, dailyLimit)
    {
    }

    public override decimal CalculateInterest()
    {
        // Yıllık %5 faiz (Standart vadesizde %2 idi)
        return Balance * 0.05m;
    }

    public override string GetAccountType()
    {
        return "Premium";
    }
}