using MiniBankApp.Interfaces;

namespace MiniBankApp.Infrastructure;

public class ConsoleTransactionLogger : ITransactionLogger
{
    private string[] _logs = new string[100];
    private int _logCount = 0;

    public void Log(string accountId, string operation, decimal amount, decimal balanceAfter)
    {
        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Hesap: {accountId} | İşlem: {operation,-10} | Tutar: {amount,8:C2} | Bakiye: {balanceAfter,8:C2}";

        if (_logCount >= _logs.Length)
        {
            Array.Resize(ref _logs, _logs.Length * 2);
        }

        _logs[_logCount] = logEntry;
        _logCount++;

        Console.WriteLine($"  ⚡ LOG: {logEntry}");
    }

    public string[] GetHistory(string accountId)
    {
        int matchCount = 0;
        for (int i = 0; i < _logCount; i++)
        {
            if (_logs[i].Contains($"Hesap: {accountId}"))
            {
                matchCount++;
            }
        }

        string[] history = new string[matchCount];
        int index = 0;
        for (int i = 0; i < _logCount; i++)
        {
            if (_logs[i].Contains($"Hesap: {accountId}"))
            {
                history[index] = _logs[i];
                index++;
            }
        }

        return history;
    }
}