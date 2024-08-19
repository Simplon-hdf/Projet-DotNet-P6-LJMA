using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.Modules.ReserverModule.Services;
using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.ReserverModule.Controllers;

[ApiController, Route("[Controller]")]
public class ReserversController : ControllerBase
{
    private readonly IReserverService _reserverService;

    public ReserversController(IReserverService reserverService)
        => _reserverService = reserverService;

    [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll()
        => Ok(_reserverService.GetAllAsync());

    [HttpGet("{id}"), ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetId(Guid id)
        => Ok(await _reserverService.GetByIdAsync(id));

    [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] ReserverCreatedDTO reserverDto)
    {
        await _reserverService.CreateAsync(reserverDto);
        return Created(string.Empty, new { Message = "La reservation a été créer!"});
    }

    [HttpPut, ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Edit([FromBody] ReserverDTO reserverDto)
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