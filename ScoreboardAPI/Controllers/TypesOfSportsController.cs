using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using ScoreboardAPI.Models;

namespace ScoreboardAPI.Controllers.Models;

[ApiController]
[Route("[controller]")]
public class TypesOfSportsController : ControllerBase
{
    private readonly ITypeOfSportsService _typeOfSportsService;

    public TypesOfSportsController(ITypeOfSportsService typeOfSportsService)
    {
        _typeOfSportsService = typeOfSportsService;
    }

    [HttpGet]
    public IEnumerable<TypeOfSport> Get()
    {
        var typeOfSports = _typeOfSportsService.GetAll();

        return typeOfSports.Select(s => 
            new TypeOfSport
            {
                Id = s.Id,
                Name = s.Name,
            })
            .ToList();
    }

    [HttpGet("{sportId}")]
    public ActionResult<TypeOfSport> GetSportById(int sportId)
    {
        var typeOfSport = _typeOfSportsService.Get(sportId);

        if (typeOfSport is null)
        {
            return NotFound("Type of sport not found.");
        }

        var model = new TypeOfSport
        {
            Id = typeOfSport.Id,
            Name = typeOfSport.Name,
        };

        return Ok(model);
    }

    [HttpPost]
    public ActionResult CreateSport([FromBody] NewTypeOfSport newSport)
    {
        if (newSport == null)
        {
            return BadRequest("Invalid type of sport data provided.");
        }

        if (string.IsNullOrWhiteSpace(newSport.Name))
        {
            return BadRequest("Invalid type of sport name.");
        }

        int id = _typeOfSportsService.Add(newSport.Name);

        return Created(id.ToString(), new { Id = id });
    }

    /*[HttpPut("{spotrId}")]
     public ActionResult UpdateSport(int sportId, [FromBody] TypeOfSport updateSport)
     {
         if (updateSport == null || updateSport.SportId != null)
         {
             return BadRequest("Invalid sport data or sport ID mismatch");
         }

         var existingSport = _typeOfSportsService.FirstOrDefault(s => s.SportId == sportId);
         if (existingSport == null)
         {
             return NotFound("Sport not found");
         }

         return NoContent();
     }
     */

    [HttpDelete("{sportId}")]
    public ActionResult DeleteSport(int sportId) 
    {
        _typeOfSportsService.Delete(sportId);

        return Ok();
    }
}
