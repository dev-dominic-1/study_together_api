using Microsoft.AspNetCore.Mvc;
using study_together_api.Entities;
using study_together_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.OpenApi.Any;
using System.Globalization;
using study_together_api.Utilities;

/// WARNING: Fat controller. Should be revised to use a Service
namespace study_together_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var result = await _context.Users.ToListAsync();
            return Ok(result); // respond 200
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int Id)
        {
            var result = await _context.Users
                .Include(u => u.Posts)
                .Where(u => u.Id == Id)
                .SingleOrDefaultAsync();
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Example of using <b>Reflection</b> to map the values of a Dictionary (`props`)
        /// to a new User entity for saving.
        /// </summary>
        /// <param name="props">Map of properties to set on new user</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<object>> AddUser(string FirstName, string LastName, Dictionary<string, string> props)
        {
            // Start with the required property, `Name`
            var user = new User { FirstName = FirstName, LastName = LastName };
            // Instantiate a Utility instance of `User` to set properties using Reflection
            var userUtil = typeof(User);
            // Loop through `props` passed on payload and set values on `user`
            foreach (KeyValuePair<string, string> entry in props.ToList()) 
            {
                string key = StringUtils.ToTitleCase(entry.Key);
                userUtil.GetProperty(key)?.SetValue(user, entry.Value);
            }
            // Add new user to DB context and save
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }
}