using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.SessionModule.Services
{
    public interface ISessionService
    {
        IAsyncEnumerable<SessionDTO> GetAllAsync();
        Task<SessionDTO?> GetByIdAsync(Guid id);
        Task CreateAsync(SessionDTO session);
        Task UpdateAsync(SessionDTO session);
        Task DeleteAsync(Guid id);
    }
}
