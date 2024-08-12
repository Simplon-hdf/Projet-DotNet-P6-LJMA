using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;

namespace Projet_DotNet_P6_LJMA.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApiDbContext _context;
        public PostRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async IAsyncEnumerable<Post> GetAllAsync()
        {
            await foreach (var post in _context.Posts)
            {
                yield return post;
            }
        }

        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task CreateAsync(Post post)
        {
            _context.Posts.Add(post);
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
