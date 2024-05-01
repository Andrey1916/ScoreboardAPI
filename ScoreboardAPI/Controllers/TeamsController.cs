using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ScoreboardAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace ScoreboardAPI.Controllers.Models
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private static List<Teams> _teamService;

        static TeamsController()
        {
            _teamService = new List<Teams>()
            {
                new Teams{ TeamId = 1, TeamName = "Los Angeles Lakers" },
                new Teams{ TeamId = 2, TeamName = "San Antonio Spurs" },
                new Teams{ TeamId = 3, TeamName = "Milwaukee Bucks" },
            };
        }
        
        [HttpGet]
        public ActionResult GetTeams()
        {
            return Ok(_teamService);
        }
        
        [HttpGet("{teamId}")]
        public ActionResult GetTeam(int teamId)
        {
            var team = _teamService.FirstOrDefault(t => t.TeamId == teamId);
            if (team == null)
            {
                return NotFound(); 
            }
            return Ok(team); 
        }

        [HttpPost]
        public ActionResult CreateTeam([FromBody] Teams newTeam)
        {
            if (newTeam == null || string.IsNullOrEmpty(newTeam.TeamName))
            {
                return BadRequest("Team name is required"); 
            }

          
            if (_teamService.Any(t => t.TeamName == newTeam.TeamName))
            {
                return Conflict("Team name already exists"); 
            }

            
            int nextId = _teamService.Max(t => t.TeamId) + 1;
            newTeam.TeamId = nextId;

            _teamService.Add(newTeam);
            return CreatedAtRoute("GetTeam", new { teamId = newTeam.TeamId }, newTeam); 
        }
        
        [HttpPut("{teamId}")]
        public ActionResult UpdateTeam(int teamId, [FromBody] Teams updatedTeam)
        {
            if (updatedTeam == null || string.IsNullOrEmpty(updatedTeam.TeamName) || updatedTeam.TeamId != teamId)
            {
                return BadRequest("Invalid team data"); 
            }

            var existingTeam = _teamService.FirstOrDefault(t => t.TeamId == teamId);
            if (existingTeam == null)
            {
                return NotFound(); 
            }

            existingTeam.TeamName = updatedTeam.TeamName;

            return NoContent(); 
        }
        
        [HttpDelete("{teamId}")]
        public ActionResult DeleteTeam(int teamId)
        {
            var teamToDelete = _teamService.FirstOrDefault(t => t.TeamId == teamId);
            if (teamToDelete == null)
            {
                return NotFound(); 
            }

            _teamService.Remove(teamToDelete);
            return NoContent(); 
        }
    }
}
