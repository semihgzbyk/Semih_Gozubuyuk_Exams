namespace Odev01_LibraryBook.Models
{
    public class LibraryBook
    {
        // Property'ler 
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; private set; }

        // Yapıcı Metot (Constructor)
        public LibraryBook(string title, string author)
        {
            Title = title;
            Author = author;
            IsAvailable = true; // Kitap ilk oluşturulduğunda raftadır
        }

        // Metot 1: Kitap Ödünç Alma
        public void Borrow()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine($"[BAŞARILI] '{Title}' kitabı başarıyla ödünç alındı.");
            }
            else
            {
                Console.WriteLine($"[UYARI] '{Title}' kitabı şu an kütüphanede değil, başka birinde!");
            }
        }

        // Metot 2: Kitap İade Etme
        public void ReturnBook()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
                Console.WriteLine($"[İADE] '{Title}' kitabı iade edildi. Tekrar ödünç alınabilir.");
            }
            else
            {
                Console.WriteLine($"[BİLGİ] '{Title}' kitabı zaten kütüphanede bulunuyor.");
            }
        }
    }
}