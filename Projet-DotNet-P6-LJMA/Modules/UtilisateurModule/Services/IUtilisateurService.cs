using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.UtilisateurModule.Services
{
    public interface IUtilisateurService
    {
        IAsyncEnumerable<UtilisateurDTO> GetAllAsync();
        Task<UtilisateurDTO?> GetByIdAsync(Guid id);
        Task CreateAsync(UtilisateurCreatedDTO utilisateur);
        Task UpdateAsync(UtilisateurDTO utilisateur);
        Task DeleteAsync(Guid id);
    }
}
