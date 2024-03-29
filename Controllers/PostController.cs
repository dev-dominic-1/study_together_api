using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using study_together_api.Data;
using study_together_api.Entities;

namespace study_together_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PostController : DbControllerBase<PostController>
    {
        public PostController(DataContext context) : base(context) {}

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            return Ok(await _context.Posts.Include(p => p.User).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post is null)
                return NotFound("Post record could not be located");
            return Ok(post);
        }
    }
}