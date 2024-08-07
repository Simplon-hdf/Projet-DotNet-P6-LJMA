using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories.Interface;

/// <summary>
/// Cette interface représente le repository de la classe Reserver.
/// </summary>
public interface IReserverRepository
{
    IAsyncEnumerable<Reserver> GetAllAsync();
    Task<Reserver?> GetByIdAsync(string id);
    Task CreateAsync(Reserver reserver);
    Task UpdateAsync(Reserver reserver);
    Task DeleteAsync(string id);
}