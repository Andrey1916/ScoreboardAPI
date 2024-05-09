using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services;


    public class TeamService : ITeamService
    {
        private static readonly List<Team> _teamService = new()
    {
            new Team{ Id = 1, Name = "Los Angeles Lakers" },
            new Team{ Id  = 2, Name = "San Antonio Spurs" },
            new Team{ Id  = 3, Name = "Milwaukee Bucks" },
    };

        public int Add(string name)
        {
            int newId = _teamService.Max(s => s.Id);
            newId++;

            _teamService.Add(
                new Team
                {
                    Id = newId,
                    Name = name
                });

            return newId;
        }

        public void Delete(int id)
        {
            var item = _teamService.Find(i => i.Id == id);

            if (item != null)
            {
                _teamService.Remove(item);
            }
        }

        public Team? Get(int id)
        {
            var item = _teamService.Find(i => i.Id == id);

            return item;
        }

        public IEnumerable<Team> GetAll()
        {
            return _teamService;
        }
    }


