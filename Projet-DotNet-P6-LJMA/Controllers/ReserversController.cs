using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Projet_DotNet_P6_LJMA.Services.Interfaces;

namespace Projet_DotNet_P6_LJMA.Controllers;

[ApiController, Route("[Controller]")]
public class ReserversController : ControllerBase
{
    private readonly IReserverService _reserverService;

    public ReserversController(IReserverService reserverService)
    {
        _reserverService = reserverService;
    }

    [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var reservers = _reserverService.GetAllAsync();
        return Ok(reservers);
    }

    [HttpGet("{id}"), ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetId(Guid id)
    {
        var reservers = await _reserverService.GetByIdAsync(id);
        return Ok(reservers);
    }

    [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] ReserverCreatedDto reserverDto)
    {
        await _reserverService.CreateAsync(reserverDto);
        return Created();
    }

    [HttpPut, ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Edit([FromBody] ReserverDto reserverDto)
    {
        await _reserverService.UpdateAsync(reserverDto);
        return NoContent();
    }

    [HttpDelete("{id}"), ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _reserverService.DeleteAsync(id);
        return NoContent();
    }
}