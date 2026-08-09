using CampusLibraryApp.Catalog;
using CampusLibraryApp.Infrastructure;
using CampusLibraryApp.Interfaces;
using CampusLibraryApp.Members;
using CampusLibraryApp.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

IRepository<Member> memberRepo = new InMemoryMemberRepository();
IRepository<Book> bookRepo = new InMemoryBookRepository();
ILoanLogger logger = new ConsoleLoanLogger();

// Genişletme C: Muafiyetli ceza stratejisini enjekte ediyoruz
ILateFeeCalculator feeCalculator = new GracePeriodFeeCalculator();

LibraryService libraryService = new LibraryService(memberRepo, bookRepo, logger, feeCalculator);

Console.WriteLine("=== KAMPÜS KÜTÜPHANESİ UYGULAMASI BAŞLATILDI ===\n");

// 1. Üye Kayıtları (Öğrenci + Akademisyen + Genişletme A: GuestMember)
Console.WriteLine("--- 1. Üye Kayıtları ---");
libraryService.RegisterMember(new StudentMember("M101", "Ali Yılmaz"));
libraryService.RegisterMember(new StudentMember("M102", "Elif Demir"));
libraryService.RegisterMember(new AcademicMember("M201", "Dr. Mehmet Kaya"));
libraryService.RegisterMember(new GuestMember("M301", "Can Misafir"));

// 2. Kitap Eklemeleri
Console.WriteLine("\n--- 2. Kitap Eklemeleri ---");
libraryService.AddBook(new Book("B101", "C# İle Nesne Yonelim", "Ahmet Yazar", totalCopies: 2));
libraryService.AddBook(new Book("B102", "Veri Yapilari", "Ayse Yazar", totalCopies: 1));
libraryService.AddBook(new Book("B103", "Yazilim Mimarileri", "Can Yazar", totalCopies: 3));

// 3. Başarılı Ödünç Alımları
Console.WriteLine("\n--- 3. Ödünç Alma İşlemleri ---");
libraryService.Borrow("M101", "B101");
libraryService.Borrow("M101", "B102");
libraryService.Borrow("M301", "B103"); // Misafir üye ödünç alımı

// 4. Reddedilen İşlem Testleri
Console.WriteLine("\n--- 4. Kural İhlal Testleri (Reddedilen İşlemler) ---");
Console.WriteLine("> Test A: Misafir üye limit aşımı (2. kitap deneniyor):");
libraryService.Borrow("M301", "B101"); // Misafir limiti 1 olduğu için reddedilmeli

Console.WriteLine("\n> Test B: Stokta bitmiş kitap deneniyor:");
libraryService.Borrow("M102", "B102"); // Stok 1'di ve M101 aldığı için reddedilmeli

// 5. Genişletme B: Süre Uzatma (Renew) Testi
Console.WriteLine("\n--- 5. Süre Uzatma (Renew) Testi ---");
Console.WriteLine("> 1. Uzatma denemesi (Başarılı):");
libraryService.Renew("M101", "B101");

Console.WriteLine("\n> 2. Uzatma denemesi (Reddedilmeli):");
libraryService.Renew("M101", "B101");

// 6. İade ve Ceza Testi
Console.WriteLine("\n--- 6. İade ve Ceza Testi ---");
libraryService.Return("M101", "B102", DateTime.Today);

// 7. Raporlamalar
libraryService.PrintMemberList();
libraryService.PrintBookList();
libraryService.PrintHistory("M101");

// 8. Hata Yönetimi Testi
Console.WriteLine("\n--- 7. Hata Yönetimi Testi ---");
try
{
    Console.WriteLine("> Var olmayan üyeyle işlem:");
    libraryService.Borrow("M999", "B101");
}
catch (Exception ex)
{
    Console.WriteLine($"  ⚠️ YAKALANAN HATA: {ex.Message}");
}

Console.WriteLine("\n=== UYGULAMA SONLANDI ===");