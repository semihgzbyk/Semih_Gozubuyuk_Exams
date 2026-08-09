using CampusLibraryApp.Catalog;
using CampusLibraryApp.Interfaces;
using CampusLibraryApp.Members;

namespace CampusLibraryApp.Services;

public class LibraryService
{
    private readonly IRepository<Member> _memberRepo;
    private readonly IRepository<Book> _bookRepo;
    private readonly ILoanLogger _logger;
    private readonly ILateFeeCalculator _feeCalculator;

    // Uzatılan kitapların takibi için üye-kitap eşleşmesini tutan dizi
    private string[] _renewedKeys = new string[50];
    private int _renewedCount = 0;

    public LibraryService(
        IRepository<Member> memberRepo, 
        IRepository<Book> bookRepo, 
        ILoanLogger logger,
        ILateFeeCalculator feeCalculator)
    {
        _memberRepo = memberRepo;
        _bookRepo = bookRepo;
        _logger = logger;
        _feeCalculator = feeCalculator;
    }

    public void RegisterMember(Member member)
    {
        _memberRepo.Add(member);
        _logger.Log(member.MemberId, "-", "KAYIT", $"Yeni {member.GetMemberType()} üye eklendi.");
    }

    public void AddBook(Book book)
    {
        _bookRepo.Add(book);
        _logger.Log("-", book.BookId, "KİTAP EKLE", $"'{book.Title}' stoğa eklendi. Kopya: {book.TotalCopies}");
    }

    public bool Borrow(string memberId, string bookId)
    {
        Member member = GetActiveMemberOrThrow(memberId);
        Book book = GetBookOrThrow(bookId);

        if (book.AvailableCopies <= 0)
        {
            _logger.Log(memberId, bookId, "RED", "Stokta kitap kalmamış.");
            Console.WriteLine($"  ❌ Ödünç Verilemedi: '{book.Title}' stokta yok!");
            return false;
        }

        if (member.BorrowedCount >= member.MaxBooks)
        {
            _logger.Log(memberId, bookId, "RED", $"Maksimum kitap limitine ({member.MaxBooks}) ulaşıldı.");
            Console.WriteLine($"  ❌ Ödünç Verilemedi: Üye {member.FullName} limitini doldurmuş!");
            return false;
        }

        if (book.BorrowOne())
        {
            member.AddBorrowedBook(bookId);
            _logger.Log(memberId, bookId, "ÖDÜNÇ", $"Süre: {member.LoanPeriodDays} gün");
            Console.WriteLine($"  ✅ Ödünç Verildi: '{book.Title}' -> {member.FullName}");
            return true;
        }

        return false;
    }

    public bool Renew(string memberId, string bookId)
    {
        Member member = GetActiveMemberOrThrow(memberId);
        Book book = GetBookOrThrow(bookId);

        if (!member.HasBook(bookId))
        {
            _logger.Log(memberId, bookId, "RED", "Üye bu kitaba sahip değil, uzatılamaz.");
            Console.WriteLine($"  ❌ Uzatma Başarısız: {member.FullName} bu kitabı almamış.");
            return false;
        }

        string key = $"{memberId}_{bookId}";
        if (IsAlreadyRenewed(key))
        {
            _logger.Log(memberId, bookId, "RED", "Kitap daha önce uzatılmış, ikinci uzatma reddedildi.");
            Console.WriteLine($"  ❌ Uzatma Başarısız: '{book.Title}' zaten 1 kez uzatılmış!");
            return false;
        }

        AddRenewedKey(key);
        _logger.Log(memberId, bookId, "UZATMA", $"+{member.LoanPeriodDays} gün süre eklendi.");
        Console.WriteLine($"  ✅ Süre Uzatıldı: '{book.Title}' -> {member.FullName} (+{member.LoanPeriodDays} gün)");
        return true;
    }

    public bool Return(string memberId, string bookId, DateTime? returnDate = null)
    {
        Member member = GetActiveMemberOrThrow(memberId);
        Book book = GetBookOrThrow(bookId);

        if (!member.HasBook(bookId))
        {
            _logger.Log(memberId, bookId, "RED", "Üye bu kitabı ödünç almamış.");
            Console.WriteLine($"  ❌ İade Alınamadı: {member.FullName} üzerinde bu kitap görünmüyor.");
            return false;
        }

        DateTime actualReturnDate = returnDate ?? DateTime.Today;
        DateTime borrowedDate = DateTime.Today.AddDays(-20); 
        int allowedDays = member.LoanPeriodDays;
        int totalDaysHeld = (actualReturnDate - borrowedDate).Days;
        int daysLate = totalDaysHeld - allowedDays;

        // Enjekte edilen strateji üzerinden ceza hesaplama
        decimal lateFee = _feeCalculator.Calculate(member, daysLate);

        member.RemoveBorrowedBook(bookId);
        book.ReturnOne();

        string detail = daysLate > 0 ? $"Gecikme: {daysLate} gün, Ceza: {lateFee:C2}" : "Zamanında iade edildi.";
        _logger.Log(memberId, bookId, "İADE", detail);

        Console.WriteLine($"  ✅ İade Edildi: '{book.Title}' <- {member.FullName} | {detail}");
        return true;
    }

    public void PrintMemberList()
    {
        Console.WriteLine("\n=== ÜYE LİSTESİ ===");
        Member[] members = _memberRepo.GetAll();
        for (int i = 0; i < members.Length; i++)
        {
            Member m = members[i];
            Console.WriteLine($"ID: {m.MemberId,-6} | İsim: {m.FullName,-15} | Tip: {m.GetMemberType(),-20} | Aktif Kitap: {m.BorrowedCount}/{m.MaxBooks} | Durum: {(m.IsActive ? "Aktif" : "Pasif")}");
        }
    }

    public void PrintBookList()
    {
        Console.WriteLine("\n=== KİTAP KATALOĞU (STOK) ===");
        Book[] books = _bookRepo.GetAll();
        for (int i = 0; i < books.Length; i++)
        {
            Book b = books[i];
            Console.WriteLine($"ID: {b.BookId,-6} | Başlık: {b.Title,-25} | Yazarlar: {b.Author,-15} | Mevcut Stok: {b.AvailableCopies}/{b.TotalCopies}");
        }
    }

    public void PrintHistory(string memberId)
    {
        Console.WriteLine($"\n=== ÜYE İŞLEM GEÇMİŞİ ({memberId}) ===");
        string[] logs = _logger.GetHistory(memberId);
        for (int i = 0; i < logs.Length; i++)
        {
            Console.WriteLine(logs[i]);
        }
    }

    private bool IsAlreadyRenewed(string key)
    {
        for (int i = 0; i < _renewedCount; i++)
        {
            if (_renewedKeys[i] == key) return true;
        }
        return false;
    }

    private void AddRenewedKey(string key)
    {
        if (_renewedCount >= _renewedKeys.Length)
        {
            Array.Resize(ref _renewedKeys, _renewedKeys.Length * 2);
        }
        _renewedKeys[_renewedCount] = key;
        _renewedCount++;
    }

    private Member GetActiveMemberOrThrow(string memberId)
    {
        Member? member = _memberRepo.GetById(memberId);
        if (member == null)
            throw new KeyNotFoundException($"'{memberId}' ID'li üye bulunamadı.");

        if (!member.IsActive)
            throw new InvalidOperationException($"'{memberId}' ID'li üye pasif durumda.");

        return member;
    }

    private Book GetBookOrThrow(string bookId)
    {
        Book? book = _bookRepo.GetById(bookId);
        if (book == null)
            throw new KeyNotFoundException($"'{bookId}' ID'li kitap bulunamadı.");

        return book;
    }
}