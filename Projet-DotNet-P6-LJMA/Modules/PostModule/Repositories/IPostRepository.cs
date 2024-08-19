using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;

namespace Projet_DotNet_P6_LJMA.Modules.PostModule.Repositories
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
