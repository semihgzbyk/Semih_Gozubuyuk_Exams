namespace CampusLibraryApp.Interfaces;

public interface ILoanLogger
{
    void Log(string memberId, string bookId, string operation, string details);
    string[] GetHistory(string memberId);
}