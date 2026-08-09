using MiniBankApp.Accounts;
using MiniBankApp.Interfaces;

namespace MiniBankApp.Services;

public class BankService
{
    private readonly IRepository<Account> _repository;
    private readonly ITransactionLogger _logger;

    public BankService(IRepository<Account> repository, ITransactionLogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public void OpenAccount(Account account)
    {
        _repository.Add(account);
        _logger.Log(account.AccountId, "HESAP AÇILIŞI", account.Balance, account.Balance);
    }

    public bool Deposit(string accountId, decimal amount)
    {
        var account = GetActiveAccountOrThrow(accountId);

        if (account.Deposit(amount))
        {
            _logger.Log(accountId, "MEVDUAT", amount, account.Balance);
            return true;
        }

        Console.WriteLine($"  ❌ Yatırma başarısız: {accountId}");
        return false;
    }

    public bool Withdraw(string accountId, decimal amount)
    {
        var account = GetActiveAccountOrThrow(accountId);

        if (account.Withdraw(amount))
        {
            _logger.Log(accountId, "ÇEKİM", amount, account.Balance);
            return true;
        }

        Console.WriteLine($"  ❌ Çekim Reddedildi: {accountId} (Limit aşımı, vadesi dolmadı veya yetersiz bakiye).");
        return false;
    }

    public bool TransferFunds(string fromId, string toId, decimal amount)
    {
        var sourceAcc = GetActiveAccountOrThrow(fromId);
        var targetAcc = GetActiveAccountOrThrow(toId);

        if (!sourceAcc.Withdraw(amount))
        {
            Console.WriteLine($"  ❌ Transfer Başarısız: {fromId} hesabından çekim yapılamadı.");
            return false;
        }

        _logger.Log(fromId, "TRNSFR-ÇEKİM", amount, sourceAcc.Balance);

        targetAcc.Deposit(amount);
        _logger.Log(toId, "TRNSFR-YATIR", amount, targetAcc.Balance);

        Console.WriteLine($"  ✅ Transfer Başarılı: {fromId} -> {toId} ({amount:C2})");
        return true;
    }

    public void PrintAccountList()
    {
        Console.WriteLine("\n=== HESAP LİSTESİ ===");
        Account[] accounts = _repository.GetAll();
        for (int i = 0; i < accounts.Length; i++)
        {
            Account acc = accounts[i];
            Console.WriteLine($"ID: {acc.AccountId,-6} | Müşteri: {acc.OwnerName,-12} | Tip: {acc.GetAccountType(),-18} | Bakiye: {acc.Balance,10:C2} | Durum: {(acc.IsActive ? "Aktif" : "Kapalı")}");
        }
    }

    public void PrintInterestReport()
    {
        Console.WriteLine("\n=== FAİZ RAPORU (Polimorfik) ===");
        Account[] accounts = _repository.GetAll();
        for (int i = 0; i < accounts.Length; i++)
        {
            Account acc = accounts[i];
            decimal interest = acc.CalculateInterest();
            Console.WriteLine($"Hesap: {acc.AccountId} ({acc.GetAccountType()}) | Bakiye: {acc.Balance:C2} | Tahmini Faiz: {interest:C2}");
        }
    }

    public void PrintHistory(string accountId)
    {
        Console.WriteLine($"\n=== HESAP İŞLEM GEÇMİŞİ ({accountId}) ===");
        string[] logs = _logger.GetHistory(accountId);
        for (int i = 0; i < logs.Length; i++)
        {
            Console.WriteLine(logs[i]);
        }
    }

    private Account GetActiveAccountOrThrow(string accountId)
    {
        var account = _repository.GetById(accountId);
        if (account == null)
            throw new KeyNotFoundException($"'{accountId}' ID'li hesap bulunamadı.");

        if (!account.IsActive)
            throw new InvalidOperationException($"'{accountId}' ID'li hesap kapalı.");

        return account;
    }
}