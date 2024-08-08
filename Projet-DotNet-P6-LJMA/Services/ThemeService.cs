using Projet_DotNet_P6_LJMA.Mapping;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;
using Projet_DotNet_P6_LJMA.Services.Interfaces;

namespace Projet_DotNet_P6_LJMA.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository _themeRepository;

        public ThemeService(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }

        public async Task CreateAsync(ThemeDto theme)
        {
            await _themeRepository.CreateAsync(theme.Map());
        }

        public async Task DeleteAsync(Guid id)
        {
            await _themeRepository.DeleteAsync(id);
        }

        public async IAsyncEnumerable<ThemeDto> GetAllAsync()
        {
            await foreach (Theme theme in _themeRepository.GetAllAsync())
            {
                yield return theme.MapToDto();
            }
        }

        public async Task<ThemeDto> GetByIdAsync(Guid id)
        {
            return (await _themeRepository.GetByIdAsync(id)).MapToDto();
        }

        public async Task UpdateAsync(ThemeDto theme)
        {
            await _themeRepository.UpdateAsync(theme.Map());
        }
    }
}
