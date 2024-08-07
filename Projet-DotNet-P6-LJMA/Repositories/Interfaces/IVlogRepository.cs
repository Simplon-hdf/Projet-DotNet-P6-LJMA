using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA;

public interface IVlogRepository
{
    IAsyncEnumerable<Vlog> GetAllAsync();
    Task<Vlog?> GetByIdAsync(string id);
    Task CreateAsync(Vlog vlog);
    Task UpdateAsync(Vlog vlog);
    Task DeleteAsync(string id);
}
