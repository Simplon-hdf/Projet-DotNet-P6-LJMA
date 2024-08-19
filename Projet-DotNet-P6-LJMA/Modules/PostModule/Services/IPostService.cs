using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.PostModule.Services
{
    public interface IPostService
    {
        IAsyncEnumerable<PostDTO> GetAllAsync();
        Task<PostDTO?> GetByIdAsync(Guid id);
        Task CreateAsync(PostDTO post);
        Task UpdateAsync(PostDTO post);
        Task DeleteAsync(Guid id);
    }
}
