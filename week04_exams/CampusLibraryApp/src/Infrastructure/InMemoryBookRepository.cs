using CampusLibraryApp.Catalog;
using CampusLibraryApp.Interfaces;

namespace CampusLibraryApp.Infrastructure;

public class InMemoryBookRepository : IRepository<Book>
{
    private Book[] _books = new Book[50];
    private int _count = 0;

    public void Add(Book item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_books[i].BookId == item.BookId)
                throw new InvalidOperationException($"'{item.BookId}' ID'li kitap zaten mevcut.");
        }

        if (_count >= _books.Length)
        {
            Array.Resize(ref _books, _books.Length * 2);
        }

        _books[_count] = item;
        _count++;
    }

    public Book? GetById(string id)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_books[i].BookId == id)
                return _books[i];
        }
        return null;
    }

    public Book[] GetAll()
    {
        Book[] result = new Book[_count];
        for (int i = 0; i < _count; i++)
        {
            result[i] = _books[i];
        }
        return result;
    }

    public void Delete(string id)
    {
        int index = -1;
        for (int i = 0; i < _count; i++)
        {
            if (_books[i].BookId == id)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            for (int i = index; i < _count - 1; i++)
            {
                _books[i] = _books[i + 1];
            }
            _count--;
        }
    }
}