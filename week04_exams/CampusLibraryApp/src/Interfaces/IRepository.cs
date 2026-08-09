namespace CampusLibraryApp.Interfaces;

public interface IRepository<T>
{
    void Add(T item);
    T? GetById(string id);
    T[] GetAll();
    void Delete(string id);
}