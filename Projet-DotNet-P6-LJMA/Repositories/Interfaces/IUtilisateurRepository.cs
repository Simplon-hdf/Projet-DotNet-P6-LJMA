using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories.Interfaces
{
    public interface IUtilisateurRepository
    {
        IAsyncEnumerable<Utilisateur> GetAllAsync();
        Task<Utilisateur> GetByIdAsync(Guid id);
        Task CreateAsync(Utilisateur utilisateur);
        Task UpdateAsync(Utilisateur utilisateur);
        Task DeleteAsync(Guid id);
        Task<bool> UtilisateurExist(Guid id);
    }
}
