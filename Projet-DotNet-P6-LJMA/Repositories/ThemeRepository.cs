using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;

namespace Projet_DotNet_P6_LJMA.Repositories
{
    /// <summary>
    /// Repository de la classe Theme.
    /// </summary>
    public class ThemeRepository : IThemeRepository
    {
        private readonly ApiDbContext _context;

        public ThemeRepository(ApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère l'ensemble des themes de la BDD.
        /// </summary>
        /// <returns></returns>
        public async IAsyncEnumerable<Theme> GetAllAsync()
        {
            await foreach (var theme in _context.Themes)
            {
                yield return theme;
            }
        }

        /// <summary>
        /// Récupère le theme avec l'id correspondant.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Theme> GetByIdAsync(Guid id)
        {
            return await _context.Themes.FindAsync(id);
        }

        /// <summary>
        /// Crée un nouveau theme dans la BDD.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public async Task CreateAsync(Theme theme)
        {
            _context.Themes.Add(theme);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Met a jour un theme de la BDD.
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Theme theme)
        {
            _context.Themes.Update(theme);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Supprime un theme par son id de la BDD.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
