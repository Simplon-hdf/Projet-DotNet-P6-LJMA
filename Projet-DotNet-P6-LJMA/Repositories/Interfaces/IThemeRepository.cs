using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories.Interfaces
{
    public interface IThemeRepository
    {
        IAsyncEnumerable<Theme> GetAllAsync();
        Task<Theme> GetByIdAsync(string id);
        Task CreateAsync(Theme theme);
        Task UpdateAsync(Theme theme);
        Task DeleteAsync(string id);
    }
}
