using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;

namespace Projet_DotNet_P6_LJMA.Modules.VlogModule.Repositories
{
    public interface IVlogRepository
    {
        IAsyncEnumerable<Vlog> GetAllAsync();
        Task<Vlog?> GetByIdAsync(Guid id);
        Task CreateAsync(Vlog vlog);
        Task UpdateAsync(Vlog vlog);
        Task DeleteAsync(Guid id);
    }
}