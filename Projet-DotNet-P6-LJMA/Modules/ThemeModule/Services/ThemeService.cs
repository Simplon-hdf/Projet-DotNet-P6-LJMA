using Projet_DotNet_P6_LJMA.Shared.Mapping;
using Projet_DotNet_P6_LJMA.Shared.DTOs;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;
using Projet_DotNet_P6_LJMA.Modules.ThemeModule.Repositories;

namespace Projet_DotNet_P6_LJMA.Modules.ThemeModule.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository _themeRepository;
        public ThemeService(IThemeRepository themeRepository)
            => _themeRepository = themeRepository;

        public async Task CreateAsync(ThemeDTO theme)
            => await _themeRepository.CreateAsync(theme.Map());

        public async Task DeleteAsync(Guid id)
            => await _themeRepository.DeleteAsync(id);

        public async IAsyncEnumerable<ThemeDTO> GetAllAsync()
        {
            await foreach (Theme theme in _themeRepository.GetAllAsync())
            {
                yield return theme.Map();
            }
        }

        public async Task<ThemeDTO?> GetByIdAsync(Guid id)
            => (await _themeRepository.GetByIdAsync(id))?.Map();

        public async Task UpdateAsync(ThemeDTO theme)
            => await _themeRepository.UpdateAsync(theme.Map());
    }
}
