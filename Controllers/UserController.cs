using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using study_together_api.Entities;

/// WARNING: Fat controller. Should be revised to use a Service
namespace study_together_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var result =  new List<User> {
                new User
                {
                    Id = 1,
                    Name = "John Wick",
                    FirstName = "John",
                    LastName = "Wick",
                    Email = "johnwick@example.com"
                }
            };
            return Ok(result); // respond 200
        }
    }
}