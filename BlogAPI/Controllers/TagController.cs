using BlogApi.Services.DTO;
using BlogApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController(ITagService tagService) : ControllerBase
    {
        private readonly ITagService _tagService = tagService;

        [HttpGet]
        public async Task<IActionResult> GetAllTags(CancellationToken cancellationToken)
        {
            var tags = await _tagService.GetAllTagsAsync(cancellationToken);
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById(int id, CancellationToken cancellationToken)
        {
            var tag = await _tagService.GetTagByIdAsync(id, cancellationToken);
            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        [HttpPost]
        //public async Task<IActionResult> AddTag([FromBody] AddTagRequest request, CancellationToken cancellationToken)
        //{
        //    try
        //    {
                

        //        await _tagService.AddTagAsync(tag, cancellationToken);
        //        return CreatedAtAction(nameof(GetTagById), new { id = tag.Id }, tag);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error adding tag: {ex.Message}");
        //    }
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, [FromBody] AddTagRequest request, CancellationToken cancellationToken)
        {
            

            var existingTag = await _tagService.GetTagByIdAsync(id, cancellationToken);
            if (existingTag == null)
            {
                return NotFound($"Tag with ID {id} not found.");
            }

            existingTag.Name = request.Name ?? existingTag.Name;

            await _tagService.UpdateTagAsync(existingTag, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id, CancellationToken cancellationToken)
        {
            await _tagService.DeleteTagAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
