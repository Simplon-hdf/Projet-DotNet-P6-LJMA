using Projet_DotNet_P6_LJMA.ModelsDTO;

namespace Projet_DotNet_P6_LJMA.Services.Interfaces
{
    public interface ISessionService
    {
        IAsyncEnumerable<SessionDto> GetAllAsync();
        Task<SessionDto> GetByIdAsync(Guid id);
        Task CreateAsync(SessionDto session);
        Task UpdateAsync(SessionDto session);
        Task DeleteAsync(Guid id);
    }
}
