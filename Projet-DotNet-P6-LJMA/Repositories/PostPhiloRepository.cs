using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;

namespace Projet_DotNet_P6_LJMA.Repositories
{
    public class PostPhiloRepository : IPostPhiloRepository
    {
        private readonly ApiDbContext _context;
        public PostPhiloRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async IAsyncEnumerable<PostPhilo> GetAllAsync()
        {
            await foreach (var post_philo in _context.PostPhilos)
            {
                yield return post_philo;
            }
        }

        public async Task<PostPhilo?> GetByIdAsync(string id)
        {
            return await _context.PostPhilos.FindAsync(id);
        }

        public async Task CreateAsync(PostPhilo post_philo)
        {
            _context.Add(post_philo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PostPhilo post_philo)
        {
            _context.Update(post_philo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var post_philo = await _context.PostPhilos.FindAsync(id);
            if (post_philo != null)
            {
                _context.PostPhilos.Remove(post_philo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
