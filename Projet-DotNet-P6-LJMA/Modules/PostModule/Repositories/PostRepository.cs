using Projet_DotNet_P6_LJMA.Infrastructure.Data;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;

namespace Projet_DotNet_P6_LJMA.Modules.PostModule.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApiDbContext _context;
        public PostRepository(ApiDbContext context)
            => _context = context;

        public async IAsyncEnumerable<Post> GetAllAsync()
        {
            await foreach (var post in _context.Posts)
            {
                yield return post;
            }
        }

        public async Task<Post?> GetByIdAsync(Guid id)
            => await _context.Posts.FindAsync(id);

        public async Task CreateAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}
