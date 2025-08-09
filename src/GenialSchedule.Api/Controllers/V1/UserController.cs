using FluentValidation.Results;
using GenialSchedule.Api.Responses;
using GenialSchedule.Application.DTOs.Users;
using GenialSchedule.Application.Usecases.User.Commands;
using GenialSchedule.Application.Validations;
using Microsoft.AspNetCore.Mvc;

namespace GenialSchedule.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserUseCase _createUserUseCase;

        public UserController(ICreateUserUseCase createUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
        }

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
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var validator = new CreateUserRequestValidator().Validate(request);

            if (!validator.IsValid)
                return BadRequest(GetResponseErrors(validator.Errors));

            await _createUserUseCase.ExecuteAsync(request);

            return CreatedAtAction(nameof(CreateUser), new ApiResponse<CreateUserRequest>(request));
        }

        private static ApiResponse<List<ApiError>> GetResponseErrors(List<ValidationFailure> errors)
            => new(errors.ConvertAll(e => new ApiError(e.PropertyName, e.ErrorMessage)));
    }
}