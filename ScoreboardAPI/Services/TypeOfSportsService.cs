using Microsoft.AspNetCore.Mvc;
using ScoreboardAPI.Models;

namespace ScoreboardAPI.Services
{
    public class TypeOfSportsService
    {
        private static List<TypeOfSport> _sportsData;
        static TypeOfSportsService()
        {
            _sportsData = new List<TypeOfSport>()
            {
                new TypeOfSport { SportId = 1, SportName = "Basketball"},
                new TypeOfSport { SportId = 2, SportName = "Football" },
                new TypeOfSport { SportId = 3, SportName = "Baseball" },
            };
        }

        public IEnumerable<TypeOfSport> GetAll()
        {
            return _sportsData;
        }

    }
}
