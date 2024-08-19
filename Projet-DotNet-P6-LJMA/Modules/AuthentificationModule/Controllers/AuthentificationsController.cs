using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.Modules.AuthentificationModule.Services;
using Projet_DotNet_P6_LJMA.Shared.DTOs;
using Projet_DotNet_P6_LJMA.Shared.Exceptions;
using Projet_DotNet_P6_LJMA.Shared.Helpers;

namespace Projet_DotNet_P6_LJMA.Modules.AuthentificationModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationsController : ControllerBase
    {
        private readonly IAuthentificationService _authentificationService;
        private readonly JwtHelper _jwtHelper;
        public AuthentificationsController(IAuthentificationService authentificationService, JwtHelper jwtHelper)
        {
            _authentificationService = authentificationService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO utilisateurLogin)
        {
            try
            {
                return await _authentificationService.RegisterAsync(utilisateurLogin)
                    ? Created(string.Empty, new { Message = "Vous avez été enregistrer!" })
                    : StatusCode(500, "Une erreur interne s'est produite");
            }
            catch (DuplicateEmailException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpPost("register-admin")]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                return await _authentificationService.RegisterAdminAsync(registerDTO)
                    ? Ok("Admin registered successfully")
                    : StatusCode(500, new { Message = "Failed to register admin" });
            }
            catch (DuplicateEmailException ex)
            {
                return Conflict(ex.Message);
            }
        }


        [HttpPost("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO loginDTO)
        {
            AuthentificateDTO? authentificateDTO = await _authentificationService.AuthentificateAsync(loginDTO);
            return authentificateDTO is not null
                ? Ok(new
                {
                    Token = _jwtHelper.CreateJWT(authentificateDTO),
                    Message = "Login Sucess!"
                })
                : Unauthorized(new { Message = "You haven't acces!" });
        }

        [HttpPost("refresh-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RefreshToken([FromBody] RefreshTokenDTO refreshTokenDTO)
        {
            var newToken = _jwtHelper.RefreshToken(refreshTokenDTO.ExpiredToken);
            return newToken is not null
                ? BadRequest(new { Message = "Invalid token" })
                : Ok(new
                {
                    Token = newToken,
                    Message = "Token refreshed successfully"
                });
        }
    }
}
