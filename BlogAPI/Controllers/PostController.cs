using BlogApi.Services.DTO;
using BlogApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController(IPostService postService) : ControllerBase
    {
        private readonly IPostService _postService = postService;

        [HttpGet]
        public async Task<IActionResult> GetAllPosts(CancellationToken cancellationToken)
        {
            var posts = await _postService.GetAllAsync(cancellationToken);
            return Ok(posts);
        }

        [HttpGet("deleted-posts")]
        public async Task<IActionResult> GetIsDeletedPosts(CancellationToken cancellationToken)
        {
            var posts = await _postService.GetIsDeletedPostsAsync(cancellationToken);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id, CancellationToken cancellationToken)
        {
            var post = await _postService.GetPostByIdAsync(id, cancellationToken);
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostDTO request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return BadRequest("Post is null.");
            }

            //if (request.Tags != null && request.Tags.Any())
            //{
            //    Console.WriteLine(request.Tags);
            //}

            await _postService.AddPostAsync(request, cancellationToken);

            return CreatedAtAction(nameof(GetPostById), new { id = request.Id }, request);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] UpdatePostRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest("Request body is null.");

            var existingPost = await _postService.GetPostByIdAsync(id, cancellationToken);
            if (existingPost == null)
            {
                return NotFound($"Post with ID {id} not found.");
            }

            existingPost.Author = request.Author ?? existingPost.Author;
            existingPost.Title = request.Title ?? existingPost.Title;
            existingPost.Content = request.Content ?? existingPost.Content;

            if (request.TagIds != null && request.TagIds.Any())
            {
            }

            await _postService.UpdatePostAsync(existingPost, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id, CancellationToken cancellationToken)
        {
            await _postService.DeletePostAsync(id, cancellationToken);
            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestorePost(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _postService.RestorePostAsync(id, cancellationToken);
                return Ok($"Post with ID {id} has been restored.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
