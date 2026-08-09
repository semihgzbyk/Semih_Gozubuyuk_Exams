using CampusLibraryApp.Members;

namespace CampusLibraryApp.Interfaces;

public interface ILateFeeCalculator
{
    decimal Calculate(Member member, int daysLate);
}