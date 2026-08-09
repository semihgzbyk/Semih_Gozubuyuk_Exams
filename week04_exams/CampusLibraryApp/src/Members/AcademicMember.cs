namespace CampusLibraryApp.Members;

public class AcademicMember : Member
{
    public AcademicMember(string memberId, string fullName)
        : base(memberId, fullName)
    {
    }

    public override int MaxBooks => 10;
    public override int LoanPeriodDays => 30;

    public override decimal CalculateLateFee(int daysLate)
    {
        if (daysLate <= 0) return 0m;
        return daysLate * 2m; // Günlük 2 TL
    }

    public override string GetMemberType() => "Akademisyen (Academic)";
}