using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Projet_DotNet_P6_LJMA.Services.Interfaces;

namespace Projet_DotNet_P6_LJMA.Controllers
{
    [ApiController, Route("[Controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var sessions = _sessionService.GetAllAsync();
            return Ok(sessions);
        }

        [HttpGet("{id}"), ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetId(Guid id)
        {
            var session = await _sessionService.GetByIdAsync(id);
            return Ok(session);
        }

        [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] SessionDto sessionDto)
        {
            await _sessionService.CreateAsync(sessionDto);
            return Created();
        }

        [HttpPut, ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromBody] SessionDto sessionDto)
        {
            await _sessionService.UpdateAsync(sessionDto);
            return NoContent();
        }

        [HttpDelete("{id}"), ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _sessionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
