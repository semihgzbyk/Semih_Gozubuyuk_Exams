namespace MiniBankApp.Accounts;

public class CheckingAccount : Account
{
    private decimal _dailyLimit;
    private decimal _withdrawnToday;

    public decimal DailyLimit
    {
        get { return _dailyLimit; }
    }

    public decimal WithdrawnToday
    {
        get { return _withdrawnToday; }
    }

    public CheckingAccount(string accountId, string ownerName, decimal initialBalance = 0, decimal dailyLimit = 1000m)
        : base(accountId, ownerName, initialBalance)
    {
        _dailyLimit = dailyLimit;
        _withdrawnToday = 0;
    }

    public override bool CanWithdraw(decimal amount)
    {
        if (amount > Balance) return false;
        if (_withdrawnToday + amount > _dailyLimit) return false;
        return true;
    }

    public override bool Withdraw(decimal amount)
    {
        bool success = base.Withdraw(amount);
        if (success)
        {
            _withdrawnToday += amount;
        }
        return success;
    }

    public override decimal CalculateInterest()
    {
        return Balance * 0.02m;
    }

    public override string GetAccountType()
    {
        return "Vadesiz (Checking)";
    }
}