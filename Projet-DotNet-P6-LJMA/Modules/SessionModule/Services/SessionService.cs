using Projet_DotNet_P6_LJMA.Shared.Mapping;
using Projet_DotNet_P6_LJMA.Shared.DTOs;
using Projet_DotNet_P6_LJMA.Modules.SessionModule.Repositories;
using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Modules.SessionModule.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionService(ISessionRepository sessionRepository)
            => _sessionRepository = sessionRepository;

        public async Task CreateAsync(SessionDTO session)
            => await _sessionRepository.CreateAsync(session.Map());

        public async Task DeleteAsync(Guid id)
            => await _sessionRepository.DeleteAsync(id);

        public async IAsyncEnumerable<SessionDTO> GetAllAsync()
        {
            await foreach (Session session in _sessionRepository.GetAllAsync())
            {
                yield return session.Map();
            }
        }

        public async Task<SessionDTO?> GetByIdAsync(Guid id)
            => (await _sessionRepository.GetByIdAsync(id))?.Map()!;

        public async Task UpdateAsync(SessionDTO session)
            => await _sessionRepository.UpdateAsync(session.Map());
    }
}
