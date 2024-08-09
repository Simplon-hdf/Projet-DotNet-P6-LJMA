using Projet_DotNet_P6_LJMA.ModelsDTO;

namespace Projet_DotNet_P6_LJMA.Services.Interfaces
{
    public interface IPostService
    {
        IAsyncEnumerable<PostDto> GetAllAsync();
        Task<PostDto> GetByIdAsync(Guid id);
        Task CreateAsync(PostDto post);
        Task UpdateAsync(PostDto post);
        Task DeleteAsync(Guid id);
    }
}
