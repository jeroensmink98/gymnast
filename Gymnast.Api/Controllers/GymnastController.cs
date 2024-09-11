using Gymnast.Api.DTO;
using Gymnast.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gymnast.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GymnastController(IGymnastService gymnastService): ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GymnastDto>>> GetGymnasts()
    {
        var gymnasts = await gymnastService.GetGymnastsAsync();
        return Ok(gymnasts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GymnastDto>> GetGymnast(int id)
    {
        var gymnast = await gymnastService.GetGymnastAsync(id);
        return Ok(gymnast);
    }

    [HttpPost]
    public async Task<ActionResult<Models.Gymnast>> PostGymnast(CreateGymnastDto gymnastDto)
    {
        try
        {
            var newGymnast = await gymnastService.CreateGymnastAsync(gymnastDto);
            return Ok(newGymnast);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGymnast(int id)
    {
        try
        {
            var result = await gymnastService.DeleteGymnastAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();


        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}