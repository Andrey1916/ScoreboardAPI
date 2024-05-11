using BusinessLogic.Dtos;

namespace BusinessLogic.Services;

public interface ITypeOfSportsService
{
    IEnumerable<TypeOfSport> GetAll();
    TypeOfSport? Get(int id);
    int Add(string name);
    void Delete(int id);
}
