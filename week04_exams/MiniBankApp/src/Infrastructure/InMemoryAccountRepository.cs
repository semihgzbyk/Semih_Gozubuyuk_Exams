using MiniBankApp.Accounts;
using MiniBankApp.Interfaces;

namespace MiniBankApp.Infrastructure;

public class InMemoryAccountRepository : IRepository<Account>
{
    private Account[] _accounts = new Account[100];
    private int _count = 0;

    public void Add(Account account)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_accounts[i].AccountId == account.AccountId)
                throw new InvalidOperationException($"'{account.AccountId}' ID'li hesap zaten mevcut.");
        }

        if (_count >= _accounts.Length)
        {
            Array.Resize(ref _accounts, _accounts.Length * 2);
        }

        _accounts[_count] = account;
        _count++;
    }

    public Account? GetById(string id)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_accounts[i].AccountId == id)
                return _accounts[i];
        }
        return null;
    }

    public Account[] GetAll()
    {
        Account[] result = new Account[_count];
        for (int i = 0; i < _count; i++)
        {
            result[i] = _accounts[i];
        }
        return result;
    }

    public void Delete(string id)
    {
        int index = -1;
        for (int i = 0; i < _count; i++)
        {
            if (_accounts[i].AccountId == id)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            for (int i = index; i < _count - 1; i++)
            {
                _accounts[i] = _accounts[i + 1];
            }
            _count--;
        }
    }
}