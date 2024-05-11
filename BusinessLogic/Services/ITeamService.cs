using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services;
public interface ITeamService
{
    IEnumerable<Team> GetAll();
    Team? Get(int id);
    int Add(string name);
    void Delete(int id);
}
