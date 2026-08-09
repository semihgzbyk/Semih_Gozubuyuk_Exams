namespace MiniBankApp.Interfaces;

public interface ITransactionLogger
{
    void Log(string accountId, string operation, decimal amount, decimal balanceAfter);
    string[] GetHistory(string accountId);
}