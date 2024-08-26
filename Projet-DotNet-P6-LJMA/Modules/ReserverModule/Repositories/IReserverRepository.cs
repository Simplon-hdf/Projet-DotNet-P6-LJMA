using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Modules.ReserverModule.Repositories
{
    public interface IReserverRepository
    {
        IAsyncEnumerable<Reserver> GetAllAsync();
        Task<Reserver?> GetByIdAsync(Guid id);
        Task CreateAsync(Reserver reserver);
        Task UpdateAsync(Reserver reserver);
        Task DeleteAsync(Guid id);
    }
}