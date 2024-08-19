using Projet_DotNet_P6_LJMA.Shared.Mapping;
using Projet_DotNet_P6_LJMA.Shared.DTOs;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;
using Projet_DotNet_P6_LJMA.Modules.ReserverModule.Repositories;

namespace Projet_DotNet_P6_LJMA.Modules.ReserverModule.Services;

public class ReserverService : IReserverService
{
    private readonly IReserverRepository _reserverRepository;
    public ReserverService(IReserverRepository reserverRepository)
        => _reserverRepository = reserverRepository;

    public async Task CreateAsync(ReserverCreatedDTO reserver)
        => await _reserverRepository.CreateAsync(reserver.Map());

    public async Task DeleteAsync(Guid id)
        => await _reserverRepository.DeleteAsync(id);

    public async IAsyncEnumerable<ReserverDTO> GetAllAsync()
    {
        await foreach (Reserver reserver in _reserverRepository.GetAllAsync())
        {
            yield return reserver.Map();
        }
    }

    public async Task<ReserverDTO?> GetByIdAsync(Guid id)
        => (await _reserverRepository.GetByIdAsync(id))?.Map();

    public async Task UpdateAsync(ReserverDTO reserver)
        => await _reserverRepository.UpdateAsync(reserver.Map());
}
