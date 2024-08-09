using Projet_DotNet_P6_LJMA.Mapping;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;
using Projet_DotNet_P6_LJMA.Services.Interfaces;

namespace Projet_DotNet_P6_LJMA.Services
{
        public class PostService : IPostService
        {
            private readonly IPostRepository _postRepository;

            public PostService(IPostRepository PostRepository)
            {
                _postRepository = PostRepository;
            }

            public async Task CreateAsync(PostDto post)
            {
                await _postRepository.CreateAsync(post.Map());
            }

            public async Task DeleteAsync(Guid id)
            {
                await _postRepository.DeleteAsync(id);
            }

            public async IAsyncEnumerable<PostDto> GetAllAsync()
            {
                await foreach (Post post in _postRepository.GetAllAsync())
                {
                    yield return post.MapToDto();
                }
            }
            public async Task<PostDto> GetByIdAsync(Guid id)
            {
                return (await _postRepository.GetByIdAsync(id)).MapToDto();
            }

            public async Task UpdateAsync(PostDto post)
            {
                await _postRepository.UpdateAsync(post.Map());
            }
        }
}
