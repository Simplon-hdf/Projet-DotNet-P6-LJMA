using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Modules.ThemeModule.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly ApiDbContext _context;
        public ThemeRepository(ApiDbContext context)
            => _context = context;

        public async IAsyncEnumerable<Theme> GetAllAsync()
        {
            await foreach (var theme in _context.Themes)
            {
                yield return theme;
            }
        }

        public async Task<Theme?> GetByIdAsync(Guid id)
            => await _context.Themes.FindAsync(id);

        public async Task CreateAsync(Theme theme)
        {
            await _context.Themes.AddAsync(theme);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Theme theme)
        {
            _context.Themes.Update(theme);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var contact = await _context.Themes.FindAsync(id);
            if (contact != null)
            {
                _context.Themes.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
