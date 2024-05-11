using BusinessLogic.Dtos;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ScoreboardAPI.Controllers.Models;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamsController(TeamService teamService)
    {
        _teamService = teamService;
    }

    [HttpGet]
    public IEnumerable<Team> Get()
    {
        var teamService = _teamService.GetAll();

        return teamService.Select(t =>
            new Team
            {
                Id = t.Id,
                Name = t.Name,
            })
            .ToList();
    }

    [HttpGet("{teamId}")]
    public ActionResult<Team> GetSportById(int teamId)
    {
        var teamService = _teamService.Get(teamId);

        if (teamService is null)
        {
            return NotFound("Team not found.");
        }

        var team = new Team
        {
            Id = teamService.Id,
            Name = teamService.Name,
        };

        return Ok(team);
    }

    [HttpPost]
    public ActionResult CreateTeam([FromBody] Team newTeam)
    {
        if (newTeam == null)
        {
            return BadRequest("Invalid team data provided.");
        }

        if (string.IsNullOrWhiteSpace(newTeam.Name))
        {
            return BadRequest("Invalid team name.");
        }

        int id = _teamService.Add(newTeam.Name);

        return Created(id.ToString(), new { Id = id });
    }

    [HttpDelete("{teamId}")]
    public ActionResult DeleteSport(int teamId)
    {
        _teamService.Delete(teamId);

        return Ok();
    }
}
