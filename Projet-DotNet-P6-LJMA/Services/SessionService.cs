using Projet_DotNet_P6_LJMA.Mapping;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;
using Projet_DotNet_P6_LJMA.Services.Interfaces;

namespace Projet_DotNet_P6_LJMA.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task CreateAsync(SessionDto session)
        {
            await _sessionRepository.CreateAsync(session.Map());
        }

        public async Task DeleteAsync(Guid id)
        {
            await _sessionRepository.DeleteAsync(id);
        }

        public async IAsyncEnumerable<SessionDto> GetAllAsync()
        {
            await foreach (Session session in _sessionRepository.GetAllAsync())
            {
                yield return session.MapToDto();
            }
        }

        public async Task<SessionDto> GetByIdAsync(Guid id)
        {
            return (await _sessionRepository.GetByIdAsync(id)).MapToDto();
        }

        public async Task UpdateAsync(SessionDto session)
        {
            await _sessionRepository.UpdateAsync(session.Map());
        }
    }
}
