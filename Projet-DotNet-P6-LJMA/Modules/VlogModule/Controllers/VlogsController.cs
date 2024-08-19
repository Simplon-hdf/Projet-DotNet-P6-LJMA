using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.Modules.VlogModule.Services;
using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.VlogModule.Controllers
{
    [ApiController, Route("[Controller]")]
    public class VlogsController : ControllerBase
    {
        private readonly IVlogService _vlogService;

        public VlogsController(IVlogService vlogService)
        {
            _vlogService = vlogService;
        }

        [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
            => Ok(_vlogService.GetAllAsync());

        [HttpGet("{id}"), ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetId(Guid id)
        {
            var vlogs = await _vlogService.GetByIdAsync(id);
            return Ok(vlogs);
        }

        [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] VlogCreatedDTO vlogDto)
        {
            await _vlogService.CreateAsync(vlogDto);
            return NoContent();
        }

        [HttpPut, ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromBody] VlogDTO vlogDto)
        {
            await _vlogService.UpdateAsync(vlogDto);
            return NoContent();
        }

        [HttpDelete("{id}"), ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _vlogService.DeleteAsync(id);
            return NoContent();
        }
    }
}