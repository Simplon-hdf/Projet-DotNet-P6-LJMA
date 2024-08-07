using Microsoft.AspNetCore.Mvc;

namespace Projet_DotNet_P6_LJMA.Controllers;

[ApiController, Route("[Controller]")]
public class ThemesController : ControllerBase
{
    [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(null);
    }

    [HttpGet("{id}"), ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetId(string id)
    {
        return Ok(null);
    }

    [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create()
    {
        return Ok(null);
    }

    [HttpPut("{id}"), ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Edit(string id)
    {
        return Ok(null);
    }

    [HttpDelete("{id}"), ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(string id)
    {
        return Ok(null);
    }
}