using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories.Interfaces
{
    public interface IPostRepository
    {
        IAsyncEnumerable<Post> GetAllAsync();
        Task<Post?> GetByIdAsync(Guid id);
        Task CreateAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(Guid id);
    }
}
