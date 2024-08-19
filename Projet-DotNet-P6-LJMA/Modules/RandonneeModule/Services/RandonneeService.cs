using Projet_DotNet_P6_LJMA.Shared.Mapping;
using Projet_DotNet_P6_LJMA.Modules.RandonneeModule.Repositories;
using Projet_DotNet_P6_LJMA.Shared.DTOs;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;

namespace Projet_DotNet_P6_LJMA.Modules.RandonneeModule.Services
{
    public class RandonneeService : IRandonneeService
    {
        private readonly IRandonneeRepository _randonneeRepository;

        public RandonneeService(IRandonneeRepository randonneeRepository)
            => _randonneeRepository = randonneeRepository;

        public async Task CreateAsync(RandonneeDTO randonnee)
            => await _randonneeRepository.CreateAsync(randonnee.Map());

        public async Task DeleteAsync(Guid id)
            => await _randonneeRepository.DeleteAsync(id);

        public async IAsyncEnumerable<RandonneeDTO> GetAllAsync()
        {
            await foreach (Randonnee randonnee in _randonneeRepository.GetAllAsync())
            {
                yield return randonnee.Map();
            }
        }
        public async Task<RandonneeDTO?> GetByIdAsync(Guid id)
            => (await _randonneeRepository.GetByIdAsync(id))?.Map();

        public async Task UpdateAsync(RandonneeDTO randonnee)
            => await _randonneeRepository.UpdateAsync(randonnee.Map());
    }
}
