using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.Modules.ThemeModule.Services;
using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.ThemeModule.Contollers
{
    [ApiController, Route("[Controller]")]
    public class ThemesController : ControllerBase
    {
        private readonly IThemeService _themeService;
        public ThemesController(IThemeService themeService)
            => _themeService = themeService;

        [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
            => Ok(_themeService.GetAllAsync());

        [HttpGet("{id}"), ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetId(Guid id)
            => Ok(await _themeService.GetByIdAsync(id));

        [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ThemeDTO themeDto)
        {
            await _themeService.CreateAsync(themeDto);
            return Created(string.Empty, new { Message = "Le thème a bien été créer!" });
        }

        [HttpPut, ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromBody] ThemeDTO themeDto)
        {
            await _themeService.UpdateAsync(themeDto);
            return NoContent();
        }

        [HttpDelete("{id}"), ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _themeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
