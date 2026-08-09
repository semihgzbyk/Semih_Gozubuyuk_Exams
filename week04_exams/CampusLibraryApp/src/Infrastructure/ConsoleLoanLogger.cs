using CampusLibraryApp.Interfaces;

namespace CampusLibraryApp.Infrastructure;

public class ConsoleLoanLogger : ILoanLogger
{
    private string[] _logs = new string[100];
    private int _logCount = 0;

    public void Log(string memberId, string bookId, string operation, string details)
    {
        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Üye: {memberId,-6} | Kitap: {bookId,-6} | İşlem: {operation,-8} | Detay: {details}";

        if (_logCount >= _logs.Length)
        {
            Array.Resize(ref _logs, _logs.Length * 2);
        }

        _logs[_logCount] = logEntry;
        _logCount++;

        Console.WriteLine($"  ⚡ LOG: {logEntry}");
    }

    public string[] GetHistory(string memberId)
    {
        int matchCount = 0;
        for (int i = 0; i < _logCount; i++)
        {
            if (_logs[i].Contains($"Üye: {memberId}"))
            {
                matchCount++;
            }
        }

        string[] history = new string[matchCount];
        int index = 0;
        for (int i = 0; i < _logCount; i++)
        {
            if (_logs[i].Contains($"Üye: {memberId}"))
            {
                history[index] = _logs[i];
                index++;
            }
        }

        return history;
    }
}