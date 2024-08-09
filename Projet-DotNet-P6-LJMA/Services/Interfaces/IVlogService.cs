using Projet_DotNet_P6_LJMA.ModelsDTO;

namespace Projet_DotNet_P6_LJMA.Services.Interfaces;

public interface IVlogService
{
    IAsyncEnumerable<VlogDto> GetAllAsync();
    Task<VlogDto> GetByIdAsync(Guid id);
    Task CreateAsync(VlogCreatedDto vlog);
    Task UpdateAsync(VlogDto vlog);
    Task DeleteAsync(Guid id);
}
