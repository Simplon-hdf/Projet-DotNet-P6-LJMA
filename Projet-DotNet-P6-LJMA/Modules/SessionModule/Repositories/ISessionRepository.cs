using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Modules.SessionModule.Repositories
{
    public interface ISessionRepository
    {
        IAsyncEnumerable<Session> GetAllAsync();
        Task<Session?> GetByIdAsync(Guid id);
        Task CreateAsync(Session session);
        Task UpdateAsync(Session session);
        Task DeleteAsync(Guid id);
    }
}
