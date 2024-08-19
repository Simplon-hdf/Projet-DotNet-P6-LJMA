using Projet_DotNet_P6_LJMA.Infrastructure.Data;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;

namespace Projet_DotNet_P6_LJMA.Modules.RandonneeModule.Repositories
{
    public class RandonneeRepository : IRandonneeRepository
    {
        private readonly ApiDbContext _context;
        public RandonneeRepository(ApiDbContext context)
            => _context = context;

        public async IAsyncEnumerable<Randonnee> GetAllAsync()
        {
            await foreach (var randonnee in _context.Randonnees)
            {
                yield return randonnee;
            }
        }

        public async Task<Randonnee?> GetByIdAsync(Guid id)
            => await _context.Randonnees.FindAsync(id);

        public async Task CreateAsync(Randonnee randonnee)
        {
            await _context.Randonnees.AddAsync(randonnee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Randonnee randonnee)
        {
            _context.Randonnees.Update(randonnee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var randonnee = await _context.Randonnees.FindAsync(id);
            if (randonnee != null)
            {
                _context.Randonnees.Remove(randonnee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
