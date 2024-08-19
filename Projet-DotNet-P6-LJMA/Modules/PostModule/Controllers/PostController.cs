using Microsoft.AspNetCore.Mvc;
using Projet_DotNet_P6_LJMA.Modules.PostModule.Services;
using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Modules.PostModule.Controllers
{
    [ApiController, Route("[Controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
            => _postService = postService;

        [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
            => Ok(_postService.GetAllAsync());

        [HttpGet("{id}"), ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetId(Guid id)
            => Ok(await _postService.GetByIdAsync(id));

        [HttpPost, ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] PostDTO postDto)
        {
            await _postService.CreateAsync(postDto);
            return Created(string.Empty,new { Message = "Post a bien été créer"});
        }

        [HttpPut, ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromBody] PostDTO postDto)
        {
            await _postService.UpdateAsync(postDto);
            return NoContent();
        }

        [HttpDelete("{id}"), ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _postService.DeleteAsync(id);
            return NoContent();
        }
    }
}
