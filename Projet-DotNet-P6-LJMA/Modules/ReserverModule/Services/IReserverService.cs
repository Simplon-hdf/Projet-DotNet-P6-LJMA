using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.ReserverModule.Services;

public interface IReserverService
{
    IAsyncEnumerable<ReserverDTO> GetAllAsync();
    Task<ReserverDTO?> GetByIdAsync(Guid id);
    Task CreateAsync(ReserverCreatedDTO reserver);
    Task UpdateAsync(ReserverDTO reserver);
    Task DeleteAsync(Guid id);
}
