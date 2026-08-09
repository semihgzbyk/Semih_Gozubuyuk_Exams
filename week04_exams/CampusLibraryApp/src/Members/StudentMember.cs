namespace CampusLibraryApp.Members;

public class StudentMember : Member
{
    public StudentMember(string memberId, string fullName)
        : base(memberId, fullName)
    {
    }

    public override int MaxBooks => 3;
    public override int LoanPeriodDays => 14;

    public override decimal CalculateLateFee(int daysLate)
    {
        if (daysLate <= 0) return 0m;
        return daysLate * 5m; // Günlük 5 TL
    }

    public override string GetMemberType() => "Öğrenci (Student)";
}