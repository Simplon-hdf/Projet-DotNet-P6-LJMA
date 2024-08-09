using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;

namespace Projet_DotNet_P6_LJMA.Repositories

{
    /// <summary>
    /// Repository de la classe Session.
    /// </summary>
    public class SessionRepository : ISessionRepository
    {
        private readonly ApiDbContext _context;

        public SessionRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async IAsyncEnumerable<Session> GetAllAsync()
        {
            await foreach (var session in _context.Sessions)
            {
                yield return session;
            }
        }

        public async Task<Session?> GetByIdAsync(Guid id)
        {
            return await _context.Sessions.FindAsync(id);
        }

        public async Task CreateAsync(Session session)
        {
            _context.Add(session);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Session session)
        {
            _context.Update(session);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                await _context.SaveChangesAsync();
            }
        }
    }
}
