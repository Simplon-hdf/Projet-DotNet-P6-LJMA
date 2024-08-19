using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.Modules.RandonneeModule.Services;
using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.RandonneeModule.Controllers
{
    [ApiController, Route("[Controller]")]
    public class RandonneeController : ControllerBase
    {
        private readonly IRandonneeService _randonneeService;

        public RandonneeController(IRandonneeService randonneeService)
            => _randonneeService = randonneeService;

        [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
            => Ok(_randonneeService.GetAllAsync());

        [HttpGet("{id}"), ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetId(Guid id)
            => Ok(await _randonneeService.GetByIdAsync(id));

        [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] RandonneeDTO randonneeDto)
        {
            await _randonneeService.CreateAsync(randonneeDto);
            return Created(string.Empty, new { Message = "Utilisateur à bin été créer!" });

        }

        [HttpPut, ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromBody] RandonneeDTO randonneeDto)
        {
            await _randonneeService.UpdateAsync(randonneeDto);
            return NoContent();
        }

        [HttpDelete("{id}"), ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _randonneeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
