using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ScoreboardAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace ScoreboardAPI.Controllers.Models
{
    [ApiController]
    [Route("[controller]")]
    public class TypesOfSportsController : ControllerBase
    {
        private static List<TypeOfSport> _sportsData;

        static TypesOfSportsController()
        {
            _sportsData = new List<TypeOfSport>()
            {
                new TypeOfSport { SportId = 1, SportName = "Basketball"},
                new TypeOfSport { SportId = 2, SportName = "Football" },
                new TypeOfSport { SportId = 3, SportName = "Baseball" },
            };
        }

        [HttpGet]
        
        public List<TypeOfSport> Get()
        {
            return _sportsData;
        }

        [HttpGet("{sportId}")]
        public ActionResult<TypeOfSport> GetSportById(int sportId) 
        {
            var sport = _sportsData.FirstOrDefault(s => s.SportId == sportId);
            if (sport == null)
            {
                return NotFound("Write messege ");
            }
            return Ok(sport);
        }
        
    }
}
