using Projet_DotNet_P6_LJMA.ModelsDTO;

namespace Projet_DotNet_P6_LJMA.Services.Interfaces
{
    public interface IUtilisateurService
    {
        IAsyncEnumerable<UtilisateurDto> GetAllAsync();
        Task<UtilisateurDto> GetByIdAsync(Guid id);
        Task CreateAsync(UtilisateurCreatedDto utilisateur);
        Task UpdateAsync(UtilisateurDto utilisateur);
        Task DeleteAsync(Guid id);
        Task<bool> UtilisateurExist(Guid id);
    }
}
