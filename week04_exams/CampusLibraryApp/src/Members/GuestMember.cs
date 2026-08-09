namespace CampusLibraryApp.Members;

public class GuestMember : Member
{
    public GuestMember(string memberId, string fullName)
        : base(memberId, fullName)
    {
    }

    public override int MaxBooks => 1;
    public override int LoanPeriodDays => 7;

    public override decimal CalculateLateFee(int daysLate)
    {
        if (daysLate <= 0) return 0m;
        return daysLate * 10m; // Günlük 10 TL
    }

    public override string GetMemberType() => "Misafir (Guest)";
}