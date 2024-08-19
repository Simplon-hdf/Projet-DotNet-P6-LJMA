using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.AuthentificationModule.Services
{
    public interface IAuthentificationService
    {
        Task<AuthentificateDTO?> AuthentificateAsync(LoginDTO loginDTO);
        Task<bool> RegisterAsync(RegisterDTO registerDTO);
        Task<bool> RegisterAdminAsync(RegisterDTO registerDTO);
    }
}