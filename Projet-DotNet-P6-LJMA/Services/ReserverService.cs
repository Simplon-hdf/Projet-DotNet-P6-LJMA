using Projet_DotNet_P6_LJMA.Mapping;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;
using Projet_DotNet_P6_LJMA.Services.Interfaces;

namespace Projet_DotNet_P6_LJMA.Services;

public class ReserverService : IReserverService
{
    private readonly IReserverRepository _reserverRepository;

    public ReserverService(IReserverRepository reserverRepository)
    {
        _reserverRepository = reserverRepository;
    }

    public async Task CreateAsync(ReserverCreatedDto reserver)
        {
            await _reserverRepository.CreateAsync(reserver.Map());
        }

        public async Task DeleteAsync(Guid id)
        {
            await _reserverRepository.DeleteAsync(id);
        }

        public async IAsyncEnumerable<ReserverDto> GetAllAsync()
        {
            await foreach (Reserver reserver in _reserverRepository.GetAllAsync())
            {
                yield return reserver.MapToDto();
            }
        }

        public async Task<ReserverDto> GetByIdAsync(Guid id)
        {
            return (await _reserverRepository.GetByIdAsync(id)).MapToDto();
        }

        public async Task UpdateAsync(ReserverDto reserver)
        {
            await _reserverRepository.UpdateAsync(reserver.Map());
        }

}
