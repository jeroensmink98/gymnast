using Gymnast.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gymnast.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchController(IMatchService matchService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMatchesAsync()
    {
       var matches = await matchService.GetMatchesAsync();
       return Ok(matches);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetMatchAsync(int Id)
    {
        var match = await matchService.GetMatchAsync(Id);
        return Ok(match);
    }
    
    
    
    
    
}