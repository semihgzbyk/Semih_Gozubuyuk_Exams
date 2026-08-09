namespace MiniBankApp.Accounts;

public abstract class Account
{
    private decimal _balance;
    private bool _isActive;

    public string AccountId { get; }
    public string OwnerName { get; }
    public DateTime CreatedAt { get; }

    public decimal Balance
    {
        get { return _balance; }
    }

    public bool IsActive
    {
        get { return _isActive; }
    }

    public Account(string accountId, string ownerName, decimal initialBalance = 0)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Başlangıç bakiyesi negatif olamaz.");

        AccountId = accountId;
        OwnerName = ownerName;
        _balance = initialBalance;
        _isActive = true;
        CreatedAt = DateTime.Now;
    }

    public virtual bool Deposit(decimal amount)
    {
        if (!_isActive) return false;
        if (amount <= 0) return false;

        _balance += amount;
        return true;
    }

    public virtual bool Withdraw(decimal amount)
    {
        if (!_isActive) return false;
        if (amount <= 0) return false;

        if (CanWithdraw(amount))
        {
            _balance -= amount;
            return true;
        }
        return false;
    }

    public void Close()
    {
        _isActive = false;
    }

    public abstract bool CanWithdraw(decimal amount);
    public abstract decimal CalculateInterest();
    public abstract string GetAccountType();
}