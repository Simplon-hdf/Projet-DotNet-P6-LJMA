using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.VlogModule.Services
{
    public interface IVlogService
    {
        IAsyncEnumerable<VlogDTO> GetAllAsync();
        Task<VlogDTO?> GetByIdAsync(Guid id);
        Task CreateAsync(VlogCreatedDTO vlog);
        Task UpdateAsync(VlogDTO vlog);
        Task DeleteAsync(Guid id);
    }
}