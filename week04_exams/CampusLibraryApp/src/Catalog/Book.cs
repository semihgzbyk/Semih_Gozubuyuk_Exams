namespace CampusLibraryApp.Catalog;

public class Book
{
    private string _bookId;
    private string _title;
    private string _author;
    private int _totalCopies;
    private int _availableCopies;

    public string BookId
    {
        get { return _bookId; }
    }

    public string Title
    {
        get { return _title; }
    }

    public string Author
    {
        get { return _author; }
    }

    public int TotalCopies
    {
        get { return _totalCopies; }
    }

    public int AvailableCopies
    {
        get { return _availableCopies; }
    }

    public Book(string bookId, string title, string author, int totalCopies)
    {
        if (totalCopies <= 0)
            throw new ArgumentException("Toplam kopya sayısı en az 1 olmalıdır.");

        _bookId = bookId;
        _title = title;
        _author = author;
        _totalCopies = totalCopies;
        _availableCopies = totalCopies;
    }

    public bool BorrowOne()
    {
        if (_availableCopies <= 0)
            return false;

        _availableCopies--;
        return true;
    }

    public void ReturnOne()
    {
        if (_availableCopies < _totalCopies)
        {
            _availableCopies++;
        }
    }
}