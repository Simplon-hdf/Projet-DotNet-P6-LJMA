using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.Modules.PostModule.Repositories;
using Projet_DotNet_P6_LJMA.Shared.DTOs;
using Projet_DotNet_P6_LJMA.Shared.Mapping;

namespace Projet_DotNet_P6_LJMA.Modules.PostModule.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository; // TODO:

        public PostService(IPostRepository PostRepository)
            => _postRepository = PostRepository;

        public async Task CreateAsync(PostDTO post)
            => await _postRepository.CreateAsync(post.Map());

        public async Task DeleteAsync(Guid id)
            => await _postRepository.DeleteAsync(id);


        public async IAsyncEnumerable<PostDTO> GetAllAsync()
        {
            await foreach (Post post in _postRepository.GetAllAsync())
            {
                yield return post.Map();
            }
        }
        public async Task<PostDTO?> GetByIdAsync(Guid id)
            => (await _postRepository.GetByIdAsync(id))?.Map();

        public async Task UpdateAsync(PostDTO post)
            => await _postRepository.UpdateAsync(post.Map());
    }
}
