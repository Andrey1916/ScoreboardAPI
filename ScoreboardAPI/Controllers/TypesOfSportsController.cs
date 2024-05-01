using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ScoreboardAPI.Models;
using ScoreboardAPI.Services;
using System.Security.Cryptography.X509Certificates;

namespace ScoreboardAPI.Controllers.Models
{
    [ApiController]
    [Route("[controller]")]
    public class TypesOfSportsController : ControllerBase
    {
        private TypeOfSportsService _sportsService;
        public TypesOfSportsController() 
        {
            _sportsService = new TypeOfSportsService();
        }

        [HttpGet]
        public IEnumerable<TypeOfSport> Get()
        {
            return _sportsService.GetAll();
        }

        [HttpGet("{sportId}")]
        public ActionResult<TypeOfSport> GetSportById(int sportId)
        {
            var sport = _sportsService.FirstOrDefault(s => s.SportId == sportId);
            if (sport == null)
            {
                return NotFound("Write messege ");//TODO: Write massege for not found
            }
            return Ok(sport);
        }

        [HttpPost]
        public ActionResult CreateSport([FromBody] TypeOfSport newSport)
        {
            if (newSport == null)
            {
                return BadRequest("Invalid sport data provided");
            }

            _sportsService.Add(newSport);

            return CreatedAtRoute("GetSportById", new { sportId = newSport.SportId }, newSport);
        }

        [HttpPut("{spotrId}")]
        public ActionResult UpdateSport(int sportId, [FromBody] TypeOfSport updateSport)
        {
            if (updateSport == null || updateSport.SportId != null)
            {
                return BadRequest("Invalid sport data or sport ID mismatch");
            }

            var existingSport = _sportsService.FirstOrDefault(s => s.SportId == sportId);
            if (existingSport == null)
            {
                return NotFound("Sport not found");
            }

            return NoContent();
        }

        [HttpDelete("{spotrId}")]
        public ActionResult DeleteSport(int sportId) 
        {
            var sportToDelete = _sportsService.FirstOrDefault(s => s.SportId == sportId);
            if (sportToDelete == null)
            {
                return NotFound("Sport not found");
            }

            _sportsService.Remove(sportToDelete);

            return NoContent();
        }
    }
}
