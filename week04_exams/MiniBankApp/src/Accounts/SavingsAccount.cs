namespace MiniBankApp.Accounts;

public class SavingsAccount : Account
{
    private int _termMonths;
    private DateTime _maturityDate;

    public int TermMonths
    {
        get { return _termMonths; }
    }

    public DateTime MaturityDate
    {
        get { return _maturityDate; }
    }

    public SavingsAccount(string accountId, string ownerName, decimal initialBalance, int termMonths)
        : base(accountId, ownerName, initialBalance)
    {
        _termMonths = termMonths;
        _maturityDate = CreatedAt.AddMonths(termMonths);
    }

    public override bool CanWithdraw(decimal amount)
    {
        // Vade dolmadan çekim yapılmasına izin verilmez
        if (DateTime.Now < _maturityDate) return false;
        if (amount > Balance) return false;
        return true;
    }

    public override decimal CalculateInterest()
    {
        decimal annualRate = 0.15m;
        return Balance * (annualRate * _termMonths / 12m);
    }

    public override string GetAccountType()
    {
        return "Vadeli (Savings)";
    }
}