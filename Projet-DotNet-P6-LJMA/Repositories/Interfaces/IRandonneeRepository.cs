using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories.Interfaces
{

    /// <summary>
    /// Cette interface représente le repository de la classe Reserver.
    /// </summary>
    public interface IRandonneeRepository
    {
        IAsyncEnumerable<Randonnee> GetAllAsync();
        Task<Randonnee?> GetByIdAsync(string id);
        Task CreateAsync(Randonnee randonnee);
        Task UpdateAsync(Randonnee randonnee);
        Task DeleteAsync(string id);
    }
}
