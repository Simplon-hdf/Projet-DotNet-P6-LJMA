using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.Modules.SessionModule.Services;
using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.SessionModule.Controllers
{
    [ApiController, Route("[Controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionsController(ISessionService sessionService)
            => _sessionService = sessionService;

        [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
            => Ok(_sessionService.GetAllAsync());

        [HttpGet("{id}"), ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetId(Guid id)
            => Ok(await _sessionService.GetByIdAsync(id));

        [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] SessionDTO sessionDto)
        {
            await _sessionService.CreateAsync(sessionDto);
            return Created(string.Empty, new { Message = "Session a bien été créer!"});
        }

        [HttpPut, ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromBody] SessionDTO sessionDto)
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
