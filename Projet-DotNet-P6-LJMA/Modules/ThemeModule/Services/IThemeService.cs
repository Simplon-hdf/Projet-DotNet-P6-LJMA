using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.ThemeModule.Services
{
    public interface IThemeService
    {
        IAsyncEnumerable<ThemeDTO> GetAllAsync();
        Task<ThemeDTO?> GetByIdAsync(Guid id);
        Task CreateAsync(ThemeDTO theme);
        Task UpdateAsync(ThemeDTO theme);
        Task DeleteAsync(Guid id);
    }
}
