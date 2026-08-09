using System;

namespace MiniBankApp.Interfaces;

public interface IRepository<T>
{
    void Add(T account);
    T? GetById(string id);
    T[] GetAll();
    void Delete(string id);
}