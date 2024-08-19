using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.RandonneeModule.Services
{
    public interface IRandonneeService
    {
        IAsyncEnumerable<RandonneeDTO> GetAllAsync();
        Task<RandonneeDTO?> GetByIdAsync(Guid id);
        Task CreateAsync(RandonneeDTO randonnee);
        Task UpdateAsync(RandonneeDTO randonnee);
        Task DeleteAsync(Guid id);
    }
}
