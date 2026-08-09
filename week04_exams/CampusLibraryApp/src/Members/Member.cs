namespace CampusLibraryApp.Members;

public abstract class Member
{
    private string _memberId;
    private string _fullName;
    private bool _isActive;
    private DateTime _createdAt;
    
    // Üyenin ödünç aldığı kitapların ID'lerini tutan basit dizi
    private string[] _borrowedBookIds;
    private int _borrowedCount;

    public string MemberId => _memberId;
    public string FullName => _fullName;
    public bool IsActive => _isActive;
    public DateTime CreatedAt => _createdAt;
    public int BorrowedCount => _borrowedCount;

    public Member(string memberId, string fullName)
    {
        _memberId = memberId;
        _fullName = fullName;
        _isActive = true;
        _createdAt = DateTime.Now;
        _borrowedBookIds = new string[10];
        _borrowedCount = 0;
    }

    public bool AddBorrowedBook(string bookId)
    {
        if (!_isActive) return false;
        if (_borrowedCount >= MaxBooks) return false;

        if (_borrowedCount >= _borrowedBookIds.Length)
        {
            Array.Resize(ref _borrowedBookIds, _borrowedBookIds.Length * 2);
        }

        _borrowedBookIds[_borrowedCount] = bookId;
        _borrowedCount++;
        return true;
    }

    public bool RemoveBorrowedBook(string bookId)
    {
        int index = -1;
        for (int i = 0; i < _borrowedCount; i++)
        {
            if (_borrowedBookIds[i] == bookId)
            {
                index = i;
                break;
            }
        }

        if (index == -1) return false;

        for (int i = index; i < _borrowedCount - 1; i++)
        {
            _borrowedBookIds[i] = _borrowedBookIds[i + 1];
        }

        _borrowedCount--;
        return true;
    }

    public bool HasBook(string bookId)
    {
        for (int i = 0; i < _borrowedCount; i++)
        {
            if (_borrowedBookIds[i] == bookId)
                return true;
        }
        return false;
    }

    public void Close()
    {
        _isActive = false;
    }

    public abstract int MaxBooks { get; }
    public abstract int LoanPeriodDays { get; }
    public abstract decimal CalculateLateFee(int daysLate);
    public abstract string GetMemberType();
}