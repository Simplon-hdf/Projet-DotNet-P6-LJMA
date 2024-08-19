//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.Modules.UtilisateurModule.Services;
using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.UtilisateurModule.Controllers
{
    [ApiController, Route("[Controller]")]
    public class UtilisateursController : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService;
        public UtilisateursController(IUtilisateurService utilisateurService)
            => _utilisateurService = utilisateurService;

        [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
            => Ok(_utilisateurService.GetAllAsync());

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetId(Guid id)
        {
            UtilisateurDTO? utilisateur = await _utilisateurService.GetByIdAsync(id);
            return utilisateur is not null
                ? Ok(utilisateur)
                : NotFound(new { Message = "Utilisateur non trouvé" });
        }

        [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] UtilisateurCreatedDTO utilisateurDto)
        {
            await _utilisateurService.CreateAsync(utilisateurDto);
            return Created(string.Empty, new { Message = "L'utilisateur a bien été créer!" });
        }

        [HttpPut, ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromBody] UtilisateurDTO utilisateurDto)
        {
            await _utilisateurService.UpdateAsync(utilisateurDto);
            return NoContent();
        }

        //[Authorize(Policy = "RequireDefaultRole")]
        [HttpDelete("{id}"), ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _utilisateurService.DeleteAsync(id);
            return NoContent();
        }
    }
}
