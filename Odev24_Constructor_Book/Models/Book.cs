namespace Odev24_Constructor_Book.Models
{
    public class Book
    {
        // Auto-property'ler
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string AuthorName { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public int PageCount { get; set; } = 100;
        public decimal Price { get; set; }

        // 1. Parametresiz Constructor
        public Book()
        {
            PageCount = 100;
        }

        // 2. Sadece Kitap Adı alan Constructor
        public Book(string name) : this()
        {
            Name = name;
        }

        // 3. Ad ve Yazar Adı alan Constructor
        public Book(string name, string authorName) : this(name)
        {
            AuthorName = authorName;
        }

        // 4. Ad, Yazar Adı ve Kategori Adı alan Constructor
        public Book(string name, string authorName, string categoryName) : this(name, authorName)
        {
            CategoryName = categoryName;
        }

        // 5. Tüm detayları (Sayfa Sayısı dahil) alan Constructor
        public Book(string name, string authorName, string categoryName, int pageCount) : this(name, authorName, categoryName)
        {
            PageCount = pageCount;
        }
    }
}