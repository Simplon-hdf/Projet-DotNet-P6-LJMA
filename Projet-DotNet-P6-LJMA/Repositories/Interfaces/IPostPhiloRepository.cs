using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories.Interfaces
{
    public interface IPostPhiloRepository
    {
        IAsyncEnumerable<Post_philo> GetAllAsync();
        Task<Post_philo?> GetByIdAsync(string id);
        Task CreateAsync(Post_philo post_philo);
        Task UpdateAsync(Post_philo post_philo);
        Task DeleteAsync(string id);
    }
}
