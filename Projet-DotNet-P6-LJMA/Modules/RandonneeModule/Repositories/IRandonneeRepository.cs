using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;

namespace Projet_DotNet_P6_LJMA.Modules.RandonneeModule.Repositories
{
    public interface IRandonneeRepository
    {
        IAsyncEnumerable<Randonnee> GetAllAsync();
        Task<Randonnee?> GetByIdAsync(Guid id);
        Task CreateAsync(Randonnee randonnee);
        Task UpdateAsync(Randonnee randonnee);
        Task DeleteAsync(Guid id);
    }
}
