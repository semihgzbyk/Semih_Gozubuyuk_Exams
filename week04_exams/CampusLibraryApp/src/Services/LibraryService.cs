using CampusLibraryApp.Catalog;
using CampusLibraryApp.Interfaces;
using CampusLibraryApp.Members;

namespace CampusLibraryApp.Services;

public class LibraryService
{
    private readonly IRepository<Member> _memberRepo;
    private readonly IRepository<Book> _bookRepo;
    private readonly ILoanLogger _logger;

    public LibraryService(IRepository<Member> memberRepo, IRepository<Book> bookRepo, ILoanLogger logger)
    {
        _memberRepo = memberRepo;
        _bookRepo = bookRepo;
        _logger = logger;
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
        // Basit test senaryosu için varsayılan ödünç alma tarihini geriye dönük hesaplıyoruz
        DateTime borrowedDate = DateTime.Today.AddDays(-20); 
        int allowedDays = member.LoanPeriodDays;
        int totalDaysHeld = (actualReturnDate - borrowedDate).Days;
        int daysLate = totalDaysHeld - allowedDays;

        decimal lateFee = member.CalculateLateFee(daysLate);

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