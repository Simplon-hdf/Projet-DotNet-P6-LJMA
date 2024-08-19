using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;

namespace Projet_DotNet_P6_LJMA.Modules.ThemeModule.Repositories
{
    public interface IThemeRepository
    {
        IAsyncEnumerable<Theme> GetAllAsync();
        Task<Theme?> GetByIdAsync(Guid id);
        Task CreateAsync(Theme theme);
        Task UpdateAsync(Theme theme);
        Task DeleteAsync(Guid id);
    }
}
