using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Projet_DotNet_P6_LJMA.Services;
using Projet_DotNet_P6_LJMA.Services.Interfaces;

namespace Projet_DotNet_P6_LJMA.Controllers
{
    [ApiController, Route("[Controller]")]
    public class RandonneeController : ControllerBase
    {
        private readonly IRandonneeService _randonneeService;

        public RandonneeController(IRandonneeService randonneeService)
        {
            _randonneeService = randonneeService;
        }

        [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var randonnees = _randonneeService.GetAllAsync();
            return Ok(randonnees);
        }

        [HttpGet("{id}"), ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetId(Guid id)
        {
            var randonnees = await _randonneeService.GetByIdAsync(id);
            return Ok(randonnees);
        }

        [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] RandonneeDto randonneeDto)
        {
                await _randonneeService.CreateAsync(randonneeDto);
                return Created();
           
        }

        [HttpPut, ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromBody] RandonneeDto randonneeDto)
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
