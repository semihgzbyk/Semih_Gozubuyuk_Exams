using CampusLibraryApp.Interfaces;
using CampusLibraryApp.Members;

namespace CampusLibraryApp.Infrastructure;

public class InMemoryMemberRepository : IRepository<Member>
{
    private Member[] _members = new Member[50];
    private int _count = 0;

    public void Add(Member item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_members[i].MemberId == item.MemberId)
                throw new InvalidOperationException($"'{item.MemberId}' ID'li üye zaten kayıtlı.");
        }

        if (_count >= _members.Length)
        {
            Array.Resize(ref _members, _members.Length * 2);
        }

        _members[_count] = item;
        _count++;
    }

    public Member? GetById(string id)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_members[i].MemberId == id)
                return _members[i];
        }
        return null;
    }

    public Member[] GetAll()
    {
        Member[] result = new Member[_count];
        for (int i = 0; i < _count; i++)
        {
            result[i] = _members[i];
        }
        return result;
    }

    public void Delete(string id)
    {
        int index = -1;
        for (int i = 0; i < _count; i++)
        {
            if (_members[i].MemberId == id)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            for (int i = index; i < _count - 1; i++)
            {
                _members[i] = _members[i + 1];
            }
            _count--;
        }
    }
}