using Projet_DotNet_P6_LJMA.ModelsDTO;

namespace Projet_DotNet_P6_LJMA.Services.Interfaces
{
    public interface IRandonneeService
    {
        IAsyncEnumerable<RandonneeDto> GetAllAsync();
        Task<RandonneeDto> GetByIdAsync(Guid id);
        Task CreateAsync(RandonneeDto randonnee);
        Task UpdateAsync(RandonneeDto randonnee);
        Task DeleteAsync(Guid id);
    }
}
