using Projet_DotNet_P6_LJMA.Infrastructure.Data;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;

namespace Projet_DotNet_P6_LJMA.Modules.ReserverModule.Repositories
{
    public class ReserverRepository : IReserverRepository
    {
        private readonly ApiDbContext _context;

        public ReserverRepository(ApiDbContext context)
            => _context = context;

        public async IAsyncEnumerable<Reserver> GetAllAsync()
        {
            await foreach (var reserver in _context.Reservers)
            {
                yield return reserver;
            }
        }

        public async Task<Reserver?> GetByIdAsync(Guid id)
            => await _context.Reservers.FindAsync(id);

        public async Task CreateAsync(Reserver reserver)
        {
            await _context.AddAsync(reserver);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reserver reserver)
        {
            _context.Reservers.Update(reserver);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var reserver = await _context.Reservers.FindAsync(id);
            if (reserver != null)
            {
                _context.Reservers.Remove(reserver);
                await _context.SaveChangesAsync();
            }
        }
    }
}