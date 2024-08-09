using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories.Interfaces;

public interface IVlogRepository
{
    IAsyncEnumerable<Vlog> GetAllAsync();
    Task<Vlog?> GetByIdAsync(Guid id);
    Task CreateAsync(Vlog vlog);
    Task UpdateAsync(Vlog vlog);
    Task DeleteAsync(Guid id);
}
