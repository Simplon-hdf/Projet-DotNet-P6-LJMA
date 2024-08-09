using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories.Interfaces

/// <summary>
/// Cet interface représente le repository de la classe Session.
/// </summary>
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
