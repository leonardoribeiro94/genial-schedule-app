namespace GenialSchedule.Application.DTOs.Users
{
    public record CreateUserRequest(string Name,
        DateTime BirthDate,
        string Email,
        string Password);
}