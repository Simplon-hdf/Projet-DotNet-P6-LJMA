using Projet_DotNet_P6_LJMA.Mapping;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;
using Projet_DotNet_P6_LJMA.Services.Interfaces;

namespace Projet_DotNet_P6_LJMA.Services
{
    public class RandonneeService : IRandonneeService
    {
        private readonly IRandonneeRepository _randonneeRepository;

        public RandonneeService(IRandonneeRepository randonneeRepository)
        {
            _randonneeRepository = randonneeRepository;
        }

        public async Task CreateAsync(RandonneeDto randonnee)
        {
            await _randonneeRepository.CreateAsync(randonnee.Map());
        }

        public async Task DeleteAsync(Guid id)
        {
            await _randonneeRepository.DeleteAsync(id);
        }

        public async IAsyncEnumerable<RandonneeDto> GetAllAsync()
        {
            await foreach (Randonnee randonnee in _randonneeRepository.GetAllAsync())
            {
                yield return randonnee.MapToDto();
            }
        }
        public async Task<RandonneeDto> GetByIdAsync(Guid id)
        {
            return (await _randonneeRepository.GetByIdAsync(id)).MapToDto();
        }

        public async Task UpdateAsync(RandonneeDto randonnee)
        {
            await _randonneeRepository.UpdateAsync(randonnee.Map());
        }

    }
}
