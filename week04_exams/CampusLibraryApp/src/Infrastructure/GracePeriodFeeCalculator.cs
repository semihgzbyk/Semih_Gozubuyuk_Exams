using CampusLibraryApp.Interfaces;
using CampusLibraryApp.Members;

namespace CampusLibraryApp.Infrastructure;

public class GracePeriodFeeCalculator : ILateFeeCalculator
{
    public decimal Calculate(Member member, int daysLate)
    {
        // İlk 3 gün cezasız muafiyet tanır, sonraki günler üyenin ceza tarifesini uygular
        int chargeableDays = daysLate - 3;
        if (chargeableDays <= 0) return 0m;

        return member.CalculateLateFee(chargeableDays);
    }
}