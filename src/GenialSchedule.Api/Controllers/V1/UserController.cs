using Microsoft.AspNetCore.Mvc;

namespace GenialSchedule.Api.Controllers.V1
{
    [Route("users")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = new List<object>
            {
                new { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
                new { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
            };

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            var user = new { Id = id, Name = "John Doe", Email = "john.doe@example.com" };
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            var newUser = new { Id = 3, Name = request.Name, request.Email };
            return CreatedAtAction(nameof(GetUserById), new { id = 3 }, newUser);
        }

        public class CreateUserRequest
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}