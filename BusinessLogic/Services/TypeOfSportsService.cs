using BusinessLogic.Dtos;

namespace BusinessLogic.Services;

public class TypeOfSportsService : ITypeOfSportsService
{
    private static readonly List<TypeOfSport> _sportsData = new()
    {
        new TypeOfSport { Id = 1, Name = "Basketball" },
        new TypeOfSport { Id = 2, Name = "Football" },
        new TypeOfSport { Id = 3, Name = "Baseball" }
    };

    public int Add(string name)
    {
        int newId = _sportsData.Max(s => s.Id);
        newId++;

        _sportsData.Add(
            new TypeOfSport
            {
                Id = newId,
                Name = name
            });

        return newId;
    }

    public void Delete(int id)
    {
        var item = _sportsData.Find(i => i.Id == id);

        if (item != null)
        {
            _sportsData.Remove(item);
        }
    }

    public TypeOfSport? Get(int id)
    {
        var item = _sportsData.Find(i => i.Id == id);

        return item;
    }

    public IEnumerable<TypeOfSport> GetAll()
    {
        return _sportsData;
    }
}
