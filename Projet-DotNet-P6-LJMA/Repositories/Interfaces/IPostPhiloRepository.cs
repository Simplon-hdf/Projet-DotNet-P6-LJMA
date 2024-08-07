using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories.Interfaces
{
    public interface IPostPhiloRepository
    {
        IAsyncEnumerable<PostPhilo> GetAllAsync();
        Task<PostPhilo?> GetByIdAsync(string id);
        Task CreateAsync(PostPhilo post_philo);
        Task UpdateAsync(PostPhilo post_philo);
        Task DeleteAsync(string id);
    }
}
