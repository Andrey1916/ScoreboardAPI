using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PlayerService : IPlayerService
    {
        private static readonly List<Player> _playerService = new()
        {
                new Player{ Id = 1, Name = "LeBron James" },
                new Player{ Id  = 2, Name = "Antony Davis" },
                new Player{ Id  = 3, Name = "Austin Reaves" },
        };

        public int Add(string name)
        {
            int newId = _playerService.Max(s => s.Id);
            newId++;

            _playerService.Add(
                new Player
                {
                    Id = newId,
                    Name = name
                });

            return newId;
        }

        public void Delete(int id)
        {
            var item = _playerService.Find(i => i.Id == id);

            if (item != null)
            {
                _playerService.Remove(item);
            }
        }

        public Player? Get(int id)
        {
            var item = _playerService.Find(i => i.Id == id);

            return item;
        }

        public IEnumerable<Player> GetAll()
        {
            return _playerService;
        }
    }
}
