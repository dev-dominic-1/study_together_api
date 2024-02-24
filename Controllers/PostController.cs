using Microsoft.AspNetCore.Mvc;
using study_together_api.Data;
using study_together_api.Entities;

namespace study_together_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DataContext _context;

        public PostController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var result = new List<Post>();
            return Ok(result);
        }
    }
}