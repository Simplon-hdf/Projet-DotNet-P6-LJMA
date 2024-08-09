using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Projet_DotNet_P6_LJMA.Services.Interfaces;

namespace Projet_DotNet_P6_LJMA.Controllers
{
    [ApiController, Route("[Controller]")]
    public class UtilisateursController : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService;
        
        public UtilisateursController(IUtilisateurService utilisateurService) {
            _utilisateurService = utilisateurService;
        }

        [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var utilisateurs = _utilisateurService.GetAllAsync();
            return Ok(utilisateurs);
        }

        [HttpGet("{id}"), ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetId(Guid id)
        {
            var utilisateur = await _utilisateurService.GetByIdAsync(id);
            return Ok(utilisateur);
        }

        [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] UtilisateurCreatedDto utilisateurDto)
        {
            await _utilisateurService.CreateAsync(utilisateurDto);
            return Created();
        }

        [HttpPut("{id}"), ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromBody] UtilisateurDto utilisateurDto)
        {
            await _utilisateurService.UpdateAsync(utilisateurDto);
            return NoContent();
        }

        [HttpDelete("{id}"), ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _utilisateurService.DeleteAsync(id);
            return NoContent();
        }
    }
}
