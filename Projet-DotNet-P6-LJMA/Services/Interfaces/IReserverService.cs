using Projet_DotNet_P6_LJMA.ModelsDTO;

namespace Projet_DotNet_P6_LJMA.Services.Interfaces;

public interface IReserverService
{
    IAsyncEnumerable<ReserverDto> GetAllAsync();
    Task<ReserverDto> GetByIdAsync(Guid id);
    Task CreateAsync(ReserverCreatedDto reserver);
    Task UpdateAsync(ReserverDto reserver);
    Task DeleteAsync(Guid id);
}
