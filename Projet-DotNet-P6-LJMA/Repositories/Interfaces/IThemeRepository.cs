using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories.Interfaces
{
    /// <summary>
    /// Cette classe représente l'interface du repository de la classe Theme.
    /// </summary>
    public interface IThemeRepository
    {
        IAsyncEnumerable<Theme> GetAllAsync();
        Task<Theme> GetByIdAsync(string id);
        Task CreateAsync(Theme theme);
        Task UpdateAsync(Theme theme);
        Task DeleteAsync(string id);
    }
}
