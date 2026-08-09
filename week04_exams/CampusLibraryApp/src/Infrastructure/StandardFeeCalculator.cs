using CampusLibraryApp.Interfaces;
using CampusLibraryApp.Members;

namespace CampusLibraryApp.Infrastructure;

public class StandardFeeCalculator : ILateFeeCalculator
{
    public decimal Calculate(Member member, int daysLate)
    {
        // Doğrudan üyenin kendi varsayılan ceza kuralını çalıştırır
        return member.CalculateLateFee(daysLate);
    }
}