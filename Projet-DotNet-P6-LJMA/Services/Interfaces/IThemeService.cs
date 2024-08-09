using Projet_DotNet_P6_LJMA.ModelsDTO;

namespace Projet_DotNet_P6_LJMA.Services.Interfaces
{
    public interface IThemeService
    {
        IAsyncEnumerable<ThemeDto> GetAllAsync();
        Task<ThemeDto> GetByIdAsync(Guid id);
        Task CreateAsync(ThemeDto theme);
        Task UpdateAsync(ThemeDto theme);
        Task DeleteAsync(Guid id);
    }
}
